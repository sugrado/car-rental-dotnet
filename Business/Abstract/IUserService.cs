using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IUserService
    {
        IDataResult<List<User>> GetAllUsers();
        IDataResult<User> GetById(int userId);
        IResult AddUser(User user);
        IResult UpdateUser(User user);
        IResult DeleteUser(User user);
    }
}
