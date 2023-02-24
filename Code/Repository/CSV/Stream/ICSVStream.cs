/***********************************************************************
 * Module:  ICSVStream.cs
 * Purpose: Definition of the Interface Repository.ICSVStream
 ***********************************************************************/

using System;
using System.Collections.Generic;

namespace Repository.Csv.Stream
{
   public interface ICSVStream<E> where E : class
    {
      void SaveAll(List<E> entities);
      List<E> ReadAll();
      void AppendToFile(E entity);
   }
}