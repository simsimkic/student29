using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model.Rooms;
using Model.Treatment;
using Repository;
using Model.SystemUsers;
using Model.Surveys;
using Controller;
using health_clinicClassDiagram.Repository;
using health_clinicClassDiagram.Model.Treatment;
using health_clinicClassDiagram.Controller;
using Service;

namespace health_clinicClassDiagram
{
    public static class MainClass
    {
        static void Main()
         {/*
                         DiagnosisAndReview diagnosisAndReview = new DiagnosisAndReview("Nova dijagnoza", "Nova procedura");
                         DiagnosisAndReview diagnosisAndReview2 = new DiagnosisAndReview("Nova dijagnoza2", "Nova procedura2");
                         DiagnosisAndReviewRepository.Instance.Save(diagnosisAndReview);
                         DiagnosisAndReviewRepository.Instance.Save(diagnosisAndReview2);
                         //            DiagnosisAndReviewRepository.Instance.Delete(2);
                         List<DiagnosisAndReview> diagnosisAndReviews =  DiagnosisAndReviewRepository.Instance.GetAll();
                         Console.WriteLine("Lista dijagnoza:");
                         foreach (DiagnosisAndReview dAndR in diagnosisAndReviews)
                         {
                             Console.WriteLine(dAndR);
                         }
             //            Console.WriteLine("Dijagnoza id == 3:" + DiagnosisAndReviewRepository.Instance.GetDiagnosisAndReview(3).Id);

                         Drug drug1 = new Drug(null, "Panklav 200mg", "Opis Panklava", true, 20);
                         Drug drug2 = new Drug(null, "Aerius 50mg", "Opis Aeriusa", false, 5);
                         List<Drug> drugs = new List<Drug>();
                         drugs.Add(drug1);
                         drugs.Add(drug2);

                         Prescription prescription = new Prescription(drugs);
                         PrescriptionRepository.Instance.Save(prescription);
                         List<Prescription> prescriptions = PrescriptionRepository.Instance.GetAll();
                         PrescriptionRepository.Instance.Delete(3);
                         foreach (Prescription p in prescriptions)
                         {
                             Console.WriteLine(p);
                         }
                     }

             DiagnosisAndReview diagnosisAndReview = new DiagnosisAndReview("Nova dijagnoza", "Nova procedura");
             Drug drug1 = new Drug(null, "Panklav 200mg", "Opis Panklava", true, 20);
             Drug drug2 = new Drug(null, "Aerius 50mg", "Opis Aeriusa", false, 5);
             List<Drug> drugs = new List<Drug>();
             drugs.Add(drug1);
             drugs.Add(drug2);
             Prescription prescription = new Prescription(drugs);
             Treatment treatment = new Treatment(prescription, new ScheduledSurgery(DateTime.Today, DateTime.Now, "Razlog operacije", new Surgeon("Pera", "Peric", SurgicalSpecialty.CARDIOTHORACIC)), diagnosisAndReview, new ReferralToHospitalTreatment(DateTime.Today, DateTime.Now, "Razlog bolnickog lecenja"), DateTime.Today, DateTime.Now, new Doctor("Marko", "Markovic"));
             TreatmentRepository.Instance.Save(treatment);
         */
            /*            Blog blog1 = new Blog("naslov 1", "blablbalblalba", DateTime.Now);
                        Blog blog2 = new Blog("naslov 2", "blablbalblalba", DateTime.Now.AddHours(2));
                        BlogController.Instance.Create(blog1);
                        BlogController.Instance.Create(blog2);
                        BlogController.Instance.GetBlogByTitle("naslov 1");
                        BlogController.Instance.Delete(blog1);
                        blog2.Text = "Promenjen text";
                        BlogController.Instance.Edit(blog2);*/
            Drug drug1 = new Drug(213, null, "Panklav 200mg", "Opis Panklava", true, 20);
            Drug drug2 = new Drug(312, null, "Aerius 50mg", "Opis Aeriusa", false, 5);
            List<Drug> drugs = new List<Drug>();
            drugs.Add(drug1);
            drugs.Add(drug2);
            DrugRepository.Instance.Save(drug1);
            DrugRepository.Instance.Save(drug2);

            Doctor doctor = new Doctor(123, "Marko", "Markovic", Model.SystemUsers.Gender.MALE, DateTime.Now);
            DoctorController.Instance.Create(doctor);
//            DoctorRepository.Instance.Save(doctor);

            DateTime startDate = DateTime.Now;
            DateTime endDate = DateTime.Now.AddDays(1);

            Prescription prescription = new Prescription(drugs);

            Surgeon surgeon = new Surgeon(222, "Pera", "Peric", Model.SystemUsers.Gender.FEMALE, DateTime.Now, SurgicalSpecialty.CARDIOTHORACIC);
            SurgeonController.Instance.Create(surgeon);
 //           SurgeonRepository.Instance.Save(surgeon);
            ScheduledSurgery scheduledSurgery = new ScheduledSurgery(startDate, endDate, "Razlog za operaciju", surgeon);

            Specialist specialist = new Specialist(333, "Ana", "Jovanovic", Model.SystemUsers.Gender.FEMALE, DateTime.Now, Specialization.ENDOCRINOLOGY);
            SpecialistController.Instance.Create(specialist);
//            SpecialistRepository.Instance.Save(specialist);
            SpecialistAppointment specialistAppointment = new SpecialistAppointment("Razlog za specijalistu", specialist);

            ReferralToHospitalTreatment referralToHospitalTreatment = new ReferralToHospitalTreatment("Razlog za bolnicko lecenje", drugs);

            DiagnosisAndReview diagnosisAndReview = new DiagnosisAndReview("Dijagnoza", "Procedura");

            Patient patient = new Patient("Sima", "Simic", 345);
            Treatment treatment = new Treatment(prescription, scheduledSurgery, diagnosisAndReview, referralToHospitalTreatment, startDate, endDate, 23, doctor, specialistAppointment);
//            TreatmentController.Instance.Create(patient, treatment);
            TreatmentRepository.Instance.Save(treatment);

            Treatment treatment2 = new Treatment(prescription, new ScheduledSurgery(), diagnosisAndReview, referralToHospitalTreatment, startDate, endDate, 23, doctor, specialistAppointment);
            //            TreatmentController.Instance.Create(patient, treatment);
            TreatmentRepository.Instance.Save(treatment2);
            Console.WriteLine(TreatmentController.Instance.GetTreatment(treatment2).Prescription.Drugs[0].Name);

            Treatment treatment1 = TreatmentRepository.Instance.GetTreatment(23);
            foreach (Drug oneDrug in treatment1.Prescription.Drugs)
            {
                Console.WriteLine(oneDrug.Name);
            }

            Console.WriteLine("\n\n");
            foreach (Drug oneDrug in treatment1.ReferralToHospitalTreatment.Drugs)
            {
                Console.WriteLine(oneDrug.Name);
            }

            Console.WriteLine("\n\n");
            Console.WriteLine(treatment1.Doctor.NameAndSurname);
            Console.WriteLine(treatment1.ScheduledSurgery.Surgeon.NameAndSurname);
            Console.WriteLine(treatment1.SpecialistAppointment.Doctor.NameAndSurname);
//            DoctorDrugService doctorDrugService = new DoctorDrugService(new DrugService());
//            doctorDrugService.LowerQuantity(drug1);

            DoctorDrugController doctorDrugController = new DoctorDrugController(new DrugController());
            doctorDrugController.LowerQuantity(drug1);

            //            ManagerDrugService managerDrugService = new ManagerDrugService(new DrugService());
            //            managerDrugService.AddDrug("Prozak", 15);

            ManagerDrugController managerDrugController = new ManagerDrugController(new DrugController());
            managerDrugController.AddDrug("Prozak", 22);
        }
        

    }
}
