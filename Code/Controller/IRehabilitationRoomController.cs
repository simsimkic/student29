using Controller;
using Model.Appointment;
using Model.Rooms;
using Model.SystemUsers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace health_clinicClassDiagram.Controller
{
    public interface IRehabilitationRoomController : IController<RehabilitationRoom>
    {
        Boolean AddPatient(MedicalRecord record, RehabilitationRoom room);
        Boolean ReleasePatient(MedicalRecord record, RehabilitationRoom room);
        RehabilitationRoom GetRoom(RehabilitationRoom room);
        Room IncreaseQuantity(Room room, Equipment equipment);

        Room DecreaseQuantity(Room room, Equipment equipment);

        RehabilitationRoom GetRoomById(long id);

        List<RehabilitationRoom> GetAllFreeRooms();
    }
}
