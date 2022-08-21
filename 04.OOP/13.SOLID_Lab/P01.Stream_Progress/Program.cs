namespace P01.Stream_Progress
{
    using Contracts;
    public class Program
    {
        static void Main()
        {
            IFile file = new Music("Woah", 20, 300, "Kenny", "Brotheer");
            StreamProgressInfo musicProgress = new StreamProgressInfo(file);

            IFile file2 = new Video("Johnyyyyy", 3, 1000);
            StreamProgressInfo videoProgress = new StreamProgressInfo(file2);

            System.Console.WriteLine(musicProgress.CalculateCurrentPercent());
            System.Console.WriteLine(videoProgress.CalculateCurrentPercent());
        }
    }
}
