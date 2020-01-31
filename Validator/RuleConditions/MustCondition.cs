using System;

namespace Validator.Validator.RuleConditions
{
    public class MustCondition<TEntity> : RuleConditionBase<TEntity>, IRuleCondition<TEntity>
    {
        private Func<TEntity, bool> _mustCondition { get; set; }

        public MustCondition(Func<TEntity, bool> mustCondition, string parameterName)
            : base(parameterName)
        {
            _mustCondition = mustCondition;
        }

        public ValidationResult Validate(TEntity originalValue)
        {
            var validationResult = new ValidationResult();

            if (!_mustCondition.Invoke(originalValue))
            {
                validationResult.AddValidation(ParameterName, "Don't pass the external function");
            }

            return validationResult;
        }
    }
}
