using System;

namespace Validator.Validator
{
    public class Rule<TEntity>
    {
        private Func<TEntity, bool> _rule { get; set; }

        public Rule(Func<TEntity, bool> rule)
        {
            _rule = rule;
        }

        public bool Validate(TEntity entity)
        {
            return _rule.Invoke(entity);
        }
    }
}
