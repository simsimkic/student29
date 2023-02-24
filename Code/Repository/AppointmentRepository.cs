/***********************************************************************
 * Module:  UserRepository.cs
 * Purpose: Definition of the Class Repository.UserRepository
 ***********************************************************************/

using health_clinicClassDiagram.Repository.Sequencer;
using Model.Appointment;
using Model.Rooms;
using Model.SystemUsers;
using Repository.Csv.Converter;
using Repository.Csv.Stream;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Repository
{
   public class AppointmentRepository : IRepository<Appointment>
   {
        private static AppointmentRepository instance = null;
        private readonly ICSVStream<Appointment> _stream = new CSVStream<Appointment>("../../Resources/Data/appointments.csv", new AppointmentCSVConverter(","));
        private readonly iSequencer<long> _sequencer = new LongSequencer();

        public static AppointmentRepository Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new AppointmentRepository();
                }
                return instance;
            }
        }

        private AppointmentRepository()
        {
            //InitializeId();
        }

        private long GetMaxId(List<Appointment> appointments)
        {
            return appointments.Count() == 0 ? 0 : appointments.Max(apt => apt.Id);
        }

        public Appointment Save(Appointment obj)
        {
            //obj.Id = (_sequencer.GenerateId()) + 1;
            _stream.AppendToFile(obj);
            return obj;
        }

        public Appointment Edit(Appointment obj)
        {

            List<Appointment> appointments = _stream.ReadAll().ToList();
            appointments[appointments.FindIndex(apt => apt.Id == obj.Id)] = obj;
            _stream.SaveAll(appointments);
            return obj;

        }


        public bool Delete(Appointment obj)
        {
            List<Appointment> appointments = _stream.ReadAll().ToList();
            Appointment appointmentToRemove = appointments.SingleOrDefault(acc => acc.Id == obj.Id);
            if (appointmentToRemove != null)
            {
                appointments.Remove(appointmentToRemove);
                _stream.SaveAll(appointments);
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<Appointment> GetAll()
        {
            return _stream.ReadAll();
        }

        protected void InitializeId() => _sequencer.Initialize(GetMaxId(_stream.ReadAll()));


    }
}