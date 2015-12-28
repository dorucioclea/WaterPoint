using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Utility;
using WaterPoint.Core.Domain.Db;
using WaterPoint.Core.Domain.Exceptions;
using WaterPoint.Data.Entity;

namespace WaterPoint.Api.Common
{
    public interface IPatchEntityAdapter
    {
        TOutput PatchEnitity<TInput, TExisting, TOutput>(TExisting existingEntity, Action<TInput> patchAction)
            where TOutput : class, IQueryParameter, new()
            where TExisting : class, IDataEntity
            where TInput : class, new();
    }

    public class PatchEntityAdapter : IPatchEntityAdapter
    {
        public TOutput PatchEnitity<TInput, TExisting, TOutput>(TExisting existingEntity, Action<TInput> patchAction)
            where TOutput : class, IQueryParameter, new()
            where TExisting : class, IDataEntity
            where TInput : class, new()
        {
            if (existingEntity == null)
                //TODO: Add message to resource file.
                //TODO: detailLink
                throw new NotFoundException();

            //map existing object from DB to a temp dto
            var payloadBeingPatched = existingEntity.MapTo(new TInput());

            //patch the payload
            patchAction(payloadBeingPatched);

            Validate(payloadBeingPatched);

            //1) map everything back to the query parameter
            var queryParameter = existingEntity.MapTo(new TOutput());

            //2) map patched values to the query parameter
            queryParameter = payloadBeingPatched.MapTo(queryParameter);

            return queryParameter;
        }

        private static void Validate<TInput>(TInput payloadBeingPatched)
        {
            var validationResults = new List<ValidationResult>();

            //validate the merged version
            var validationContext = new ValidationContext(payloadBeingPatched);

            var isValidRequest = Validator.TryValidateObject
                (payloadBeingPatched, validationContext, validationResults, true);

            if (isValidRequest)
                return;

            var exception = new InvalidInputDataException();

            foreach (var validationResult in validationResults)
                exception.AddMessage(validationResult.ErrorMessage);

            throw exception;
        }
    }
}
