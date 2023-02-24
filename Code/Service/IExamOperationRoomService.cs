using Model.Rooms;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace health_clinicClassDiagram.Service
{
    public interface IExamOperationRoomService : IService<ExamOperationRoom>
    {
        ExamOperationRoom GetRoomById(long id);

        Room IncreaseQuantity(Room room, Equipment equipment);

        Room DecreaseQuantity(Room room, Equipment equipment);
    }
}