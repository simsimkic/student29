/***********************************************************************
 * Module:  City.cs
 * Purpose: Definition of the Class SystemUsers.City
 ***********************************************************************/

using System;

namespace Model.SystemUsers
{
   public class City
   {
        private Country country;

        private String name;

        public City()
        {
            Country = new Country();
            Name = "";
        }

        public Country Country { get => country; set => country = value; }
        public string Name { get => name; set => name = value; }
    }
}