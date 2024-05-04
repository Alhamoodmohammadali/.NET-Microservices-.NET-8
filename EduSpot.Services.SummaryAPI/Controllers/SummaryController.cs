using AutoMapper;
using EduSpot.Services.SummaryAPI.Data;
using EduSpot.Services.SummaryAPI.Models;
using EduSpot.Services.SummaryAPI.Models.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EduSpot.Services.SummaryAPI.Controllers
{
    [Route("api/Summary")]
    [ApiController]
    public class SummaryController : ControllerBase
    {
        private readonly AppDbContext _db;
        protected ResponseDto _response;
        private IMapper _mapper;
        public SummaryController(AppDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
            _response = new ResponseDto();
        }
        [HttpGet]
        public async Task<ResponseDto> Get()
        {
            return await Task.Run(() =>
            {
                try
                {
                    IEnumerable<Summary> ObjList = _db.Summaries.ToList();
                    _response.Result = _mapper.Map<IEnumerable<SummaryDto>>(ObjList);
                }
                catch (Exception ex)
                {
                    _response.IsSuccess = false;
                    _response.Message = ex.Message;
                }
                return _response;
            });
        }
        [HttpGet]
        [Route("{id:int}")]
        public async Task<ResponseDto> Get(int id)
        {
            return await Task.Run(async () =>
            {
                try
                {
                    Summary Obj = await _db.Summaries.FirstAsync(u => u.SummarieId == id);
                    _response.Result = _mapper.Map<SummaryDto>(Obj);
                }
                catch (Exception ex)
                {
                    _response.IsSuccess = false;
                    _response.Message = ex.Message;
                }
                return _response;
            });
        }
        [HttpPost]
        [Authorize(Roles = "ADMIN")]
        public async Task<ResponseDto> Post(SummaryDto ObjDto)
        {
            return await Task.Run(async () =>
            {
                try
                {
                    Summary Obj = _mapper.Map<Summary>(ObjDto);
                    await _db.Summaries.AddAsync(Obj);
                    await _db.SaveChangesAsync();
                    if (ObjDto.Pdf != null)
                    {
                        string fileName = Obj.SummarieId + Path.GetExtension(ObjDto.Pdf.FileName);
                        string filePath = @"wwwroot\PdfFile\" + fileName;
                        var directoryLocation = Path.Combine(Directory.GetCurrentDirectory(), filePath);
                        FileInfo file = new FileInfo(directoryLocation);
                        if (file.Exists)
                        {
                            file.Delete();
                        }

                        var filePathDirectory = Path.Combine(Directory.GetCurrentDirectory(), filePath);
                        using (var fileStream = new FileStream(filePathDirectory, FileMode.Create))
                        {
                            ObjDto.Pdf.CopyTo(fileStream);
                        }
                        var baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.Value}{HttpContext.Request.PathBase.Value}";
                        Obj.PdfUrl = baseUrl + "/PdfFile/" + fileName;
                        Obj.PdfLocalPath = filePath;
                    }
                    else
                    {
                        Obj.PdfUrl = "https://placehold.co/600x400";
                    }
                    _db.Summaries.Update(Obj);
                    await _db.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    _response.IsSuccess = false;
                    _response.Message = ex.Message;
                }
                return _response;
            });
        }
        [HttpPut]
        [Authorize(Roles = "ADMIN")]
        public async Task<ResponseDto> Put(SummaryDto ObjDto)
        {
            return await Task.Run(async () =>
            {
                try
                {
                    Summary Obj = _mapper.Map<Summary>(ObjDto);
                    if (ObjDto.Pdf != null)
                    {
                        if (!string.IsNullOrEmpty(Obj.PdfLocalPath))
                        {
                            var oldFilePathDirectory = Path.Combine(Directory.GetCurrentDirectory(), Obj.PdfLocalPath);
                            FileInfo file = new FileInfo(oldFilePathDirectory);
                            if (file.Exists)
                            {
                                file.Delete();
                            }
                        }
                        string fileName = Obj.SummarieId + Path.GetExtension(ObjDto.Pdf.FileName);
                        string filePath = @"wwwroot\PdfFile\" + fileName;
                        var filePathDirectory = Path.Combine(Directory.GetCurrentDirectory(), filePath);
                        using (var fileStream = new FileStream(filePathDirectory, FileMode.Create))
                        {
                            ObjDto.Pdf.CopyTo(fileStream);
                        }
                        var baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.Value}{HttpContext.Request.PathBase.Value}";
                        Obj.PdfUrl = baseUrl + "/PdfFile/" + fileName;
                        Obj.PdfLocalPath = filePath;
                    }

                    _db.Summaries.Update(Obj);
                    await _db.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    _response.IsSuccess = false;
                    _response.Message = ex.Message;
                }
                return _response;
            });
        }
        [HttpDelete]
        [Route("{id:int}")]
        [Authorize(Roles = "ADMIN")]
        public async Task<ResponseDto> Delete(int id)
        {
            return await Task.Run(async () =>
            {
                try
                {
                    Summary Obj = await _db.Summaries.FirstAsync(u => u.SummarieId == id);
                    if (!string.IsNullOrEmpty(Obj.PdfLocalPath))
                    {
                        var oldFilePathDirectory = Path.Combine(Directory.GetCurrentDirectory(), Obj.PdfLocalPath);
                        FileInfo file = new FileInfo(oldFilePathDirectory);
                        if (file.Exists)
                        {
                            file.Delete();
                        }
                    }
                    _db.Summaries.Remove(Obj);
                    await _db.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    _response.IsSuccess = false;
                    _response.Message = ex.Message;
                }
                return _response;

            });
        }
    }
}
