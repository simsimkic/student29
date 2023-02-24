using health_clinicClassDiagram.Model.SystemUsers;
using Model.SystemUsers;
using Repository.Csv.Converter;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace health_clinicClassDiagram.Repository.Csv.Converter
{
    class SpecialistCSVConverter : ICSVConverter<Specialist>
    {

        private readonly string _delimiter;

        public SpecialistCSVConverter(string delimiter)
        {
            _delimiter = delimiter;
        }

        public Specialist ConvertCSVFormatToEntity(string entityCSVFormat)
        {
            string[] tokens = entityCSVFormat.Split(_delimiter.ToCharArray());

            long id = long.Parse(tokens[0]);
            string name = tokens[1];
            string surname = tokens[2];
            
            string genderString = tokens[3];
            Gender gender = (Gender)Enum.Parse(typeof(Gender), genderString, true);

            DateTime dateOfBirth = DateTime.ParseExact(tokens[4], "dd/MM/yyyy", CultureInfo.InvariantCulture);

            String specializationString = tokens[5];

            Specialization specialization = (Specialization)Enum.Parse(typeof(Specialization), specializationString, true);

            Specialist specialist = new Specialist(id, name, surname, gender, dateOfBirth, specialization);

            return specialist;
        }

        public string ConvertEntityToCSVFormat(Specialist entity)
        {
            return string.Join(_delimiter,
             entity.Id,
             entity.Name,
             entity.Surname,
             entity.Gender,
             entity.DateOfBirth.ToString("dd/MM/yyyy"),
             entity.Specialization);
        }
    }
}
