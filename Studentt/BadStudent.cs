using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Studentt
{
    public class BadStudent : Student
    {
        public BadStudent() : base() 
        {
            for (int i = 0; i < 8; i++)
            {
                AddExams(random.Next(2, 7));
                AddProjects(random.Next(2, 7));
                AddOffset(random.Next(2, 7));
            }
        }
    }
}
