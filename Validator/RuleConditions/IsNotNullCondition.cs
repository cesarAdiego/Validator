using System.Collections.Generic;

namespace Validator.Validator.RuleConditions
{
    public class IsNotNullCondition<TEntity> : RuleConditionBase<TEntity>, IRuleCondition<TEntity>
    {
        public ValidationResult Validate(TEntity originalValue)
        {
            var validationResult = new ValidationResult();

            if(EqualityComparer<TEntity>.Default.Equals(originalValue, default))
            {
                validationResult.AddValidation(ParameterName, "Is null");
            }

            return validationResult;
        }
    }
}
