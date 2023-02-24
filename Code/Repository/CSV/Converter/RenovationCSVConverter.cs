/***********************************************************************
 * Module:  RenovationCSVConverter.cs
 * Purpose: Definition of the Class Repository.Csv.Converter.RenovationCSVConverter
 ***********************************************************************/

using health_clinicClassDiagram.Repository;
using health_clinicClassDiagram.Repository.Csv.Converter;
using health_clinicClassDiagram.Repository.Sequencer;
using Model.Rooms;
using Repository.Csv.Stream;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Repository.Csv.Converter
{
   public class RenovationCSVConverter : ICSVConverter<Renovation>
   {
        private String _delimiter;
        public RenovationCSVConverter(string delimiter)
        {
            _delimiter = delimiter;

        }

        public Renovation ConvertCSVFormatToEntity(string entityCSVFormat)
        {
            string[] tokens = entityCSVFormat.Split(_delimiter.ToCharArray());
            List<Room> rooms = new List<Room>();
            DateTime startingDate = DateTime.ParseExact(tokens[2], "dd/MM/yyyy", CultureInfo.InvariantCulture);
            DateTime endingDate = DateTime.ParseExact(tokens[3], "dd/MM/yyyy", CultureInfo.InvariantCulture);
           
            var examOperationRoomRepository = ExamOperationRoomRepository.Instance;


            var rehabilitationRoomRepository = RehabilitationRoomRepository.Instance;

          

            if (tokens[4] != "")
            {
                String roomString = tokens[4];
                String[] oneRoom = roomString.Split('|');
                Room room = null;
                for (int j = 0; j < oneRoom.Length; j++)
                {
                    var roomFinder = examOperationRoomRepository.GetRoomById(long.Parse(oneRoom[j]));
                    var roomFinder2 = rehabilitationRoomRepository.GetRoomById(long.Parse(oneRoom[j]));
                    if (roomFinder != null)
                    {
                        room = (Room)roomFinder;
                    }
                    else
                    {
                        room = (Room)roomFinder2;
                    }
                    rooms.Add(room);
                }
            }

            String typeString = tokens[1];

            TypeOfRenovation type = (TypeOfRenovation)Enum.Parse(typeof(TypeOfRenovation), typeString, true);


            Renovation reno = new Renovation(long.Parse(tokens[0]), type, startingDate, endingDate, rooms);
            return reno;
        }

        public string ConvertEntityToCSVFormat(Renovation entity)
        {
            String roomsEntity = "";
            if (entity.Rooms.Count != 0)
            {
                Room last = entity.Rooms.Last();
                foreach (Room room in entity.Rooms)
                {
                    if (room != null)
                    {
                        if (room != last)
                        {
                            roomsEntity += room.Id + "|";
                        }
                        else
                        {
                            roomsEntity += room.Id;
                        }
                    }
                }
            }

            return string.Join(_delimiter,
            entity.Id,
            entity.Type,
            entity.StartDate.ToString("dd/MM/yyyy"),
            entity.EndDate.ToString("dd/MM/yyyy"),
            roomsEntity);
        }
    }
}