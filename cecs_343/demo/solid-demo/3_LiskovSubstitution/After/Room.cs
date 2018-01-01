namespace solid_demo.LiskovSubstitution.After
{
    public class Room
    {
        // Read-only accessors can only be set by Constructor
        public string BuildingName {get;}
        public int Floor {get;}
        public int RoomNumber {get;}

        public Room(string buildingName, int floor, int roomNumber)
        {
            BuildingName = buildingName;
            Floor = floor;
            RoomNumber = roomNumber;
        }
    }
}