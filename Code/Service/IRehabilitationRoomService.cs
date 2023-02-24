using Model.Appointment;
using Model.Rooms;
using Model.SystemUsers;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace health_clinicClassDiagram.Service
{
    public interface IRehabilitationRoomService : IService<RehabilitationRoom>
    {
        Boolean AddPatient(MedicalRecord record, RehabilitationRoom room);
        Boolean ReleasePatient(MedicalRecord record, RehabilitationRoom room);
        RehabilitationRoom GetRoom(RehabilitationRoom room);
        RehabilitationRoom GetRoomById(long id);
        Room IncreaseQuantity(Room room, Equipment equipment);
        Room DecreaseQuantity(Room room, Equipment equipment);
        List<RehabilitationRoom> GetAllFreeRooms();
    }
}
