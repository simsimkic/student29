/***********************************************************************
 * Module:  Equipment.cs
 * Purpose: Definition of the Class Rooms.Equipment
 ***********************************************************************/

using System;

namespace Model.Rooms
{
   public class Equipment
   {
      public static Equipment GetInstance()
      {
         // TODO: implement
         return null;
      }

        private long id;
       
        private TypeOfEquipment type;
        private String name;
        private int quantity;

        public Equipment(TypeOfEquipment tip, int quantity)
        {
            type = tip;
            Quantity = quantity;
        }
       
        public Equipment(long id, String name, int quantity)
        {
            Id = id;
            Name = name;
            Quantity = quantity;
        }

        public Equipment(long id, int quantity)
        {
            Id = id;
            Quantity = quantity;
        }

        public Equipment(long id, TypeOfEquipment tip, int quantity)
        {
            Id = id;
            type = tip;
            Quantity = quantity;
        }

        public TypeOfEquipment Type
        {
            get { return type; }   // get method
            set { type = value; }

        }
        public String Name
        {
            get { return name; }   // get method
            set { name = value; }
        }

        public int Quantity { get => quantity; set => quantity = value; }
        public long Id { get => id; set => id = value; }
        public string Ispisi()
        {
            return "Id : " + id + " " + " Naziv: " + name + " Kolicina: " + quantity;
        }

    }
}