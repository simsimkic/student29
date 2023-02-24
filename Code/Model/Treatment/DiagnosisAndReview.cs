/***********************************************************************
 * Module:  Diagnosis.cs
 * Purpose: Definition of the Class Treatment.Diagnosis
 ***********************************************************************/

using System;

namespace Model.Treatment
{
   public class DiagnosisAndReview
   {
        private string diagnosis;
        private string review;

        public string Diagnosis { get => diagnosis; set => diagnosis = value; }
        public string Review { get => review; set => review = value; }

        public DiagnosisAndReview(string diagnosis, string review)
        {
            Diagnosis = diagnosis;
            Review = review;
        }

        public DiagnosisAndReview()
        {
            Diagnosis = "";
            Review = "";
        }

    }
}