using System;
using System.Collections.Generic;

namespace Validator.Validator
{
    public class AbstractValidator<TEntity>
    {
        public List<Rule<TEntity, object>> Rules { get; set; }

        private TEntity _entity { get; set; }

        public AbstractValidator(TEntity entity) 
        {
            Rules = new List<Rule<TEntity, object>>();
            _entity = entity;
        }

        public bool Validate()
        {
            bool result = true;

            foreach(var rule in Rules)
            {
                result = result && rule.Validate(_entity);
            }

            return result;
        }

        public void AddRule(Rule<TEntity, object> rule)
        {
            Rules.Add(rule);
        }
    }
}
