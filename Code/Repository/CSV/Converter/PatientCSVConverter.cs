using health_clinicClassDiagram.Model.SystemUsers;
using Model.SystemUsers;
using Repository.Csv.Converter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace health_clinicClassDiagram.Repository.Csv.Converter
{
    class PatientCSVConverter : ICSVConverter<Patient>
    {
        private readonly string _delimiter;

        public PatientCSVConverter(string delimiter)
        {
            _delimiter = delimiter;
        }
        public Patient ConvertCSVFormatToEntity(string entityCSVFormat)
        {
            string[] tokens = entityCSVFormat.Split(_delimiter.ToCharArray());

            String genderString = tokens[4];

            Gender gender = (Gender)Enum.Parse(typeof(Gender), genderString, true);

            return new Patient(tokens[1], tokens[2], long.Parse(tokens[0]), DateTime.Parse(tokens[3]), gender);
        }

        public string ConvertEntityToCSVFormat(Patient entity)
        {
            return string.Join(_delimiter,
              entity.Id,
              entity.Name,
              entity.Surname,
              entity.DateOfBirth,
              entity.Gender);
        }
    }
}
