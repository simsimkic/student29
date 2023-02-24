using Model.SystemUsers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace health_clinicClassDiagram.Model.Treatment
{
    public class SpecialistAppointment
    {
        private Doctor doctor;
        private String cause;

        public SpecialistAppointment()
        {
            Doctor = new Doctor();
            Cause = "";
        }

        public SpecialistAppointment(string cause, Doctor doctor)
        {
            Cause = cause;
            Doctor = doctor;
        }

        public string Cause { get => cause; set => cause = value; }
        public Doctor Doctor { get => doctor; set => doctor = value; }
    }
}
