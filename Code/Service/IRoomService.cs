/***********************************************************************
 * Module:  IRoomService.cs
 * Purpose: Definition of the Interface Service.IRoomService
 ***********************************************************************/

using Model.Rooms;
using Model.SystemUsers;
using System;
using System.Collections.Generic;

namespace Service
{
   public interface IRoomService : IService<Room>
   {
      Boolean IsRoomFree(DateTime from, DateTime to, Model.Rooms.Room room);
      List<Patient> GetAllPatientsByRoom(Model.Rooms.Room room);
      Boolean AddPatient(Model.SystemUsers.Patient patient, Model.Rooms.Room room);

      Room IncreaseQuantity(Room room, Equipment equipment);

      Room DecreaseQuantity(Room room, Equipment equipment);

    }
}