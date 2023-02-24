/***********************************************************************
 * Module:  EquipmentCSVConverter.cs
 * Purpose: Definition of the Class Repository.Csv.Converter.EquipmentCSVConverter
 ***********************************************************************/

using Model.Rooms;
using System;

namespace Repository.Csv.Converter
{
   public class EquipmentCSVConverter : ICSVConverter<Equipment>
   {
        private readonly string _delimiter;

        public EquipmentCSVConverter(string delimiter)
        {
            _delimiter = delimiter;

        }

        public Equipment ConvertCSVFormatToEntity(string entityCSVFormat)
        {
            string[] tokens = entityCSVFormat.Split(_delimiter.ToCharArray());
            Equipment eq = new Equipment(int.Parse(tokens[0]), tokens[1], int.Parse(tokens[2]));
            return eq;
        }

        public string ConvertEntityToCSVFormat(Equipment entity)
        {
            return string.Join(_delimiter,
                 entity.Id,
                 entity.Name,
                 entity.Quantity
                 );
        }
    }
}