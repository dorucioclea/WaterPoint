using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Ninject;
using WaterPoint.Data.Entity;

namespace WaterPoint.Core.ContractMapper
{
    public class CoreMapper : ICoreMapper
    {
        [Inject]
        public void Initialize()
        {
            Mapper.Initialize(config =>
            {
                config.AddProfile<BasicCustomerPocoProfile>();
            });
        }

        public T MapTo<T>(object source)
        {
            return Mapper.Map<T>(source);
        }
    }

    public interface ICoreMapper
    {
        void Initialize();

        T MapTo<T>(object source);
    }
}
