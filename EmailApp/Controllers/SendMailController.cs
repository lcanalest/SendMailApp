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

        [HttpPost]
        public async Task<IActionResult> Post()
        {
            var message = new Message(
                new string[] { "u201524476@upc.edu.pe" }, 
                "Servicio de Consulta Especialiizada UPC - Registro de solicitud", 
                "Estimado usuario: \n\n \n\n" 
                    + "Su solicitud ha sido registrada y será atendida dentro los siguientes 3 días hábiles. \n\n "                    
                    + "Gracias por su preferencia. \n\n \n\n"                    
                    + "Saludos, \n\n"                    
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
