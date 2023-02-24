/***********************************************************************
 * Module:  UserService.cs
 * Purpose: Definition of the Class Service.UserService
 ***********************************************************************/

using Model.SystemUsers;
using Service;
using System;
using System.Collections.Generic;

namespace Controller
{
   public class UserController : IUserController
   {
        public Service.IUserService _service;

        private static UserController Instance;

        public UserController GetInstance() { return null; }

        public UserController(IUserService service)
        {
            _service = service;
        }

        public RegisteredUser LoginUser(string username, string password)
        {
            throw new NotImplementedException();
        }

        public List<RegisteredUser> GetAll()
        {
            List<RegisteredUser> users = (List<RegisteredUser>)_service.GetAll();
            return users;
        }

        public bool Delete(RegisteredUser obj)
        {
            _service.Delete(obj);
            return true;
        }

        public RegisteredUser Create(RegisteredUser obj)
        {
            _service.Create(obj);
            return obj;
        }

        public RegisteredUser Edit(RegisteredUser obj)
        {
            _service.Edit(obj);
            return obj;
        }

    }
}