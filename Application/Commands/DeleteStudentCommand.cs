using Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Commands
{
    public record DeleteStudentCommand(Guid StudentId) : IRequest<string>;
    internal class DeleteStudentCommandHANDLER(IStudentRepository studentRepository) : IRequestHandler<DeleteStudentCommand, string>
    {
        public Task<string> Handle(DeleteStudentCommand request, CancellationToken cancellationToken)
        {
            return studentRepository.deleteStudentAsync(request.StudentId);
        }
    
    }
}
