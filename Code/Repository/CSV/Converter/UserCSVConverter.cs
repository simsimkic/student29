/***********************************************************************
 * Module:  UserCSVConverter.cs
 * Purpose: Definition of the Class Repository.Csv.Converter.UserCSVConverter
 ***********************************************************************/

using Model.SystemUsers;
using System;

namespace Repository.Csv.Converter
{
   public class UserCSVConverter : ICSVConverter<RegisteredUser>
   {

        private readonly string _delimiter;

        public UserCSVConverter(string delimiter)
        {
            _delimiter = delimiter;
        }

        public RegisteredUser ConvertCSVFormatToEntity(string entityCSVFormat)
        {
            string[] tokens = entityCSVFormat.Split(_delimiter.ToCharArray());


            return new RegisteredUser();
        }

        public string ConvertEntityToCSVFormat(RegisteredUser entity)
        {
            return string.Join(_delimiter,
              entity.Id,
              entity.Name,
              entity.Surname,
              entity.Address,
              entity.Username);
        }
    }
}