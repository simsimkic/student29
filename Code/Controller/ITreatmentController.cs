/***********************************************************************
 * Module:  ITreatmentController.cs
 * Purpose: Definition of the Interface Controller.ITreatmentController
 ***********************************************************************/

using health_clinicClassDiagram.Model.Treatment;
using Model.Rooms;
using Model.SystemUsers;
using Model.Treatment;
using System;
using System.Collections.Generic;

namespace Controller
{
   public interface ITreatmentController
   {
        Treatment Create(Patient patient, Treatment obj);
        Treatment Edit(Treatment obj);
        Boolean Delete(Treatment obj);
        List<Treatment> GetAll();
        Model.Treatment.Prescription WritePrescription(List<Drug> drugs, Model.Treatment.Treatment treatment);
        SpecialistAppointment ScheduleSpecialistAppointment(Doctor specialist, String cause, Treatment treatment, ExamOperationRoom room, DateTime startDate, DateTime endDate);
        Model.Treatment.ScheduledSurgery ScheduleSurgery(Model.Treatment.Treatment treatment, DateTime startDate, DateTime endDate, String cause, Surgeon surgeon, ExamOperationRoom room);
        Model.Treatment.DiagnosisAndReview WriteDiagnosisAndReview(Model.Treatment.Treatment treatment, String diagnosis, String review);
        Model.Treatment.ReferralToHospitalTreatment WriteReferralToHospitalTreatment(Model.Treatment.Treatment treatment, DateTime startDate, DateTime endDate, String cause, List<Drug> drugs, RehabilitationRoom room);
        Model.Appointment.Appointment ScheduleControlAppointment(Model.Appointment.Appointment appointment);
        Treatment GetTreatment(Treatment obj);
        List<Drug> GetDrugsByDate(DateTime startDate, DateTime endDate);
    }
}