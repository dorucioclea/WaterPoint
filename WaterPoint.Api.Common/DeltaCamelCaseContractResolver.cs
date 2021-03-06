﻿using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Reflection;
using System.Web.Http.OData;
using Microsoft.CSharp.RuntimeBinder;
using Newtonsoft.Json.Serialization;

namespace WaterPoint.Api.Common
{
    public class DeltaCamelCaseContractResolver : CamelCasePropertyNamesContractResolver
    {
        protected override JsonContract CreateContract(Type objectType)
        {
            if (!objectType.IsGenericType
                || objectType.GetGenericTypeDefinition() != typeof(Delta<>)
                || objectType.GetGenericArguments().Length != 1)
                return base.CreateContract(objectType);

            var contract = CreateDynamicContract(objectType);

            contract.Properties.Clear();

            var underlyingContract = CreateObjectContract(objectType.GetGenericArguments()[0]);
            var underlyingProperties = underlyingContract
                .CreatedType
                .GetProperties(BindingFlags.Public | BindingFlags.Instance);

            foreach (var property in underlyingContract.Properties)
            {
                property.DeclaringType = objectType;

                property.ValueProvider = new DynamicObjectValueProvider()
                {
                    PropertyName = ResolveName(underlyingProperties, property.PropertyName)
                };

                contract.Properties.Add(property);
            }

            return contract;
        }

        private static GetMemberBinder CreateGetMemberBinder(Type type, string memberName)
        {
            return (GetMemberBinder)Microsoft.CSharp.RuntimeBinder.Binder.GetMember(
                CSharpBinderFlags.None,
                memberName,
                type,
                new CSharpArgumentInfo[] { });
        }

        private static SetMemberBinder CreateSetMemberBinder(Type type, string memberName)
        {
            return (SetMemberBinder)Microsoft.CSharp.RuntimeBinder.Binder.SetMember(CSharpBinderFlags.None,
                memberName,
                type,
                new[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) });
        }

        private class DynamicObjectValueProvider : IValueProvider
        {
            public string PropertyName
            {
                private get;
                set;
            }

            public object GetValue(object target)
            {
                var d = (DynamicObject)target;

                object result;

                var binder = CreateGetMemberBinder(target.GetType(), PropertyName);

                d.TryGetMember(binder, out result);

                return result;
            }

            public void SetValue(object target, object value)
            {
                var d = (DynamicObject)target;

                var binder = CreateSetMemberBinder(target.GetType(), PropertyName);
                d.TrySetMember(binder, value);
            }
        }

        private static string ResolveName(IEnumerable<PropertyInfo> properties, string propertyName)
        {

            var prop = properties.SingleOrDefault(p => p.Name.Equals(propertyName, StringComparison.OrdinalIgnoreCase));

            return prop != null ? prop.Name : propertyName;
        }
    }
}
