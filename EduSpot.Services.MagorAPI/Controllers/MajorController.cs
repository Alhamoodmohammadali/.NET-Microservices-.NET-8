using AutoMapper;
using EduSpot.Services.MagorAPI.Data;
using EduSpot.Services.MagorAPI.Models;
using EduSpot.Services.MagorAPI.Models.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace EduSpot.Services.MagorAPI.Controllers
{
    [Route("api/Major")]
    [ApiController]
    [Authorize]
    public class MajorController : ControllerBase
    {
        private readonly AppDbContext _db;
        protected ResponseDto _response;
        private IMapper _mapper;
        public MajorController(AppDbContext db, IMapper mapper )
        {
            _mapper = mapper;
            _db = db;
            _response = new ResponseDto();
        }
        [HttpGet]
        public async Task<ResponseDto> Get()
        {
            return await Task.Run(() =>
            {
                try
                {
                    IEnumerable<Major> ObjList = _db.Majors.ToList();
                    _response.Result = _mapper.Map<IEnumerable<MajorDto>>(ObjList);
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
                    Major Obj = await _db.Majors.FirstAsync(u => u.MajorId == id);
                    _response.Result = _mapper.Map<MajorDto>(Obj);
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
        public async Task<ResponseDto> Post( MajorDto ObjDto)
        {
            return await Task.Run(async () =>
            {
                try
                {
                    Major Obj = _mapper.Map<Major>(ObjDto);
                    await _db.Majors.AddAsync(Obj);
                    await _db.SaveChangesAsync();
                    if (ObjDto.Image != null)
                    {
                        string fileName = Obj.MajorId + Path.GetExtension(ObjDto.Image.FileName);
                        string filePath = @"wwwroot\MajorImages\" + fileName;
                        var directoryLocation = Path.Combine(Directory.GetCurrentDirectory(), filePath);
                        FileInfo file = new FileInfo(directoryLocation);
                        if (file.Exists)
                        {
                            file.Delete();
                        }

                        var filePathDirectory = Path.Combine(Directory.GetCurrentDirectory(), filePath);
                        using (var fileStream = new FileStream(filePathDirectory, FileMode.Create))
                        {
                            ObjDto.Image.CopyTo(fileStream);
                        }
                        var baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.Value}{HttpContext.Request.PathBase.Value}";
                        Obj.ImageUrl = baseUrl + "/MajorImages/" + fileName;
                        Obj.ImageLocalPath = filePath;
                    }
                    else
                    {
                        Obj.ImageUrl = "https://placehold.co/600x400";
                    }


                    if (ObjDto.Pdf != null)
                    {
                        string fileName = Obj.MajorId + Path.GetExtension(ObjDto.Pdf.FileName);
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






                    _db.Majors.Update(Obj);
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
        public async Task<ResponseDto> Put(MajorDto ObjDto)
        {
            return await Task.Run(async () =>
            {
                try
                {
                    Major Obj = _mapper.Map<Major>(ObjDto);
                    if (ObjDto.Image != null)
                    {
                        if (!string.IsNullOrEmpty(Obj.ImageLocalPath))
                        {
                            var oldFilePathDirectory = Path.Combine(Directory.GetCurrentDirectory(), Obj.ImageLocalPath);
                            FileInfo file = new FileInfo(oldFilePathDirectory);
                            if (file.Exists)
                            {
                                file.Delete();
                            }
                        }
                        string fileName = Obj.MajorId + Path.GetExtension(ObjDto.Image.FileName);
                        string filePath = @"wwwroot\MajorImages\" + fileName;
                        var filePathDirectory = Path.Combine(Directory.GetCurrentDirectory(), filePath);
                        using (var fileStream = new FileStream(filePathDirectory, FileMode.Create))
                        {
                            ObjDto.Image.CopyTo(fileStream);
                        }
                        var baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.Value}{HttpContext.Request.PathBase.Value}";
                        Obj.ImageUrl = baseUrl + "/MajorImages/" + fileName;
                        Obj.ImageLocalPath = filePath;
                    }
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
                        string fileName = Obj.MajorId + Path.GetExtension(ObjDto.Pdf.FileName);
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
                    _db.Majors.Update(Obj);
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
                    Major Obj = await _db.Majors.FirstAsync(u => u.MajorId == id);
                    if (!string.IsNullOrEmpty(Obj.ImageLocalPath))
                    {
                        var oldFilePathDirectory = Path.Combine(Directory.GetCurrentDirectory(), Obj.ImageLocalPath);
                        FileInfo file = new FileInfo(oldFilePathDirectory);
                        if (file.Exists)
                        {
                            file.Delete();
                        }
                    }
                    if (!string.IsNullOrEmpty(Obj.PdfLocalPath))
                    {
                        var oldFilePathDirectory = Path.Combine(Directory.GetCurrentDirectory(), Obj.PdfLocalPath);
                        FileInfo file = new FileInfo(oldFilePathDirectory);
                        if (file.Exists)
                        {
                            file.Delete();
                        }
                    }
                    _db.Majors.Remove(Obj);
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
