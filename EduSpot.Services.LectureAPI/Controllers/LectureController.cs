using AutoMapper;
using EduSpot.Services.LectureAPI.Data;
using EduSpot.Services.LectureAPI.Models;
using EduSpot.Services.LectureAPI.Models.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace EduSpot.Services.LectureAPI.Controllers
{
    [Route("api/Lecture")]
    [ApiController]
    public class LectureController : ControllerBase
    {

        private readonly AppDbContext _db;
        protected ResponseDto _response;
        private IMapper _mapper;
        public LectureController(AppDbContext db, IMapper mapper)
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
                    IEnumerable<Lecture> ObjList = _db.Lectures.ToList();
                    _response.Result = _mapper.Map<IEnumerable<LectureDto>>(ObjList);
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
                    Lecture Obj = await _db.Lectures.FirstAsync(u => u.LectureId == id);
                    _response.Result = _mapper.Map<LectureDto>(Obj);
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
        public async Task<ResponseDto> Post(LectureDto ObjDto)
        {
            return await Task.Run(async () =>
            {
                try
                {
                    Lecture Obj = _mapper.Map<Lecture>(ObjDto);
                    await _db.Lectures.AddAsync(Obj);
                    await _db.SaveChangesAsync();
                    if (ObjDto.Video != null)
                    {
                        string fileName = Obj.LectureId + Path.GetExtension(ObjDto.Video.FileName);
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
                            ObjDto.Video.CopyTo(fileStream);
                        }
                        var baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.Value}{HttpContext.Request.PathBase.Value}";
                        Obj.VideoUrl = baseUrl + "/PdfFile/" + fileName;
                        Obj.VideoLocalPath = filePath;
                    }
                    else
                    {
                        Obj.VideoUrl = "https://placehold.co/600x400";
                    }
                    _db.Lectures.Update(Obj);
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
        public async Task<ResponseDto> Put(LectureDto ObjDto)
        {
            return await Task.Run(async () =>
            {
                try
                {
                    Lecture Obj = _mapper.Map<Lecture>(ObjDto);
                    if (ObjDto.Video != null)
                    {
                        if (!string.IsNullOrEmpty(Obj.VideoLocalPath))
                        {
                            var oldFilePathDirectory = Path.Combine(Directory.GetCurrentDirectory(), Obj.VideoLocalPath);
                            FileInfo file = new FileInfo(oldFilePathDirectory);
                            if (file.Exists)
                            {
                                file.Delete();
                            }
                        }
                        string fileName = Obj.LectureId + Path.GetExtension(ObjDto.Video.FileName);
                        string filePath = @"wwwroot\PdfFile\" + fileName;
                        var filePathDirectory = Path.Combine(Directory.GetCurrentDirectory(), filePath);
                        using (var fileStream = new FileStream(filePathDirectory, FileMode.Create))
                        {
                            ObjDto.Video.CopyTo(fileStream);
                        }
                        var baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.Value}{HttpContext.Request.PathBase.Value}";
                        Obj.VideoUrl = baseUrl + "/PdfFile/" + fileName;
                        Obj.VideoLocalPath = filePath;
                    }

                    _db.Lectures.Update(Obj);
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
                    Lecture Obj = await _db.Lectures.FirstAsync(u => u.LectureId == id);
                    if (!string.IsNullOrEmpty(Obj.VideoLocalPath))
                    {
                        var oldFilePathDirectory = Path.Combine(Directory.GetCurrentDirectory(), Obj.VideoLocalPath);
                        FileInfo file = new FileInfo(oldFilePathDirectory);
                        if (file.Exists)
                        {
                            file.Delete();
                        }
                    }
                    _db.Lectures.Remove(Obj);
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
