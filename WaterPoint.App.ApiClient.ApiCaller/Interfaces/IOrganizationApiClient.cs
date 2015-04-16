using System.Threading.Tasks;
using WaterPoint.Api.DataContract;

namespace WaterPoint.App.ApiClient.Endpoints.Interfaces
{
    public interface IOrganizationApiClient
    {
        /// <summary>
        /// "http://localhost/WaterPoint.Api/organizations";
        /// "http://localhost/WaterPoint.Api/organizations/1";
        /// </summary>
        Task<OrganizationContract> GetById(int id);

        void Dispose();
    }
}