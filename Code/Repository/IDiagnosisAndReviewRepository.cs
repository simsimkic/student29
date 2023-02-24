using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model.Treatment;

namespace Repository
{
    public interface IDiagnosisAndReviewRepository : IRepository<DiagnosisAndReview>
    {
        DiagnosisAndReview GetDiagnosisAndReview(int id);
    }
}
