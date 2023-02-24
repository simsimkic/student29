/***********************************************************************
 * Module:  IUserController.cs
 * Purpose: Definition of the Interface Controller.IUserController
 ***********************************************************************/

using Model.SystemUsers;
using System;

namespace Controller
{
   public interface IUserController : IController<RegisteredUser>
   {
      Model.SystemUsers.RegisteredUser LoginUser(String username, String password);
   }
}