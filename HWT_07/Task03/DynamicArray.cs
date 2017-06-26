using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Task03
{
    public class DynamicArray<T> : IEnumerable<T>
    {
        private readonly int defaultLength = 8;
        private T[] array;

        public int Capacity { get; private set; }

        public int Length
        {
            get
            {
                return this.array.Length;
            }
        }

        public DynamicArray()
        {
            this.array = new T[this.defaultLength];
        }

        public DynamicArray(int count)
        {
            if (count < 1)
            {
                throw new Exception("Invalid array length");
            }

            this.array = new T[count];
        }

        public DynamicArray(IEnumerable<T> inputCollection)
        {
            this.array = new T[inputCollection.Count()];
            var i = 0;
            foreach (var element in inputCollection)
            {
                this.array[i] = element;
                i++;
            }

            this.Capacity = i;
        }

        public void Add(T newElement)
        {
            if (this.Capacity == this.Length)
            {
                this.array = this.GenerateNewArray(this.Length * 2); //todo не очень хорошее решение с т.з. производительности. Представь, что у тебя в массиве 1млн элементов, а добавить нужно штук 100. Для чего выделять дополнительно ещё 1млн пустых записей? Лучше задать константой какое-то значение, на которое ты увеличиваешь массив при переполнении.
			}

            this.array[this.Capacity] = newElement;
            this.Capacity++;
        }

        public void AddRange(IEnumerable<T> elementsCollection)
        {
            if (elementsCollection == null)
            {
                return;
            }

            var lengthNewCollection = elementsCollection.Count();
            if (this.Capacity + lengthNewCollection >= this.Length)
            {
                this.array = this.GenerateNewArray((this.Capacity + lengthNewCollection) * 2);
            }

            foreach (var element in elementsCollection)
            {
                this.array[this.Capacity] = element;
                this.Capacity++;
            }
        }

        public bool Remove(T removableElement)
        {
            var isRemoved = false;
            for (var i = 0; i < this.Capacity; i++)
            {
                if (this.array[i].Equals(removableElement))
                {
                    for (var j = i + 1; j < this.Capacity; j++)
                    {
                        this.array[j - 1] = this.array[j];
                    }

                    isRemoved = true;
                    break;
                }
            }

            if (isRemoved)
            {
                this.Capacity--;
            }

            return isRemoved;
        }

        public bool Insert(T addedElement, int position)
        {
            if (position < 0 || position > this.Capacity)
            {
                throw new ArgumentOutOfRangeException();
            }

            if (this.Capacity == this.Length)
            {
                this.array = this.GenerateNewArray(this.Length * 2);
            }

            for (var i = this.Capacity - 1; i >= position; i--)
            {
                this.array[i + 1] = this.array[i];
            }

            this.array[position] = addedElement;
            this.Capacity++;
            return this.array[position].Equals(addedElement);
        }

        private T[] GenerateNewArray(int count)
        {
            var newArray = new T[count];
            for (var i = 0; i < this.Length; i++)
            {
                newArray[i] = this.array[i];
            }

            return newArray;
        }

        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= this.Capacity)
                {
                    throw new IndexOutOfRangeException();
                }

                return this.array[index];
            }

            set
            {
                if (index < 0 || index >= this.Capacity)
                {
                    throw new IndexOutOfRangeException();
                }

                this.array[index] = value;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (var i = 0; i < this.Capacity; i++)
            {
                yield return this.array[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
