using Core.Events;
using Infrastructure.Projections;
using Marten.Events.Aggregation;

public partial class StudentProjection
    : SingleStreamProjection<StudentDetails,Guid>
{
    public static StudentDetails Create(
        StudentCreated e)
    {
        return new StudentDetails
        {
            Id = e.StudentId,
            Name = e.Name,
            Class = e.Class,
            FatherName = e.FatherName,
            MotherName = e.MotherName
        };
    }

    public void Apply(
        StudentUpdated e,
        StudentDetails student)
    {
        student.Name = e.Name;
        student.Class = e.Class;
        student.FatherName = e.Father_Name;
        student.MotherName = e.Mother_Name;
    }

    public void Apply(
        StudentDeleted e,
        StudentDetails student)
    {
        student.IsDeleted = true;
    }
}
