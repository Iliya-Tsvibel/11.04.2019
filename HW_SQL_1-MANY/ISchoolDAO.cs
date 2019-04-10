using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_SQL_1_MANY
{
    interface ISchoolDAO
    {
        Dictionary<Classroom, List<Student>> GetMapClassToStudentsDictionary(int n);
        List<Student> GetStudentsFromClass(int id);
    }
}
