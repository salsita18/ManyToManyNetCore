using System;

namespace ManyToManyCore.BasicExample1
{
    public class Job : IBaseEntity<Guid>
    {
        public Guid Id { get; set; }
        public string Descripcion { get; set; }
    }
}
