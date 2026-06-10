using Application.Interfaces;
using Core.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Commands
{
    public record CreateStudentCommand(Student student):IRequest<Student>;
    internal class CreateStudentCommandHandler(IStudentRepository studentRepository) : IRequestHandler<CreateStudentCommand, Student>
    {
        public Task<Student> Handle(CreateStudentCommand request, CancellationToken cancellationToken)
        {
            return studentRepository.addStudentAsync(request.student);
        }
    
    }
}
