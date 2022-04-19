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

    }
}
