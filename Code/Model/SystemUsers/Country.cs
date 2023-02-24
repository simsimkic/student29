/***********************************************************************
 * Module:  Country.cs
 * Purpose: Definition of the Class SystemUsers.Country
 ***********************************************************************/

using System;

namespace Model.SystemUsers
{
   public class Country
   {
      private String name;

        public Country()
        {
            Name = "";
        }

        public string Name { get => name; set => name = value; }
    }
}