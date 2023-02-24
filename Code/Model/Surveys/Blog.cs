/***********************************************************************
 * Module:  Blog.cs
 * Purpose: Definition of the Class SystemUsers.Blog
 ***********************************************************************/

using System;

namespace Model.Surveys
{
   public class Blog
   {
      public Model.SystemUsers.Doctor doctor;
   
      private String title;
      private String text;
      private DateTime date;

        public string Title { get => title; set => title = value; }
        public string Text { get => text; set => text = value; }
        public DateTime Date { get => date; set => date = value; }

        public Blog(string title, string text, DateTime date)
        {
            Title = title;
            Text = text;
            Date = date;
        }
    }
}