using System;

namespace CSharpIntermediate
{
    class Post
    {
        private int _votes;
        public DateTime DateOfPost { get; private set; }
        public string Title { get; set; }
        public string Description { get; set; }

        // Methods
        // Constructor
        public Post()
        {
            DateOfPost = DateTime.Now;
        }

        public void UpVote()
        {
            _votes++;
        }

        public void DownVote()
        {
            _votes--;
        }

        public int GetVote()
        {
            return _votes;
        }
    }
}
