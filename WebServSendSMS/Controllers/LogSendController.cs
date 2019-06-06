using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using WebServSendSMS.DAL.Entities;
using WebServSendSMS.Models;
using WebServSendSMS.ModelsView;

namespace WebServSendSMS.Controllers
{
    public class LogSendController : ApiController
    {
        private ApplicationDbContext _context;// = new ApplicationDbContext();
        //public List<LogSend> Get()
        //{
        //    //_context = new ApplicationDbContext();
        //    var model = _context.Logs.Select(l => new LogSend
        //    {
        //        Id = l.Id,
        //        Recipient = l.Recipient,
        //        Message = l.Message
        //    }).ToList();
        //    return model;
        //}

        public IHttpActionResult Post(LogModel model)
        {
            _context = new ApplicationDbContext();
            _context.Logs.Add(new LogSend
            {
                Recipient = model.Recipient,
                Message = model.Message
            });

            string url = "https://api.mobizon.ua/service/message/sendSmsMessage?output=json&api=v1&apiKey=" + model.ApiKey;
            using (WebClient client = new WebClient())
            {
                client.Encoding = Encoding.UTF8;
                client.Headers.Add("content-type", "application/x-www-form-urlencoded");
                client.Headers.Add("cache-control", "no-cache");
                string data = JsonConvert.SerializeObject(new
                {
                    recipient = model.Recipient,
                    text = model.Message,
                });
                var result = client.UploadString(url, "POST", data);
            }

            _context.SaveChanges();
            return Ok();
        }
    }
}
