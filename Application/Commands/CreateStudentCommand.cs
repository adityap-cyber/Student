using Core.Entities;
using MediatR;

public record CreateStudentCommand(
    string Name,
    string Class,
    string FatherName,
    string MotherName
) : IRequest<Guid>;