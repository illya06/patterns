using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace patterns
{
    class Originator
    {
        private string _state;

        public Originator(string state)
        {
            this._state = state;
            Console.WriteLine("init state = " + state);
        }

        public void DoSomething()
        {
            Console.WriteLine("Change state pls: ");
            this._state = Console.ReadLine();
            Console.WriteLine($"state has changed to: {_state}");
        }

        public IMemento Save()
        {
            return new ConcreteMemento(this._state);
        }

        public void Restore(IMemento memento)
        {
            if (!(memento is ConcreteMemento))
            {
                throw new Exception("aeeee" + memento.ToString());
            }

            this._state = memento.GetState();
            Console.Write($"state has changed to: {_state}");
        }
    }

    public interface IMemento
    {
        string GetName();

        string GetState();

        DateTime GetDate();
    }

    class ConcreteMemento : IMemento
    {
        private string _state;

        private DateTime _date;

        public ConcreteMemento(string state)
        {
            this._state = state;
            this._date = DateTime.Now;
        }

        public string GetState()
        {
            return this._state;
        }

        public string GetName()
        {
            return $"{this._date} / ({this._state})...";
        }

        public DateTime GetDate()
        {
            return this._date;
        }
    }

    class Caretaker
    {
        private List<IMemento> _mementos = new List<IMemento>();

        private Originator _originator = null;

        public Caretaker(Originator originator)
        {
            this._originator = originator;
        }

        public void Backup()
        {
            Console.WriteLine("\nsaving Originator's state =]");
            this._mementos.Add(this._originator.Save());
        }

        public void Undo()
        {
            if (this._mementos.Count == 0)
            {
                return;
            }

            var memento = this._mementos.Last();
            this._mementos.Remove(memento);

            Console.WriteLine("restoring state to: " + memento.GetName());

            try
            {
                this._originator.Restore(memento);
            }
            catch (Exception)
            {
                this.Undo();
            }
        }

        public void ShowHistory()
        {
            Console.WriteLine("git history");

            foreach (var memento in this._mementos)
            {
                Console.WriteLine(memento.GetName());
            }
        }
    }
}