using Model.SystemUsers;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace health_clinicClassDiagram.Repository
{
    public interface IPatientRepository : IRepository<Patient>
    {
        Patient GetPatientById(long id);
    }
}
