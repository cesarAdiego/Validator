using System;
using System.Linq.Expressions;

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
            Rule.CheckIfNull = true;

            return this;
        }

        public RuleBuilder<TIn> IsBiggerThan(object value)
        {
            Rule.CheckIsBiggerThan = true;
            Rule.BiggerThanObject = value;

            return this;
        }

        public RuleBuilder<TIn> IsLesserThan(object value)
        {
            Rule.CheckIsLesserThan = true;
            Rule.LesserThanObject = value;

            return this;
        }

        public RuleBuilder<TIn> AreEqual(object value)
        {
            Rule.CheckAreEqual = true;
            Rule.EqualObject = value;

            return this;
        }

        public static RuleBuilder<TIn> RuleFor(Expression<Func<TIn, object>> func)
        {
            return new RuleBuilder<TIn>(func);
        }
    }
}
