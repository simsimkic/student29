/***********************************************************************
 * Module:  TreatmentService.cs
 * Purpose: Definition of the Class Service.TreatmentService
 ***********************************************************************/

using Controller;
using health_clinicClassDiagram.Model.Treatment;
using health_clinicClassDiagram.Repository;
using health_clinicClassDiagram.Service;
using Model.Appointment;
using Model.Rooms;
using Model.SystemUsers;
using Model.Treatment;
using Repository;
using System;
using System.Collections.Generic;

namespace Service
{
   public class TreatmentService : ITreatmentService
   {
        public Repository.ITreatmentRepository iTreatmentRepository;

        private static TreatmentService instance = null;

        private TreatmentService()
        {
        }

        public static TreatmentService Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new TreatmentService();
                }
                return instance;
            }
        }

        public Prescription WritePrescription(List<Drug> drugs, Treatment treatment)
        {
            Prescription prescription = new Prescription(drugs);
            treatment.Prescription = prescription;
            return treatment.Prescription;
        }

        public SpecialistAppointment ScheduleSpecialistAppointment(Doctor specialist, String cause, Treatment treatment, ExamOperationRoom room, DateTime startDate, DateTime endDate)
        {
            SpecialistAppointment specialistAppointment = new SpecialistAppointment(cause, specialist);
            treatment.SpecialistAppointment = specialistAppointment;
            MedicalRecord medicalRecord = MedicalRecordRepository.Instance.GetMedicalRecordByTreatmentId(treatment.Id);
            Patient patient = medicalRecord.Patient;
            Appointment appointment = new Appointment(specialist, patient, room, TypeOfAppointment.EXAM, startDate, endDate);
            AppointmentRepository.Instance.Save(appointment);
            return treatment.SpecialistAppointment;
        }

        public ScheduledSurgery ScheduleSurgery(Treatment treatment, DateTime startDate, DateTime endDate, string cause, Surgeon surgeon, ExamOperationRoom room)
        {
            ScheduledSurgery scheduledSurgery = new ScheduledSurgery(startDate, endDate, cause, surgeon);
            treatment.ScheduledSurgery = scheduledSurgery;
            MedicalRecord medicalRecord = MedicalRecordRepository.Instance.GetMedicalRecordByTreatmentId(treatment.Id);
            Patient patient = medicalRecord.Patient;
            Appointment surgery = new Appointment(surgeon, patient, room,TypeOfAppointment.SURGERY, startDate, endDate);
            AppointmentRepository.Instance.Save(surgery);
            return treatment.ScheduledSurgery;
        }

        public DiagnosisAndReview WriteDiagnosisAndReview(Treatment treatment, string diagnosis, string review)
        {
            DiagnosisAndReview diagnosisAndReview = new DiagnosisAndReview(diagnosis, review);
            treatment.DiagnosisAndReview = diagnosisAndReview;
            return treatment.DiagnosisAndReview;
        }

        public ReferralToHospitalTreatment WriteReferralToHospitalTreatment(Treatment treatment, DateTime startDate, DateTime endDate, string cause, List<Drug> drugs, RehabilitationRoom room)
        {
            ReferralToHospitalTreatment referralToHospitalTreatment = new ReferralToHospitalTreatment(cause, drugs);
            treatment.ReferralToHospitalTreatment = referralToHospitalTreatment;
            MedicalRecord medicalRecord = MedicalRecordRepository.Instance.GetMedicalRecordByTreatmentId(treatment.Id);
            RehabilitationRoomService.Instance.AddPatient(medicalRecord, room);
            return treatment.ReferralToHospitalTreatment;
        }

        public Appointment ScheduleControlAppointment(Appointment appointment)
        {
            return AppointmentRepository.Instance.Save(appointment);
        }

        public Treatment Create(Patient patient, Treatment obj)
        {
            MedicalRecordRepository.Instance.AddTreatmentToMedicalRecord(MedicalRecordRepository.Instance.GetMedicalRecordByPatient(patient), obj);
            return TreatmentRepository.Instance.Save(obj);
        }

        public Treatment Edit(Treatment obj)
        {
            MedicalRecord medicalRecord = MedicalRecordRepository.Instance.GetMedicalRecordByTreatmentId(obj.Id);
            MedicalRecordRepository.Instance.EditTreatmentInMedRec(obj, medicalRecord);
            return obj;
        }

        public bool Delete(Treatment obj)
        {
            MedicalRecord medicalRecord = MedicalRecordRepository.Instance.GetMedicalRecordByTreatmentId(obj.Id);
            MedicalRecordRepository.Instance.EditTreatmentInMedRec(null, medicalRecord);
            return true;
        }

        public List<Treatment> GetAll()
        {
            return TreatmentRepository.Instance.GetAll();
        }


        public Treatment GetTreatment(Treatment obj)
        {
            return TreatmentRepository.Instance.GetTreatment(obj.Id);
        }

        public List<Drug> GetDrugsByDate(DateTime startDate, DateTime endDate)
        {
            List<Drug> drugs = new List<Drug>();

            foreach (Treatment treatment in GetAll())
            {
                if (treatment.FromDate >= startDate && treatment.EndDate <= endDate)
                {
                    drugs.AddRange(treatment.Prescription.Drugs);
                    drugs.AddRange(treatment.ReferralToHospitalTreatment.Drugs);
                }
            }
            return drugs;
        }
    }
}