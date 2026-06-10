using Core.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Application.Interfaces;

namespace Infrastructure.Repository
{

    public class StudentRepository(ApplicationDbContext context) : IStudentRepository

    {
        public async Task<IEnumerable<Student>> getStudentsAsync(){
            return await context.Students.ToListAsync();
        }
        public async Task<IEnumerable<Student>> getStudentByIdAsync(Guid id)
        {
            return await context.Students.Where(x => x.Id == id).ToListAsync();
        }
        public async Task<Student> addStudentAsync(Student student)
        {
            context.Students.Add(student);
            await context.SaveChangesAsync();
            return student;
        }
        public async Task<Student> updateStudentAsync(Guid Id,Student student)
        {
            var data=await context.Students.FirstOrDefaultAsync(x => x.Id == Id);
            if(data is not null) { 
                data.Name = student.Name;
                data.Class = student.Class;
                data.Father_Name = student.Father_Name;
                data.Mother_Name = student.Mother_Name;
                context.Students.Update(student);
                await context.SaveChangesAsync();

            }
            
            return student;
        }
        public async Task<String> deleteStudentAsync(Guid Id)
        {
            var student=context.Students.FirstOrDefault(x => x.Id == Id);
             context.Students.Remove(student);
            await context.SaveChangesAsync();
            return "Deleted Successfully";
        }
    }

}