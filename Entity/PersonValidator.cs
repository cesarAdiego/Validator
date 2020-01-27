using Validator.Validator;

namespace Validator.Entity
{
    public class PersonValidator : AbstractValidator<Person>
    {
        public PersonValidator()
        {
            AddRule(RuleFor(p => p.Name).AreEqual("Cesar").Build());
        }
    }
}
