using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iHeartConnectorWindows.Data
{
    internal class DataStorage<T>
    {
        private readonly T[] _data;
        public long Count = 0;

        public long Length { get { return _data.Length; } }

        public bool IsFull { get { return Count >= _data.Length; } }

        public T this[long index]
        {
            get { return _data[index]; }
            set { _data[index] = value; }
        }

        public DataStorage(long slize)
        {
            _data = new T[slize];
        }

        public void Clear()
        {
            Count = 0;
        }


        public void AddRange(T[] data)
        {
            long length = data.Length;
            if (length > Length - Count)
                length = Length - Count;

            Array.Copy(data, 0, _data, Count, length);

            Count += length;
        }
    }
}
