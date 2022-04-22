using ProjectCRUD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectCRUD.Repository
{
   public  interface IStudentInterface
    {

        Task<IList<Student>> getAllStudents();

        Task<Student> getStudentsById(Guid studentId);

        Task<IList<Gender>> getGender();

        Task<bool> UserExists(Guid studentId);

        Task<Student> UpdateUser(Guid studentId, Student request);

        Task<Student> deleteUser(Guid studentId);

        Task<Student> addStudent(Student student);

    }
}
