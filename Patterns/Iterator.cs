using System;
using System.Collections;
using System.Collections.Generic;

namespace patterns
{
    abstract class Iterator : IEnumerator
    {
        object IEnumerator.Current => Current();

        public abstract int Key();

        public abstract object Current();

        public abstract bool MoveNext();

        public abstract void Reset();

    }

    public abstract class IteratorAggregate :IEnumerable
    {
        public abstract IEnumerator GetEnumerator();
    }

    class NumericIterator : Iterator
    {
        private string _collection;

        private int _position = -1;

        public NumericIterator(string collection)
        {
            this._collection = collection;
        }

        public override object Current()
        {
            return this._collection[_position];
        }

        public override int Key()
        {
            return this._position;
        }

        public override bool MoveNext()
        {
            this._position++;

            while(this._position < _collection.Length && !Char.IsNumber(_collection[_position]))
            {
                this._position++;
            }
            return this._position < _collection.Length;
        }

        public override void Reset()
        {
            this._position = -1;
        }
    }
    public class NumericCollection : IteratorAggregate
    {
        private string _collection;

        public NumericCollection(string collection)
        {
            this._collection = collection;
        }

        public override IEnumerator GetEnumerator()
        {
            return new NumericIterator(_collection);
        }
    }
}