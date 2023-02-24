using Controller;
using Model.Rooms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace health_clinicClassDiagram.Controller
{
    public interface IExamOperationRoomController : IController<ExamOperationRoom>
    {
        ExamOperationRoom GetRoomById(long id);

        Room IncreaseQuantity(Room room, Equipment equipment);

        Room DecreaseQuantity(Room room, Equipment equipment);
    }
}