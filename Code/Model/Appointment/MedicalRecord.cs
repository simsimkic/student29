/***********************************************************************
 * Module:  MedicalRecord.cs
 * Purpose: Definition of the Class Appointment.MedicalRecord
 ***********************************************************************/

using health_clinicClassDiagram.Model.SystemUsers;
using Model.SystemUsers;
using Model.Treatment;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;

namespace Model.Appointment
{
   public class MedicalRecord
    {
        public long id;
        private List<Model.Treatment.Treatment> treatments;
        public Doctor choosenDoctor;
        private Patient patient;
        private DateTime rehabilitationFrom;
        private DateTime rehabilitationTo;

        /// <pdGenerated>default getter</pdGenerated>
        /// 

        public long Id { get => id; set => id = value; }
        public string Name { get => Patient.Name; set => Patient.Name = value; }
        public string Surname { get => Patient.Surname; set => Patient.Surname = value; }
        public long IDPatient { get => Patient.Id; set => Patient.Id = value; }
        public DateTime DateOfBirth { get => Patient.DateOfBirth; set => Patient.DateOfBirth = value; }
        public Gender GenderProp { get => Patient.Gender; set => Patient.Gender = value; }

        public String DateOfBirthString { get => DateOfBirth.ToShortDateString(); }

        public String IdNameSurnameDoctor
        {
            get
            {
                return (choosenDoctor.Id + " " + choosenDoctor.Name + " " + choosenDoctor.Surname);
            }

        }

        public List<Model.Treatment.Treatment> Treatments { get => treatments; set => treatments = value; }
        public Patient Patient { get => patient; set => patient = value; }

        public MedicalRecord(long id, Patient patient, Doctor doctor, List<Model.Treatment.Treatment> treatments)
        {
            this.id = id;
            this.Patient = patient;
            this.choosenDoctor = doctor;
            Treatments = treatments;
        }

        public MedicalRecord(Patient patient, List<Model.Treatment.Treatment> treatments, Doctor doctor)
        {
            this.Patient = patient;
            this.Treatments = treatments;
            this.choosenDoctor = doctor;
        }

        public MedicalRecord(long id, Patient patient, Doctor doctor, List<Model.Treatment.Treatment> treatments, DateTime rehabilitationFrom, DateTime rehabilitationTo)
        {
            this.id = id;
            this.Patient = patient;
            this.choosenDoctor = doctor;
            Treatments = treatments;
            this.rehabilitationFrom = rehabilitationFrom;
            this.rehabilitationTo = rehabilitationTo;
        }


    }
}