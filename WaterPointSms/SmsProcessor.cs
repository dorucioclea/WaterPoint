using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Twilio;

namespace WaterPointSms
{
    public class SmsProcessor
    {
        //private const string AccountSid = "AC6ca1c0dbf8b122dfdc79ceea50bbe206";

        //private const string AuthToken = "6bfabfdf99a787bf139aa9d615a5cd66";

        public string SendMessage(string receipientNumber, string textMessage)
        {
            //var twilio = new TwilioRestClient(AccountSid, AuthToken);

            //var message = twilio.SendMessage("+61400725057", receipientNumber, textMessage);

            //return message.Sid;

            return string.Empty;
        }
    }
}