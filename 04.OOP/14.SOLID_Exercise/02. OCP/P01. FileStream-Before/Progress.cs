using P01._FileStream_Before.Contracts;

namespace P01._FileStream_Before
{
    public class Progress
    {
        private readonly IFile file;

        public Progress(IFile file)
        {
            this.file = file;
        }

        public int CurrentPercent()
        {
            return this.file.Sent * 100 / this.file.Length;
        }
    }
}
