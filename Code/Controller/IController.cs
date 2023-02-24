/***********************************************************************
 * Module:  IController.cs
 * Purpose: Definition of the Interface Controller.IController
 ***********************************************************************/

using System;
using System.Collections.Generic;

namespace Controller
{
   public interface IController<T>
   {
        List<T> GetAll();
        Boolean Delete(T obj);
        T Create(T obj);
        T Edit(T obj);
   }
}