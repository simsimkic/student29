using Model.Appointment;
using Model.Rooms;
using Model.SystemUsers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace health_clinicClassDiagram.View.Util
{
    class AppointmentGenerator
    {
        private static AppointmentGenerator instance = null;

        public static AppointmentGenerator Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new AppointmentGenerator();
                }
                return instance;

            }
        }

        public List<Appointment> generateList(DateTime date)
        {
            List<Appointment> blankAppointments = new List<Appointment>();

            for (double i = 0.0; i < 24.0; i += 1.0)
            {
                DateTime startDate = date.AddHours(i);
                DateTime endDate = date.AddHours(i + 1.0);

                Appointment temp = new Appointment(new Doctor(), new Patient(), new ExamOperationRoom(), TypeOfAppointment.None, startDate, endDate);
                blankAppointments.Add(temp);
            }

            return blankAppointments;
        }
    }
}