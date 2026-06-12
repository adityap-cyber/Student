using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Events
{
    public record StudentUpdated(Guid Id, string Name, string Class, string Father_Name, string Mother_Name);
}
