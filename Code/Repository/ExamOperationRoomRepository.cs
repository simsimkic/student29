using health_clinicClassDiagram.Repository.Csv.Converter;
using health_clinicClassDiagram.Repository.Sequencer;
using Model.Rooms;
using Repository.Csv.Stream;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace health_clinicClassDiagram.Repository
{
    public class ExamOperationRoomRepository : IExamOperationRoomRepository
    {
        private readonly ICSVStream<ExamOperationRoom> _stream = new CSVStream<ExamOperationRoom>("../../Resources/Data/examoperationrooms.csv", new ExamOperationRoomCSVConverter(","));
        private readonly iSequencer<long> _sequencer = new LongSequencer();

        private static ExamOperationRoomRepository instance;
        public static ExamOperationRoomRepository Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ExamOperationRoomRepository();
                }
                return instance;
            }
        }

        private ExamOperationRoomRepository() { }

        private long GetMaxId(List<ExamOperationRoom> rooms)
        {
            return rooms.Count() == 0 ? 0 : rooms.Max(ro => ro.Id);
        }


        public bool Delete(ExamOperationRoom obj)
        {
            List<ExamOperationRoom> rooms = _stream.ReadAll().ToList();
            ExamOperationRoom roomToRemove = rooms.SingleOrDefault(ro => ro.Id == obj.Id);
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

        public ExamOperationRoom Edit(ExamOperationRoom obj)
        {
            List<ExamOperationRoom> rooms = _stream.ReadAll().ToList();
            rooms[rooms.FindIndex(ro => ro.Id == obj.Id)] = obj;
            _stream.SaveAll(rooms);
            return obj;
        }

        public List<ExamOperationRoom> GetAll()
        {
            List<ExamOperationRoom> rooms = _stream.ReadAll();
            return rooms;
        }

        public ExamOperationRoom Save(ExamOperationRoom obj)
        {
            _stream.AppendToFile(obj);
            return obj;
        }
        public ExamOperationRoom GetRoomById(long id)
        {
            var rooms = GetAll();
            foreach (ExamOperationRoom examOperationRoom in rooms)
            {
                if (examOperationRoom.Id == id)
                {
                    return examOperationRoom;
                }
            }
            return null;
        }
    }
}