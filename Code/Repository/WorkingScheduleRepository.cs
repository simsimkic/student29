/***********************************************************************
 * Module:  UserRepository.cs
 * Purpose: Definition of the Class Repository.UserRepository
 ***********************************************************************/

using health_clinicClassDiagram.Repository.Sequencer;
using Model.SystemUsers;
using Repository.Csv.Converter;
using Repository.Csv.Stream;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Repository
{
    public class WorkingScheduleRepository : IWorkingScheduleRepository
    {
        private static WorkingScheduleRepository instance = null;
        private readonly ICSVStream<WorkingSchedule> _stream = new CSVStream<WorkingSchedule>("../../Resources/Data/workingSchedules.csv", new WorkingScheduleCSVConverter(","));
        private readonly iSequencer<long> _sequencer = new LongSequencer();

        public static WorkingScheduleRepository Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new WorkingScheduleRepository();
                }
                return instance;
            }
        }

        private WorkingScheduleRepository()
        {
            //InitializeId();
        }

        private long GetMaxId(List<WorkingSchedule> list)
        {
            return list.Count() == 0 ? 0 : list.Max(li => li.Id);
        }

        public WorkingSchedule GetWorkingSchedule(WorkingSchedule workingSchedule)
        {
            throw new NotImplementedException();
        }

        public WorkingSchedule Save(WorkingSchedule obj)
        {
            //obj.Id = _sequencer.GenerateId();
            _stream.AppendToFile(obj);
            return obj;
        }

        public WorkingSchedule Edit(WorkingSchedule obj)
        {
            List<WorkingSchedule> workingSchedules = _stream.ReadAll().ToList();
            workingSchedules[workingSchedules.FindIndex(li => li.Id == obj.Id)] = obj;
            _stream.SaveAll(workingSchedules);

            return obj;
        }

        public bool Delete(WorkingSchedule obj)
        {
            List<WorkingSchedule> workingSchedules = _stream.ReadAll().ToList();
            WorkingSchedule workingScheduleToRemove = workingSchedules.SingleOrDefault(li => li.Id == obj.Id);

            if (workingScheduleToRemove != null)
            {
                workingSchedules.Remove(workingScheduleToRemove);
                _stream.SaveAll(workingSchedules);
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<WorkingSchedule> GetAll()
        {
            List<WorkingSchedule> workingSchedules = (List<WorkingSchedule>)_stream.ReadAll();
            return workingSchedules;
        }

        public List<WorkingSchedule> GetWorkingSchedulebyDoctor(Doctor doctor)
        {
            throw new NotImplementedException();
        }

        public WorkingSchedule GetWorkingShceduleById(long id)
        {
            var workingSchedukes = _stream.ReadAll().ToList();
            return workingSchedukes[workingSchedukes.FindIndex(apt => apt.Id == id)];
        }
        protected void InitializeId() => _sequencer.Initialize(GetMaxId(_stream.ReadAll()));

    }
}