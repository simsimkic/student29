/***********************************************************************
 * Module:  MedicalRecordCSVConverter.cs
 * Purpose: Definition of the Class Repository.Csv.Converter.MedicalRecordCSVConverter
 ***********************************************************************/

using health_clinicClassDiagram.Model.SystemUsers;
using health_clinicClassDiagram.Repository;
using Model.Appointment;
using Model.SystemUsers;
using Model.Treatment;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Repository.Csv.Converter
{
   public class MedicalRecordCSVConverter : ICSVConverter<MedicalRecord>
   {

        private readonly string _delimiter;

        public MedicalRecordCSVConverter(string delimiter)
        {
            _delimiter = delimiter;
        }

        public MedicalRecord ConvertCSVFormatToEntity(string entityCSVFormat)
        {
            string[] tokens = entityCSVFormat.Split(_delimiter.ToCharArray());

            var doctorRepository = DoctorRepository.Instance;
            var patientRepository = PatientRepository.Instance;

            Doctor doctor = doctorRepository.GetDoctorById(long.Parse(tokens[2]));
            Patient patient = patientRepository.GetPatientById(long.Parse(tokens[1]));
            List<Treatment> treatments = new List<Treatment>();

            if (tokens[3] != "")
            {
                String treatmentsString = tokens[3];

                String[] oneTreatment = treatmentsString.Split('|');

                for (int j = 0; j < oneTreatment.Length; j++)
                {
                    treatments.Add(TreatmentRepository.Instance.GetTreatment(long.Parse(oneTreatment[j])));
                }
            }



            return new MedicalRecord(
                long.Parse(tokens[0]),
                patient,
                doctor,
                treatments);
        }

        public string ConvertEntityToCSVFormat(MedicalRecord entity)
        {

            String treatments = "";

            if (entity.Treatments.Count != 0)
            {
                Treatment last = entity.Treatments.Last();
                foreach (Treatment treatment in entity.Treatments)
                {
                    if (treatment != null)
                    {
                        if (treatment != last)
                        {
                            treatments += treatment.Id + "|";
                        }
                        else
                        {
                            treatments += treatment.Id;
                        }
                    }
                }
            }

            return string.Join(_delimiter,
              entity.id,
              entity.Patient.Id,
              entity.choosenDoctor.Id,
              treatments);

        }
    }

}