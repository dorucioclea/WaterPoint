﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaterPoint.Data.Entity.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class OneToManyAttribute : RelationshipAttribute
    {
        public OneToManyAttribute(Type type)
            : base(type)
        {

        }
    }
}
