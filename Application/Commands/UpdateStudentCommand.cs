using Application.Interfaces;
using Core.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Commands
{
    public record UpdateStudentCommand(Guid Id, Student student) : IRequest<Student>;
    internal class UpdateStudentCommandHandler(IStudentRepository studentRepository) : IRequestHandler<UpdateStudentCommand, Student>
    {
        public Task<Student> Handle(UpdateStudentCommand request, CancellationToken cancellationToken)
        {
            return studentRepository.updateStudentAsync(request.Id, request.student);
        }
    
    }
}
