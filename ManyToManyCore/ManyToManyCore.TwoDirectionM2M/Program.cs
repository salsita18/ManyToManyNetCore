using System;

namespace ManyToManyCore.TwoDirectionM2M
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Student student1 = new Student { Id = 1 };
            Student student2 = new Student { Id = 2 };

            Class class1 = new Class { Id = 1 };
            Class class2 = new Class { Id = 2 };

            class1.StudentToClass.Add(student1.AddClass(class1));
            class1.StudentToClass.Add(student2.AddClass(class2));

            class2.StudentToClass.Add(student1.AddClass(class2));


        }
    }
}
