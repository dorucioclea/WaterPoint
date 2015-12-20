//using System;
//using WaterPoint.Api.Common;
//using WaterPoint.Core.Bll.Commands.Jobs;
//using WaterPoint.Core.Bll.Executors;
//using WaterPoint.Core.Bll.Queries.Jobs;
//using WaterPoint.Core.Bll.QueryRunners.Jobs;
//using WaterPoint.Core.Domain;
//using WaterPoint.Core.Domain.Contracts.Jobs;
//using WaterPoint.Core.Domain.Exceptions;
//using WaterPoint.Core.Domain.Dtos.Payloads.Jobs;
//using WaterPoint.Core.Domain.Dtos.Requests.Jobs;
//using WaterPoint.Data.DbContext.Dapper;
//using WaterPoint.Data.Entity.DataEntities;

//namespace WaterPoint.Core.RequestProcessor.Jobs
//{
//    public class UpdateJobRequestProcessor :
//        BaseDapperUowRequestProcess,
//        IRequestProcessor<UpdateJobRequest, JobWithCustomerAndStatusContract>
//    {
//        private readonly IPatchEntityAdapter _patchEntityAdapter;
//        private readonly GetJobByIdQuery _getJobByIdQuery;
//        private readonly GetJobByIdQueryRunner _getJobByIdQueryRunner;
//        private readonly UpdateJobByIdCommand _updateJobByIdQuery;
//        private readonly UpdateCommandExecutor _updateCommandExecutor;

//        public UpdateJobRequestProcessor(
//            IDapperUnitOfWork dapperUnitOfWork,
//            IPatchEntityAdapter patchEntityAdapter,
//            GetJobByIdQuery getJobByIdQuery,
//            GetJobByIdQueryRunner getJobByIdQueryRunner,
//            UpdateJobByIdCommand updateJobByIdQuery,
//            UpdateCommandExecutor updateCommandExecutor)
//            : base(dapperUnitOfWork)
//        {
//            _patchEntityAdapter = patchEntityAdapter;
//            _getJobByIdQuery = getJobByIdQuery;
//            _getJobByIdQueryRunner = getJobByIdQueryRunner;
//            _updateJobByIdQuery = updateJobByIdQuery;
//            _updateCommandExecutor = updateCommandExecutor;
//        }

//        public JobWithCustomerAndStatusContract Process(UpdateJobRequest input)
//        {
//            var result = UowProcess(ProcessDeFacto, input);

//            return result;
//        }

//        private JobWithCustomerAndStatusContract ProcessDeFacto(UpdateJobRequest input)
//        {
//            _getJobByIdQuery.BuildQuery(input.OrganizationEntityParameter.OrganizationId, input.OrganizationEntityParameter.Id);

//            var existingJob = _getJobByIdQueryRunner.Run(_getJobByIdQuery);

//            var updatedJob = _patchEntityAdapter.PatchEnitity<WriteJobPayload, Job>(
//                existingJob,
//                input.UpdateJobPayload.Patch,
//                (o) => { o.UtcUpdated = DateTime.UtcNow; },
//                _getJobByIdQuery);

//            //then build the query to update the object.
//            _updateJobByIdQuery.BuildQuery(input.OrganizationEntityParameter.OrganizationId, updatedJob);

//            var success = _updateCommandExecutor.Run(_updateJobByIdQuery);

//            if (success)
//                return ContractMapper.JobMapper.Map(updatedJob);

//            var updateException = new UpdateFailedException();

//            updateException.AddMessage("operation is finished but there is no result returned");

//            throw updateException;
//        }
//    }



//}
