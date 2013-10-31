using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ
{
    class Program
    {
        static List<Student> students = new List<Student>
                {
                   new Student {First="Svetlana", Last="Omelchenko", ID=111, Scores= new List<int> {97, 92, 81, 60}},
                   new Student {First="Claire", Last="O'Donnell", ID=112, Scores= new List<int> {75, 84, 91, 39}},
                   new Student {First="Sven", Last="Mortensen", ID=113, Scores= new List<int> {88, 94, 65, 91}},
                   new Student {First="Cesar", Last="Garcia", ID=114, Scores= new List<int> {97, 89, 85, 82}},
                   new Student {First="Debra", Last="Garcia", ID=115, Scores= new List<int> {35, 72, 91, 70}},
                   new Student {First="Fadi", Last="Fakhouri", ID=116, Scores= new List<int> {99, 86, 90, 94}},
                   new Student {First="Hanying", Last="Feng", ID=117, Scores= new List<int> {93, 92, 80, 87}},
                   new Student {First="Hugo", Last="Garcia", ID=118, Scores= new List<int> {92, 90, 83, 78}},
                   new Student {First="Lance", Last="Tucker", ID=119, Scores= new List<int> {68, 79, 88, 92}},
                   new Student {First="Terry", Last="Adams", ID=120, Scores= new List<int> {99, 82, 81, 79}},
                   new Student {First="Eugene", Last="Zabokritski", ID=121, Scores= new List<int> {96, 85, 91, 60}},
                   new Student {First="Michael", Last="Tucker", ID=122, Scores= new List<int> {94, 92, 91, 91} }
                };

        static void OrderByTest()
        {
            IEnumerable<Student> studentQuery = from student in students
                                                where student.Scores[0] > 90 && student.Scores[3] < 80
                                                orderby student.Scores[0] descending
                                                select student;

            foreach (Student student in studentQuery)
            {
                Console.WriteLine("{0} {1} {2}", student.First, student.Last, student.Scores[0]);
            }
        }

        static void GroupByTest()
        {
            var studentGroupQuery = from student in students
                                    group student by student.Last[0];

            foreach (var studentGroup in studentGroupQuery)
            {
                Console.WriteLine(studentGroup.Key);
                foreach (var student in studentGroup)
                {
                    Console.WriteLine("    {0} {1}", student.Last, student.First);
                }
            }
        }

        static void OrderGroups()
        {
            var studentQuery = from studnet in students
                                group studnet by studnet.Last[0] into studnetGroup
                                orderby studnetGroup.Key
                                select studnetGroup;

            foreach (var groupOfStudents in studentQuery)
            {
                Console.WriteLine(groupOfStudents.Key);
                foreach (var student in groupOfStudents)
                {
                    Console.WriteLine("   {0}, {1}",
                        student.Last, student.First);
                }
            }
        }

        static void LetTest()
        {
            var studentQuery = from student in students
                               let totalScope =
                                    student.Scores[0]
                                    + student.Scores[1]
                                    + student.Scores[2]
                                    + student.Scores[3]
                               where totalScope / 4 < student.Scores[0]
                               select student.Last + " " + student.First;
            
            foreach (var s in studentQuery)
            {
                Console.WriteLine(s);
            }
        }

        static void ProjectTest()
        {
            var studentQuery1 = from student in students
                               let totalScope =
                                    student.Scores[0]
                                    + student.Scores[1]
                                    + student.Scores[2]
                                    + student.Scores[3]
                               select totalScope;
            var studentQuery2 = from student in students
                                let x = student.Scores[0] + student.Scores[1] +
                                    student.Scores[2] + student.Scores[3]
                                where x > studentQuery1.Average()
                                select new { id = student.ID, score = x };

            foreach (var item in studentQuery2)
            {
                Console.WriteLine("Student ID: {0}, Score: {1}", item.id, item.score);
            }

        }

        static void Main(string[] args)
        {
            OrderByTest();
            GroupByTest();
            OrderGroups();
            LetTest();
            ProjectTest();

        }
    }
}
