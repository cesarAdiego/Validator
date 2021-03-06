﻿using System.Collections.Generic;

namespace Validator.Validator.RuleConditions
{
    public class BiggerThanCondition<TEntity> : RuleConditionBase<TEntity>, IRuleCondition<TEntity>
    {
        public BiggerThanCondition(TEntity value, string parameterName)
            : base(value, parameterName)
        {

        }

        public ValidationResult Validate(TEntity originalValue)
        {
            var validationResult = new ValidationResult();

            if (!(Comparer<TEntity>.Default.Compare(originalValue, ValueToCompare) > 0))
            {
                validationResult.AddValidation(ParameterName, "Is not greater");
            }

            return validationResult;
        }
    }
}
