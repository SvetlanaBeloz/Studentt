using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Studentt
{
    public class Enumerator
    {
        public List<Student> list;

        public Enumerator(List<Student> list)
        {
            this.list = list;
        }

        public object Current
        {
            get;
            private set;
        }

        int index = 0;

        public bool MoveNext()
        {
            if (index >= list.Count) return false;
            Current = list[index++];
            return true;
        }

        public void Reset()
        {
            index = 0;
        }
    }
}
