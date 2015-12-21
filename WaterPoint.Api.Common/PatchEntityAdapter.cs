using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Utility;
using WaterPoint.Core.Domain.Exceptions;
using WaterPoint.Data.Entity;

namespace WaterPoint.Api.Common
{
    public interface IPatchEntityAdapter
    {
        TOutput PatchEnitity<TInput, TOutput>(
            TOutput existingEntity,
            Action<TInput> patchAction,
            Action<TOutput> postUpdateAction)
            where TOutput : class,
            IDataEntity where TInput : class,
            new();
    }

    public class PatchEntityAdapter : IPatchEntityAdapter
    {
        public TOutput PatchEnitity<TInput, TOutput>(
            TOutput existingEntity,
            Action<TInput> patchAction,
            Action<TOutput> postUpdateAction)
            where TOutput : class, IDataEntity
            where TInput : class, new()
        {
            if (existingEntity == null)
                //TODO: Add message to resource file.
                //TODO: detailLink
                throw new NotFoundException();


            //map existing object from DB to a temp dto
            var existingDto = existingEntity.MapTo(new TInput());

            //patch request payload the temp dto, now it should contain a merged version
            patchAction(existingDto);

            var validationResults = new List<ValidationResult>();

            //validate the merged version
            var validationContext = new ValidationContext(existingDto, null, null);

            var isValidRequest = Validator.TryValidateObject(existingDto, validationContext, validationResults);

            if (!isValidRequest)
            {
                var exception = new InvalidInputDataException();

                foreach (var validationResult in validationResults)
                    exception.AddMessage(validationResult.ErrorMessage);

                throw exception;
            }

            //valid then merge the temp dto to the existing DB object
            //TODO: valid then update the object
            var updatedCustomer = existingDto.MapTo(existingEntity);

            postUpdateAction(updatedCustomer);

            return updatedCustomer;
        }
    }
}
