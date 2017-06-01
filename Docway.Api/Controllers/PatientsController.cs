using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Docway.Api.Controllers
{
    [Route("api/patients")]
    public class PatientsController : Controller
    {
       
    }
}

public HttpResponseMessage Get(string id)
{
    var patient = PatientRepository.List
        .Include(p => p.CreditCards)
        .Include(p => p.Addresses)
        .Include(p => p.Vaccines)
        .Include(p => p.Parent.Addresses)
        .Include(p => p.Parent.CreditCards)
        .Include(p => p.Parent.Vaccines)
        .Include(p => p.Dependents.Select(d => d.Addresses))
        .Include(p => p.Dependents.Select(d => d.CreditCards))
        .Include(p => p.Dependents.Select(d => d.Vaccines))
        .FirstOrDefault(p => p.Id == id);

    Util.UpdateMobileData(patient, Request);

    var model = Mapper.Map<PatientViewModel>(patient);

    return Request.CreateResponse(HttpStatusCode.OK, model);
}

[AllowAnonymous]
public HttpResponseMessage Post([FromBody]PatientViewModel model)
{
    if (DoctorRepository.List.Any(p => p.UserName == model.Email))
        ModelState.AddModelError("Validate", "Não é possível realizar o cadastro com o mesmo email de médico.");

    if (UserRepository.List.Any(p => p.UserName == model.Email))
        ModelState.AddModelError("Validate", "E-mail já cadastrado no sistema");

    if (ModelState.IsValid)
    {
        var patient = Mapper.Map<Patient>(model);

        patient.CreateDate = DateTime.UtcNow;
        patient.PasswordHash = new PasswordHasher().HashPassword(model.Password);
        patient.SecurityStamp = Guid.NewGuid().ToString();
        patient.UserName = patient.Email;

        PatientRepository.Insert(patient);
        PatientRepository.SaveChanges();

        // envia email de cadastro
        EmailRepository.Insert(new EmailQueue
        {
            TemplateName = "PatientRegister",
            Destinations = patient.Email,
            UserReferenceId = patient.Id
        });

        EmailRepository.SaveChanges();

        return Request.CreateResponse(HttpStatusCode.Created, patient.Id);
    }

    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
}

[HttpPost]
[Route("api/patients/{id}/dependents")]
public HttpResponseMessage PostDependent(string id, [FromBody]PatientViewModel model)
{
    if (DoctorRepository.List.Any(p => p.UserName == model.Email))
        ModelState.AddModelError("Validate", "Não é possível realizar o cadastro com o mesmo email de médico.");

    if (ModelState.IsValid)
    {
        var parent = PatientRepository.List
            .Include(p => p.Dependents)
            .FirstOrDefault(p => p.Id == id);

        var patient = Mapper.Map<Patient>(model);

        patient.CreateDate = DateTime.UtcNow;
        patient.PasswordHash = new PasswordHasher().HashPassword(model.Password);
        patient.SecurityStamp = Guid.NewGuid().ToString();

        if (string.IsNullOrEmpty(patient.Email))
        {
            var username = $"{Guid.NewGuid().ToString()}@docway.co";
            patient.UserName = username;
            patient.Email = username;
        }
        else
        {
            patient.UserName = patient.Email;
        }

        patient.Parent = parent;
        parent.Dependents.Add(patient);

        PatientRepository.Insert(patient);
        PatientRepository.SaveChanges();

        return Request.CreateResponse(HttpStatusCode.Created, new PatientDependentResponseViewModel
        {
            Id = patient.Id,
            UserName = patient.UserName
        });
    }

    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
}

public HttpResponseMessage Patch(string id, [FromBody]PatientViewModel model)
{
    if (ModelState.IsValid)
    {
        model.CreditCards = null;
        var patient = PatientRepository.List
            .Include(p => p.CreditCards)
            .Include(p => p.Vaccines)
            .FirstOrDefault(p => p.Id == id);

        patient = Mapper.Map(model, patient, typeof(PatientViewModel), typeof(Patient)) as Patient;

        PatientRepository.Update(patient);
        PatientRepository.SaveChanges();

        return Request.CreateResponse(HttpStatusCode.NoContent);
    }

    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
}
    }
