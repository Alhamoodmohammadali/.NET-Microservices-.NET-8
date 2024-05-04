using AutoMapper;
using EduSpot.Services.CourcesAPI.Models;
using EduSpot.Services.CourcesAPI.Models.Dto;
using EduSpot.Services.CourcesAPI.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace EduSpot.Services.CourcesAPI.Controllers
{
    [Route("api/Category")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        protected ResponseDto _response;
        private IMapper _mapper;
        public CategoryController(IUnitOfWork unitOfWork, IMapper mapper)
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
                    IEnumerable<Category> ObjList = await _unitOfWork.category.GetAllAsync();
                    _response.Result = _mapper.Map<IEnumerable<CategoryDto>>(ObjList);
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
                    Category Obj = await _unitOfWork.category.GetAsync(u => u.CategoryId == id);
                    _response.Result = _mapper.Map<CategoryDto>(Obj);
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
        public async Task<ResponseDto> Post(CategoryDto ObjDto)
        {
            return await Task.Run(async () =>
            {
                try
                {
                    Category Obj = _mapper.Map<Category>(ObjDto);
                    await _unitOfWork.category.CreateAsync(Obj);
                    await _unitOfWork.category.SaveAsync();
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
        public async Task<ResponseDto> Put(CategoryDto ObjDto)
        {
            return await Task.Run(async () =>
            {
                try
                {
                    Category Obj = _mapper.Map<Category>(ObjDto);
                    await _unitOfWork.category.UpdateAsync(Obj);
                    await _unitOfWork.category.SaveAsync();
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
                    Category Obj = await _unitOfWork.category.GetAsync(u => u.CategoryId == id);
                    await _unitOfWork.category.RemoveAsync(Obj);
                    await _unitOfWork.category.SaveAsync();
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