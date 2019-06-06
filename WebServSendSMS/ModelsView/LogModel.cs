using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebServSendSMS.ModelsView
{
    public class LogModel
    {
        public string Recipient { get; set; }
        public string Message { get; set; }
        public string ApiKey { get; set; }
    }
}