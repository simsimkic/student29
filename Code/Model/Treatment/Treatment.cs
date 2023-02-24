/***********************************************************************
 * Module:  Treatment.cs
 * Purpose: Definition of the Class Treatment.Treatment
 ***********************************************************************/

using health_clinicClassDiagram.Model.Treatment;
using Model.SystemUsers;
using System;

namespace Model.Treatment
{
   public class Treatment
   {
        /// <pdGenerated>default getter</pdGenerated>

        private Prescription prescription;
        private ScheduledSurgery scheduledSurgery;
        private DiagnosisAndReview diagnosisAndReview;
        private ReferralToHospitalTreatment referralToHospitalTreatment;
        private Model.SystemUsers.Doctor doctor;
        private SpecialistAppointment specialistAppointment;

        private DateTime startDate;
        private DateTime endDate;
        private long id;

        public Treatment(Prescription prescription, ScheduledSurgery scheduledSurgery, DiagnosisAndReview diagnosisAndReview, ReferralToHospitalTreatment referralToHospitalTreatment, DateTime fromDate, DateTime endDate, long id, Doctor doctor)
        {
            Prescription = prescription;
            ScheduledSurgery = scheduledSurgery;
            DiagnosisAndReview = diagnosisAndReview;
            ReferralToHospitalTreatment = referralToHospitalTreatment;
            FromDate = fromDate;
            EndDate = endDate;
            Id = id;
            Doctor = doctor;
        }

        public Treatment(Prescription prescription, ScheduledSurgery scheduledSurgery, DiagnosisAndReview diagnosisAndReview, ReferralToHospitalTreatment referralToHospitalTreatment, DateTime fromDate, DateTime endDate, Doctor doctor)
        {
            Prescription = prescription;
            ScheduledSurgery = scheduledSurgery;
            DiagnosisAndReview = diagnosisAndReview;
            ReferralToHospitalTreatment = referralToHospitalTreatment;
            FromDate = fromDate;
            EndDate = endDate;
            Doctor = doctor;
        }

        public Treatment(DateTime fromDate, DateTime endDate)
        {
            FromDate = fromDate;
            EndDate = endDate;
        }

        public Treatment()
        {
            Prescription = new Prescription();
            ScheduledSurgery = new ScheduledSurgery();
            DiagnosisAndReview = new DiagnosisAndReview();
            ReferralToHospitalTreatment = new ReferralToHospitalTreatment();
            FromDate = DateTime.Now;
            EndDate = DateTime.Now;
            Id = 0;
            Doctor = new Doctor();
        }

        public Treatment(Prescription prescription, ScheduledSurgery scheduledSurgery, DiagnosisAndReview diagnosisAndReview, ReferralToHospitalTreatment referralToHospitalTreatment, DateTime fromDate, DateTime endDate, long id, Doctor doctor, SpecialistAppointment specialistAppointment) : this(prescription, scheduledSurgery, diagnosisAndReview, referralToHospitalTreatment, fromDate, endDate, id, doctor)
        {
            SpecialistAppointment = specialistAppointment;
        }

        public Prescription Prescription { get => prescription; set => prescription = value; }
        public ScheduledSurgery ScheduledSurgery { get => scheduledSurgery; set => scheduledSurgery = value; }
        public DiagnosisAndReview DiagnosisAndReview { get => diagnosisAndReview; set => diagnosisAndReview = value; }
        public ReferralToHospitalTreatment ReferralToHospitalTreatment { get => referralToHospitalTreatment; set => referralToHospitalTreatment = value; }
        public DateTime FromDate { get => startDate; set => startDate = value; }
        public DateTime EndDate { get => endDate; set => endDate = value; }
        public long Id { get => id; set => id = value; }
        public Doctor Doctor { get => doctor; set => doctor = value; }
        public SpecialistAppointment SpecialistAppointment { get => specialistAppointment; set => specialistAppointment = value; }

        public long GetId() => Id;

        public void SetId(long id) => Id = id;
    }
}