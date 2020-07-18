using System;
using System.Threading;

namespace EventsAndDelegates
{
    public class VideoEventArgs : EventArgs
    {
        public Video Video { get; set; }
    }

    public class VideoEncoder
    {
        // To publish events we need to:
        //
        // 1 - Define a delegate
        // 2 - Define an event based on that delegate
        // 3 - Rase the event

        // The convention in C# for an event handler is to have (object, EventArgs) as parameters
        // Also appending "EventHandler" to the name is a convention

        // 1 - Define a delegate
        public delegate void VideoEncodedEventHandler(object source, VideoEventArgs args);

        // 2 - Define an event based on that delegate
        public event VideoEncodedEventHandler VideoEncoded;

        // DotNet includes delegates to handle this for us:
        // - EventHandler
        // - EventHandler<TEventArgs>
        //
        // The delegate and event lines could be replaced with:
        //
        // public event EventHandler<VideoEventArgs> VideoEncoded;
        // or
        // public event EventHandler VideoEncoded;

        public void Encode(Video video)
        {
            Console.WriteLine("Encoding Video...");
            Thread.Sleep(3000);

            OnVideoEncoded(video);
        }

        // DotNet conventions for event published methods
        // should be defined:
        // - protected
        // - virtual
        // - void
        // - named starting with "On"

        // 3 - Rase the event
        protected virtual void OnVideoEncoded(Video video)
        {
            if (VideoEncoded != null)
                VideoEncoded(this, new VideoEventArgs() { Video = video });
        }
    }
}
