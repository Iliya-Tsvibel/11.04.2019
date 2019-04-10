using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_SQL_1_MANY
{
    class SchoolDAO : ISchoolDAO
    {

        static SQLiteConnection connection;
        public static string dbName = @"C:\Users\itsvibel\Downloads\SQL_Tirgul";

        static SchoolDAO()
        {
            connection = new SQLiteConnection($"Data Source = {dbName}; Version=3;");
            connection.Open();
        }
        public Dictionary<Classroom, List<Student>> GetMapClassToStudentsDictionary(int n)
        {
            Dictionary<Classroom, List<Student>> diclass = new Dictionary<Classroom, List<Student>>();
            List<Student> students = new List<Student>();
            using (SQLiteCommand cmd = new SQLiteCommand($"SELECT *,class.NAME as class_NAME, students.NAME as students_NAME, class.id as class_id, students.id as students_id FROM students JOIN class ON students.class_id = class.id ", connection))
            {
                using (SQLiteDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Student student = new Student
                        {
                            Id = (int)reader["students_ID"],
                            Name = (string)reader["students_NAME"],
                            Age = (int)reader["AGE"],
                            Address_City = (string)reader["ADRESS_CITY"],
                            Vip = (string)reader["VIP"],
                            Class_Id = (int)reader["class_id"]
                        };

                        Classroom classroom = new Classroom
                        {
                            Id = (int)reader["class_ID"],
                            Name = (string)reader["class_NAME"],
                            Code = (int)reader["code"],
                            Number_Of_Students = (int)reader["number_of_students"],
                            Number_Of_Vip = (int)reader["number_of_vip"],
                            Age_Average = (int)reader["age_average"],
                            Most_Popular_City = (string)reader["most_popular_city"],
                            Oldest_Vip = (int)reader["oldest_vip"],
                            Youngest_Vip = (int)reader["youngest_vip"]
                        };

                        diclass.Add(classroom, GetStudentsFromClass(classroom.Id));


                    }
                }
            }
            return diclass;
        }


        public List<Student> GetStudentsFromClass(int id)
        {
            List<Student> students = new List<Student>();
            using (SQLiteCommand cmd = new SQLiteCommand($"SELECT *,class.NAME as class_NAME, students.NAME as students_NAME,class.id as class_id, students.id as students_id FROM students JOIN class ON students.class_id = class.id WHERE class.ID = {id} ", connection))
            {
                using (SQLiteDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Student student = new Student
                        {
                            Id = (int)reader["students_ID"],
                            Name = (string)reader["students_NAME"],
                            Age = (int)reader["AGE"],
                            Address_City = (String)reader["ADRESS_CITY"],
                            Vip = (string)reader["VIP"],
                            Class_Id = (int)reader["class_id"]
                        };

                        Classroom classroom = new Classroom
                        {
                            Id = (int)reader["class_ID"],
                            Name = (string)reader["class_NAME"],
                            Code = (int)reader["code"],
                            Number_Of_Students = (int)reader["number_of_students"],
                            Number_Of_Vip = (int)reader["number_of_vip"],
                            Age_Average = (int)reader["age_average"],
                            Most_Popular_City = (string)reader["most_popular_city"],
                            Oldest_Vip = (int)reader["oldest_vip"],
                            Youngest_Vip = (int)reader["youngest_vip"]
                        };
                        students.Add(student);


                    }
                }
            }

            return students;
           
        }
    }
}
