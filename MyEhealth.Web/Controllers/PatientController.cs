using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyEhealth.Domain.Entities;
using MyEhealth.Domain.Interface;
using MyEhealth.Domain.Models;

namespace MyEhealth.Web.Controllers
{
    public class PatientController : Controller
    {
        private readonly IPatientRepository _patientRepository;

        public PatientController(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }

        // GET: Patient
        [HttpGet]
        public ActionResult Index()
        {
            return View(_patientRepository.GetAllPatient());
        }

        // GET: Patient/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Patient/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PatientModel patient)
        {
            try
            {
                _patientRepository.AddPatient(patient);
                
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Patient/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_patientRepository.GetPatientById(id));
        }

        // POST: PatientController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(PatientModel patientModel)
        {
            try
            {
                _patientRepository.EditPatient(patientModel);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //// GET: PatientController/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //// POST: PatientController/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            try
            {
                _patientRepository.DeletePatient(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}