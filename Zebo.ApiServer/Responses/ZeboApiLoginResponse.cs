using System.Net;
using Zebo.ApiServer.Lib;
using Zebo.Domain.Models.Users;

namespace Zebo.ApiServer.Responses
{
    public class ZeboApiLoginResponse
    {
        public ZeboApiLoginResponse()
        {
            IsValid = false;
        }

        public ZeboApiLoginResponse(Token token,
                                     User user,
                                     HttpStatusCode statusCode,
                                     bool isValid = false)
        {
            IsValid = isValid;
            StatusCode = statusCode;
            Token = token;
            UserId = user.Id;
            UserName = user.Name;
            UserRole = user.UserRole;
            UserString = user.UserString;
        }

        public bool IsValid { get; set; }
        public HttpStatusCode StatusCode { get; set; }
        public Token Token { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public UserRole UserRole { get; set; }
        public string UserString { get; set; }
    }
}
