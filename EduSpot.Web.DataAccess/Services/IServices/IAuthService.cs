using EduSpot.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduSpot.Web.DataAccess.Services.IServices
{
    public interface IAuthService
    {
        Task<ResponseDto?> LoginAsync(LoginRequestDto loginRequestDto);
        Task<ResponseDto?> RegisterAsync(RegistrationRequestDto registrationRequestDto);
        Task<ResponseDto?> AssignRoleAsync(RegistrationRequestDto registrationRequestDto);
    }
}
