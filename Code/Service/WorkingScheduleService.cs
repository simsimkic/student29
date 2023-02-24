/***********************************************************************
 * Module:  WorkingScheduleService.cs
 * Purpose: Definition of the Class Service.WorkingScheduleService
 ***********************************************************************/

using Model.SystemUsers;
using Repository;
using System;
using System.Collections.Generic;

namespace Service
{
    public class WorkingScheduleService : IService<WorkingSchedule>
    {
        public readonly IRepository<WorkingSchedule> _workingScheduleRepository = WorkingScheduleRepository.Instance;

        private static WorkingScheduleService instance;

        public static WorkingScheduleService Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new WorkingScheduleService();
                }
                return instance;
            }
        }

        private WorkingScheduleService()
        {
        }

        public WorkingSchedule Create(WorkingSchedule obj)
        {
            WorkingSchedule newWorkSc = _workingScheduleRepository.Save(obj);

            return newWorkSc;
        }

        public WorkingSchedule Edit(WorkingSchedule obj)
        {
            return _workingScheduleRepository.Edit(obj);
        }

        public bool Delete(WorkingSchedule obj)
        {
            return _workingScheduleRepository.Delete(obj);
        }

        public List<WorkingSchedule> GetAll()
        {
            List<WorkingSchedule> workingSchedules = _workingScheduleRepository.GetAll();
            return workingSchedules;
        }


    }
}