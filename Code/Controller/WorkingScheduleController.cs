/***********************************************************************
 * Module:  WorkingScheduleService.cs
 * Purpose: Definition of the Class Service.WorkingScheduleService
 ***********************************************************************/

using Model.SystemUsers;
using Service;
using System;
using System.Collections.Generic;

namespace Controller
{
   public class WorkingScheduleController : IController<WorkingSchedule>
   {
        public WorkingScheduleService _service = WorkingScheduleService.Instance;

        private static WorkingScheduleController instance;

        public static WorkingScheduleController Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new WorkingScheduleController();
                }
                return instance;
            }
        }

        private WorkingScheduleController()
        {
        }

        public List<WorkingSchedule> GetAll()
        {
            List<WorkingSchedule> workingSchedules = (List<WorkingSchedule>)_service.GetAll();
            return workingSchedules;
        }

        public bool Delete(WorkingSchedule obj)
        {
            return _service.Delete(obj);
        }

        public WorkingSchedule Create(WorkingSchedule obj)
        {
            return _service.Create(obj);
        }

        public WorkingSchedule Edit(WorkingSchedule obj)
        {
            return _service.Edit(obj);
        }


    }
}