using System;
using System.Collections.Generic;

namespace Validator.Validator
{
    public class Rule<TIn, TOut>
    {
        private Func<TIn, TOut> _singleParam { get; set; }

        public bool CheckIfNull { get; set; }

        public bool CheckIsBiggerThan { get; set; }

        public bool CheckIsLesserThan { get; set; }

        public bool CheckAreEqual { get; set; }

        public TOut BiggerThanObject { get; set; }

        public TOut LesserThanObject { get; set; }

        public TOut EqualObject { get; set; }

        public Rule(Func<TIn, TOut> func)
        {
            _singleParam = func;
        }

        public ValidationResult Validate(TIn entity)
        {
            var result = new ValidationResult();

            if(CheckIfNull)
            {
                ValidateParamIsNotNull(entity, result);
            }

            if(CheckIsBiggerThan)
            {
                ValidateParamIsBiggerThan(entity, result);
            }

            if(CheckIsLesserThan)
            {
                ValidateParamIsLesserThan(entity, result);
            }

            if(CheckAreEqual)
            {
                ValidateParamAreEqual(entity, result);
            }

            return result;
        }

        private void ValidateParamIsNotNull(TIn entity, ValidationResult validationResult)
        {
            var value = _singleParam.Invoke(entity);

            if(EqualityComparer<TOut>.Default.Equals(value, default))
            {
                validationResult.AddValidation(_singleParam.Target.ToString(), "Is null");
            }
        }

        private void ValidateParamIsBiggerThan(TIn entity, ValidationResult validationResult)
        {
            var value = _singleParam.Invoke(entity);

            if(!(Comparer<TOut>.Default.Compare(value, BiggerThanObject) >= 0))
            {
                validationResult.AddValidation(_singleParam.Target.ToString(), "Is not greater");
            }
        }

        private void ValidateParamIsLesserThan(TIn entity, ValidationResult validationResult)
        {
            var value = _singleParam.Invoke(entity);

            if(!(Comparer<TOut>.Default.Compare(value, LesserThanObject) <= 0))
            {
                validationResult.AddValidation(_singleParam.Target.ToString(), "Is not less");
            }
        }

        private void ValidateParamAreEqual(TIn entity, ValidationResult validationResult)
        {
            var value = _singleParam.Invoke(entity);

            if(Comparer<TOut>.Default.Compare(value, EqualObject) != 0) {
                validationResult.AddValidation(_singleParam.Target.ToString(), "Are not equal");
            }
        }
    }
}
