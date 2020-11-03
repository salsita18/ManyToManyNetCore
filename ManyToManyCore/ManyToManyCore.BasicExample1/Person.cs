using System;
using System.Collections.Generic;

namespace ManyToManyCore.BasicExample1
{
    public class Person : IBaseEntity<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<MiddleEntity<Job, Person, Guid, int>> PersonToJob { get; set; }
        public ICollection<Job> Jobs => PersonToJob.ToDependent();

        public void AddJob(Job job)
        {
            PersonToJob.AddIntermediate(job, this);
        }
    }
}
