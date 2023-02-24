/***********************************************************************
 * Module:  ReferralToHospitalTreatment.cs
 * Purpose: Definition of the Class Treatment.ReferralToHospitalTreatment
 ***********************************************************************/

using Model.Rooms;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Model.Treatment
{
   public class ReferralToHospitalTreatment
   {
        private List<Drug> drugs;
        private String causeForHospitalTreatment;

        public ReferralToHospitalTreatment()
        {
            Drugs = new List<Drug>();
            CauseForHospitalTreatment = "";
        }

        public ReferralToHospitalTreatment(string causeForHospTreatment, List<Drug> drugs)
        {
            Drugs = drugs;
            CauseForHospitalTreatment = causeForHospTreatment;
        }

        public List<Drug> Drugs { get => drugs; set => drugs = value; }
        public string CauseForHospitalTreatment { get => causeForHospitalTreatment; set => causeForHospitalTreatment = value; }
    }
}