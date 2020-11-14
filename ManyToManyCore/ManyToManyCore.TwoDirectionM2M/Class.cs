using System.Collections.Generic;

namespace ManyToManyCore.TwoDirectionM2M
{
    public class Class : IBaseEntity<int>
    {
        public int Id { get; set; }
        public ICollection<MiddleEntity<Student, Class, int, int>> StudentToClass { get; set; }
        public ICollection<Student> Students => StudentToClass.ToDependent();

        public Class()
        {
            StudentToClass = new List<MiddleEntity<Student, Class, int, int>>();
        }
    }
}
