/***********************************************************************
 * Module:  TreatmentCSVConverter.cs
 * Purpose: Definition of the Class Repository.Csv.Converter.TreatmentCSVConverter
 ***********************************************************************/

using health_clinicClassDiagram.Model.Treatment;
using health_clinicClassDiagram.Repository;
using Model.Rooms;
using Model.SystemUsers;
using Model.Treatment;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace Repository.Csv.Converter
{
   public class TreatmentCSVConverter : ICSVConverter<Treatment>
   {
      private String Delimiter;

        public TreatmentCSVConverter(string delimiter)
        {
            Delimiter = delimiter;
        }

        public Treatment ConvertCSVFormatToEntity(string entityCSVFormat)
        {
            string[] tokens = entityCSVFormat.Split(Delimiter.ToCharArray());
            long id = long.Parse(tokens[0]);

            string doctorId = tokens[1];
            Doctor doctor = DoctorRepository.Instance.GetDoctorById(long.Parse(doctorId));

            DateTime startDate = DateTime.ParseExact(tokens[2], "dd/MM/yyyy hh:mm", CultureInfo.InvariantCulture);
            DateTime endDate = DateTime.ParseExact(tokens[3], "dd/MM/yyyy hh:mm", CultureInfo.InvariantCulture);

            List<Drug> prescriptionDrugs = new List<Drug>();
            string prescriptionDrugString = tokens[4];
            string[] prescriptionDrugParts = prescriptionDrugString.Split('|');
            if (!prescriptionDrugString.Equals(""))
            {
                foreach (string drugID in prescriptionDrugParts)
                {
                    Drug drug = DrugRepository.Instance.GetDrugById(long.Parse(drugID));
                    prescriptionDrugs.Add(drug);
                }
            }
            Prescription prescription = new Prescription(prescriptionDrugs);

            ScheduledSurgery scheduledSurgery = new ScheduledSurgery();
            if (!tokens[5].Equals(""))
            {
                DateTime surgeryStartDate = DateTime.ParseExact(tokens[5], "dd/MM/yyyy hh:mm", CultureInfo.InvariantCulture);
                DateTime surgeryEndDate = DateTime.ParseExact(tokens[6], "dd/MM/yyyy hh:mm", CultureInfo.InvariantCulture);
                string causeForSurgery = tokens[7];
                Surgeon surgeon = SurgeonRepository.Instance.GetSurgeonById(long.Parse(tokens[8]));
                scheduledSurgery = new ScheduledSurgery(surgeryStartDate, surgeryEndDate, causeForSurgery, surgeon);
            }

            Specialist specialist = SpecialistRepository.Instance.GetSpecialistById(long.Parse(tokens[9]));
            string causeForSpecialistAppointment = tokens[10];
            SpecialistAppointment specialistAppointment = new SpecialistAppointment(causeForSpecialistAppointment, specialist);

            string causeForHospitalTreatment = tokens[11];
            List<Drug> hospitalTreatmentDrugs = new List<Drug>();
            string hospitalTreatmentDrugsString = tokens[12];
            string[] hospitalTreatmentDrugsParts = hospitalTreatmentDrugsString.Split('|');
            if (!hospitalTreatmentDrugsString.Equals(""))
            {
                foreach (string drugID in hospitalTreatmentDrugsParts)
                {
                    Drug drug = DrugRepository.Instance.GetDrugById(long.Parse(drugID));
                    hospitalTreatmentDrugs.Add(drug);
                }
            }
            ReferralToHospitalTreatment referralToHospitalTreatment = new ReferralToHospitalTreatment(causeForHospitalTreatment, hospitalTreatmentDrugs);

            string diagnosis = tokens[13];
            string review = tokens[14];
            DiagnosisAndReview diagnosisAndReview = new DiagnosisAndReview(diagnosis, review);

            return new Treatment(prescription, scheduledSurgery, diagnosisAndReview, referralToHospitalTreatment, startDate, endDate, id, doctor, specialistAppointment);
        }

        public string ConvertEntityToCSVFormat(Treatment entity)
        {
            string id = entity.Id.ToString();
            string doctorId = entity.Doctor.Id.ToString();           
            string startDate = entity.FromDate.ToString("dd/MM/yyyy hh:mm");
            string endDate = entity.EndDate.ToString("dd/MM/yyyy hh:mm");
            string prescription = "";
            foreach (Drug drug in entity.Prescription.Drugs)
            {
                if(entity.Prescription.Drugs.IndexOf(drug) == entity.Prescription.Drugs.Count - 1)
                {
                    prescription += drug.Id;
                }
                else
                {
                    prescription += drug.Id + "|";
                }
            }
            string scheduledSurgery = "";
            if (entity.ScheduledSurgery.StartDate == new DateTime() || entity.ScheduledSurgery.EndDate == new DateTime())
            {
                 scheduledSurgery = "" + "," + "" + "," + entity.ScheduledSurgery.CauseForOperation + "," + "";
            }
            else
            {
                scheduledSurgery = entity.ScheduledSurgery.StartDate.ToString("dd/MM/yyyy hh:mm") + "," + entity.ScheduledSurgery.EndDate.ToString("dd/MM/yyyy hh:mm") + "," + entity.ScheduledSurgery.CauseForOperation + "," + entity.ScheduledSurgery.Surgeon.Id;
            }
            string specialistAppointment = entity.SpecialistAppointment.Doctor.Id + "," + entity.SpecialistAppointment.Cause;
            string referralToAHospitalTreatment = entity.ReferralToHospitalTreatment.CauseForHospitalTreatment + ",";
            string hospitalTreatmentDrugs = "";
            foreach (Drug drug in entity.ReferralToHospitalTreatment.Drugs)
            {
                if (entity.ReferralToHospitalTreatment.Drugs.IndexOf(drug) == entity.ReferralToHospitalTreatment.Drugs.Count - 1)
                {
                    hospitalTreatmentDrugs += drug.Id;
                }
                else
                {
                    hospitalTreatmentDrugs += drug.Id + "|";
                }
            }
            referralToAHospitalTreatment += hospitalTreatmentDrugs;
            string diagnosisAndReview = entity.DiagnosisAndReview.Diagnosis + "," + entity.DiagnosisAndReview.Review;
            return string.Join(Delimiter, id, doctorId, startDate, endDate, prescription, scheduledSurgery, specialistAppointment, referralToAHospitalTreatment, diagnosisAndReview);
        }
    }
}