/***********************************************************************
 * Module:  Patient.cs
 * Purpose: Definition of the Class SystemUsers.Patient
 ***********************************************************************/

using health_clinicClassDiagram.Model.SystemUsers;
using System;

namespace Model.SystemUsers
{
   public class Patient : RegisteredUser
   {
        private DateTime dateOfBirth;
        private Boolean guestAccount;
        private Gender gender;

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

        public String NameAndSurname
        {
            get { return Name + " " + Surname; }
        }

        public Patient()
        {
            this.Id = 0;
        }

        public Patient(String name, String surname, long jmbg)
        {
            this.Name = name;
            this.Surname = surname;
            this.Id = jmbg;
        }

        public Patient(String name, String surname, long jmbg, DateTime dateOfBirth, Gender gender)
        {
            this.Name = name;
            this.Surname = surname;
            this.Id = jmbg;
            this.dateOfBirth = dateOfBirth;
            this.gender = gender;
        }

    }
}