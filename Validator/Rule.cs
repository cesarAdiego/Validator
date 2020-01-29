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

        //public bool CheckIfNull { get; set; }

        //public bool CheckIsBiggerThan { get; set; }

        //public bool CheckIsLesserThan { get; set; }

        //public bool CheckAreEqual { get; set; }

        //public TOut BiggerThanObject { get; set; }

        //public TOut LesserThanObject { get; set; }

        //public TOut EqualObject { get; set; }

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

            //if(CheckIfNull)
            //{
            //    ValidateParamIsNotNull(value, result);
            //}

            //if(CheckIsBiggerThan)
            //{
            //    ValidateParamIsBiggerThan(value, result);
            //}

            //if(CheckIsLesserThan)
            //{
            //    ValidateParamIsLesserThan(value, result);
            //}

            //if(CheckAreEqual)
            //{
            //    ValidateParamAreEqual(value, result);
            //}

            return result;
        }

        //private void ValidateParamIsNotNull(TOut value, ValidationResult validationResult)
        //{
        //    if(EqualityComparer<TOut>.Default.Equals(value, default))
        //    {
        //        validationResult.AddValidation(ParamName, "Is null");
        //    }
        //}

        //private void ValidateParamIsBiggerThan(TOut value, ValidationResult validationResult)
        //{
        //    if(!(Comparer<TOut>.Default.Compare(value, BiggerThanObject) >= 0))
        //    {
        //        validationResult.AddValidation(ParamName, "Is not greater");
        //    }
        //}

        //private void ValidateParamIsLesserThan(TOut value, ValidationResult validationResult)
        //{
        //    if(!(Comparer<TOut>.Default.Compare(value, LesserThanObject) <= 0))
        //    {
        //        validationResult.AddValidation(ParamName, "Is not less");
        //    }
        //}

        //private void ValidateParamAreEqual(TOut value, ValidationResult validationResult)
        //{
        //    if(Comparer<TOut>.Default.Compare(value, EqualObject) != 0) {
        //        validationResult.AddValidation(ParamName, "Are not equal");
        //    }
        //}
    }
}
