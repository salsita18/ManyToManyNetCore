using System.Collections.Generic;

namespace ManyToManyCore.TwoDirectionM2M
{
    public class Student : IBaseEntity<int>
    {
        public int Id { get; set; }
        public ICollection<MiddleEntity<Student, Class, int, int>> StudentToClass { get; set; }
        public ICollection<Class> Classes => StudentToClass.ToEntity1();
        public MiddleEntity<Student, Class, int, int> AddClass(Class newClass)
        {
            return StudentToClass.AddIntermediate(newClass, this);
        }

        public Student()
        {
            StudentToClass = new List<MiddleEntity<Student, Class, int, int>>();
        }
    }
}
