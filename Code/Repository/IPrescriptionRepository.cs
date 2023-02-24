using Model.Treatment;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository
{
    public interface IPrescriptionRepository : IRepository<Prescription>
    {
        Model.Treatment.Prescription GetPrescription(int id);
    }
}
