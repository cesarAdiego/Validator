using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Validator.Validator
{
    public class AbstractValidator<TEntity>
    {
        public List<Rule<TEntity, object>> Rules { get; set; }

        public AbstractValidator() 
        {
            Rules = new List<Rule<TEntity, object>>();
        }

        public ValidationResult Validate(TEntity entity)
        {
            var validationResult = new ValidationResult();

            foreach(var rule in Rules)
            {
                var result = rule.Validate(entity);

                validationResult.MergeWith(result);
            }

            return validationResult;
        }

        public void AddRule(Rule<TEntity, object> rule)
        {
            Rules.Add(rule);
        }

        public RuleBuilder<TEntity> RuleFor(Expression<Func<TEntity, object>> func)
        {
            return RuleBuilder<TEntity>.RuleFor(func);
        }
    }
}
