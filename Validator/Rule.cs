using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Validator.Validator
{
    public class Rule<TIn, TOut>
    {
        private Expression<Func<TIn, TOut>> _singleParam { get; set; }

        private string _paramName { get; set; }

        private string ParamName
        {
            get
            {
                if(_paramName == null)
                {
                    _paramName = (_singleParam.Body as MemberExpression).Member.Name;
                }

                return _paramName;
            }
        }

        public bool CheckIfNull { get; set; }

        public bool CheckIsBiggerThan { get; set; }

        public bool CheckIsLesserThan { get; set; }

        public bool CheckAreEqual { get; set; }

        public TOut BiggerThanObject { get; set; }

        public TOut LesserThanObject { get; set; }

        public TOut EqualObject { get; set; }

        public Rule(Expression<Func<TIn, TOut>> func)
        {
            _singleParam = func;
        }

        public ValidationResult Validate(TIn entity)
        {
            var result = new ValidationResult();
            var value = _singleParam.Compile().Invoke(entity);

            if(CheckIfNull)
            {
                ValidateParamIsNotNull(value, result);
            }

            if(CheckIsBiggerThan)
            {
                ValidateParamIsBiggerThan(value, result);
            }

            if(CheckIsLesserThan)
            {
                ValidateParamIsLesserThan(value, result);
            }

            if(CheckAreEqual)
            {
                ValidateParamAreEqual(value, result);
            }

            return result;
        }

        private void ValidateParamIsNotNull(TOut value, ValidationResult validationResult)
        {
            if(EqualityComparer<TOut>.Default.Equals(value, default))
            {
                validationResult.AddValidation(ParamName, "Is null");
            }
        }

        private void ValidateParamIsBiggerThan(TOut value, ValidationResult validationResult)
        {
            if(!(Comparer<TOut>.Default.Compare(value, BiggerThanObject) >= 0))
            {
                validationResult.AddValidation(ParamName, "Is not greater");
            }
        }

        private void ValidateParamIsLesserThan(TOut value, ValidationResult validationResult)
        {
            if(!(Comparer<TOut>.Default.Compare(value, LesserThanObject) <= 0))
            {
                validationResult.AddValidation(ParamName, "Is not less");
            }
        }

        private void ValidateParamAreEqual(TOut value, ValidationResult validationResult)
        {
            if(Comparer<TOut>.Default.Compare(value, EqualObject) != 0) {
                validationResult.AddValidation(ParamName, "Are not equal");
            }
        }
    }
}
