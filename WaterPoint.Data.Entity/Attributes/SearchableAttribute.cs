using System;

namespace WaterPoint.Data.Entity.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class SearchableAsEnglishAttribute : Attribute
    {
    }

    [AttributeUsage(AttributeTargets.Property)]
    public class SearchableAsUnicodeAttribute : Attribute
    {
    }
}
