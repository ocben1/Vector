using System;
using System.Collections.Generic;
using System.Text;

namespace Vector
{
    public class Vector<T>
    {
        // This constant determines the default number of elements in a newly created vector.
        // It is also used to extend the capacity of the existing vector
        private const int DEFAULT_CAPACITY = 10;

        // This array represents the internal data structure wrapped by the vector class.
        // In fact, all the elements are to be stored in this private  array. 
        // You will just write extra functionality (methods) to make the work with the array more convenient for the user.
        private T[] data;

        // This property represents the number of elements in the vector
        public int Count { get; private set; } = 0;

        // This property represents the maximum number of elements (capacity) in the vector
        public int Capacity { get; private set; } = 0;

        // This is an overloaded constructor
        public Vector(int capacity)
        {
            data = new T[capacity];
        }

        // This is the implementation of the default constructor
        public Vector() : this(DEFAULT_CAPACITY) { }

        // An Indexer is a special type of property that allows a class or structure to be accessed the same way as 
        // array for its internal collection. 
        // For example, introducing the following indexer you may address an element of the vector as vector[i] or vector[0] or ...
        public T this[int index]
        {
            get
            {
                if (index >= Count || index < 0) throw new IndexOutOfRangeException();
                return data[index];
            }
            set
            {
                if (index >= Count || index < 0) throw new IndexOutOfRangeException();
                data[index] = value;
            }
        }

        // This private method allows extension of the existing capacity of the vector by another 'extraCapacity' elements.
        // The new capacity is equal to the existing one plus 'extraCapacity'.
        // It copies the elements of 'data' (the existing array) to 'newData' (the new array), 
        //and then makes data pointing to 'newData'.
        private void ExtendData(int extraCapacity)
        {
            T[] newData = new T[data.Length + extraCapacity];
            for (int i = 0; i < Count; i++) newData[i] = data[i];
            data = newData;
        }

        // This method adds a new element to the existing array.
        // If the internal array is out of capacity, its capacity is first extended to fit the new element.
        public void Add(T element)
        {
            if (Count == data.Length) ExtendData(DEFAULT_CAPACITY);
            //add element to the end of the vector, extending the count.
            data[Count++] = element;
        }

        // This method searches for the specified object and 
        //returns the zero‐based index of the first occurrence within the entire data structure.
        // This method performs a linear search; therefore, this method is an O(n) runtime complexity operation.
        // If occurrence is not found, then the method returns –1.
        // Note that Equals is the proper method to compare two objects for equality, you must not use operator '=' for this purpose.
        public int IndexOf(T element)
        {
            for (var i = 0; i < Count; i++)
            {
                //search for element
                if (data[i].Equals(element))
                    //return zero-based index of the first occurence within the entire data structure.
                    return i;
            }
            return -1;
        }

        // TODO: Your task is to implement all the remaining methods.
        // Read the instruction carefully, study the code examples from above as they should help you to write the rest of the code.
        public void Insert(int index, T element)
        {
            if (index >= Count || index < 0) throw new IndexOutOfRangeException();
            if (Count == data.Length) ExtendData(DEFAULT_CAPACITY); //Correct
            if (Count == index) Add(element); //Correct

            T[] newData = new T[Count++]; //resize the array

            //copy all elements to the left of the insertion point to new collection at same index as original
            for (int i = 0; i < index; i++)
            {
                newData[i] = data[i];
            }
            //insert element into new array at specified index
            newData[index] = element;
            //copy all all elements to the right of the insertion point to new collection
            for (int i = index++; i < Count; i++)
            {
                newData[i] = data[i - 1];
            }
            data = newData;
        }

        public void Clear()
        {
         //      for (int i = 0; i < data.Length; i++)
         //      {
         //          data[i] = default(T);
         //      }
         //          Count = 0;
         //          Capacity = DEFAULT_CAPACITY;

            for (int i = Count - 1; i >= 0; i--)
            {
                    data[Count--] = default(T);
            }
         //   for (int i = 0; i < data.Length; i++)
         //   {
         //       data[i] = default(T);
         //   }
         //   Count = 0;
            throw new NotImplementedException();
        }

        public bool Contains(T element)
        {
            for (var i = 0; i < Count; i++)
            {
                if (data[i].Equals(element)) return true;
            }
            return false;
            throw new NotImplementedException();
        }

        public bool Remove(T element)
        {
            for (int i = Count - 1; i >= 0; i--)
            {
                if (data[i].Equals(element))
                data[--Count] = default(T);
            }
            var index = IndexOf(element);
            //data[index] = data[Count];
           // data[Count] = data[Count--];
            //data[Count--] = data[index];
            //for (int i = Count; i >= 0; i--) data[Count--] = element;
            if (index < 0)
            {
                return true;
            }
            else
            {
                return false;
            }
                 throw new NotImplementedException();
        }

        public void RemoveAt(int index)
        {
            if (index >= Count || index < 0) throw new IndexOutOfRangeException();

            T[] newData = new T[data.Length -1]; //resize the array
                //copy all elements to the left of the deletion point to new collection at indices corresponding to original
                for (int i = 0; i < index; i++)
                {
                    newData[i] = data[i];
                }
         
                //copy all elements to the right of the deletion point to new collection, omitting the index to be deleted
                for (int i = index; i < data.Length; i++)
                {
                    newData[i] = data[i + 1];
                }
                data = newData;
        }
       
        public override string ToString()
        {
            for (int i = 0; i < data.Length; i++)
            {
                string stringData = Convert.ToString(data[i]);
                return stringData;
            }
            throw new NotImplementedException();
        }
    }
}
