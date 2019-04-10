using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_SQL_1_MANY
{
    class Program
    {
        static void Main(string[] args)
        {


            ISchoolDAO school = new SchoolDAO();
            Dictionary<Classroom, List<Student>> dictclastu1 = school.GetMapClassToStudentsDictionary(1);
            List<Student> students1 = school.GetStudentsFromClass(1);
            List<Student> students2 = school.GetStudentsFromClass(2);

            Console.WriteLine(school);
        }
    }
}
