/***********************************************************************
 * Module:  Appointment.cs
 * Purpose: Definition of the Class Appointment.Appointment
 ***********************************************************************/

using Model.Rooms;
using Model.SystemUsers;
using System;

namespace Model.Appointment
{
   public class Appointment
   {
        private Patient patient;
        private Doctor doctor;
        private ExamOperationRoom examOperationRoom;
        private DateTime startDate;
        private DateTime endDate;
        private TypeOfAppointment typeOfAppointment;

        public long Id { get; set; }
        public DateTime EndDate { get => endDate; set => endDate = value; }
        public DateTime StartDate { get => startDate; set => startDate = value; }
        public Doctor Doctor { get => doctor; set => doctor = value; }
        public Patient Patient { get => patient; set => patient = value; }
        public TypeOfAppointment TypeOfAppointment { get => typeOfAppointment; set => typeOfAppointment = value; }
        public ExamOperationRoom ExamOperationRoom { get => examOperationRoom; set => examOperationRoom = value; }
        public long RoomId { get => examOperationRoom.Id; set => examOperationRoom.Id = value; }

        public String DoctorIdNameSurname { get => doctor.NameDoctor + " " + doctor.SurnameDoctor; }

        public String PatientIdNameSurname { get => patient.Name + " " + patient.Surname; }

        public String TypeString
        {
            get
            {
                if (patient == null || patient.Id == 0)
                {
                    return "";
                }
                else
                {
                    return TypeOfAppointment.ToString();
                }
            }

        }

        public String RoomIdTekst { get => "Soba broj. " + examOperationRoom.Id; }




        public Appointment(Doctor doctor, Patient patient, ExamOperationRoom room, TypeOfAppointment type, DateTime startDate, DateTime endDate)
        {
            this.Doctor = doctor;
            this.Patient = patient;
            this.ExamOperationRoom = room;
            this.TypeOfAppointment = type;
            this.StartDate = startDate;
            this.EndDate = endDate;
        }

        public Appointment(long id, Doctor doctor, Patient patient, ExamOperationRoom room, TypeOfAppointment type, DateTime startDate, DateTime endDate)
        {
            Id = id;
            this.Doctor = doctor;
            this.Patient = patient;
            this.ExamOperationRoom = room;
            this.TypeOfAppointment = type;
            this.StartDate = startDate;
            this.EndDate = endDate;
        }

        public Appointment(Doctor doctor, Patient patient, TypeOfAppointment type)
        {
            this.Doctor = doctor;
            this.Patient = patient;
            this.TypeOfAppointment = type;
        }

        public Appointment(Doctor doctor, Patient patient, ExamOperationRoom room, TypeOfAppointment type)
        {
            this.Doctor = doctor;
            this.Patient = patient;
            this.ExamOperationRoom = room;
            this.TypeOfAppointment = type;
        }

        public Appointment()
        {
            Patient  = new Patient();
            Doctor  = new Doctor();
            ExamOperationRoom  = new ExamOperationRoom();
            StartDate = DateTime.Now;
            EndDate = DateTime.Now ;
            TypeOfAppointment  = TypeOfAppointment.EXAM;
        }


    }
}