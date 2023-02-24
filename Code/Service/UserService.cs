/***********************************************************************
 * Module:  UserService.cs
 * Purpose: Definition of the Class Service.UserService
 ***********************************************************************/

using Model.SystemUsers;
using Repository;
using System;
using System.Collections.Generic;

namespace Service
{
   public class UserService : IUserService
   {
        public Repository.IUserRepository _userRepository;

        private static UserService Instance;

        public UserService GetInstance() { return null; }

        public UserService(IUserRepository repository)
        {
            _userRepository = repository;

        }

        public RegisteredUser LoginUser(string username, string password)
        {
            throw new NotImplementedException();
        }

        public bool IsUsernameValid(string username)
        {
            throw new NotImplementedException();
        }

        public bool IsPasswordValid(string password)
        {
            throw new NotImplementedException();
        }

        public RegisteredUser Create(RegisteredUser obj)
        {
            var newRegisteredUser = _userRepository.Save(obj);
            return newRegisteredUser;
        }

        public RegisteredUser Edit(RegisteredUser obj)
        {
            return _userRepository.Edit(obj);
        }

        public bool Delete(RegisteredUser obj)
        {
            return _userRepository.Delete(obj);

        }

        public List<RegisteredUser> GetAll()
        {
            var users = _userRepository.GetAll();
            return users;
        }

    }
}