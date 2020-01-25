using System.Collections.Generic;
using System.Linq;

namespace Validator.Validator
{
    public class ValidationResult
    {
        public Dictionary<string, List<string>> PropertiesValidation { get; set; }

        public bool Success
        {
            get
            {
                return !PropertiesValidation.Any();
            }
        }

        public ValidationResult()
        {
            PropertiesValidation = new Dictionary<string, List<string>>();
        }

        public void Clear()
        {
            PropertiesValidation.Clear();
        }

        public void AddValidation(string property, string message)
        {
            if(PropertiesValidation.ContainsKey(property))
            {
                PropertiesValidation[property].Add(message);
            }
            else
            {
                var messages = new List<string>() { message };
                
                PropertiesValidation.Add(property, messages);
            }
        }

        public void MergeWith(ValidationResult validationResult)
        {
            foreach(var propertyValidation in validationResult.PropertiesValidation)
            {
                if(PropertiesValidation.ContainsKey(propertyValidation.Key))
                {
                    PropertiesValidation[propertyValidation.Key].AddRange(propertyValidation.Value);
                }
                else
                {
                    PropertiesValidation.Add(propertyValidation.Key, propertyValidation.Value);
                }
            }
        }
    }
}
