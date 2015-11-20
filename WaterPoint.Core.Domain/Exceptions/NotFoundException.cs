using System;

namespace WaterPoint.Core.Domain.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException()
            : base("resource cannot be found.")
        {
        }
    }
}
