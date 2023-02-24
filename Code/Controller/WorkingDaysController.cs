using Controller;
using health_clinicClassDiagram.Service;
using Model.SystemUsers;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace health_clinicClassDiagram.Controller
{
    public class WorkingDaysController : IController<WorkingDays>
    {
        private static WorkingDaysController instance;

        private readonly IService<WorkingDays> _service = WorkingDaysService.Instance;

        public static WorkingDaysController Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new WorkingDaysController();
                }
                return instance;
            }
        }

        private WorkingDaysController() { }

        public WorkingDays Create(WorkingDays obj)
        {
            return _service.Create(obj);
        }

        public bool Delete(WorkingDays obj)
        {
            return _service.Delete(obj);
        }

        public WorkingDays Edit(WorkingDays obj)
        {
            return _service.Edit(obj);
        }

        public List<WorkingDays> GetAll()
        {
            List<WorkingDays> workingDays = (List<WorkingDays>)_service.GetAll();
            return workingDays;
        }

    }
}
