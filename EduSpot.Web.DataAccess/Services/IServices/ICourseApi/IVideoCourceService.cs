using EduSpot.Web.Models;
using EduSpot.Web.Models.CourseApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduSpot.Web.DataAccess.Services.IServices.ICourseApi
{
    public interface IVideoCourceService
    {
        Task<ResponseDto?> GetAllVideoCourceAsync();
        Task<ResponseDto?> GetVideoCourceByIdAsync(int id);
        Task<ResponseDto?> CreateVideoCourceAsync(VideoCourseCreateDto VideoCourceDto);
        Task<ResponseDto?> UpDateVideoCourceAsync(VideoCourseCreateDto VideoCourceDto);
        Task<ResponseDto?> DeleteVideoCourceAsync(int id);
    }
}
