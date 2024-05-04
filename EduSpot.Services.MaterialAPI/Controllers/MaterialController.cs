using AutoMapper;
using EduSpot.Services.MaterialAPI.Data;
using EduSpot.Services.MaterialAPI.Models;
using EduSpot.Services.MaterialAPI.Models.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace EduSpot.Services.MaterialAPI.Controllers
{
    [Route("api/Material")]
    [ApiController]
    public class MaterialController : ControllerBase
    {
        private readonly AppDbContext _db;
        protected ResponseDto _response;
        private IMapper _mapper;
        public MaterialController( AppDbContext db,IMapper mapper)
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
                    IEnumerable<Material> ObjList = _db.Materials.ToList();
                    _response.Result = _mapper.Map<IEnumerable<MaterialDto>>(ObjList);
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
                    Material Obj = await _db.Materials.FirstAsync(u => u.MaterialId == id);
                    _response.Result = _mapper.Map<MaterialDto>(Obj);
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
        public async Task<ResponseDto> Post(MaterialDto ObjDto)
        {
            return await Task.Run(async () =>
            {
                try
                {
                    Material Obj = _mapper.Map<Material>(ObjDto);
                    await _db.Materials.AddAsync(Obj);
                    await _db.SaveChangesAsync();
                    if (ObjDto.Image != null)
                    {
                        string fileName = Obj.MajorId + Path.GetExtension(ObjDto.Image.FileName);
                        string filePath = @"wwwroot\Materialimages\" + fileName;
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
                        Obj.ImageUrl = baseUrl + "/Materialimages/" + fileName;
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


                    _db.Materials.Update(Obj);
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
        public async Task<ResponseDto> Put(MaterialDto ObjDto)
        {
            return await Task.Run(async () =>
            {
                try
                {
                    Material Obj = _mapper.Map<Material>(ObjDto);
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
                        string filePath = @"wwwroot\Materialimages\" + fileName;
                        var filePathDirectory = Path.Combine(Directory.GetCurrentDirectory(), filePath);
                        using (var fileStream = new FileStream(filePathDirectory, FileMode.Create))
                        {
                            ObjDto.Image.CopyTo(fileStream);
                        }
                        var baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.Value}{HttpContext.Request.PathBase.Value}";
                        Obj.ImageUrl = baseUrl + "/Materialimages/" + fileName;
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


                    _db.Materials.Update(Obj);
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
                    Material Obj = await _db.Materials.FirstAsync(u => u.MaterialId == id);
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
                    _db.Materials.Remove(Obj);
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