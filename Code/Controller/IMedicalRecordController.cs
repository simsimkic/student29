/***********************************************************************
 * Module:  IMedicalRecordController.cs
 * Purpose: Definition of the Interface Controller.IMedicalRecordController
 ***********************************************************************/

using Model.Appointment;
using Model.Treatment;
using System;
using System.Collections.Generic;

namespace Controller
{
   public interface IMedicalRecordController : IController<MedicalRecord>
   {
      Model.Appointment.MedicalRecord AddTreatment(Model.Treatment.Treatment treatment, Model.Appointment.MedicalRecord medRec);
      Model.Appointment.MedicalRecord GetMedicalRecordByPatient(Model.SystemUsers.Patient patient);
      MedicalRecord GetMedicalRecordById(long id);
      List<MedicalRecord> GetAllAvailablePatientsForRehabilitation();
    }
}