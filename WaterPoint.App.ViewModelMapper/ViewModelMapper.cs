using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Ninject;

namespace WaterPoint.App.ViewModelMapper
{
    public class ApiContractToViewModelMapper : IApiContractToViewModelMapper
    {
        [Inject]
        public void Initialize()
        {
            Mapper.Initialize(config =>
            {
                config.AddProfile<BasicCustomerProfile>();
            });
        }

        public T MapTo<T>(object source)
        {
            return Mapper.Map<T>(source);
        }
    }

    public interface IApiContractToViewModelMapper
    {
        void Initialize();

        T MapTo<T>(object source);
    }
}
