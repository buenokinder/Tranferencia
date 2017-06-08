using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Dockway.Application.Interfaces;
using Docway.Domain.Core.Notifications;
using Microsoft.AspNetCore.Authorization;
using Dockway.Application.ViewModels;

namespace Docway.Api.Controllers.V1
{
    [RequireHttps]
    [Route("api/doctors/")]
    public class DoctorController : BaseController
    {

        private readonly IDoctorAppService _doctorAppService;

        public DoctorController(IDoctorAppService doctorAppService, IDomainNotificationHandler<DomainNotification> notifications) : base(notifications)
        {
            _doctorAppService = doctorAppService;
        }


        [HttpGet]
        [AllowAnonymous]
        [Route("{id:guid}")]
        public IActionResult Get(double latitude, double longitude, DayOfWeek? dayOfWeek, int? hour , DateTime? date, int? specialtyId = null, bool isSUSEnabled = false)
        {
            return Ok(_doctorAppService.Find(latitude, longitude, dayOfWeek, hour, date, specialtyId, isSUSEnabled));
        }


        [HttpPost]
        [AllowAnonymous]
        public IActionResult Create([FromBody]DoctorViewModel doctorViewModel)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            _doctorAppService.Register(doctorViewModel);

            if (IsValidOperation())
                return Created("/api/doctors", doctorViewModel);

            return BadRequestValidations();
        }


        [HttpPatch]
        [AllowAnonymous]
        public IActionResult Patch([FromBody]DoctorViewModel doctorViewModel)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            _doctorAppService.Update(doctorViewModel);

            if (IsValidOperation())
                return Ok(doctorViewModel);

            return BadRequestValidations();
        }


        [HttpGet]
        [AllowAnonymous]
        [Route("{id:guid}")]
        public IActionResult Get(Guid? id)
        {
            if (id == null) return NotFound();

            var doctorViewModel = _doctorAppService.GetById(id.Value);

            if (doctorViewModel == null) return NotFound();

            return Ok(doctorViewModel);
        }
    }
}