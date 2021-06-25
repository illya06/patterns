using System;

namespace patterns
{
    class Program
    {
        static void Main(string[] args)
        {
            //iterator pattern
            NumericCollection nums = new ("Sl4ve M2sTe4");
            foreach (var item in nums)
                System.Console.WriteLine(item);

            //mediator pattern
            Slave1 slave1 = new ();
            Slave2 slave2 = new ();
            DungeonMaster master = new (slave1, slave2);
            slave1.OpenTheLocker();

            //snapshot pattern
            Originator originator = new Originator("0");
            Caretaker caretaker = new Caretaker(originator);

            caretaker.Backup();
            originator.DoSomething();

            caretaker.Backup();
            originator.DoSomething();

            Console.WriteLine("\nrollback!\n");
            caretaker.Undo();
        }
    }
}
