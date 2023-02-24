/***********************************************************************
 * Module:  IMedicalRecordRepository.cs
 * Purpose: Definition of the Interface Repository.IMedicalRecordRepository
 ***********************************************************************/

using Model.Appointment;
using Model.Treatment;
using System;

namespace Repository
{
   public interface IMedicalRecordRepository : IRepository<MedicalRecord>
   {
      Model.Appointment.MedicalRecord GetMedicalRecordByPatient(Model.SystemUsers.Patient patient);
      Model.Appointment.MedicalRecord GetMedicalRecordByTreatmentId(long id);
      Model.Appointment.MedicalRecord AddTreatmentToMedicalRecord(MedicalRecord medicalRecord, Model.Treatment.Treatment treatment);
      Model.Appointment.MedicalRecord EditTreatmentInMedRec(Model.Treatment.Treatment treatment, Model.Appointment.MedicalRecord medRec);
        Treatment GetTreatmentByTreatmentId(long id);
        MedicalRecord GetMedicalRecordById(long id);
    }
}