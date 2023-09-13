using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Linq;
using infantiaApi.Interfaces;
using System.Security.Claims;

namespace infantiaApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FilesController : ControllerBase
    {

        private readonly string _documentsFolderPath = @"C:\Users\CIDHUM\Documents\";

        [HttpPost("UploadFiles")]
        public IActionResult UploadFiles()
        {
            try
            {
                if (!Request.HasFormContentType)
                {
                    return Problem();
                }

                if (!Request.Form.Files.Any())
                {
                    return BadRequest("Suba al menos un archivo.");
                }

                foreach (var file in Request.Form.Files)
                {
                    using (var stream = new FileStream(@"C:\Users\CIDHUM\Documents\DocumentosInfantia\" + file.FileName, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                }

                return Ok("Archivo Subido Exitosamente");
            }
            catch (Exception ex)
            {
                // Handle exceptions or log them
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        /*{
            try
            {
                if (!Request.HasFormContentType)
                {
                    return Problem();
                }

                if (!Request.Form.Files.Any())
                {
                    return BadRequest("Suba al menos un archivo.");
                }

                // Get the logged-in user's name
                var userName = User.FindFirst(ClaimTypes.Name)?.Value;

                // Construct the user-specific folder path
                var userFolderPath = Path.Combine(@"C:\Users\CIDHUM\Documents\DocumentosInfantia", userName);

                // Create the user folder if it doesn't exist
                if (!Directory.Exists(userFolderPath))
                {
                    Directory.CreateDirectory(userFolderPath);
                }

                foreach (var file in Request.Form.Files)
                {
                    // Combine the user folder path with the file name
                    var filePath = Path.Combine(userFolderPath, file.FileName);

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                }

                return Ok("Archivo Subido Exitosamente");
            }
            catch (Exception ex)
            {
                // Handle exceptions or log them
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }*/

        [HttpGet("FileList/{folderName}")]
        public IActionResult GetDocumentsInFolder(string folderName)
        {
            try
            {
                // Combine the base folder path with the specified folder name
                var folderPath = Path.Combine(_documentsFolderPath, folderName);

                // Check if the folder exists
                if (!Directory.Exists(folderPath))
                {
                    return NotFound("No se encuentra el folder.");
                }

                // Get a list of file names in the folder
                var fileNames = Directory.GetFiles(folderPath)
                    .Select(Path.GetFileName)
                    .ToList();

                return Ok(fileNames);
            }
            catch (Exception ex)
            {
                // Handle exceptions or log them
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost("DeleteFile")]
        public IActionResult DeleteDocument(string folderName, string fileName)
        {
            try
            {
                // Combine the base folder path with the specified folder name
                var folderPath = Path.Combine(_documentsFolderPath, folderName);

                // Check if the folder exists
                if (!Directory.Exists(folderPath))
                {
                    return NotFound("Folder not found.");
                }

                // Combine the folder path with the file name
                var filePath = Path.Combine(folderPath, fileName);

                // Check if the file exists
                if (!System.IO.File.Exists(filePath))
                {
                    return NotFound("File not found.");
                }

                // Delete the file
                System.IO.File.Delete(filePath);

                return Ok("Archivo Eliminado Exitosamente");
            }
            catch (Exception ex)
            {
                // Handle exceptions or log them
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

    }
}
