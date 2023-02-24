/***********************************************************************
 * Module:  Renovation.cs
 * Purpose: Definition of the Class Rooms.Renovation
 ***********************************************************************/

using System;
using System.Collections.Generic;

namespace Model.Rooms
{
   public class Renovation
   {
        private List<Room> rooms = new List<Room>();
        private long id;
        private DateTime startDate;
        private DateTime endDate;
        private TypeOfRenovation type;

        public DateTime StartDate  // property
        {
            get { return startDate; }   // get method
            set { startDate = value; }  // set method
        }
        public DateTime EndDate  // property
        {
            get { return endDate; }   // get method
            set { endDate = value; }  // set method
        }

        public long Id { get => id; set => id = value; }

        public List<Room> Rooms { get => rooms; set => rooms = value; }
        public TypeOfRenovation Type { get => type; set => type = value; }

        public Renovation(long id, TypeOfRenovation type, DateTime startDate, DateTime endDate, List<Room> rooms)
        {
            this.Id = id;
            this.Type = type;
            this.StartDate = startDate;
            this.EndDate = endDate;
            this.Rooms = rooms;
        }

    }
}