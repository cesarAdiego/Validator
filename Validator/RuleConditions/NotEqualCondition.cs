using System.Collections.Generic;

namespace Validator.Validator.RuleConditions
{
    public class NotEqualCondition<TEntity> : RuleConditionBase<TEntity>, IRuleCondition<TEntity>
    {
        public ValidationResult Validate(TEntity originalValue)
        {
            var validationResult = new ValidationResult();

            if(Comparer<TEntity>.Default.Compare(originalValue, ValueToCompare) != 0)
            {
                validationResult.AddValidation(ParameterName, "Are not equal");
            }

            return validationResult;
        }
    }
}
