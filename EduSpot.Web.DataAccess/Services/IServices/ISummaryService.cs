using EduSpot.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduSpot.Web.DataAccess.Services.IServices
{
    public interface ISummaryService
    {
        Task<ResponseDto?> GetAllSummaryAsync();
        Task<ResponseDto?> GetSummaryByIdAsync(int id);
        Task<ResponseDto?> CreateSummaryAsync(SummaryDto SummaryDto);
        Task<ResponseDto?> UpDateSummaryAsync(SummaryDto SummaryDto);
        Task<ResponseDto?> DeleteSummaryAsync(int id);
    }
}
