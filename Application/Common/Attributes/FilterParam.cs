using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class FilterParamAttribute :Attribute
    {
        public bool range = false;
        public bool equals = false;
        public bool startsWith = false;
        public bool contains = false;
        public bool useInJoin = false;
    }

}
