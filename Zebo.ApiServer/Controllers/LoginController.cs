using System.ComponentModel.Composition;
using System.Net;
using System.Web.Http;
using Zebo.ApiServer.Lib;
using Zebo.ApiServer.Responses;
using Zebo.Persistance;

namespace Zebo.ApiServer.Controllers
{
    [Export]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class LoginController : ApiController
    {
        private readonly IUserDao _userDao;

        [ImportingConstructor]
        public LoginController(IUserDao userDao)
        {
            _userDao = userDao;
        }

        //GET =>  http://localhost:8080/api/getToken/{pin}
        public ZeboApiLoginResponse GetLogin(string pin)
        {
            ZeboApiLoginResponse ret;

            if (!_userDao.GetIsUserExists(pin))
            {
                ret = new ZeboApiLoginResponse(null, null, HttpStatusCode.Unauthorized);
            }
            else
            {
                var user = _userDao.GetUserByPinCode(pin);
                ret = new ZeboApiLoginResponse(new Token(user.Id),
                                                user,
                                                HttpStatusCode.Accepted,
                                                true);
            }

            return ret;
        }
    }
}
