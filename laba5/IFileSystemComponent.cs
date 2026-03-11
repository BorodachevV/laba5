using System;
using System.Collections.Generic;
using System.Text;

namespace laba5
{
    public interface IFileSystemComponent
    {
        string Name { get; }
        int GetSize();
        void Display(int depth = 0);
        void Delete();
        IFileSystemComponent Copy();
    }
}
