using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Linq;
using infantiaApi.Interfaces;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.StaticFiles;

namespace infantiaApi.Controllers   
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class FilesController : ControllerBase
    {

        //private readonly string _documentsFolderPath = @"C:\Users\CIDHUM\Documents\";
        private readonly IWebHostEnvironment _env;
        private readonly string _documentsFolderPath;

        public FilesController(IWebHostEnvironment env)
        {
            _env = env;
            _documentsFolderPath = Path.Combine(_env.ContentRootPath, "DocumentosInfantia");

            // Verifica si existe la carpeta DocumentosInfantia, si no, la crea
            if (!Directory.Exists(_documentsFolderPath))
            {
                Directory.CreateDirectory(_documentsFolderPath);
            }
        }

        [Authorize]
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

                // Obtén la cédula del usuario actualmente autenticado
                var userCedula = User.FindFirstValue(ClaimTypes.Name);

                // Combina la ruta base con la cédula del usuario
                var userFolderPath = Path.Combine(_documentsFolderPath, userCedula);

                foreach (var file in Request.Form.Files)
                {
                    using (var stream = new FileStream(userFolderPath + file.FileName, FileMode.Create))
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

        [Authorize]
        [HttpGet("FolderList")]
        public IActionResult GetDocumentsInFolder()
        {
            try
            {
                // Obtén la cédula y el idRol del usuario actualmente autenticado
                var userCedula = User.FindFirstValue(ClaimTypes.Name);
                var userIdRol = int.Parse(User.FindFirstValue(ClaimTypes.Role));

                // Combina la ruta base con la cédula del usuario
                var userFolderPath = Path.Combine(_documentsFolderPath, userCedula);

                // Verifica si la carpeta del usuario existe, si no, la crea
                if (!Directory.Exists(userFolderPath))
                {
                    Directory.CreateDirectory(userFolderPath);
                }

                // Si el idRol es el de un administrador, muestra todas las carpetas
                if (userIdRol == 1) // Asume que 1 es el idRol para administradores
                {
                    // Obtiene una lista de todas las carpetas
                    var allFolders = Directory.GetDirectories(_documentsFolderPath)
                        .Select(Path.GetFileName)
                        .ToList();

                    return Ok(allFolders);
                }
                else
                {
                    // Obtiene una lista de los nombres de los archivos en la carpeta del usuario
                    var fileNames = Directory.GetFiles(userFolderPath)
                        .Select(Path.GetFileName)
                        .ToList();

                    return Ok(fileNames);
                }
            }
            catch (Exception ex)
            {
                // Maneja las excepciones o regístralas
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [Authorize]
        [HttpGet("FolderContent/{folderName}")]
        public IActionResult GetFolderContent(string folderName)
        {
            try
            {
                // Obtén la cédula del usuario actualmente autenticado
                var userCedula = User.FindFirstValue(ClaimTypes.Name);

                // Combina la ruta base con la cédula del usuario y el nombre de la carpeta
                var folderPath = Path.Combine(_documentsFolderPath, userCedula, folderName);

                // Verifica si la carpeta existe
                if (!Directory.Exists(folderPath))
                {
                    return NotFound("No se encuentra el folder.");
                }

                // Obtiene una lista de los nombres de los archivos en la carpeta
                var fileNames = Directory.GetFiles(folderPath)
                    .Select(Path.GetFileName)
                    .ToList();

                return Ok(fileNames);
            }
            catch (Exception ex)
            {
                // Maneja las excepciones o regístralas
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [Authorize]
        [HttpGet("DownloadFile/{folderName}/{fileName}")]
        public IActionResult DownloadFile(string folderName, string fileName)
        {
            try
            {
                // Obtén la cédula del usuario actualmente autenticado
                var userCedula = User.FindFirstValue(ClaimTypes.Name);

                // Combina la ruta base con la cédula del usuario, el nombre de la carpeta y el nombre del archivo
                var filePath = Path.Combine(_documentsFolderPath, userCedula, folderName, fileName);

                // Verifica si el archivo existe
                if (!System.IO.File.Exists(filePath))
                {
                    return NotFound("No se encuentra el archivo.");
                }

                // Obtiene los datos del archivo como un flujo de bytes
                var fileBytes = System.IO.File.ReadAllBytes(filePath);

                // Obtiene el tipo MIME del archivo para que el navegador sepa cómo manejarlo
                var contentType = GetContentType(filePath);

                // Envía los datos del archivo con el tipo MIME correcto
                return File(fileBytes, contentType, fileName);
            }
            catch (Exception ex)
            {
                // Maneja las excepciones o regístralas
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        private string GetContentType(string path)
        {
            var provider = new FileExtensionContentTypeProvider();
            string contentType;
            if (!provider.TryGetContentType(path, out contentType))
            {
                contentType = "application/octet-stream";
            }
            return contentType;
        }

        [Authorize]
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
