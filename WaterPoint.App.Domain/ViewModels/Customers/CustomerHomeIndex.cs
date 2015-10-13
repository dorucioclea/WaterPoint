using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WaterPoint.App.Domain.ViewModels.Customers.Partials;

namespace WaterPoint.App.Domain.ViewModels.Customers
{
    public class CustomerHomeIndex
    {
        public IEnumerable<BasicCustomerInfo> Customers { get; set; }
    }
}
