using System;

namespace WaterPoint.Core.Domain.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException()
            : this(string.Empty)
        {
        }

        public NotFoundException(string resource)
            : base($"{resource} cannot be found.")
        {

        }
    }
}
