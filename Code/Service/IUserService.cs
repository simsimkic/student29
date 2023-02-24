/***********************************************************************
 * Module:  IUserService.cs
 * Purpose: Definition of the Interface Service.IUserService
 ***********************************************************************/

using Model.SystemUsers;
using System;

namespace Service
{
   public interface IUserService : IService<RegisteredUser>
   {
      Model.SystemUsers.RegisteredUser LoginUser(String username, String password);
      Boolean IsUsernameValid(String username);
      Boolean IsPasswordValid(String password);
   }
}