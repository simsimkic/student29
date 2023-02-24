/***********************************************************************
 * Module:  ReferralToOperation.cs
 * Purpose: Definition of the Class Treatment.ReferralToOperation
 ***********************************************************************/

using Model.SystemUsers;
using System;

namespace Model.Treatment
{
   public class ScheduledSurgery
   {
        private SystemUsers.Surgeon surgeon;

        private DateTime startDate;
      private DateTime endDate;
      private String causeForOperation;

        public DateTime StartDate { get => startDate; set => startDate = value; }
        public DateTime EndDate { get => endDate; set => endDate = value; }
        public string CauseForOperation { get => causeForOperation; set => causeForOperation = value; }
        public Surgeon Surgeon { get => surgeon; set => surgeon = value; }

        public ScheduledSurgery(DateTime startDate, DateTime endDate, string causeForOperation, Surgeon surgeon)
        {
            StartDate = startDate;
            EndDate = endDate;
            CauseForOperation = causeForOperation;
            Surgeon = surgeon;
        }

        public ScheduledSurgery()
        {
            StartDate = new DateTime();
            EndDate = new DateTime();
            CauseForOperation = "";
            Surgeon = new Surgeon();
        }
    }
}