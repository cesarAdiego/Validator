using Validator.Validator;

namespace Validator.Entity
{
    public class PersonValidator : AbstractValidator<Person>
    {
        public PersonValidator(Person person)
            :base(person)
        {

        }
    }
}
