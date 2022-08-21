namespace P01.Stream_Progress.Contracts
{
    public interface IFile
    {
        public int Length { get; set; }

        public int BytesSent { get; set; }
    }
}
