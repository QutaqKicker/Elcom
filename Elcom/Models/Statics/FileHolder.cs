using System.Collections.Generic;
using System.IO;

namespace Elcom.Models
{
    public static class FileHolder
    {
        private static Dictionary<short, MemoryStream> _fileList = new Dictionary<short, MemoryStream>();

        private static short _key; 
        public static short AddFile(MemoryStream body)
        {
            _fileList.Add(_key++, body);
            return _key;
        }

        public static MemoryStream GetFile(short key)
        {
            MemoryStream file = _fileList[key];
            _fileList.Remove(key);
            return file;
        }
    }
}