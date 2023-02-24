/***********************************************************************
 * Module:  ICSVConverter.cs
 * Purpose: Definition of the Interface Repository.ICSVConverter
 ***********************************************************************/

using System;

namespace Repository.Csv.Converter
{
   public interface ICSVConverter<E> where E : class
    {
      String ConvertEntityToCSVFormat(E entity);
        E ConvertCSVFormatToEntity(String entityCSVFormat);
   }
}