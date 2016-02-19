using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Utility;
using WaterPoint.Core.Domain.Contracts.Contacts;
using WaterPoint.Core.Domain.Contracts.Customers;
using WaterPoint.Core.Domain.Requests.Customers;
using WaterPoint.Data.Entity.DataEntities;
using WaterPoint.Data.Entity.Pocos.Customers;

namespace WaterPoint.Core.RequestProcessor.Mappers.EntitiesToContracts
{
    public class ContactMapper
    {
        static ContactMapper()
        {
            Mapper.CreateMap<Contact, ContactContract>()
                .ForMember(o => o.Version, i => i.MapFrom(d => d.Version.ToSha1(d.Id.ToString())));

            Mapper.CreateMap<BasicCustomerPoco, CustomerIdNameContract>();
        }

        public static ContactContract Map(Contact source)
        {
            return Mapper.Map<ContactContract>(source);
        }
    }
}
