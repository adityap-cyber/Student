
using Core.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using Marten;
using Core.Events;

namespace Application.Commands
{
    public class UpdateStudentHandler : IRequestHandler<UpdateStudentCommand, Guid>
    {
        IDocumentSession _session;

        public UpdateStudentHandler(IDocumentSession session)
        {
            _session = session;
        }

        public async Task<Guid> Handle(UpdateStudentCommand request, CancellationToken cancellationToken)
        {
            var state = await _session.Events
       .FetchStreamStateAsync(request.Id);

            if (state is null)
            {
                throw new Exception("Student not found");
            }
           _session.Events.Append(request.Id, new StudentUpdated(
                request.Id,
                request.Name,
                request.Class,
                request.FatherName,
                request.MotherName
            ));
            await _session.SaveChangesAsync();
            return request.Id;

        }
}
}
