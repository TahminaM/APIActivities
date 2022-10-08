
namespace MyConsoleApplication
{

    //Interface
    interface MyInterface
    {
        // Methods
        int Age { get; set; }
        string Name { get; set; }
        bool IsAlive { get; set; }
    }

    class MyClass : MyInterface
    {
        //Property
        private int age;
        private string name;
        private bool isAlive;

        public int Age { get { return age; } set { age = value; } }
        public string Name { get { return name; } set { name = value; } }
        public bool IsAlive { get { return isAlive; } set { isAlive = value; } }


    }

    //Event
    class DisplayInfo
    {
        // Define a delegate
        public delegate void DisplayInfoEventHandler(object source, EventArgs args);

        // Declare the event
        public event DisplayInfoEventHandler InfoDisplayed;

        public void ShowInfo(MyClass avenger)
        {
            Console.WriteLine ($"When Dad died, {avenger.Name} was only {avenger.Age}.");
            Thread.Sleep(4000);

            OnInfoDisplayed();
        }

        // Raising the event
        protected virtual void OnInfoDisplayed()
        {
            if (InfoDisplayed != null)
                InfoDisplayed (this, null);
        }

    }

    // Subscribing to the event
    public class AppService
    {
        public void OnInfoDisplayed (object source, EventArgs eventargs)
        {
            Console.WriteLine("She Miss him everyday!!");
        }

    }


    class Program
    {
        static void Main()
        {
            var Avenger = new MyClass();

            Avenger.Age = 4;
            Avenger.Name = "Tahmina";
            Avenger.IsAlive = false;

            var displayInfo = new DisplayInfo();
            var appService = new AppService();

            displayInfo.InfoDisplayed += appService.OnInfoDisplayed;
            displayInfo.ShowInfo(Avenger);
            Console.ReadKey();
        }


    }

}
