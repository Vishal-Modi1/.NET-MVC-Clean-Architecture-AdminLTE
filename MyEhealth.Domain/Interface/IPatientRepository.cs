using MyEhealth.Domain.Entities;
using MyEhealth.Domain.Models;
using System.Collections.Generic;

namespace MyEhealth.Domain.Interface
{
    public interface IPatientRepository
    {
        void AddPatient(PatientModel patient);

        void EditPatient(PatientModel patient);

        List<PatientModel> GetAllPatient();

        PatientModel GetPatientById(int id);

        void DeletePatient(int id);
    }
}
