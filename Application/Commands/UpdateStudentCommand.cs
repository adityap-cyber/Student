
using Core.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Commands
{
    public record UpdateStudentCommand(Guid Id,
        string Name,
        string Class,
        string FatherName,
        string MotherName) : IRequest<Guid>;
    
}
