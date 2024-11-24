using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace linkedlist_homework
{


    class Student<T>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public T TestScore1 { get; set; }
        public T TestScore2 { get; set; }
        public double AverageScore { get; set; } // لحفظ المحصلة
        public string Grade { get; set; } // لتخزين تقدير المحصلة

        // دالة لحساب المحصلة والتقدير
        public void CalculateAverageAndGrade()
        {
            // تحويل النتائج إلى double لحساب المحصلة
            double score1 = Convert.ToDouble(TestScore1);
            double score2 = Convert.ToDouble(TestScore2);
            AverageScore = (score1 + score2) / 2;

            if (AverageScore < 60)
                Grade = "failing";
            else if (AverageScore < 75)
                Grade = "good";
            else if (AverageScore < 85)
                Grade = "very good";
            else
                Grade = "excellent";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Student<double>> students = new List<Student<double>>();
            char continueInput;

            do
            {
                // إدخال بيانات الطالب
                Student<double> student = new Student<double>();

                Console.Write("Enter  student number: ");
                student.Id = int.Parse(Console.ReadLine());

                Console.Write("Enter student's name: ");
                student.Name = Console.ReadLine();

                Console.Write("Enter the first test mark: ");
                student.TestScore1 = double.Parse(Console.ReadLine());

                Console.Write("Enter the second test mark: ");
                student.TestScore2 = double.Parse(Console.ReadLine());

                // حساب المحصلة والتقدير
                student.CalculateAverageAndGrade();

                // إدخال الطالب إلى القائمة مع المحافظة على الفرز
                InsertStudentInOrder(students, student);

                Console.Write("Do you want to enter another student؟ (y/n): ");
                continueInput = Console.ReadKey().KeyChar;
                Console.WriteLine();
            } while (char.ToLower(continueInput) == 'y');

            // عرض بيانات الطلاب
            Console.WriteLine("\nstudent data:");
            foreach (var stud in students)
            {
                Console.WriteLine($"number: {stud.Id},name: {stud.Name}, collector: {stud.AverageScore}, assessment: {stud.Grade}");
            }
        }

        // دالة لإدخال الطالب مع مراعاة الفرز
        static void InsertStudentInOrder(List<Student<double>> students, Student<double> student)
        {
            // إدراج الطالب في المكان المناسب بناءً على المحصلة
            int index = students.FindIndex(s => s.AverageScore > student.AverageScore);
            if (index == -1)
            {
                students.Add(student); // إذا لم يتم العثور على مكان، نضيف الطالب في النهاية
            }
            else
            {
                students.Insert(index, student); // إدراج الطالب في الموضع الصحيح
            }
        }
    }
}  
