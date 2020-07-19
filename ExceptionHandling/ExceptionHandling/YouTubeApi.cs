using System;
using System.Collections.Generic;

namespace ExceptionHandling
{
    public class YouTubeApi
    {
        public List<Video> GetVideos(string user)
        {
            try
            {
                // throw an exception so the catch is executed
                throw new Exception("Oops some low level YouTube error");
            }
            catch (Exception ex)
            {
                // Masks the lovel level exception that's throw and replaces it with a more user-friendly one
                throw new YouTubeException("Could not fetch videos from YouTube", ex);
            }

            return new List<Video>();
        }
    }
}
