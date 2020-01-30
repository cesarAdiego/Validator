using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Validator.Validator.RuleConditions;

namespace Validator.Validator
{
    public class Rule<TIn, TOut>
    {
        private Expression<Func<TIn, TOut>> _singleParam { get; set; }

        private string _paramName { get; set; }

        public string ParameterName
        {
            get
            {
                if(_paramName == null)
                {
                    var member = _singleParam.Body as MemberExpression;

                    if (member != null)
                    {
                        _paramName = member.Member.Name;
                    }
                    else
                    {
                        var expression = _singleParam.Body as UnaryExpression;
                        var operand = expression.Operand as MemberExpression;
                        _paramName = operand.Member.Name;
                    }
                }

                return _paramName;
            }
        }

        public List<IRuleCondition<TOut>> Conditions { get; set; }

        public Rule(Expression<Func<TIn, TOut>> func)
        {
            _singleParam = func;
            Conditions = new List<IRuleCondition<TOut>>();
        }

        public ValidationResult Validate(TIn entity)
        {
            var result = new ValidationResult();
            var value = _singleParam.Compile().Invoke(entity);

            foreach(var condition in Conditions)
            {
                var ruleConditionResult = condition.Validate(value);

                result.MergeWith(ruleConditionResult);
            }

            return result;
        }
    }
}
