using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Events
{
    public record StudentCreated(
    Guid StudentId,
    string Name,
    string Class,
    string FatherName,
    string MotherName);
}
