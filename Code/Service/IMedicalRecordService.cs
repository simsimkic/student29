/***********************************************************************
 * Module:  IMedicalRecordService.cs
 * Purpose: Definition of the Interface Service.IMedicalRecordService
 ***********************************************************************/

using Model.Appointment;
using System;
using System.Collections.Generic;

namespace Service
{
   public interface IMedicalRecordService : IService<MedicalRecord>
   {
      Model.Appointment.MedicalRecord AddTreatment(Model.Treatment.Treatment treatment, Model.Appointment.MedicalRecord medRec);
      Model.Appointment.MedicalRecord GetMedicalRecordByPatient(Model.SystemUsers.Patient patient);
      MedicalRecord GetMedicalRecordById(long id);
      List<MedicalRecord> GetAllAvailablePatientsForRehabilitation();
    }
}