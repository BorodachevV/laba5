using System;
using System.Collections.Generic;
using System.Text;

namespace laba5
{
    public interface IFileSystem
    {
        void Read(string absolutePath);
        void Delete(string absolutePath);
    }
}
