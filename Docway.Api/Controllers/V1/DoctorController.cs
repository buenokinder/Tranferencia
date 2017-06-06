using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Docway.Api.Controllers.V1
{
    [Route("api/patients/")]
    public class DoctorController : BaseController
    {

        private readonly IDoctorAppService _patientAppService;

        public DoctorController(IDoctorRepository doctorAppService, IDomainNotificationHandler<DomainNotification> notifications) : base(notifications)
        {
            _patientAppService = patientAppService;
        }
    }
}