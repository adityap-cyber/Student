
using Core.Events;
using Marten;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Commands
{
    public class DeleteStudentCommandHandler: IRequestHandler<DeleteStudentCommand, string>
    {
        private readonly IDocumentSession _session;
        public DeleteStudentCommandHandler(IDocumentSession session)
        {
            _session = session;
        }

        public async Task<string> Handle(DeleteStudentCommand request, CancellationToken cancellationToken)
        {
            var state = await _session.Events
      .FetchStreamStateAsync(request.Id);
            if (state is null)
            {
                throw new Exception("Student not found");
            }
            _session.Events.Append(
       request.Id,
       new StudentDeleted(request.Id));
            await _session.SaveChangesAsync();

            return "Student deleted successfully";
        }
    }

    }

