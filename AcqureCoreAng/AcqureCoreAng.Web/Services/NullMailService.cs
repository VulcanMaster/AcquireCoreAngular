using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace AcqureCoreAng.Web.Services
{
    public class NullMailService : IMailService
    {
        private readonly ILogger<NullMailService> _logger;

        public NullMailService(ILogger<NullMailService> logger)
        {
            this._logger = logger;
        }

        public void SendMessage(string to, string from, string body)
        {
            // Log the message
            _logger.LogInformation($"To: {to}, From: {from}, Body: {body}");
        }
    }
}
