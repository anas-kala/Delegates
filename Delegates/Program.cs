using System;

namespace Delegates
{
    class Program
    {
        static void Main(string[] args)
        {
            var video = new Video() { Title = "video 1" };
            var vedioEncoder = new VidoEncoder(); // publisher
            var mailService = new MailService(); // subscriber
            vedioEncoder.VideoEncoded += mailService.OnVideoEncoded;
            var messageService = new MessageService();
            vedioEncoder.VideoEncoded += messageService.OnVideoEncoded;

            vedioEncoder.Encode(video);
        }
    }

    public class MailService
    {
        public void OnVideoEncoded(object source,VideoEventArgs e)
        {
            Console.WriteLine("Mail service: Sending an Email..." + e.Video.Title);
        }
    }

    public class MessageService
    {
        public void OnVideoEncoded(object source, VideoEventArgs e)
        {
            Console.WriteLine("MessageService: Sending a text message..."+e.Video.Title);
        }
    }

}
