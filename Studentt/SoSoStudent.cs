using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Studentt
{
    public class SoSoStudent : Student
    {
        public SoSoStudent() : base()
        {
            for (int i = 0; i < 8; i++)
            {
                AddExams(random.Next(7, 10));
                AddProjects(random.Next(7, 10));
                AddOffset(random.Next(7, 10));
            }
        }
    }
}
