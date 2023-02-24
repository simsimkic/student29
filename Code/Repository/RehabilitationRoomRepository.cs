using health_clinicClassDiagram.Repository.Csv.Converter;
using health_clinicClassDiagram.Repository.Sequencer;
using Model.Appointment;
using Model.Rooms;
using Model.Treatment;
using Repository;
using Repository.Csv.Stream;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace health_clinicClassDiagram.Repository
{
    public class RehabilitationRoomRepository : IRehabilitationRoomRepository
    {
        private readonly ICSVStream<RehabilitationRoom> _stream = new CSVStream<RehabilitationRoom>("../../Resources/Data/rehabilitationrooms.csv", new RehabilitationRoomCSVConverter(","));
        private readonly iSequencer<long> _sequencer = new LongSequencer();

        private static RehabilitationRoomRepository instance;

        public static RehabilitationRoomRepository Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new RehabilitationRoomRepository();
                }
                return instance;
            }
        }


        private RehabilitationRoomRepository()
        {
        }

        private long GetMaxId(List<RehabilitationRoom> rooms)
        {
            return rooms.Count() == 0 ? 0 : rooms.Max(apt => apt.IdRoom);
        }

        public bool Delete(RehabilitationRoom obj)
        {
            List<RehabilitationRoom> rooms = _stream.ReadAll().ToList();
            RehabilitationRoom roomToRemove = rooms.SingleOrDefault(acc => acc.IdRoom == obj.IdRoom);
            if (roomToRemove != null)
            {
                rooms.Remove(roomToRemove);
                _stream.SaveAll(rooms);
                return true;
            }
            else
            {
                return false;
            }
        }

        public RehabilitationRoom Edit(RehabilitationRoom obj)
        {
            List<RehabilitationRoom> rooms = _stream.ReadAll().ToList();
            rooms[rooms.FindIndex(apt => apt.IdRoom == obj.IdRoom)] = obj;
            _stream.SaveAll(rooms);
            return obj;
        }

        public List<RehabilitationRoom> GetAll()
        {
            List<RehabilitationRoom> rooms = (List<RehabilitationRoom>)_stream.ReadAll();
            return rooms;
        }

        public RehabilitationRoom Save(RehabilitationRoom obj)
        {
            _stream.AppendToFile(obj);
            return obj;
        }

        public RehabilitationRoom GetRoom(RehabilitationRoom room)
        {
            List<RehabilitationRoom> rooms = _stream.ReadAll().ToList();
            return rooms[rooms.FindIndex(apt => apt.IdRoom == room.IdRoom)];
        }

        public RehabilitationRoom GetRoomById(long id)
        {
            List<RehabilitationRoom> rooms = GetAll();
            foreach (RehabilitationRoom rehabilitationRoom in rooms)
            {
                if (rehabilitationRoom.Id == id)
                {
                    return rehabilitationRoom;
                }
            }
            return null;
        }
    }
}
