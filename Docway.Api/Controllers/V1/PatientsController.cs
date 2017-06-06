using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Dockway.Application.Interfaces;
using Docway.Domain.Core.Notifications;
using Dockway.Application.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Docway.Domain.Models;

namespace Docway.Api.Controllers
{
    [Route("api/patients/")]
    public class PatientsController : BaseController
    {
        private readonly IPatientAppService _patientAppService;

        public PatientsController(IPatientAppService patientAppService, IDomainNotificationHandler<DomainNotification> notifications) : base(notifications)
        {
            _patientAppService = patientAppService;
        }


        [HttpPost]
        [AllowAnonymous]
        public IActionResult Create([FromBody]PatientViewModel patientViewModel)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            _patientAppService.Register(patientViewModel);

            if (IsValidOperation())
                return Created("/api/patients", patientViewModel);

            return BadRequestValidations();
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("{id:guid}")]
        public IActionResult Get(Guid? id)
        {
            if (id == null) return NotFound();

            var patientViewModel = _patientAppService.GetById(id.Value);

            if (patientViewModel == null) return NotFound();

            return Ok(patientViewModel);
        }
        [HttpPost]
        [Route("{id:guid}/dependents")]
        public IActionResult PostDependent(Guid id, [FromBody]PatientViewModel patientViewModel)
        {
            if (!ModelState.IsValid) return Ok(patientViewModel);

            _patientAppService.AddDependent(patientViewModel.AddParent(id));

            if (IsValidOperation())
                return Created("/api/patients/" + id.ToString() + "/dependents", patientViewModel);

            return BadRequestValidations();
        }
    }

   
}

//public HttpResponseMessage Get(string id)
//{
//    var patient = PatientRepository.List
//        .Include(p => p.CreditCards)
//        .Include(p => p.Addresses)
//        .Include(p => p.Vaccines)
//        .Include(p => p.Parent.Addresses)
//        .Include(p => p.Parent.CreditCards)
//        .Include(p => p.Parent.Vaccines)
//        .Include(p => p.Dependents.Select(d => d.Addresses))
//        .Include(p => p.Dependents.Select(d => d.CreditCards))
//        .Include(p => p.Dependents.Select(d => d.Vaccines))
//        .FirstOrDefault(p => p.Id == id);

//    Util.UpdateMobileData(patient, Request);

//    var model = Mapper.Map<PatientViewModel>(patient);

//    return Request.CreateResponse(HttpStatusCode.OK, model);
//}

//[AllowAnonymous]
//public HttpResponseMessage Post([FromBody]PatientViewModel model)
//{
//    if (DoctorRepository.List.Any(p => p.UserName == model.Email))
//        ModelState.AddModelError("Validate", "Não é possível realizar o cadastro com o mesmo email de médico.");

//    if (UserRepository.List.Any(p => p.UserName == model.Email))
//        ModelState.AddModelError("Validate", "E-mail já cadastrado no sistema");

//    if (ModelState.IsValid)
//    {
//        var patient = Mapper.Map<Patient>(model);

//        patient.CreateDate = DateTime.UtcNow;
//        patient.PasswordHash = new PasswordHasher().HashPassword(model.Password);
//        patient.SecurityStamp = Guid.NewGuid().ToString();
//        patient.UserName = patient.Email;

//        PatientRepository.Insert(patient);
//        PatientRepository.SaveChanges();

//        // envia email de cadastro
//        EmailRepository.Insert(new EmailQueue
//        {
//            TemplateName = "PatientRegister",
//            Destinations = patient.Email,
//            UserReferenceId = patient.Id
//        });

//        EmailRepository.SaveChanges();

//        return Request.CreateResponse(HttpStatusCode.Created, patient.Id);
//    }

//    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
//}

//[HttpPost]
//[Route("api/patients/{id}/dependents")]
//public HttpResponseMessage PostDependent(string id, [FromBody]PatientViewModel model)
//{
//    if (DoctorRepository.List.Any(p => p.UserName == model.Email))
//        ModelState.AddModelError("Validate", "Não é possível realizar o cadastro com o mesmo email de médico.");

//    if (ModelState.IsValid)
//    {
//        var parent = PatientRepository.List
//            .Include(p => p.Dependents)
//            .FirstOrDefault(p => p.Id == id);

//        var patient = Mapper.Map<Patient>(model);

//        patient.CreateDate = DateTime.UtcNow;
//        patient.PasswordHash = new PasswordHasher().HashPassword(model.Password);
//        patient.SecurityStamp = Guid.NewGuid().ToString();

//        if (string.IsNullOrEmpty(patient.Email))
//        {
//            var username = $"{Guid.NewGuid().ToString()}@docway.co";
//            patient.UserName = username;
//            patient.Email = username;
//        }
//        else
//        {
//            patient.UserName = patient.Email;
//        }

//        patient.Parent = parent;
//        parent.Dependents.Add(patient);

//        PatientRepository.Insert(patient);
//        PatientRepository.SaveChanges();

//        return Request.CreateResponse(HttpStatusCode.Created, new PatientDependentResponseViewModel
//        {
//            Id = patient.Id,
//            UserName = patient.UserName
//        });
//    }

//    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
//}

//public HttpResponseMessage Patch(string id, [FromBody]PatientViewModel model)
//{
//    if (ModelState.IsValid)
//    {
//        model.CreditCards = null;
//        var patient = PatientRepository.List
//            .Include(p => p.CreditCards)
//            .Include(p => p.Vaccines)
//            .FirstOrDefault(p => p.Id == id);

//        patient = Mapper.Map(model, patient, typeof(PatientViewModel), typeof(Patient)) as Patient;

//        PatientRepository.Update(patient);
//        PatientRepository.SaveChanges();

//        return Request.CreateResponse(HttpStatusCode.NoContent);
//    }

//    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
//}
//    }
