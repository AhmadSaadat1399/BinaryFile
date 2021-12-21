using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Files.Models;

namespace Files.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileAttachController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;
        public FileAttachController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPost]
        public IActionResult UploadFile(IFormFile files)
        {
            if (files != null)
            {
                if (files.Length > 0)
                {
                    var filename = Path.GetFileName(files.FileName);
                    var fileExtention = Path.GetExtension(filename);
                    var newFileName = string.Concat(Convert.ToString(Guid.NewGuid()), fileExtention);
                    var objFiles = new Files()
                    {
                        DocumentId = 0,
                        Name = newFileName,
                        FileType = fileExtention,
                        CreatedOn = DateTime.UtcNow
                    };
                    using (var target = new MemoryStream())
                    {
                        files.CopyTo(target);
                        objFiles.DataFiles = target.ToArray();
                    }
                    _dbContext.files.Add(objFiles);
                    _dbContext.SaveChanges();
                }
            }
            // return Ok("file inserted");
            return Ok();
        }
    }
}