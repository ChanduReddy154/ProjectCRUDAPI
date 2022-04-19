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
        public async Task<IList<Student>> getAllStudents()
        {
            var result = await _projectDBContext.Student.Include(nameof(Gender)).Include(nameof(Address)).ToListAsync();
            return result;
        }
    }
}
