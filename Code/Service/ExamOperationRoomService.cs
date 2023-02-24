using health_clinicClassDiagram.Controller;
using health_clinicClassDiagram.Repository;
using Model.Rooms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace health_clinicClassDiagram.Service
{
    public class ExamOperationRoomService : IExamOperationRoomService
    {
        private readonly IExamOperationRoomRepository _examOperationRoomRepository = ExamOperationRoomRepository.Instance;
        private static ExamOperationRoomService instance;

        public static ExamOperationRoomService Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ExamOperationRoomService();
                }
                return instance;
            }
        }

        private ExamOperationRoomService() { }

        public ExamOperationRoom Create(ExamOperationRoom obj)
        {

            var newExamOperRoom = _examOperationRoomRepository.Save(obj);

            return newExamOperRoom;
        }

        public bool Delete(ExamOperationRoom obj)
        {
            return _examOperationRoomRepository.Delete(obj);
        }

        public ExamOperationRoom Edit(ExamOperationRoom obj)
        {
            _examOperationRoomRepository.Edit(obj);
            return obj;


        }

        public List<ExamOperationRoom> GetAll()
        {
            List<ExamOperationRoom> rooms = _examOperationRoomRepository.GetAll();
            return rooms;
        }

        public ExamOperationRoom GetRoomById(long id)
        {
            return _examOperationRoomRepository.GetRoomById(id);
        }

        public Room IncreaseQuantity(Room room, Equipment equipment)
        {
            foreach (Equipment equipmentInRoom in room.Equipments)
            {
                if (equipmentInRoom.Id == equipment.Id)
                {
                    equipmentInRoom.Quantity += equipment.Quantity;
                    return room;
                }
            }
            room.Equipments.Add(equipment);
            return room;
        }

        public Room DecreaseQuantity(Room room, Equipment equipment)
        {
            foreach (Equipment equipmentInRoom in room.Equipments)
            {
                if (equipmentInRoom.Id == equipment.Id)
                {
                    if ((equipmentInRoom.Quantity - equipment.Quantity) < 0)
                    {
                        return room;
                    }
                    equipmentInRoom.Quantity -= equipment.Quantity;
                    if (equipmentInRoom.Quantity == 0)
                    {
                        room.Equipments.Remove(equipment);
                    }
                    return room;
                }
            }
            return room;
        }
    }
}