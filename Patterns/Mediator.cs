using System;

namespace patterns
{
    public interface IDungeonMediator
    {
        void Notify(object sender, string ev);
    }

    class DungeonMaster : IDungeonMediator
    {
        private Slave1 slave1;

        private Slave2 slave2;

        public DungeonMaster(Slave1 slave1, Slave2 slave2)
        {
            this.slave1 = slave1;
            this.slave1.SetMediator(this);
            this.slave2 = slave2;
            this.slave2.SetMediator(this);
        }

        public void Notify(object sender, string ev)
        {
            if (ev == "open")
            {
                Console.WriteLine("Dungeon master notifies slave2 about an unordinary event");
                this.slave2.AskSlave1();
            }
            if (ev == "ask")
            {
                Console.WriteLine("Dungeon master enjoys the show");
                this.slave1.FightWithSlave2();
                this.slave2.FightWithSlave1();
            }
        }
    }

    class GymPass
    {
        protected IDungeonMediator _mediator;

        public GymPass(IDungeonMediator mediator = null)
        {
            this._mediator = mediator;
        }

        public void SetMediator(IDungeonMediator mediator)
        {
            this._mediator = mediator;
        }
    }

    class Slave1 : GymPass
    {
        public void OpenTheLocker()
        {
            Console.WriteLine("Slave1 opens a locker");

            this._mediator.Notify(this, "open");
        }

        public void FightWithSlave2()
        {
            Console.WriteLine("Slave1 fights with slave2");

            this._mediator.Notify(this, "fight");
        }
    }

    class Slave2 : GymPass
    {
        public void AskSlave1()
        {
            Console.WriteLine("Slave2 asks slave1, why is he allowed in the gym");

            this._mediator.Notify(this, "ask");
        }

        public void FightWithSlave1()
        {
            Console.WriteLine("Gachi remix");

            this._mediator.Notify(this, "gachi");
        }
    }
}