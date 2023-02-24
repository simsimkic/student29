/***********************************************************************
 * Module:  IUserRepository.cs
 * Purpose: Definition of the Interface Repository.IUserRepository
 ***********************************************************************/

using Model.SystemUsers;
using System;

namespace Repository
{
   public interface IUserRepository : IRepository<RegisteredUser>
   {
      Model.SystemUsers.RegisteredUser GetRegisteredUser(String username);
   }
}