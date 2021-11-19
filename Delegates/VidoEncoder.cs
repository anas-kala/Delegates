using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Delegates
{

    public class VideoEventArgs: EventArgs
    {
        public Video Video { get; set; }
    }

    class VidoEncoder
    {
        //// define a delegate
        //public delegate void VideoEncodedEventHandler(object source, VideoEventArgs args);

        //// define an event based on that delegate
        //public event VideoEncodedEventHandler VideoEncoded;

        // define an event handler
        public event EventHandler<VideoEventArgs> VideoEncoded;     //Without arguments it would be: public event EventHandler VideoEncoded;


        // Raise the event
        protected virtual void OnVideoEncoded(Video video)
        {
            // check if there are subscribers
            if (VideoEncoded != null)
                VideoEncoded(this, new VideoEventArgs() { Video = video });
        }

        public void Encode(Video video)
        {
            Console.WriteLine("Encoding Video...");
            Thread.Sleep(3000);

            // Notifying subscribers
            OnVideoEncoded(video);
        }
    }
}
