namespace P01.Stream_Progress
{
    public class Music : File
    {
        private string artist;
        private string album;

        public Music(string name, int length, int bytesSent, string artist, string album) 
            : base(name, length, bytesSent)
        {
            this.artist = artist;
            this.album = album;
        }
    }
}
