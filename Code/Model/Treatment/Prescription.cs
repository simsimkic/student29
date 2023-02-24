/***********************************************************************
 * Module:  Prescription.cs
 * Purpose: Definition of the Class Treatment.Prescription
 ***********************************************************************/

using Model.Rooms;
using System;
using System.Collections.Generic;

namespace Model.Treatment
{
   public class Prescription
   {
        private List<Drug> drugs;
        public Prescription(List<Drug> drugs)
        {
            Drugs = drugs;
        }

        public Prescription()
        {
            Drugs = new List<Drug>();
        }

        public List<Drug> Drugs { get => drugs; set => drugs = value; }
    }
}