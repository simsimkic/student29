/***********************************************************************
 * Module:  WorkingDays.cs
 * Purpose: Definition of the Class SystemUsers.WorkingDays
 ***********************************************************************/

using System;

namespace Model.SystemUsers
{
   public class WorkingDays
   {
        private Days day;
        private DateTime fromTime;
        private DateTime toTime;
        private long id;

        public WorkingDays(long id, DateTime fromTime, DateTime toTime, Days day)
        {
            Id = id;
            FromTime = fromTime;
            ToTime = toTime;
            Day = day;
        }

        public long Id { get => id; set => id = value; }
        public DateTime FromTime { get => fromTime; set => fromTime = value; }
        public DateTime ToTime { get => toTime; set => toTime = value; }
        public Days Day { get => day; set => day = value; }


    }
}