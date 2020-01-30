using System.Collections.Generic;

namespace Validator.Validator.RuleConditions
{
    public class IsNullCondition<TEntity> : RuleConditionBase<TEntity>, IRuleCondition<TEntity>
    {
        public IsNullCondition(string parameterName)
            : base(parameterName)
        {

        }

        public ValidationResult Validate(TEntity originalValue)
        {
            var validationResult = new ValidationResult();

            if (!EqualityComparer<TEntity>.Default.Equals(originalValue, default))
            {
                validationResult.AddValidation(ParameterName, "Is not null");
            }

            return validationResult;
        }
    }
}
