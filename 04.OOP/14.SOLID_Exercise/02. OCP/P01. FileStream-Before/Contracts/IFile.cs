namespace P01._FileStream_Before.Contracts
{
    public interface IFile
    {
        public string Name { get; }

        public int Length { get; }

        public int Sent { get; }
    }
}
