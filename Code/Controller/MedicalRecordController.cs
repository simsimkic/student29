/***********************************************************************
 * Module:  MedicalRecordService.cs
 * Purpose: Definition of the Class Service.MedicalRecordService
 ***********************************************************************/

using Model.Appointment;
using Model.SystemUsers;
using Model.Treatment;
using Service;
using System;
using System.Collections.Generic;

namespace Controller
{
   public class MedicalRecordController : IMedicalRecordController
   {
        private static MedicalRecordController instance;
        public static MedicalRecordController Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new MedicalRecordController();
                }
                return instance;
            }
        }

        private readonly IMedicalRecordService _service = MedicalRecordService.Instance;

        private MedicalRecordController()
        {

        }


        public MedicalRecord AddTreatment(Treatment treatment, MedicalRecord medicalRecord)
        {
            return MedicalRecordService.Instance.AddTreatment(treatment, medicalRecord);
        }

        public MedicalRecord GetMedicalRecordByPatient(Patient patient)
        {
            MedicalRecord record = _service.GetMedicalRecordByPatient(patient);
            return record;
        }

        public List<MedicalRecord> GetAll()
        {
            List<MedicalRecord> records = (List<MedicalRecord>)_service.GetAll();
            return records;
        }

        public bool Delete(MedicalRecord obj)
        {
            return _service.Delete(obj);
        }

        public MedicalRecord Create(MedicalRecord obj)
        {
            return _service.Create(obj);
        }

        public MedicalRecord Edit(MedicalRecord obj)
        {
            return _service.Edit(obj);
        }

        public MedicalRecord GetMedicalRecordById(long id)
        {
            return _service.GetMedicalRecordById(id);
        }

        public List<MedicalRecord> GetAllAvailablePatientsForRehabilitation()
        {
            return _service.GetAllAvailablePatientsForRehabilitation();
        }

    }
}