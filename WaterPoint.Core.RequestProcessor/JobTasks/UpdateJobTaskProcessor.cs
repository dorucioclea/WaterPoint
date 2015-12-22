//using System;
//using WaterPoint.Api.Common;
//using WaterPoint.Core.Bll.Commands.JobTasks;
//using WaterPoint.Core.Bll.Executors;
//using WaterPoint.Core.Bll.Queries.JobTasks;
//using WaterPoint.Core.Bll.QueryRunners.JobTasks;
//using WaterPoint.Core.Domain;
//using WaterPoint.Core.Domain.Contracts.JobTasks;
//using WaterPoint.Core.Domain.Exceptions;
//using WaterPoint.Core.Domain.Dtos.Payloads.JobTasks;
//using WaterPoint.Core.Domain.Dtos.Requests.JobTasks;
//using WaterPoint.Core.RequestProcessor.Mappers.EntitiesToContracts;
//using WaterPoint.Data.DbContext.Dapper;
//using WaterPoint.Data.Entity.DataEntities;

//namespace WaterPoint.Core.RequestProcessor.JobTasks
//{
//    public class UpdateJobTaskRequestProcessor :
//        BaseDapperUowRequestProcess,
//        IRequestProcessor<UpdateJobTaskRequest, JobTaskContract>
//    {
//        private readonly IPatchEntityAdapter _patchEntityAdapter;
//        private readonly GetJobTaskByIdQuery _getJobTaskByIdQuery;
//        private readonly GetJobTaskByIdQueryRunner _getJobTaskByIdQueryRunner;
//        private readonly UpdateJobTaskByIdCommand _updateJobTaskByIdQuery;
//        private readonly UpdateCommandExecutor _updateCommandExecutor;

//        public UpdateJobTaskRequestProcessor(
//            IDapperUnitOfWork dapperUnitOfWork,
//            IPatchEntityAdapter patchEntityAdapter,
//            GetJobTaskByIdQuery getJobTaskByIdQuery,
//            GetJobTaskByIdQueryRunner getJobTaskByIdQueryRunner,
//            UpdateJobTaskByIdCommand updateJobTaskByIdQuery,
//            UpdateCommandExecutor updateCommandExecutor)
//            : base(dapperUnitOfWork)
//        {
//            _patchEntityAdapter = patchEntityAdapter;
//            _getJobTaskByIdQuery = getJobTaskByIdQuery;
//            _getJobTaskByIdQueryRunner = getJobTaskByIdQueryRunner;
//            _updateJobTaskByIdQuery = updateJobTaskByIdQuery;
//            _updateCommandExecutor = updateCommandExecutor;
//        }

//        public JobTaskContract Process(UpdateJobTaskRequest input)
//        {
//            var result = UowProcess(ProcessDeFacto, input);

//            return result;
//        }

//        private JobTaskContract ProcessDeFacto(UpdateJobTaskRequest input)
//        {
//            throw new NotImplementedException();

//            //_getJobTaskByIdQuery.BuildQuery(input.OrganizationEntityParameter.Id);

//            //var existingJobTask = _getJobTaskByIdQueryRunner.Run(_getJobTaskByIdQuery);

//            //var updatedJobTask = _patchEntityAdapter.PatchEnitity<WriteJobTaskPayload, JobTask>(
//            //    existingJobTask,
//            //    input.UpdateJobTaskPayload.Patch,
//            //    (o) => { o.UtcUpdated = DateTime.UtcNow; },
//            //    _getJobTaskByIdQuery);

//            ////then build the query to update the object.
//            //_updateJobTaskByIdQuery.BuildQuery(updatedJobTask);

//            //var success = _updateCommandExecutor.Run(_updateJobTaskByIdQuery);

//            //if (success)
//            //    return JobTaskMapper.Map(updatedJobTask);

//            //var updateException = new UpdateFailedException();

//            //updateException.AddMessage("operation is finished but there is no result returned");

//            //throw updateException;
//        }
//    }



//}
