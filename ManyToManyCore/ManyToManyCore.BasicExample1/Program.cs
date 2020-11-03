using System;
using System.Collections.Generic;

namespace ManyToManyCore.BasicExample1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var person = new Person();
            ICollection<Job> jobs = person.PersonToJob.ToDependent();

            Job job = new Job();
            person.PersonToJob.AddIntermediate(job, person);
        }
    }
}
