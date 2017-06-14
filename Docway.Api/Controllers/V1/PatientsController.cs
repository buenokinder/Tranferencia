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
    [Authorize]
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


        [HttpPatch]
        [AllowAnonymous]
        public IActionResult Patch([FromBody]PatientViewModel patientViewModel)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            _patientAppService.Update(patientViewModel);

            if (IsValidOperation())
                return Ok(patientViewModel);

            return BadRequestValidations();
        }


        [HttpGet]
 
        [Route("{id:guid}")]
        public IActionResult Get(Guid? id)
        {
            if (id == null) return NotFound();

            var patientViewModel = _patientAppService.GetById(id.Value);

            if (patientViewModel == null) return NotFound();

            return Ok(patientViewModel);
        }


        [HttpGet]
        public IActionResult GetFiltered(string cpf, string insuranceName, string insuranceNumber)
        {
           

            var patientViewModel = _patientAppService.GetByFilters(cpf, insuranceName, insuranceNumber);

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

