using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twilio;

namespace Reminder
{
    class TextMessageHandler
    {
        public TextMessageHandler()
        {
            var client = new TwilioRestClient("AC306f182c59d9c9a4f71323e12af2cba8", "f576bd328046d32424d084c9baca5147");
            client.SendMessage("3858316451", "8013269981", "Hello");
        }
    }
}
