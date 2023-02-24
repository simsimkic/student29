/***********************************************************************
 * Module:  IAppointmentController.cs
 * Purpose: Definition of the Interface Controller.IAppointmentController
 ***********************************************************************/


using Model.Appointment;
using Model.Rooms;
using Model.SystemUsers;
using System;
using System.Collections.Generic;

namespace Controller
{
   public interface IAppointmentController : IController<Appointment>
   {
      List<Appointment> GetAppointmentsByRoom(Model.Rooms.ExamOperationRoom room);
      List<Appointment> GetAppointmentsByTimeAndRoom(ExamOperationRoom room, DateTime startDate, DateTime endDate);
      List<Appointment> GetAppointmentsByTimeAndDoctor(Doctor doctor, DateTime startDate, DateTime endDate);
      List<Appointment> GetPriorityAppointments(Doctor doctor, DateTime startDate, DateTime endDate, String priority);

      DateTime GetLastDateOfAppointmentForRoom(Room room);
    }
}