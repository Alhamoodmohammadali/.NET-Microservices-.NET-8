using AutoMapper;
using EduSpot.Services.CourcesAPI.Data;
using EduSpot.Services.CourcesAPI.Models;
using EduSpot.Services.CourcesAPI.Models.Dto;
using EduSpot.Services.CourcesAPI.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace EduSpot.Services.CourcesAPI.Controllers
{
    [Route("api/Cource")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        protected ResponseDto _response;
        private IMapper _mapper;
        public CoursesController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _response = new ResponseDto();
        }
        [HttpGet]
        public async Task<ResponseDto> Get()
        {
       
                try
                {
                    IEnumerable<Cource> ObjList = await _unitOfWork.cource.GetAllAsync(includeProperties: "category");
                    _response.Result = _mapper.Map<IEnumerable<CourceDto>>(ObjList);
                }
                catch (Exception ex)
                {
                    _response.IsSuccess = false;
                    _response.Message = ex.Message;
                }
                return _response;
        }
        [HttpGet]
        [Route("{id:int}")]
        public async Task<ResponseDto> Get(int id)
        {
            return await Task.Run(async () =>
            {
                try
                {
                    Cource Obj = await _unitOfWork.cource.GetAsync(u => u.CourceId == id);
                    _response.Result = _mapper.Map<CourceDto>(Obj);
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
        //[Authorize(Roles = "ADMIN")]
        public async Task<ResponseDto> Post( CourceCreateDto ObjDto)
        {
            return await Task.Run(async () =>
            {
                try
                {
                    //if (await _unitOfWork.cource.GetAsync(u=>u.Name.ToLower()==ObjDto.Name.ToLower())!=null)
                    //{


                    //}
                    //if (ObjDto ==null)
                    //{

                    //}
                    Cource Obj = _mapper.Map<Cource>(ObjDto);
                    await _unitOfWork.cource.CreateAsync(Obj);
                    if (ObjDto.Video != null)
                    {
                        string fileName = Obj.CategoryId + Path.GetExtension(ObjDto.Video.FileName);
                        string filePath = @"wwwroot\VideoFile2\" + fileName;
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
                        Obj.VideoURl = baseUrl + "/VideoFile2/" + fileName;
                        Obj.VideoLocalPath = filePath;
                    }
                    else
                    {
                        Obj.VideoURl = "https://placehold.co/600x400";
                    }
                    await _unitOfWork.cource.UpdateAsync(Obj);
                    await _unitOfWork.cource.SaveAsync();
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
        //[Authorize(Roles = "ADMIN")]
        public async Task<ResponseDto> Put(CourceUpdateDto ObjDto)
        {
            return await Task.Run(async () =>
            {
                try
                {
                    Cource Obj = _mapper.Map<Cource>(ObjDto);
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
                        string fileName = Obj.CourceId + Path.GetExtension(ObjDto.Video.FileName);
                        string filePath = @"wwwroot\VideoFile2\" + fileName;
                        var filePathDirectory = Path.Combine(Directory.GetCurrentDirectory(), filePath);
                        using (var fileStream = new FileStream(filePathDirectory, FileMode.Create))
                        {
                            ObjDto.Video.CopyTo(fileStream);
                        }
                        var baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.Value}{HttpContext.Request.PathBase.Value}";
                        Obj.VideoURl = baseUrl + "/VideoFile2/" + fileName;
                        Obj.VideoLocalPath = filePath;
                    }


                    await _unitOfWork.cource.UpdateAsync(Obj);
                    await _unitOfWork.cource.SaveAsync();
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
        //[Authorize(Roles = "ADMIN")]
        public async Task<ResponseDto> Delete(int id)
        {
            return await Task.Run(async () =>
            {
                try
                {
                    Cource Obj = await _unitOfWork.cource.GetAsync(u => u.CourceId == id);
                    if (!string.IsNullOrEmpty(Obj.VideoLocalPath))
                    {
                        var oldFilePathDirectory = Path.Combine(Directory.GetCurrentDirectory(), Obj.VideoLocalPath);
                        FileInfo file = new FileInfo(oldFilePathDirectory);
                        if (file.Exists)
                        {
                            file.Delete();
                        }
                    }
                    await _unitOfWork.cource.RemoveAsync(Obj);
                    await _unitOfWork.cource.SaveAsync();
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