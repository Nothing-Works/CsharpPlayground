using System;

namespace CsharpPlayground.Event
{
    public class EmailService
    {
        public void OnVideoEncoded(object sender, EventArgs args)
        {
            Console.WriteLine("Sending the email");
        }
    }
}