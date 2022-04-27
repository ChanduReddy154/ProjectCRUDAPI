using Microsoft.EntityFrameworkCore;
using ProjectCRUD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectCRUD.Repository
{
    public class StudentRepository : IStudentInterface
    {
        private readonly ProjectDBContext _projectDBContext;

        public StudentRepository(ProjectDBContext projectDBContext)
        {
            _projectDBContext = projectDBContext;
        }

        public async Task<Student> addStudent(Student student)
        {
            var result = await _projectDBContext.Student.AddAsync(student);
            await _projectDBContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Student> deleteUser(Guid studentId)
        {
            var existingStudent = await getStudentsById(studentId);
            if(existingStudent != null)
            {
                 _projectDBContext.Student.Remove(existingStudent);
                await _projectDBContext.SaveChangesAsync();
                return existingStudent;
        }
            return null;
        }
          

        public async Task<IList<Student>> getAllStudents()
        {
            var result = await _projectDBContext.Student.Include(nameof(Gender)).Include(nameof(Address)).ToListAsync();
            return result;
        }

        public async Task<IList<Gender>> getGender()
        {
            var result = await _projectDBContext.Gender.ToListAsync();
            return result;
        }

        public async Task<Student> getStudentsById(Guid studentId)
        {
            var result = await _projectDBContext.Student.Include(nameof(Gender)).Include(nameof(Address)).FirstOrDefaultAsync(x => x.Id == studentId);
            return result;
        }

        public async Task<bool> updateProfileImage(Guid studentId, string profieImageUrl)
        {
            var student = await getStudentsById(studentId);

            if(student != null)
            {
                student.ProfileImageURL = profieImageUrl;
                await _projectDBContext.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<Student> UpdateUser(Guid studentId, Student request)
        {
            var existingStudent = await getStudentsById(studentId);
            if(existingStudent != null)
            {
                existingStudent.FirstName = request.FirstName;
                existingStudent.LastName = request.LastName;
                existingStudent.DOB = request.DOB;
                existingStudent.Email = request.Email;
                existingStudent.PhoneNumber = request.PhoneNumber;
                existingStudent.GenderID = request.GenderID;
                existingStudent.Address.PhysicalAddress = request.Address.PhysicalAddress;
                existingStudent.Address.PostalAddress = request.Address.PostalAddress;
               await _projectDBContext.SaveChangesAsync();
                return existingStudent;
            }
            return null;
        }

        public async Task<bool> UserExists(Guid studentId)
        {
            var result = await _projectDBContext.Student.AnyAsync(x => x.Id == studentId);
            return result;
        }
    }
}
