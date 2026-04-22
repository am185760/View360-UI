using Microsoft.AspNetCore.Mvc;

namespace EView360.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FileController : ControllerBase
    {
        [HttpGet("DownloadPdf")]
        public IActionResult DownloadPdf(string filepath)
        {
            //filepath = @"C:\view360LiveData\Temp\CashDataFile_08_23_2023_16_26.pdf";
            return File(System.IO.File.ReadAllBytes(filepath), "application/pdf", System.IO.Path.GetFileName(filepath));
        }
    }
}
