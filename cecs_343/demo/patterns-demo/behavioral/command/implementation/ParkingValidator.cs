using patterns_demo.behavioral.command.contract;

namespace patterns_demo.behavioral.command.implementation
{
    using System; // For DateTime

    public class ParkingValidator : IValidator
    {
        public bool Validate(object entity)
        {
            var ticket = entity as ParkingTicket;

            if(ticket == null)
            {
                throw new ArgumentException($"Parameter {nameof(entity)} must be a {nameof(ParkingTicket)} object");
            }

            return DateTime.UtcNow < ticket.ExpirationDate;
        }
    }
}