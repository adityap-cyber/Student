using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities
{
    public class Student
    {
        public Guid Id { get; set; }
        public string Name { get; set; }=null!;
        public string Class { get; set; } = null!;
        public string Father_Name { get; set; } = null!;
        public string Mother_Name { get; set; } = null!;
    }
}
