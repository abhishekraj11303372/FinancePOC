using Finance.Infra.Data.Context;
using FinancePOC.Application.Interfaces;
using FinancePOC.Domain.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.EntityFrameworkCore;
using RtfToHtml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace FinancePOC.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FinanceController : ControllerBase
    {
        private readonly IFinanceService _financeService;
        private IHostingEnvironment _hostingEnvironment;
        private IConvert _convert;

        //public FinanceController(IFinanceService financeService)
        //{
        //    _financeService = financeService;
        //}

        //[HttpPost]
        //public IActionResult Post([FromBody] FinanceViewModel financeViewModel)
        //{
        //    _financeService.Create(financeViewModel);

        //    return Ok(financeViewModel);
        //}

        //private readonly FinanceDBContext _context;

        //public FinanceController(FinanceDBContext context)
        //{
        //    _context = context;
        //}

        public FinanceController(IFinanceService financeService, IHostingEnvironment hostingEnvironment, IConvert convert)
        {
            _financeService = financeService;
            _hostingEnvironment = hostingEnvironment;
            _convert = convert;
        }

        //Get : /Finance
        [HttpGet]
        public IActionResult GetFinances()
        {
            var financeDetail = _financeService.GetFinances();
            if (financeDetail == null)
            {
                return NotFound();
            }
            return StatusCode((int)HttpStatusCode.OK, financeDetail);
        }

        [HttpPost]
        [Route("upload")]
        public async Task<IActionResult> Upload(IFormFile file)
        {
            var uploads = Path.Combine(_hostingEnvironment.WebRootPath, "uploads");
            if (!Directory.Exists(uploads))
            {
                Directory.CreateDirectory(uploads);
            }
            if (file.Length > 0)
            {
                var filePath = Path.Combine(uploads, file.FileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(fileStream);
                }
            }
            return Ok();
        }
        
        [HttpPost]
        [Route("uploadRTF")]
        public async Task<IActionResult> UploadRTF(IFormFile file)
        {
            var uploads = Path.Combine("E:/POC/FinancePOC/FinancePOC/RtfToHtml/Files/", "Rtf");
            if (!Directory.Exists(uploads))
            {
                Directory.CreateDirectory(uploads);
            }
            if (file.Length > 0)
            {
                var filePath = Path.Combine(uploads, file.FileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(fileStream);
                }
            }
            return Ok();
        }

        [HttpPut]
        [Route("convertrtf")]
        public IActionResult ConvertRtf()
        {
            var convertToRtf = _convert.ConvertToHtml();
            return StatusCode((int)HttpStatusCode.OK, convertToRtf);
        }

        [HttpGet]
        [Route("download")]
        public async Task<IActionResult> Download([FromQuery] string file)
        {
            var uploads = Path.Combine(_hostingEnvironment.WebRootPath, "uploads");
            var filePath = Path.Combine(uploads, file);
            if (!System.IO.File.Exists(filePath))
                return NotFound();

            var memory = new MemoryStream();
            using (var stream = new FileStream(filePath, FileMode.Open))
            {
                await stream.CopyToAsync(memory);
            }
            memory.Position = 0;

            return File(memory, GetContentType(filePath), file);
        }

        [HttpGet]
        [Route("files")]
        public IActionResult Files()
        {
            var result = new List<string>();

            var uploads = Path.Combine(_hostingEnvironment.WebRootPath, "uploads");
            if (Directory.Exists(uploads))
            {
                var provider = _hostingEnvironment.ContentRootFileProvider;
                foreach (string fileName in Directory.GetFiles(uploads))
                {
                    var fileInfo = provider.GetFileInfo(fileName);
                    result.Add(fileInfo.Name);
                }
            }
            return Ok(result);
        }

        [HttpGet]
        [Route("getrtf")]
        public IActionResult getrtf()   
        {
            var result = new List<string>();

            var uploads = Path.Combine("E:/POC/FinancePOC/FinancePOC/RtfToHtml/Files/", "Rtf");
            if (Directory.Exists(uploads))
            {
                var provider = _hostingEnvironment.ContentRootFileProvider;
                foreach (string fileName in Directory.GetFiles(uploads))
                {
                    var fileInfo = provider.GetFileInfo(fileName);
                    result.Add(fileInfo.Name);
                }
            }
            return Ok(result);
        }
        
        [HttpGet]
        [Route("gethtml")]
        public IActionResult gethtml()   
        {
            var result = new List<string>();

            var uploads = Path.Combine("E:/POC/FinancePOC/FinancePOC/RtfToHtml/Files/", "html");
            if (Directory.Exists(uploads))
            {
                var provider = _hostingEnvironment.ContentRootFileProvider;
                foreach (string fileName in Directory.GetFiles(uploads))
                {
                    var fileInfo = provider.GetFileInfo(fileName);
                    result.Add(fileInfo.Name);
                }
            }
            return Ok(result);
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

        ////Get : /Finance
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<Finances>>> GetFinances()
        //{
        //    var financeDetail = await _context.Finances.ToListAsync();
        //    if (financeDetail == null)
        //    {
        //        return NotFound();
        //    }
        //    return financeDetail;
        //}
    }
}
