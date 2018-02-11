namespace patterns_demo.behavioral.command
{
    public class Door
    {
        public ICommand Close {get;}
        public ICommand Open {get;}

        public Door()
        {
            Close = new CloseDoorCommand();
            Open = new OpenDoorCommand();
        }


    }
}