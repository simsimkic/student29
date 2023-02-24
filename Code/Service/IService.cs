/***********************************************************************
 * Module:  IService.cs
 * Purpose: Definition of the Interface Service.IService
 ***********************************************************************/

using System;
using System.Collections.Generic;

namespace Service
{
   public interface IService<T>
   {
        T Create(T obj);
        T Edit(T obj);
      Boolean Delete(T obj);
      List<T> GetAll();
   }
}