using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduSpot.Web.DataAccess.Services.IServices
{
    public interface ITokenProvider
    {

        void SetToken(string token);
        string? GetToken();
        void ClearToken();
    }
}
