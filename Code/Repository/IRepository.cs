/***********************************************************************
 * Module:  IRepository.cs
 * Purpose: Definition of the Interface Repository.IRepository
 ***********************************************************************/

using Model.SystemUsers;
using System;
using System.Collections.Generic;

namespace Repository
{
   public interface IRepository<T>
   {
        T Save(T obj);
        T Edit(T obj);
      Boolean Delete(T obj);
      List<T> GetAll();
   }
}