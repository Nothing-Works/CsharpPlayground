using System;

namespace CsharpPlayground.Event
{
    public class VideoEncoder
    {
        //1. define the delegate.
        //2. define the event base on the delegate.
        //3. raise the event.


        //1. define the delegate.
        public delegate void VideoEncodedEventHandler(object sender, EventArgs args);

        //2. define the event base on the delegate.
        public event VideoEncodedEventHandler VideoEncoded;
        //another way is just use action without delegate like this:
        public event Action<object, EventArgs> VideoEncoded1;
        //third way is even simpler also without delegate:
        public event EventHandler<EventArgs> VideoEncoded2;


        public void Encoding()
        {
            //do the work
            Console.WriteLine("do the work");

            //3. raise the event.
            FireVideoEncoded();
        }

        protected virtual void FireVideoEncoded()
        {
            //notify all the subscribers.
            VideoEncoded2?.Invoke(this, EventArgs.Empty);
        }
    }
}