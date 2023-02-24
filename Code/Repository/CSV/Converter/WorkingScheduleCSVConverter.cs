/***********************************************************************
 * Module:  WorkingScheduleCSVConverter.cs
 * Purpose: Definition of the Class Repository.Csv.Converter.WorkingScheduleCSVConverter
 ***********************************************************************/

using health_clinicClassDiagram.Model.SystemUsers;
using health_clinicClassDiagram.Repository;
using Model.SystemUsers;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;


namespace Repository.Csv.Converter
{
    public class WorkingScheduleCSVConverter : ICSVConverter<WorkingSchedule>
    {
        private readonly string _delimiter;

        public WorkingScheduleCSVConverter(string delimiter)
        {
            _delimiter = delimiter;
        }
        public WorkingSchedule ConvertCSVFormatToEntity(string entityCSVFormat)
        {
            string[] tokens = entityCSVFormat.Split(_delimiter.ToCharArray());

            long id = long.Parse(tokens[0]);

            DateTime from = DateTime.ParseExact(tokens[1], "dd/MM/yyyy", CultureInfo.InvariantCulture);

            DateTime to = DateTime.ParseExact(tokens[2], "dd/MM/yyyy", CultureInfo.InvariantCulture);

            List<WorkingDays> workingDays = new List<WorkingDays>();

            if (tokens[3] != "")
            {
                String dayString = tokens[3];

                String[] oneDay = dayString.Split('|');

                for (int j = 0; j < oneDay.Length; j++)
                {
                    workingDays.Add(WorkingDaysRepository.Instance.GetWorkingDaysById(long.Parse(oneDay[j])));
                }
            }

            WorkingSchedule workingSchedule = new WorkingSchedule(id, from, to, workingDays);
            return workingSchedule;

        }

        public string ConvertEntityToCSVFormat(WorkingSchedule entity)
        {

            String days = "";

            if (entity.WorkingDays.Count != 0)
            {
                WorkingDays last = entity.WorkingDays.Last();
                foreach (WorkingDays treatment in entity.WorkingDays)
                {
                    if (treatment != null)
                    {
                        if (treatment != last)
                        {
                            days += treatment.Id + "|";
                        }
                        else
                        {
                            days += treatment.Id;
                        }
                    }
                }
            }

            return string.Join(_delimiter,
           entity.Id,
           entity.From.ToString("dd/MM/yyyy"),
           entity.To.ToString("dd/MM/yyyy"),
           days);
        }
    }
}