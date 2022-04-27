using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectCRUD.Repository
{
   public interface IImageInterface
    {

        Task<string> uploadImage(IFormFile file, string fileName);

    }
}
