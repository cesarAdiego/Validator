﻿using System.Collections.Generic;

namespace Validator.Validator.RuleConditions
{
    public class BiggerOrEqualThanCondition<TEntity> : RuleConditionBase<TEntity>, IRuleCondition<TEntity>
    {
        public BiggerOrEqualThanCondition(TEntity value, string parameterName)
            : base(value, parameterName)
        {

        }

        public ValidationResult Validate(TEntity originalValue)
        {
            var validationResult = new ValidationResult();

            if (!(Comparer<TEntity>.Default.Compare(originalValue, ValueToCompare) >= 0))
            {
                validationResult.AddValidation(ParameterName, "Is not bigger or equal");
            }

            return validationResult;
        }
    }
}
