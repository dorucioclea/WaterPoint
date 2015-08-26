﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaterPoint.Data.Entity.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class ManyToOneAttribute : RelationshipAttribute
    {
        public ManyToOneAttribute(Type type)
            : base(type)
        {

        }
    }
}
