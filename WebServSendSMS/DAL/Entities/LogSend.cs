using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebServSendSMS.DAL.Entities
{
    [Table("WSSS_LogSend")]
    public class LogSend
    {
        [Key]
        public int Id { get; set; }
        [Required, StringLength(255)]
        public string Recipient { get; set; }
        [Required, StringLength(255)]
        public string Message { get; set; }
    }
}