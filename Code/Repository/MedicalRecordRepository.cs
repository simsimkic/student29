/***********************************************************************
 * Module:  UserRepository.cs
 * Purpose: Definition of the Class Repository.UserRepository
 ***********************************************************************/

using health_clinicClassDiagram.Repository.Sequencer;
using Model.Appointment;
using Model.SystemUsers;
using Model.Treatment;
using Repository.Csv.Converter;
using Repository.Csv.Stream;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Repository
{
   public class MedicalRecordRepository : IMedicalRecordRepository
   {
        private readonly ICSVStream<MedicalRecord> _stream = new CSVStream<MedicalRecord>("../../Resources/Data/records.csv", new MedicalRecordCSVConverter(","));
        private readonly iSequencer<long> _sequencer = new LongSequencer();

        private static MedicalRecordRepository instance = null;

        public static MedicalRecordRepository Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new MedicalRecordRepository();
                }
                return instance;
            }
        }

        private MedicalRecordRepository()
        {
            //InitializeId();
        }

        private long GetMaxId(List<MedicalRecord> records)
        {
            return records.Count() == 0 ? 0 : records.Max(apt => apt.id);
        }

        public MedicalRecord GetMedicalRecordByPatient(Patient patient)
        {
            List<MedicalRecord> medicalRecords = GetAll();
            foreach(MedicalRecord medicalRecord in medicalRecords)
            {
                if(patient.Id == medicalRecord.IDPatient)
                {
                    return medicalRecord;
                }
            }
            return null;
        }

        public MedicalRecord GetMedicalRecordByTreatmentId(long id)
        {
            Treatment treatmentToChange;
            foreach(MedicalRecord medicalRecord in GetAll())
            {
                foreach(Treatment treatment in medicalRecord.Treatments)
                {
                    if (treatment.Id == id)
                    {
                        return medicalRecord;
                    }
                }
            }
            return null;
        }

        public MedicalRecord AddTreatmentToMedicalRecord(MedicalRecord medicalRecord, Treatment treatment)
        {
            medicalRecord.Treatments.Add(treatment);
            Edit(medicalRecord);
            return medicalRecord;
        }

        public MedicalRecord EditTreatmentInMedRec(Treatment treatment, MedicalRecord medicalRecord)
        {
            Treatment treatmentToChange;
            foreach(Treatment oneTreatment in medicalRecord.Treatments)
            {
                if(oneTreatment.Id == treatment.Id)
                {
                    treatmentToChange = oneTreatment;
                }
            }
            treatmentToChange = treatment;
            Edit(medicalRecord);
            return medicalRecord;
        }

        public Treatment GetTreatmentByTreatmentId(long id)
        {
            foreach (MedicalRecord medicalRecord in GetAll())
            {
                foreach (Treatment treatment in medicalRecord.Treatments)
                {
                    if (treatment.Id == id)
                    {
                        return treatment;
                    }
                }
            }
            return null;
        }

        public MedicalRecord Save(MedicalRecord obj)
        {
            //obj.Id = (_sequencer.GenerateId()) + 1;
            _stream.AppendToFile(obj);
            return obj;
        }

        public MedicalRecord Edit(MedicalRecord obj)
        {
            List<MedicalRecord> records = _stream.ReadAll().ToList();
            records[records.FindIndex(apt => apt.id == obj.id)] = obj;
            _stream.SaveAll(records);
            return obj;
        }

        public bool Delete(MedicalRecord obj)
        {
            List<MedicalRecord> records = _stream.ReadAll().ToList();
            MedicalRecord recordToRemove = records.SingleOrDefault(acc => acc.id == obj.id);
            if (recordToRemove != null)
            {
                records.Remove(recordToRemove);
                _stream.SaveAll(records);
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<MedicalRecord> GetAll()
        {
            List<MedicalRecord> records = _stream.ReadAll();
            return records;
        }

        public MedicalRecord GetMedicalRecordById(long id)
        {
            var records = _stream.ReadAll().ToList();
            return records[records.FindIndex(apt => apt.id == id)];

        }

        protected void InitializeId() => _sequencer.Initialize(GetMaxId(_stream.ReadAll()));

    }
}