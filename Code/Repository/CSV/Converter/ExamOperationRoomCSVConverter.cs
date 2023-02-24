using Model.Rooms;
using Repository.Csv.Converter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace health_clinicClassDiagram.Repository.Csv.Converter
{
    class ExamOperationRoomCSVConverter : ICSVConverter<ExamOperationRoom>
    {
        

        private readonly string _delimiter;

        public ExamOperationRoomCSVConverter(string delimiter)
        {
            _delimiter = delimiter;
        }
        public ExamOperationRoom ConvertCSVFormatToEntity(string entityCSVFormat)
        {
            string[] tokens = entityCSVFormat.Split(_delimiter.ToCharArray());
            List<Equipment> equipments = new List<Equipment>();

            int i = 1;

            while (i < tokens.Length - 1)
            {
                int idEquip = int.Parse(tokens[i]);
                i++;
                string naziv = tokens[i];
                i++;
                int quantity = int.Parse(tokens[i]);

                Equipment equipment = new Equipment(idEquip, naziv, quantity);
                equipments.Add(equipment);
                i++;
            }

            ExamOperationRoom room = new ExamOperationRoom(long.Parse(tokens[0]), equipments);
            return room;
        }

        public string ConvertEntityToCSVFormat(ExamOperationRoom entity)
        {
            String equipemnts = "";


            foreach (Equipment equipment in entity.Equipments)
            {
                equipemnts += string.Join(_delimiter, equipment.Id, equipment.Name, equipment.Quantity);
                equipemnts += _delimiter;
            }

            return string.Join(_delimiter,
                entity.Id,
                equipemnts);
        }
    }
}
 