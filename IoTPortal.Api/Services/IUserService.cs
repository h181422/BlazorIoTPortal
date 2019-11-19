

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using IoTPortal.Model;
using Logic.Users;

namespace IoTPortal.Api.Services
{
    public interface IUserService
    {
        IoTUser Authenticate(string username, string password);
    }
    public class UserService : IUserService
    {
        private readonly UserLogic _userLogic;

        public UserService()
        {
            _userLogic = new UserLogic();
        }

        public IoTUser Authenticate(string username, string password)
        {
            return _userLogic.ValidateLogin(username, password);
        }
    }
}

