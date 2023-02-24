/***********************************************************************
 * Module:  Specialist.cs
 * Purpose: Definition of the Class SystemUsers.Specialist
 ***********************************************************************/

using health_clinicClassDiagram.Model.SystemUsers;
using System;

namespace Model.SystemUsers
{
   public class Specialist : Doctor
   {
      private Specialization specialization;
        public Specialist(long id, String name, String surname, Gender gender, DateTime dateOfBirth, Specialization specialization) : base(id, name, surname, gender, dateOfBirth)
        {
            Specialization = specialization;
        }
        public Specialization Specialization { get => specialization; set => specialization = value; }
    }
}