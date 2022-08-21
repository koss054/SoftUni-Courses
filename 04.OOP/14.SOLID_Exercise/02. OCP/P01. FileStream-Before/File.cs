using P01._FileStream_Before.Contracts;

namespace P01._FileStream_Before
{
    public abstract class File : IFile
    {
        protected File(string name, int length, int sent)
        {
           this.Name = name;
           this.Length = length;
           this.Sent = sent;
        }

        public string Name { get; }

        public int Length { get; }

        public int Sent { get; }
    }
}
