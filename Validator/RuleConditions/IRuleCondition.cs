namespace Validator.Validator.RuleConditions
{
    public interface IRuleCondition<T>
    {
        public ValidationResult Validate(T originalValue);
    }
}
