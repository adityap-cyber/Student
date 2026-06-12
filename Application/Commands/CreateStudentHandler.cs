
using Core.Entities;
using Core.Events;
using Marten;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Commands
{
    public class CreateStudentHandler : IRequestHandler<CreateStudentCommand, Guid>
    {
        private readonly IDocumentSession _session;

        public CreateStudentHandler(
            IDocumentSession session)
        {
            _session = session;
        }

        public async Task<Guid> Handle(
            CreateStudentCommand request,
            CancellationToken cancellationToken)
        {
            var id = Guid.NewGuid();

            _session.Events.StartStream(
                id,
                new StudentCreated(
                    id,
                    request.Name,
                    request.Class,
                    request.FatherName,
                    request.MotherName));

            await _session.SaveChangesAsync();

            return id;
        }
    }
}
