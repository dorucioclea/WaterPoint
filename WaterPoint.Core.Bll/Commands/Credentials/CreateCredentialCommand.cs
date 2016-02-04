using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaterPoint.Core.Domain.Db;
using WaterPoint.Core.Domain.QueryParameters.Credentials;
using WaterPoint.Data.Entity.DataEntities;

namespace WaterPoint.Core.Bll.Commands.Credentials
{
    public class CreateCredentialCommand : ICommand<CreateCredential>
    {
        public void BuildQuery(CreateCredential input)
        {
            Query = "[dbo].[Add_Credential]";

            Parameters = new
            {
                email = input.Email,
                password = input.Password
            };
        }

        public string Query { get; private set; }
        public object Parameters { get; private set; }
        public bool IsStoredProcedure => true;
    }
}
