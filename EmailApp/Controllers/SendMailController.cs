using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmailService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MailApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SendMailController : ControllerBase
    {
        private readonly IEmailSender _emailSender;

        public SendMailController(IEmailSender emailSender)
        {
            _emailSender = emailSender;
        }

        [HttpPost("client")]
        public async Task<IActionResult> SendMailToClient()
        {
            var message = new Message(
                new string[] { "u201524476@upc.edu.pe" }, 
                "Servicio de Consulta Especialiizada UPC - Registro de solicitud", 
                "Estimado usuario: <br><br>" 
                    + "Su solicitud ha sido registrada y será atendida dentro los siguientes 3 días hábiles. <br> "
                    + "Gracias por su preferencia. <br><br>"
                    + "Saludos, <br>"
                    + "Servicio de Consulta Especializada UPC",
                null);
            await _emailSender.SendEmailAsync(message);

            return Ok(
                    new
                    {
                        status = true,
                        message = "OK"
                    });
        }

        [HttpPost("biblio")]
        public async Task<IActionResult> SendMailToBiblio()
        {
            var message = new Message(
                new string[] { "u201524476@upc.edu.pe" },
                "Servicio de Consulta Especialiizada UPC - Registro de solicitud",
                "Estimado bibliótecologo: <br><br>"
                    + "Una solicitud ha sido registrada y ha sido asignada a usted para su atención. <br> "
                    + "De antemano, gracias por su esfuerzo para cumplir el SLA establecido. <br><br>"
                    + "Saludos, <br>"
                    + "Servicio de Consulta Especializada UPC",
                null);
            await _emailSender.SendEmailAsync(message);

            return Ok(
                    new
                    {
                        status = true,
                        message = "OK"
                    });
        }
    }
}
