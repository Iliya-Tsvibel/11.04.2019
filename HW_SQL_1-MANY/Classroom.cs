using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_SQL_1_MANY
{
    class Classroom
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Code { get; set; }
        public int Number_Of_Students { get; set; }
        public int Number_Of_Vip { get; set; }
        public int Age_Average { get; set; }
        public string Most_Popular_City { get; set; }
        public int Oldest_Vip { get; set; }
        public int Youngest_Vip { get; set; }

        public static bool operator == (Classroom class1, Classroom class2)
        {
            if (ReferenceEquals(class1, null) && ReferenceEquals(class2, null))
                return true;
            if (ReferenceEquals(class1, null) || ReferenceEquals(class2, null))
                return false;

            return (class1.Id == class2.Id);
        }
        public static bool operator !=(Classroom class1, Classroom class2)
        {
            return !(class1 == class2);
        }

        public override bool Equals(object ob)
        {
            if (ReferenceEquals(ob, null))
                return false;
            Classroom c = ob as Classroom;
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
            return $"Country Id is {Id}, Name is {Name}, Code is {Code}, Number Of Students is {Number_Of_Students}, Number  OfVip {Number_Of_Vip}, Age Average {Age_Average}, Most Popular City {Most_Popular_City}, Oldest Vip {Oldest_Vip}, Youngest Vip {Youngest_Vip}";
        }
    }
}
