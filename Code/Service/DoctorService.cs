using health_clinicClassDiagram.Repository;
using Model.Appointment;
using Model.SystemUsers;
using Repository;
using Service;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace health_clinicClassDiagram.Service
{
    public class DoctorService : IDoctorService
    {

        private readonly IRepository<Doctor> _doctorRepository = DoctorRepository.Instance;

        private static DoctorService instance;

        public static DoctorService Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DoctorService();
                }
                return instance;
            }
        }

        private DoctorService() { }

        public Doctor Create(Doctor obj)
        {
            Doctor newDoctor = _doctorRepository.Save(obj);
            return newDoctor;
        }

        public bool Delete(Doctor obj)
        {
            return _doctorRepository.Delete(obj);
        }

        public Doctor Edit(Doctor obj)
        {
            return _doctorRepository.Edit(obj);
        }

        public List<Doctor> GetAll()
        {
            List<Doctor> doctors = _doctorRepository.GetAll();
            return doctors;
        }

        public Doctor ValidateLogin(string username, string password)
        {
            return GetDoctorByUsernameAndPassword(username, password);
        }

        public List<Doctor> GetAllAvailableDoctors(DateTime _startDate, DateTime _endDate)
        {
            var doctors = _doctorRepository.GetAll();
            var appointments = AppointmentRepository.Instance.GetAll();

            List<Doctor> doctorsToRemove = new List<Doctor>();

            foreach (Appointment appointment in appointments)
            {
                if (appointment.StartDate <= _startDate && appointment.EndDate >= _endDate)
                {
                    doctorsToRemove.Add(appointment.Doctor);
                }
            }

            foreach (Doctor doctor in doctorsToRemove)
            {
                var doctorToRemove = doctors.SingleOrDefault(x => x.Id == doctor.Id);
                if (doctorToRemove != null)
                    doctors.Remove(doctorToRemove);
            }

            List<Doctor> availableDoctors = GetAvailableDoctorsForWorkingSchedule(doctors, _startDate, _endDate);

            return availableDoctors;

        }

        private List<Doctor> GetAvailableDoctorsForWorkingSchedule(List<Doctor> doctors, DateTime _startDate, DateTime _endDate)
        {
            List<Doctor> availableDoctors = new List<Doctor>();

            DateTime _startDateJustTime = default(DateTime).Add(_startDate.TimeOfDay);
            DateTime _endDateJustTime = default(DateTime).Add(_endDate.TimeOfDay);

            foreach (Doctor doctor in doctors)
            {
                List<DateTime> times = GetWorkingScheduleForDateAndDoctor(doctor, _startDate);
                DateTime doctorWorkingStartTime = default(DateTime).Add(times[0].TimeOfDay);
                DateTime doctorWorkingEndTime = default(DateTime).Add(times[1].TimeOfDay);

                if (_startDateJustTime >= doctorWorkingStartTime && _endDateJustTime <= doctorWorkingEndTime)
                {
                    availableDoctors.Add(doctor);
                }
            }

            return availableDoctors;
        }

        public Doctor GetDoctorByUsernameAndPassword(string username, string password)
        {
            foreach (Doctor doctor in GetAll())
            {
                if (doctor.Username.Equals(username) && doctor.Password.Equals(password)) return doctor;
            }
            return null;
        }

        public List<DateTime> GetWorkingScheduleForDateAndDoctor(Doctor doctor, DateTime date)
        {

            List<WorkingSchedule> workingSchedules = doctor.WorkingSchedules;

            WorkingSchedule wantedWorkingSchedule = FindWorkingScheduleForDate(workingSchedules, date);

            List<WorkingDays> allWorkingDays = wantedWorkingSchedule.WorkingDays;

            Calendar calendar = CultureInfo.InvariantCulture.Calendar;

            DayOfWeek dayOfWeek = calendar.GetDayOfWeek(date);

            DateTime startTime = new DateTime();
            DateTime endTime = new DateTime();

            foreach (WorkingDays workingDays in allWorkingDays)
            {
                String myDay = workingDays.Day.ToString().ToLower();
                String day = dayOfWeek.ToString().ToLower();

                if (myDay.Equals(day))
                {
                    startTime = workingDays.FromTime;
                    endTime = workingDays.ToTime;
                }
            }

            List<DateTime> times = new List<DateTime>();
            times.Add(startTime);
            times.Add(endTime);

            return times;
        }

        private WorkingSchedule FindWorkingScheduleForDate(List<WorkingSchedule> workingSchedules, DateTime date)
        {
            WorkingSchedule wantedWorkingSchedule = new WorkingSchedule();
            foreach (WorkingSchedule workingSchedule in workingSchedules)
            {
                if (workingSchedule.From <= date && workingSchedule.To >= date)
                {
                    wantedWorkingSchedule = workingSchedule;
                    break;
                }
            }

            return wantedWorkingSchedule;
        }

    }
}
