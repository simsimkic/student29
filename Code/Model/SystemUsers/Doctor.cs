/***********************************************************************
 * Module:  Doctor.cs
 * Purpose: Definition of the Class SystemUsers.Doctor
 ***********************************************************************/

using health_clinicClassDiagram.Model.SystemUsers;
using System;
using System.Collections.Generic;

namespace Model.SystemUsers
{
   public class Doctor : RegisteredUser
   {
        private Gender gender;
        private DateTime dateOfBirth;
        private List<WorkingSchedule> workingSchedules = new List<WorkingSchedule>();

        public long IdDoctor
        {
            get { return Id; }   // get method
            set { Id = value; }
        }

        public String NameDoctor
        {
            get { return Name; }   // get method
            set { Name = value; }
        }

        public String SurnameDoctor
        {
            get { return Surname; }   // get method
            set { Surname = value; }
        }

        public Gender Gender
        {
            get { return gender; }   // get method
            set { gender = value; }
        }
        public DateTime DateOfBirth
        {
            get { return dateOfBirth; }   // get method
            set { dateOfBirth = value; }
        }


        public List<WorkingSchedule> WorkingSchedules
        {
            get { return workingSchedules; }   // get method
            set { workingSchedules = value; }
        }

        public String IdWorkingSchedules
        {
            get
            {
                String ids = "";
                foreach (WorkingSchedule schedule in WorkingSchedules)
                {
                    ids += schedule.Id.ToString();
                }

                return ids;
            }
        }

        public String NameAndSurname
        {
            get { return Name + " " + Surname; }
        }

        public Doctor(long jmbg, String name, String surname, Gender gender, DateTime dateOfBirth)
        {

            this.Id = jmbg;
            this.Name = name;
            this.Surname = surname;
            this.gender = gender;
            this.dateOfBirth = dateOfBirth;
            // workingSchedule = workSc;

        }

        public Doctor(long jmbg, String name, String surname, Gender gender, DateTime dateOfBirth, string username, string password)
        {

            this.Id = jmbg;
            this.Name = name;
            this.Surname = surname;
            this.gender = gender;
            this.dateOfBirth = dateOfBirth;
            this.Username = username;
            this.Password = password;
            // workingSchedule = workSc;

        }
        public Doctor(long jmbg, String name, String surname, Gender gender,  DateTime dateOfBirth, WorkingSchedule workingSchedule, String uname, String pass)

        {

            this.Id = jmbg;
            this.Name = name;

            this.Surname = surname;
            this.gender = gender;
            this.dateOfBirth = dateOfBirth;
            this.WorkingSchedules.Add(workingSchedule);
            this.Username = uname;
            this.Password = pass;
           


        }

        public Doctor(long jmbg, String name, String surname, Gender gender, DateTime dateOfBirth, List<WorkingSchedule> workingSchedules, String uname, String pass)

        {

            this.Id = jmbg;
            this.Name = name;

            this.Surname = surname;
            this.gender = gender;
            this.dateOfBirth = dateOfBirth;
            this.WorkingSchedules = workingSchedules;
            this.Username = uname;
            this.Password = pass;
           


        }

        public Doctor(long jmbg, String name, String surname)
        {
            this.Id = jmbg;
            this.Name = name;
            this.Surname = surname;

        }

        public Doctor(String name, String surname)
        {
            this.Name = name;
            this.Surname = surname;

        }

        public Doctor() : base()
        {
            Gender = Gender.MALE;
            DateOfBirth = DateTime.Now;
            WorkingSchedules = new List<WorkingSchedule>();
        }

    }
}