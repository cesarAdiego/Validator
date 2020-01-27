using System;
using System.Collections.Generic;
using System.Text;

namespace Validator.Validator.RuleConditions
{
    public class BiggerOrEqualThan<TEntity> : IRuleCondition<TEntity>
    {
        public ValidationResult Validate(TEntity originalValue, TEntity valueToCompare, string parameterName)
        {
            var validationResult = new ValidationResult();

            if(!(Comparer<TEntity>.Default.Compare(originalValue, valueToCompare) >= 0))
            {
                validationResult.AddValidation(parameterName, "Is not bigger or equal")
            }

            return validationResult;
        }
    }
}
