using System;
using System.Collections.Generic;

namespace Validator.Validator
{
    public class AbstractValidator<TEntity>
    {
        public List<Rule<TEntity>> Rules { get; set; }

        private TEntity _entity { get; set; }

        public AbstractValidator(TEntity entity) 
        {
            Rules = new List<Rule<TEntity>>();
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

        public void AddRule(Func<TEntity, bool> func)
        {
            var rule = new Rule<TEntity>(func);
            
            Rules.Add(rule);
        }
    }
}
