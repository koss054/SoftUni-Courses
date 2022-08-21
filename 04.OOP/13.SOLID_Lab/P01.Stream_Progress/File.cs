﻿namespace P01.Stream_Progress
{
    using Contracts;

    public abstract class File : IFile
    {
        private string name;

        protected File(string name, int length, int bytesSent)
        {
            this.name = name;
            this.Length = length;
            this.BytesSent = bytesSent;
        }

        public int Length { get; set; }

        public int BytesSent { get; set; }
    }
}
