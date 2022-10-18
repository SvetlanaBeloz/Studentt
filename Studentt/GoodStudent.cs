using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Studentt
{
    public class GoodStudent : Student
    {
        public GoodStudent() : base()
        {
            for (int i = 0; i < 8; i++)
            {
                AddExams(random.Next(10, 13));
                AddProjects(random.Next(10, 13));
                AddOffset(random.Next(10, 13));
            }
        }
    }
}
