using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WaterPoint.Api.Common.BaseControllers;
using WaterPoint.Core.Domain;
using WaterPoint.Core.Domain.Contracts.JobCategories;
using WaterPoint.Core.Domain.Requests.JobCategories;

namespace WaterPoint.Api.Job.Controllers
{
    [Authorize]
    [RoutePrefix("organizations/{organizationId:int}")]
    public class CategoriesController : BaseOrgnizationContextController
    {
        private readonly IListProcessor<ListJobCategoriesRequest, JobCategoryContract> _listProcessor;

        public CategoriesController(
            IListProcessor<ListJobCategoriesRequest, JobCategoryContract> listProcessor
            )
        {
            _listProcessor = listProcessor;
        }

        [Route("categories")]
        public IHttpActionResult Get([FromUri]ListJobCategoriesRequest request)
        {
            var result = _listProcessor.Process(request);

            return Ok(result);
        }

    }
}
