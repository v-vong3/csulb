using System.Collections.Generic;

namespace patterns_demo.behavioral.command
{
    public class Car
    {
        public string Make {get;}
        public string Model {get;}
        public List<Door> Doors {get;}

        public Car(string make, string model, List<Door> doors)
        {
            Make = make;
            Model = model;
            Doors = doors;
        }

        public void ExitCar()
        {
            foreach(var door in Doors)
            {
                door.Open.Execute();
            }
        }
    }
}