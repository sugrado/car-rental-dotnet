using Core.Entities.Concrete;
using Core.Utilities.Results;
using Core.Utilities.Security.JWT;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IAuthService
    {
        IResult Register(UserForRegisterDto userForRegisterDto, string password);
        IDataResult<User> Login(UserForLoginDto userForLoginDto);
        IResult ChangePassword(ChangePasswordDto changePasswordDto);
        IResult UserExist(string email);
        IDataResult<AccessToken> CreateAccessToken(User user);  
    }
}
