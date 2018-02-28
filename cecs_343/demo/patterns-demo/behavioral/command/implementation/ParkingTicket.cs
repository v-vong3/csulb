namespace patterns_demo.behavioral.command.implementation
{
    using System;

    /// <summary>
    /// Simple domain model representing a parking ticket with a two-hour time limit
    /// </summary>
    public class ParkingTicket
    {
        public decimal ParkingRate {get;}
        public DateTime IssuedDate {get;}
        public DateTime ExpirationDate {get;}

        public ParkingTicket(decimal parkingRate)
        {
            ParkingRate = parkingRate;
            IssuedDate = DateTime.UtcNow;
            ExpirationDate = IssuedDate.AddHours(2); // 2 hour time limit
        }
    }
}