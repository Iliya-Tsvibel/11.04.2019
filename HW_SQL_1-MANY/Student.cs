using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_SQL_1_MANY
{
    class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Address_City { get; set; }
        public string Vip { get; set; }
        public int Class_Id { get; set; }

        public static bool operator ==(Student c1, Student c2)
        {
            if (ReferenceEquals(c1, null) && ReferenceEquals(c2, null))
                return true;
            if (ReferenceEquals(c1, null) || ReferenceEquals(c2, null))
                return false;

            return (c1.Id == c2.Id);
        }
        public static bool operator !=(Student c1, Student c2)
        {
            return !(c1 == c2);
        }

        public override bool Equals(object ob)
        {
            if (ReferenceEquals(ob, null))
                return false;
            Student c = ob as Student;
            if (ReferenceEquals(c, null))
                return false;

            return this.Id == c.Id;
        }

        public override int GetHashCode()
        {
            return Convert.ToInt32(this.Id);
        }

        public override string ToString()
        {
            return $"Country Id is {Id}, Name is {Name}, Age is {Age}, Address City is {Address_City}, If Vip? {Vip}, Class Id is {Class_Id}";
        }
    }
}
