using Application.Interfaces;
using Core.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Queries
{
    public record GetAllStudentsQuery : IRequest<IEnumerable<Student>>;
    internal class GetAllStudentsQueryHandler(IStudentRepository studentRepository) : IRequestHandler<GetAllStudentsQuery, IEnumerable<Student>>
    {
        public Task<IEnumerable<Student>> Handle(GetAllStudentsQuery request, CancellationToken cancellationToken)
        {
            return studentRepository.getStudentsAsync();
        }
    }
}
