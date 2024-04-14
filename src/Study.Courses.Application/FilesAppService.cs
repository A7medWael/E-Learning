using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study.Courses
{
    public class SubjectImageAppService:CoursesAppService
    {
         
        private readonly IWebHostEnvironment _hostingEnvironment;
        public SubjectImageAppService(IWebHostEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }
        [HttpPost]
        public string UploadImage(IFormFile input)
        {
            string uniqueFilePath = null;

            if (input != null)
            {
                var rootPath = _hostingEnvironment.WebRootPath;

                var uploadsFolder = Path.Combine(Path.Combine(rootPath, "courses"));
                if (!Directory.Exists(uploadsFolder))
                { Directory.CreateDirectory(uploadsFolder); }

                uniqueFilePath = Guid.NewGuid().ToString() + "__" + input.FileName;
                var filePath = Path.Combine(uploadsFolder, uniqueFilePath);
                using var fileStream = new FileStream(filePath, FileMode.Create);
                input.CopyTo(fileStream);
                return filePath;
            }
            return uniqueFilePath;
        }
    }
}