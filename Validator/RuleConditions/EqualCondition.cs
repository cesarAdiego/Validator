using System.Collections.Generic;

namespace Validator.Validator.RuleConditions
{
    public class EqualCondition<TEntity> : RuleConditionBase<TEntity>, IRuleCondition<TEntity>
    {

        public ValidationResult Validate(TEntity originalValue)
        {
            var validationResult = new ValidationResult();

            if(EqualityComparer<TEntity>.Default.Equals(originalValue, ValueToCompare))
            {
                validationResult.AddValidation(ParameterName, "Are not equal");
            }

            return validationResult;
        }
    }
}
