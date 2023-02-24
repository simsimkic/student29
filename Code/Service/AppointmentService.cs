/***********************************************************************
 * Module:  AppointmentService.cs
 * Purpose: Definition of the Class Service.AppointmentService
 ***********************************************************************/

using health_clinicClassDiagram.Repository;
using health_clinicClassDiagram.Service;
using health_clinicClassDiagram.View.Util;
using Model.Appointment;
using Model.Rooms;
using Model.SystemUsers;
using Model.Treatment;
using Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Service
{
    public class AppointmentService : IAppointmentService
    {
        public IRepository<Appointment> _appointmentRepository = AppointmentRepository.Instance;
        private readonly IService<Doctor> _doctorService = DoctorService.Instance;
        private readonly IService<Patient> _patientService = PatientService.Instance;
        private readonly IService<ExamOperationRoom> _roomService = ExamOperationRoomService.Instance;

        private static AppointmentService instance;

        public static AppointmentService Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new AppointmentService();
                }
                return instance;
            }
        }

        private AppointmentService()
        {
        }

        public List<Appointment> GetAppointmentsByRoom(ExamOperationRoom room)
        {
            List<Appointment> appointments = _appointmentRepository.GetAll();
            List<Appointment> wantedAppointments = new List<Appointment>();

            foreach (Appointment appointment in appointments)
            {
                if (appointment.RoomId.Equals(room.Id))
                {
                    wantedAppointments.Add(appointment);
                }
            }


            return wantedAppointments;
        }

        public Appointment Create(Appointment obj)
        {
            Appointment appointment = _appointmentRepository.Save(obj);
            return appointment;
        }

        public Appointment Edit(Appointment obj)
        {
            _appointmentRepository.Edit(obj);
            return obj;
        }

        public bool Delete(Appointment obj)
        {
            return _appointmentRepository.Delete(obj);
        }

        public List<Appointment> GetAll()
        {
            List<Appointment> appointments = _appointmentRepository.GetAll();
            return appointments;
        }

        public List<Appointment> GetAppointmentsByTimeAndRoom(ExamOperationRoom room, DateTime startDate, DateTime endDate)
        {
            List<Appointment> appointments = _appointmentRepository.GetAll();
            List<Appointment> wantedAppointments = new List<Appointment>();

            foreach (Appointment appointment in appointments)
            {
                if ((appointment.RoomId.Equals(room.Id)) && (appointment.StartDate >= startDate) && (appointment.EndDate <= endDate))
                {
                    wantedAppointments.Add(appointment);
                }
            }

            return wantedAppointments;
        }

        public List<Appointment> GetAppointmentsByTimeAndDoctor(Doctor doctor, DateTime startDate, DateTime endDate)
        {
            List<Appointment> appointments = _appointmentRepository.GetAll();
            List<Appointment> wantedAppointments = new List<Appointment>();

            foreach (Appointment appointment in appointments)
            {
                if ((appointment.Doctor.Id.Equals(doctor.Id)) && (appointment.StartDate >= startDate) && (appointment.EndDate <= endDate))
                {
                    wantedAppointments.Add(appointment);
                }
            }

            return wantedAppointments;
        }

        public List<Appointment> GetPriorityAppointments(Doctor doctor, DateTime startDate, DateTime endDate, string priority)
        {
            List<Appointment> appointmentsToShow = ListAppointments(doctor, startDate, endDate);
            List<Doctor> doctors = DoctorRepository.Instance.GetAll();

            if (appointmentsToShow.Count == 0)
            {
                if (priority.Equals("DOKTOR"))
                {
                    while (appointmentsToShow.Count < 3)
                    {
                        endDate = endDate.AddDays(1);
                        appointmentsToShow = ListAppointments(doctor, startDate, endDate);
                    }
                }
                else
                {
                    while (appointmentsToShow.Count < 3)
                    {
                        doctors.Remove(doctor);
                        doctor = doctors[0];
                        appointmentsToShow = ListAppointments(doctor, startDate, endDate);
                    }
                }
            }

            return appointmentsToShow;
        }

        private List<Appointment> ListAppointments(Doctor doctor, DateTime startDate, DateTime endDate)
        {

            List<ExamOperationRoom> rooms = ExamOperationRoomRepository.Instance.GetAll();

            List<Appointment> wantedAppointments = GetAppointmentsByTimeAndDoctor(doctor, startDate, endDate);

            List<Appointment> occupiedAppointmentsForRooms = ListOccupiedAppointments(startDate, endDate);

            List<Appointment> BlankAppointments = AppointmentGenerator.Instance.generateList(startDate);

            foreach (Appointment appointment in wantedAppointments)
            {
                BlankAppointments.RemoveAll(x => x.StartDate >= appointment.StartDate && x.EndDate <= appointment.EndDate);
            }

            List<Appointment> appointmentsToShow = ListAppointmentsToShow(BlankAppointments, occupiedAppointmentsForRooms);

            return appointmentsToShow;
        }

        private List<Appointment> ListOccupiedAppointments(DateTime startDate, DateTime endDate)
        {
            List<ExamOperationRoom> rooms = ExamOperationRoomRepository.Instance.GetAll();

            List<Appointment> occupiedAppointmentsForRooms = new List<Appointment>();
            int i = 0;
            foreach (ExamOperationRoom r in rooms)
            {
                List<Appointment> appointmentsForOneRoom = GetAppointmentsByTimeAndRoom(rooms[i], startDate, endDate);
                occupiedAppointmentsForRooms.AddRange(appointmentsForOneRoom);
                i++;
            }

            return occupiedAppointmentsForRooms;
        }

        private List<Appointment> ListAppointmentsToShow(List<Appointment>BlankAppointments, List<Appointment>occupiedAppointmentsForRooms)
        {
            List<ExamOperationRoom> rooms = ExamOperationRoomRepository.Instance.GetAll();

            List<Appointment> appointmentsToShow = new List<Appointment>();

            foreach (Appointment blankAppointment in BlankAppointments)
            {
                int alreadyOccupied = 0;
                for (int j = 0; j < rooms.Count; j++)
                {
                    foreach (Appointment occupiedAppointment in occupiedAppointmentsForRooms)
                    {
                        if (blankAppointment.StartDate >= occupiedAppointment.StartDate && blankAppointment.EndDate <= occupiedAppointment.EndDate)
                        {
                            alreadyOccupied = 1;
                        }
                    }
                    if (alreadyOccupied == 0)
                    {
                        blankAppointment.ExamOperationRoom = rooms[j];
                        appointmentsToShow.Add(blankAppointment);
                        break;
                    }
                }

                if (appointmentsToShow.Count > 3)
                {
                    break;
                }
            }

            return appointmentsToShow;
        }

        public List<Appointment> GetAppointmentsByDate(DateTime startDate, DateTime endDate)
        {
            List<Appointment> appointments = new List<Appointment>();
            foreach (Appointment appointment in GetAll())
            {
                if (appointment.StartDate >= startDate && (appointment.EndDate <= endDate))
                {
                    appointments.Add(appointment);
                }
            }
            return appointments;
        }

        public List<Appointment> GetAppointmentsByDayAndDoctor(DateTime day, Doctor doctor)
        {
            List<Appointment> appointments = new List<Appointment>();
            DateTime endOfDay = day.AddDays(1);
            foreach (Appointment appointment in GetAppointmentsByDate(day, endOfDay))
            {
                if (appointment.Doctor.Id == doctor.Id)
                {
                    appointments.Add(appointment);
                }
            }

            return appointments;
        }

        public List<Appointment> GetAppointmentsByDayAndDoctorAndRoomAndPatient(DateTime day, Doctor doctor, ExamOperationRoom room, Patient patient)
        {
            List<Appointment> appointments = new List<Appointment>();
            DateTime endDate = day.AddDays(1);
            foreach (Appointment appointment in GetAppointmentsByDate(day, endDate))
            {
                if (appointment.Patient.Id == patient.Id || appointment.Doctor.Id == doctor.Id || appointment.ExamOperationRoom.Id == room.Id)
                {
                    appointments.Add(appointment);
                }
            }
            return appointments;
        }

        public DateTime GetLastDateOfAppointmentForRoom(Room room)
        {
            var appointments = _appointmentRepository.GetAll();

            DateTime latestDate = DateTime.Now;
            latestDate = latestDate.AddDays(-1);

            foreach (Appointment appointment in appointments)
            {
                if (appointment.RoomId == room.Id)
                {
                    if (appointment.StartDate > latestDate)
                    {
                        latestDate = appointment.StartDate;
                    }
                }
            }
            return latestDate;
        }
    }
}