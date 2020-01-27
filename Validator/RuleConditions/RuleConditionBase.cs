using System;
using System.Collections.Generic;
using System.Text;

namespace Validator.Validator.RuleConditions
{
    public class RuleConditionBase<T>
    {
        public T ValueToCompare { get; set; }

        public string ParameterName { get; set; }
    }
}
