using System.Collections.Generic;

namespace Validator.Validator.RuleConditions
{
    public class NotEqualCondition<TEntity> : RuleConditionBase<TEntity>, IRuleCondition<TEntity>
    {
        public NotEqualCondition(TEntity value, string parameterName)
            : base(value, parameterName)
        {

        }

        public ValidationResult Validate(TEntity originalValue)
        {
            var validationResult = new ValidationResult();

            if (Comparer<TEntity>.Default.Compare(originalValue, ValueToCompare) == 0)
            {
                validationResult.AddValidation(ParameterName, "Are equal");
            }

            return validationResult;
        }
    }
}
