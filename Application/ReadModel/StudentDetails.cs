using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Projections
{
    public class StudentDetails
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Class { get; set; } = string.Empty;

        public string FatherName { get; set; } = string.Empty;

        public string MotherName { get; set; } = string.Empty;

        public bool IsDeleted { get; set; }
    }
}
