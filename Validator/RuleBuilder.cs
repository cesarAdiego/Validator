using System;
using System.Linq.Expressions;
using Validator.Validator.RuleConditions;

namespace Validator.Validator
{
    public class RuleBuilder<TIn>
    {
        private Rule<TIn, object> Rule { get; set; }

        private RuleBuilder(Expression<Func<TIn, object>> func) 
        {
            Rule = new Rule<TIn, object>(func);
        }

        public Rule<TIn, object> Build()
        {
            return Rule;
        }

        public RuleBuilder<TIn> IsNull()
        {
            var condition = new IsNullCondition<object>();
            condition.ParameterName = Rule.ParameterName;
            Rule.Conditions.Add(condition);

            return this;
        }

        public RuleBuilder<TIn> IsNotNull()
        {
            var condition = new IsNotNullCondition<object>();
            condition.ParameterName = Rule.ParameterName;

            Rule.Conditions.Add(condition);

            return this;
        }

        public RuleBuilder<TIn> IsBiggerThan(object value)
        {
            var condition = new BiggerThanCondition<object>();
            condition.ValueToCompare = value;
            condition.ParameterName = Rule.ParameterName;

            Rule.Conditions.Add(condition);

            return this;
        }

        public RuleBuilder<TIn> IsBiggerOrEqualThan(object value)
        {
            var condition = new BiggerOrEqualThanCondition<object>();
            condition.ValueToCompare = value;
            condition.ParameterName = Rule.ParameterName;

            Rule.Conditions.Add(condition);

            return this;
        }

        public RuleBuilder<TIn> IsLesserThan(object value)
        {
            var condition = new LesserThanCondition<object>();
            condition.ValueToCompare = value;
            condition.ParameterName = Rule.ParameterName;

            Rule.Conditions.Add(condition);

            return this;
        }

        public RuleBuilder<TIn> IsLesserOrEqualThan(object value)
        {
            var condition = new LesserOrEqualThanCondition<object>();
            condition.ValueToCompare = value;
            condition.ParameterName = Rule.ParameterName;

            Rule.Conditions.Add(condition);

            return this;
        }

        public RuleBuilder<TIn> AreEqual(object value)
        {
            var condition = new EqualCondition<object>();
            condition.ValueToCompare = value;
            condition.ParameterName = Rule.ParameterName;

            Rule.Conditions.Add(condition);

            return this;
        }

        public RuleBuilder<TIn> AreNotEqual(object value)
        {
            var condition = new NotEqualCondition<object>();
            condition.ValueToCompare = value;
            condition.ParameterName = Rule.ParameterName;

            Rule.Conditions.Add(condition);

            return this;
        }

        public static RuleBuilder<TIn> RuleFor(Expression<Func<TIn, object>> func)
        {
            return new RuleBuilder<TIn>(func);
        }
    }
}
