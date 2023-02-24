using health_clinicClassDiagram.Repository;
using Model.SystemUsers;
using Repository;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace health_clinicClassDiagram.Service
{
    public class WorkingDaysService : IService<WorkingDays>
    {


        private readonly IRepository<WorkingDays> _workingDaysRepository = WorkingDaysRepository.Instance;

        private static WorkingDaysService instance;

        public static WorkingDaysService Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new WorkingDaysService();
                }
                return instance;
            }
        }

        private WorkingDaysService()
        {
        }

        public WorkingDays Create(WorkingDays obj)
        {
            WorkingDays newWorkingDays = _workingDaysRepository.Save(obj);
            return newWorkingDays;
        }

        public bool Delete(WorkingDays obj)
        {
            return _workingDaysRepository.Delete(obj);
        }

        public WorkingDays Edit(WorkingDays obj)
        {
            return _workingDaysRepository.Edit(obj);
        }

        public List<WorkingDays> GetAll()
        {
            List<WorkingDays> allWorkingDays = _workingDaysRepository.GetAll();
            return allWorkingDays;
        }
    }
}