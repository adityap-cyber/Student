
using Core.Entities;

using Infrastructure.Projections;
using Marten;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Queries
{
    public record GetAllStudentsQuery
     : IRequest<IReadOnlyList<StudentDetails>>;
    public class GetAllStudentsQueryHandler :
     IRequestHandler<GetAllStudentsQuery, IReadOnlyList<StudentDetails>>
    {
        private readonly IQuerySession _session;

        public GetAllStudentsQueryHandler(IQuerySession session)
        {
            _session = session;
        }

        public async Task<IReadOnlyList<StudentDetails>> Handle(
            GetAllStudentsQuery request,
            CancellationToken cancellationToken)
        {
            return await _session.Query<StudentDetails>()
                .Where(x => !x.IsDeleted)
                .ToListAsync();
        }
    }
}

