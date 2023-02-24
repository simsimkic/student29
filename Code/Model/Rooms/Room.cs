/***********************************************************************
 * Module:  Room.cs
 * Purpose: Definition of the Class Rooms.Room
 ***********************************************************************/

using System;
using System.Collections.Generic;

namespace Model.Rooms
{
   public class Room
   {
        protected List<Equipment> equipments;
        protected long _id;
        protected TypeOfRoom typeOfRoom;
        public long Id
        {
            get { return _id; }
            set { _id = value; }
        }
        public TypeOfRoom TypeOfRoom
        {
            get { return typeOfRoom; }
            set { typeOfRoom = value; }
        }

        public List<Equipment> Equipments
        {
            get { return equipments; }
            set { equipments = value; }
        }

        public Room(long id)
        {
            Id = id;
            Equipments = new List<Equipment>();
        }
        public Room(long id, TypeOfRoom tip)
        {
            this.Id = id;
            this.TypeOfRoom = tip;
            Equipments = new List<Equipment>();
        }


        public Room() 
        {
            Id = 0;
            TypeOfRoom = TypeOfRoom.EXAMOPERATION;
            Equipments = new List<Equipment>();
        }
    }
}