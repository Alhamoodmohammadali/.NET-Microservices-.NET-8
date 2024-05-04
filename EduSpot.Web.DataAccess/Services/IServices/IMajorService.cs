using EduSpot.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduSpot.Web.DataAccess.Services.IServices
{
    public interface IMajorService
    {
        Task<ResponseDto?> GetAllMajorAsync();
        Task<ResponseDto?> GetMajorByIdAsync(int id);
        Task<ResponseDto?> CreateMajorAsync(MajorDto majorDto);
        Task<ResponseDto?> UpDateMajorAsync(MajorDto majorDto);
        Task<ResponseDto?> DeleteMajorAsync(int id);
    }
}
