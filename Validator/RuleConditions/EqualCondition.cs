using System.Collections.Generic;

namespace Validator.Validator.RuleConditions
{
    public class EqualCondition<TEntity> : IRuleCondition<TEntity>
    {

        public ValidationResult Validate(TEntity originalValue, TEntity valueToCompare, string parameterName)
        {
            var validationResult = new ValidationResult();

            if(EqualityComparer<TEntity>.Default.Equals(originalValue, valueToCompare))
            {
                validationResult.AddValidation(parameterName, "Are not equal");
            }

            return validationResult;
        }
    }
}
