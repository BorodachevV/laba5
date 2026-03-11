using System;
using System.Collections.Generic;
using System.Text;

namespace laba5
{
    public interface IStorageAdapter
    {
        void Write(string path, string data);
        string Read(string path);
        void Delete(string path);
        List<string> ListContents(string path);
    }
}
