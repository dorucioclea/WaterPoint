using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace WaterPoint.App.ApiClient
{
    public class OrganizationApiClient: ApiClientBase
    {
        public OrganizationApiClient(Uri baseUri)
            : base(baseUri)
        {

        }
    }
}
