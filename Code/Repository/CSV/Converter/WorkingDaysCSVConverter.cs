using Model.SystemUsers;
using Repository.Csv.Converter;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace health_clinicClassDiagram.Repository.Csv.Converter
{
    class WorkingDaysCSVConverter : ICSVConverter<WorkingDays>
    {

        private readonly string _delimiter;

        public WorkingDaysCSVConverter(string delimiter)
        {
            _delimiter = delimiter;
        }

        public WorkingDays ConvertCSVFormatToEntity(string entityCSVFormat)
        {
            string[] tokens = entityCSVFormat.Split(_delimiter.ToCharArray());

            long id = long.Parse(tokens[0]);

            String dayString = tokens[1];

            Days day = (Days)Enum.Parse(typeof(Days), dayString, true);

            DateTime fromTime = DateTime.ParseExact(tokens[2], "HH:mm:ss", CultureInfo.InvariantCulture);
            DateTime toTime = DateTime.ParseExact(tokens[3], "HH:mm:ss", CultureInfo.InvariantCulture);

            WorkingDays workingDays = new WorkingDays(id, fromTime, toTime, day);

            return workingDays;


        }

        public string ConvertEntityToCSVFormat(WorkingDays entity)
        {

            return string.Join(_delimiter,
             entity.Id,
             entity.Day,
             entity.FromTime.ToString("HH:mm:ss"),
             entity.ToTime.ToString("HH:mm:ss"));
        }
    }
}