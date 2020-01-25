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

        public bool Validate(TIn entity)
        {
            var result = true;

            if(CheckIfNull)
            {
                result = result && ValidateParamIsNotNull(entity);
            }

            if(CheckIsBiggerThan)
            {
                result = result && ValidateParamIsBiggerThan(entity);
            }

            if(CheckIsLesserThan)
            {
                result = result && ValidateParamIsLesserThan(entity);
            }

            if(CheckAreEqual)
            {
                result = result && ValidateParamAreEqual(entity);
            }

            return result;
        }

        private bool ValidateParamIsNotNull(TIn entity)
        {
            var value = _singleParam.Invoke(entity);

            return value != null || value != default;
        }

        private bool ValidateParamIsBiggerThan(TIn entity)
        {
            var value = _singleParam.Invoke(entity);

            return Comparer<TOut>.Default.Compare(value, BiggerThanObject) >= 0;
        }

        private bool ValidateParamIsLesserThan(TIn entity)
        {
            var value = _singleParam.Invoke(entity);

            return Comparer<TOut>.Default.Compare(value, LesserThanObject) <= 0;
        }

        private bool ValidateParamAreEqual(TIn entity)
        {
            var value = _singleParam.Invoke(entity);

            return Comparer<TOut>.Default.Compare(value, EqualObject) == 0;
        }
    }
}
