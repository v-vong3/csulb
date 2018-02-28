using patterns_demo.behavioral.command.contract;

namespace patterns_demo.behavioral.command.implementation
{
    using System;

    /// <summary>
    /// Validates if Person is a legal adult in the US
    /// </summary>
    public class AgeValidator : IValidator
    {
        private const int LEGAL_AGE = 18;

        public bool Validate(object entity)
        {
            var person = entity as Person;

            if(person == null)
            {
                throw new ArgumentException($"Parameter {nameof(entity)} must be a {nameof(Person)} object");
            }

            return person.Age >= LEGAL_AGE;
        }
    }
}