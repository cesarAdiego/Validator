namespace Validator.Validator.RuleConditions
{
    public class RuleConditionBase<T>
    {
        public T ValueToCompare { get; set; }

        public string ParameterName { get; set; }

        public RuleConditionBase(T value, string parameterName)
        {
            ValueToCompare = value;
            ParameterName = parameterName;
        }

        public RuleConditionBase(string parameterName)
        {
            ValueToCompare = default;
            ParameterName = parameterName;
        }
    }
}
