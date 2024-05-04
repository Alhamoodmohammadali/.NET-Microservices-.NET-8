using AutoMapper;
using EduSpot.Services.UniversityAPI.Data;
using EduSpot.Services.UniversityAPI.Models;
using EduSpot.Services.UniversityAPI.Models.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace EduSpot.Services.UniversityAPI.Controllers
{
    [Route("api/University")]
    [ApiController]
    [Authorize]
    public class UniversityAPIController : ControllerBase
    {
        private readonly AppDbContext _db;
        private ResponseDto _response;
        private IMapper _mapper;
        public UniversityAPIController(AppDbContext db, IMapper mapper)
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
                    IEnumerable<University> ObjList = _db.Universities.ToList();
                    _response.Result = _mapper.Map<IEnumerable<UniversityDto>>(ObjList);
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
                    University Obj = await _db.Universities.FirstAsync(u => u.UniversityId == id);
                    _response.Result = _mapper.Map<UniversityDto>(Obj);
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
        public async Task<ResponseDto> Post( UniversityDto ObjDto)
        {
            return await Task.Run(async () =>
            {
                try
                {
                    University Obj = _mapper.Map<University>(ObjDto);
                    await _db.Universities.AddAsync(Obj);
                    await _db.SaveChangesAsync();
                    if (ObjDto.Image != null)
                    {
                        string fileName = Obj.UniversityId + Path.GetExtension(ObjDto.Image.FileName);
                        string filePath = @"wwwroot\UniversityImages\" + fileName;
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
                        Obj.ImageUrl = baseUrl + "/UniversityImages/" + fileName;
                        Obj.ImageLocalPath = filePath;
                    }
                    else
                    {
                        Obj.ImageUrl = "https://placehold.co/600x400";
                    }


                    _db.Universities.Update(Obj);
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
        public async Task<ResponseDto> Put( UniversityDto ObjDto)
        {
            return await Task.Run(async () =>
            {
                try
                {
                    University Obj = _mapper.Map<University>(ObjDto);
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
                        string fileName = Obj.UniversityId + Path.GetExtension(ObjDto.Image.FileName);
                        string filePath = @"wwwroot\UniversityImages\" + fileName;
                        var filePathDirectory = Path.Combine(Directory.GetCurrentDirectory(), filePath);
                        using (var fileStream = new FileStream(filePathDirectory, FileMode.Create))
                        {
                            ObjDto.Image.CopyTo(fileStream);
                        }
                        var baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.Value}{HttpContext.Request.PathBase.Value}";
                        Obj.ImageUrl = baseUrl + "/UniversityImages/" + fileName;
                        Obj.ImageLocalPath = filePath;
                    }

                    _db.Universities.Update(Obj);
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
                    University Obj = await _db.Universities.FirstAsync(u => u.UniversityId == id);
                    if (!string.IsNullOrEmpty(Obj.ImageLocalPath))
                    {
                        var oldFilePathDirectory = Path.Combine(Directory.GetCurrentDirectory(), Obj.ImageLocalPath);
                        FileInfo file = new FileInfo(oldFilePathDirectory);
                        if (file.Exists)
                        {
                            file.Delete();
                        }
                    }
                    _db.Universities.Remove(Obj);
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
