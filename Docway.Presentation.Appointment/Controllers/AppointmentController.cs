using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Docway.Application.Appointment.Interfaces;
using Docway.Domain.Core.Notifications;
using Docway.Application.Appointment.ViewModels;

namespace Docway.Presentation.Appointment.Controllers
{
    [Produces("application/json")]
    [Route("api/appointment")]
    [Authorize]
    public class AppointmentController : BaseController
    {



        private readonly IAppointmentAppService _appointmentAppService;

        public AppointmentController(IAppointmentAppService appointmentAppService, IDomainNotificationHandler<DomainNotification> notifications) : base(notifications)
        {
            _appointmentAppService = appointmentAppService;
        }



        [HttpGet]
        [AllowAnonymous]
        [Route("/api/patients/{id:guid}/appointments")]
        public IActionResult Get(Guid patientId,  DateTime? startDate, DateTime? endDate, int initial = 0, int limit = 5)
        {
            return Ok(_appointmentAppService.GetPacientAppointmentsByFilter(patientId,startDate, endDate ));
        }


        [HttpPost]
        [Route("api/appointments")]
        public IActionResult Post([FromBody]AppointmentViewModel model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            _appointmentAppService.Register(model);

            if (IsValidOperation())
                return Created("/api/appointments", model);

            return BadRequestValidations();

        }
    }
}



//            if (ModelState.IsValid)
//            {
//                try
//                {
//                    var appointment = AppointmentService.ParseFromViewModel(model);

//Util.UpdateMobileData(appointment.Buyer, Request);

//                    if (model.PaymentMethod == PaymentMethod.CreditCard)
//                    {
//                        #region Validar Cartão

//                        var createPayment = default(CreatePaymentResponse);
//var paymentmethod = default(ClientPaymentResponse);
//var paymentModel = default(CreatePaymentRequest);
//var transaction = default(Transaction);

//transaction = Transaction.Create(appointment.Price);

//                        appointment.Transactions.Add(transaction);

//                        var patient = PatientRepository.List.FirstOrDefault(p => p.Id == appointment.Buyer.Id); ;

//                        if (appointment.CreditCard == null || string.IsNullOrWhiteSpace(patient.IuguClientId))
//                        {
//                            throw new ModelValidateException("O paciente não tem nenhum cartão de crédito cadastrado.");
//                        }
//                        else if (appointment.CreditCard?.PaymentMethodId == null)
//                        {
//                            if (!string.IsNullOrWhiteSpace(patient.IuguClientId))
//                            {
//                                paymentmethod = await PaymentService.ListClientPayment(new ClientRequest
//                                {
//                                    Client = new Client()
//{
//    CreditCardFinalNumber = appointment.CreditCard.FinalNumber,
//                                        Id = patient.IuguClientId
//                                    }
//                                });

//                                if (paymentmethod != null)
//                                {
//                                    appointment.CreditCard.PaymentMethodId = paymentmethod.PaymentMethodId;
//                                }
//                                else
//                                {
//                                    throw new InvalidOperationException("O paciente não tem nenhum cartão de crédito cadastrado");
//                                }
//                            }
//                            else
//                            {
//                                throw new InvalidOperationException("O paciente não tem nenhum cartão de crédito cadastrado");
//                            }
//                        }

//                        PaymentService.ConfigurePaymentMethod(appointment.CreditCard.PaymentMethodId);

//                        var items = new List<PaymentItem>();

//items.Add(new PaymentItem
//                        {
//                            Description = "Consulta Docway",
//                            Price = appointment.Price,
//                            Quantity = 1
//                        });

//                        var doctor = DoctorRepository.List
//                                .Include(d => d.IuguCredentials)
//                                .FirstOrDefault(d => d.Id == appointment.Seller.Id);

////configura a conta para receber em duas etapas
//var retorno = await PaymentService.ConfigureCustomer(new CustomerRequest()
//{
//    Credentials = new Credentials()
//    {
//        AccountId = doctor.IuguCredentials.AccountId,
//        ApiTokenDev = doctor.IuguCredentials.ApiTokenDev,
//        ApiTokenLive = doctor.IuguCredentials.ApiTokenLive,
//        UserToken = doctor.IuguCredentials.UserToken
//    }
//});

//                        if (!string.IsNullOrWhiteSpace(appointment.Buyer.Email))
//                        {
//                            paymentModel = new CreatePaymentRequest
//                            {
//                                Buyer = new Buyer { Email = appointment.Buyer.Email },
//                                Credentials = new Credentials
//                                {
//                                    AccountId = doctor.IuguCredentials.AccountId,
//                                    ApiTokenDev = doctor.IuguCredentials.ApiTokenDev,
//                                    ApiTokenLive = doctor.IuguCredentials.ApiTokenLive,
//                                    UserToken = doctor.IuguCredentials.UserToken
//                                },
//                                Items = items
//                            };
//                        }

//                        createPayment = await PaymentService.CreatePayment(paymentModel);

//                        if (createPayment != null && !string.IsNullOrWhiteSpace(createPayment.Message))
//                        {
//                            if (createPayment.Message.Equals("Autorizado"))
//                            {
//                                if (appointment.PaymentMethod == PaymentMethod.CreditCard)
//                                {
//                                    appointment.PaymentStatus = PaymentStatus.PreApproved;
//                                }

//                                transaction.RawResponseData = JsonConvert.SerializeObject(createPayment);
//                                transaction.ReferenceId = createPayment.InvoiceId;

//                                AppointmentService.Validate(appointment);
//                                AppointmentService.Process(appointment);
//                                AppointmentService.Notify(appointment);
//                            }
//                            else if (createPayment.Message.Equals("Transação negada"))
//                            {
//                                var exCustom = new InvalidOperationException($"Cartão não autorizado para realizar transações. Cliente: { appointment.Buyer.Name} Mensagem: { createPayment.Message } Fatura: { createPayment.InvoiceId }");
//ErrorLog.GetDefault(null).Log(new Error(exCustom));
//                                throw new ModelValidateException($"Cartão não autorizado para realizar transações. Cliente: { appointment.Buyer.Name} ");
//                            }
//                        }
//                        else
//                        {
//                            var exCustom = new InvalidOperationException($"Cartão não autorizado para realizar transações. Cliente: { appointment.Buyer.Name} Mensagem: { createPayment?.Message } Fatura: { createPayment?.InvoiceId }");
//ErrorLog.GetDefault(null).Log(new Error(exCustom));
//                            throw new ModelValidateException($"Cartão não autorizado para realizar transações. Cliente: { appointment.Buyer.Name} ");
//                        }

//                        #endregion
//                    }
//                    else
//                    {
//                        AppointmentService.Validate(appointment);
//                        AppointmentService.Process(appointment);
//                        AppointmentService.Notify(appointment);
//                    }

//                    return Request.CreateResponse(HttpStatusCode.Created, appointment.Id);
//                }
//                catch (ModelValidateException ex)
//                {
//                    ModelState.AddModelError("Validate", ex.Message);
//                }
//                catch (Exception ex)
//                {
//                    ModelState.AddModelError("Error", ex.Message);
//                    ErrorLog.GetDefault(null).Log(new Error(ex));
//                }
//            }

//            return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);