/***********************************************************************
 * Module:  IWorkingScheduleRepository.cs
 * Purpose: Definition of the Interface Repository.IWorkingScheduleRepository
 ***********************************************************************/

using Model.SystemUsers;
using System;
using System.Collections.Generic;

namespace Repository
{
   public interface IWorkingScheduleRepository : IRepository<WorkingSchedule>
   {
      Model.SystemUsers.WorkingSchedule GetWorkingSchedule(Model.SystemUsers.WorkingSchedule workingSchedule);
        List<WorkingSchedule> GetWorkingSchedulebyDoctor(Model.SystemUsers.Doctor doctor);
    }
}