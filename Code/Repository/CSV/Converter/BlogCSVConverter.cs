/***********************************************************************
 * Module:  BlogCSVConverter.cs
 * Purpose: Definition of the Class Repository.Csv.Converter.BlogCSVConverter
 ***********************************************************************/

using Model.Surveys;
using System;
using System.Globalization;

namespace Repository.Csv.Converter
{
   public class BlogCSVConverter : ICSVConverter<Blog>
   {
      private String _delimiter;

        public BlogCSVConverter(string delimiter)
        {
            _delimiter = delimiter;
        }

        public Blog ConvertCSVFormatToEntity(string entityCSVFormat)
        {
            string[] tokens = entityCSVFormat.Split(_delimiter.ToCharArray());

            string title = tokens[0];
            string text = tokens[1];
            string dateString = tokens[2];
            DateTime date = DateTime.ParseExact(dateString, "dd/MM/yyyy hh:mm", CultureInfo.InvariantCulture);

            return new Blog(title, text, date);
        }

        public string ConvertEntityToCSVFormat(Blog entity)
        {
            return string.Join(_delimiter,
                entity.Title,
                entity.Text,
                entity.Date.ToString("dd/MM/yyyy hh:mm"));
        }
    }
}