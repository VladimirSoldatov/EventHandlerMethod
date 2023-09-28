using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventHandlerMethod
{
    internal class Program
    {
        public class Student
        {
            public int Mind { set; get; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public DateTime BirthDate { get; set;}
            public void Exam(object sender, ExamEventArgs e)
            {

                Console.WriteLine($"{(sender as Teacher).Name} дал задание");
                if (Mind >= e.scanMind)
                    Console.WriteLine($"Student {FirstName} solved {e.Task}, his mark is {Mind}");
                else
                    Console.WriteLine($"Student {FirstName} didn't solve {e.Task} , his mark is {Mind}");

            }
        }
        public class  ExamEventArgs:EventArgs
        {
            public string Task { get; set; }
            public int scanMind { get; set; }
            
        }
        class Teacher
        {
            public string Name { get; set; }
            public Teacher(string name)
            {
                Name = name;
            }
            public EventHandler<ExamEventArgs> ExamEvent;
            public void Exam(ExamEventArgs task)
            {
                if(ExamEvent!=null)
                {
                    ExamEvent(this,task);
                }

            }
        }
      static public  int func(int b)
        {
            return 0;
        }
        delegate int a(int b);
        static void Main(string[] args)
        {
            a a = func;
            a += func;
            a.GetInvocationList();
            List<Student> group = new List<Student> {
                new Student {
                FirstName = "John",
                LastName = "Miller",
                BirthDate = new DateTime(1997,3,12),
                Mind = 1,
                },
                new Student {
                FirstName = "Candice",
                LastName = "Leman",
                BirthDate = new DateTime(1998,7,22),
                Mind=5,
                },
                new Student {
                FirstName = "Joey",
                LastName = "Finch",
                BirthDate = new DateTime(1996,11,30),
                Mind=3
                },
                new Student {
                FirstName = "Nicole",
                LastName = "Taylor",
                BirthDate = new DateTime(1996,5,10),
                Mind=2
                }
                };
            Teacher teacher = new Teacher("Vladimir");
            foreach (Student item in group)
            {
                teacher.ExamEvent += item.Exam;
            }
            ExamEventArgs eventArgs =
            new ExamEventArgs { Task = "Task", scanMind=3 };
            teacher.Exam(eventArgs);
        }
    }
}
