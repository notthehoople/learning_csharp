namespace EventsAndDelegates
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            var video = new Video() { Title = "Video 1" };
            var videoEncoder = new VideoEncoder();          // Publisher
            var mailService = new MailService();            // Subscriber
            var messageService = new MessageService();      // Subscriber

            // Define the subscriber before runnigng the event
            // No need for () on OnVideoEncoded as we aren't calling the method. We're passing a pointer to the method
            videoEncoder.VideoEncoded += mailService.OnVideoEncoded;
            videoEncoder.VideoEncoded += messageService.OnVideoEncoded;

            videoEncoder.Encode(video);
        }
    }
}
