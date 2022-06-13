using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventPlaning.Services.Interfaces
{
    interface IEmailSender
    {
        void SendEmail(string email, string subject, string message);
    }
}
