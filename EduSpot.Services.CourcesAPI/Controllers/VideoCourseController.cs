using AutoMapper;
using EduSpot.Services.CourcesAPI.Models;
using EduSpot.Services.CourcesAPI.Models.Dto;
using EduSpot.Services.CourcesAPI.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace EduSpot.Services.CourcesAPI.Controllers
{
    [Route("api/VideoCourse")]
    [ApiController]
    public class VideoCourseController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        protected ResponseDto _response;
        private IMapper _mapper;
        public VideoCourseController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _response = new ResponseDto();
        }
        [HttpGet]
        public async Task<ResponseDto> Get()
        {
            return await Task.Run(async () =>
            {
                try
                {
                    IEnumerable<VideoCourse> ObjList = await _unitOfWork.videoCourse.GetAllAsync(includeProperties: "cource");
                    _response.Result = _mapper.Map<IEnumerable<CourceDto>>(ObjList);
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
                    VideoCourse Obj = await _unitOfWork.videoCourse.GetAsync(u => u.VideoId == id);
                    _response.Result = _mapper.Map<VideoCourseDto>(Obj);
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
        public async Task<ResponseDto> Post(VideoCourseCreateDto ObjDto)
        {
            return await Task.Run(async () =>
            {
                try
                {
                    VideoCourse Obj = _mapper.Map<VideoCourse>(ObjDto);
                    await _unitOfWork.videoCourse.CreateAsync(Obj);
   
                    
                    
                    if (ObjDto.Video != null)
                    {
                        string fileName = Obj.VideoId + Path.GetExtension(ObjDto.Video.FileName);
                        string filePath = @"wwwroot\VideoFile1\" + fileName;
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
                        Obj.VideoURl = baseUrl + "/VideoFile1/" + fileName;
                        Obj.VideoLocalPath = filePath;
                    }
                    else
                    {
                        Obj.VideoURl = "https://placehold.co/600x400";
                    }
                    await _unitOfWork.videoCourse.UpdateAsync(Obj);
                    await _unitOfWork.videoCourse.SaveAsync();
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
        public async Task<ResponseDto> Put(VideoCourseUpdateDto ObjDto)
        {
            return await Task.Run(async () =>
            {
                try
                {
                    VideoCourse Obj = _mapper.Map<VideoCourse>(ObjDto);

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
                        string fileName = Obj.VideoId + Path.GetExtension(ObjDto.Video.FileName);
                        string filePath = @"wwwroot\VideoFile1\" + fileName;
                        var filePathDirectory = Path.Combine(Directory.GetCurrentDirectory(), filePath);
                        using (var fileStream = new FileStream(filePathDirectory, FileMode.Create))
                        {
                            ObjDto.Video.CopyTo(fileStream);
                        }
                        var baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.Value}{HttpContext.Request.PathBase.Value}";
                        Obj.VideoURl = baseUrl + "/VideoFile1/" + fileName;
                        Obj.VideoLocalPath = filePath;
                    }

                    await _unitOfWork.videoCourse.UpdateAsync(Obj);
                    await _unitOfWork.videoCourse.SaveAsync();
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
                    VideoCourse Obj = await _unitOfWork.videoCourse.GetAsync(u => u.VideoId == id);
                    if (!string.IsNullOrEmpty(Obj.VideoLocalPath))
                    {
                        var oldFilePathDirectory = Path.Combine(Directory.GetCurrentDirectory(), Obj.VideoLocalPath);
                        FileInfo file = new FileInfo(oldFilePathDirectory);
                        if (file.Exists)
                        {
                            file.Delete();
                        }
                    }
                    await _unitOfWork.videoCourse.RemoveAsync(Obj);
                    await _unitOfWork.videoCourse.SaveAsync();
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
