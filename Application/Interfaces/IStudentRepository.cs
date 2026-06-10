using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Interfaces
{
    public interface IStudentRepository
    {
        Task<IEnumerable<Student>> getStudentsAsync();

        Task<IEnumerable<Student>> getStudentByIdAsync(Guid id);

        Task<Student> addStudentAsync(Student student);

        Task<Student> updateStudentAsync(Guid Id, Student student);

        Task<String> deleteStudentAsync(Guid Id);
    }
}
