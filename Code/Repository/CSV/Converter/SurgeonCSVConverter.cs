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
    class SurgeonCSVConverter : ICSVConverter<Surgeon>
    {

        private readonly string _delimiter;

        public SurgeonCSVConverter(string delimiter)
        {
            _delimiter = delimiter;
        }

        public Surgeon ConvertCSVFormatToEntity(string entityCSVFormat)
        {
            string[] tokens = entityCSVFormat.Split(_delimiter.ToCharArray());

            long id = long.Parse(tokens[0]);
            string name = tokens[1];
            string surname = tokens[2];

            string genderString = tokens[3];
            Gender gender = (Gender)Enum.Parse(typeof(Gender), genderString, true);

            DateTime dateOfBirth = DateTime.ParseExact(tokens[4], "dd/MM/yyyy", CultureInfo.InvariantCulture);

            String specializationString = tokens[5];

            SurgicalSpecialty surgicalSpecialty = (SurgicalSpecialty)Enum.Parse(typeof(SurgicalSpecialty), specializationString, true);

            Surgeon surgeon = new Surgeon(id, name, surname, gender, dateOfBirth, surgicalSpecialty);

            return surgeon;
        }

        public string ConvertEntityToCSVFormat(Surgeon entity)
        {
            return string.Join(_delimiter,
             entity.Id,
             entity.Name,
             entity.Surname,
             entity.Gender,
             entity.DateOfBirth.ToString("dd/MM/yyyy"),
             entity.SurgicalSpecialty);
        }
    }
}
