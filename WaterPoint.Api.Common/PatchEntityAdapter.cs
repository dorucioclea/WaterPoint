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

            //patch request payload the temp dto, now it should contain a merged version
            patchAction(payloadBeingPatched);

            var validationResults = new List<ValidationResult>();

            //validate the merged version
            var validationContext = new ValidationContext(payloadBeingPatched, null, null);

            var isValidRequest = Validator.TryValidateObject(payloadBeingPatched, validationContext, validationResults);

            if (!isValidRequest)
            {
                var exception = new InvalidInputDataException();

                foreach (var validationResult in validationResults)
                    exception.AddMessage(validationResult.ErrorMessage);

                throw exception;
            }

            payloadBeingPatched.MapTo(existingEntity);

            //valid then merge the temp dto to the existing DB object
            //TODO: valid then update the object
            var queryParameter = existingEntity.MapTo(new TOutput());

            return queryParameter;
        }
    }
}
