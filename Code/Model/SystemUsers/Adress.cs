/***********************************************************************
 * Module:  Adress.cs
 * Purpose: Definition of the Class SystemUsers.Adress
 ***********************************************************************/

using System;

namespace Model.SystemUsers
{
   public class Address
   {
        private City city;

        private String streetName;
        private String streetNumber;

        public Address()
        {
            City = new City();
            StreetName = "";
            StreetNumber = "";
        }

        public City City { get => city; set => city = value; }
        public string StreetName { get => streetName; set => streetName = value; }
        public string StreetNumber { get => streetNumber; set => streetNumber = value; }
    }
}