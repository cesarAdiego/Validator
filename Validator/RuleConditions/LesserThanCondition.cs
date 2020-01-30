using System.Collections.Generic;

namespace Validator.Validator.RuleConditions
{
    public class LesserThanCondition<TEntity> : RuleConditionBase<TEntity>, IRuleCondition<TEntity>
    {
        public LesserThanCondition(TEntity value, string parameterName)
            : base(value, parameterName)
        {

        }

        public ValidationResult Validate(TEntity originalValue)
        {
            var validationResult = new ValidationResult();

            if (!(Comparer<TEntity>.Default.Compare(originalValue, ValueToCompare) < 0))
            {
                validationResult.AddValidation(ParameterName, "Is not lesser");
            }

            return validationResult;
        }
    }
}
