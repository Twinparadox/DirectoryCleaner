using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DirectoryCleaner
{
    /// <summary>
    /// 파일정보, 해시코드, 확장자코드를 이용한 중복 확인.
    /// </summary>
    public sealed class FileList
    {
        private string filePath;
        private string directoryPath;
        private FileInfo item;

        public string FilePath
        {
            get
            {
                return filePath;
            }
            set
            {
                if (value == null)
                    throw new ArgumentException("FilePath cannot be null", "FilePath");
                filePath = value;
            }
        }
        public string DirectoryPath
        {
            get
            {
                return directoryPath;
            }
            set
            {
                if (value == null)
                    throw new ArgumentException("DirectoryPath Cannot be null", "DirectoryPath");
                directoryPath = value;
            }
        }
        public int ExtensionCode { get; set; }
        public FileInfo Item
        {
            get
            {
                return item;
            }
            set
            {
                item = value ?? throw new ArgumentException("FileInfo cannot be null", "FilePath");
            }
        }

        public FileList()
        {
            FilePath = null;
            DirectoryPath = null;
            Item = null;
            ExtensionCode = -1;
        }

        public FileList(string filePath)
        {
            FilePath = filePath;
            Item = new FileInfo(filePath);
            DirectoryPath = item.DirectoryName;

            string fileType = Extension.CheckExtensionType(item.Extension.Substring(1, item.Extension.Length - 1));
            ExtensionCode = Extension.GetExtensionCode(fileType);
        }

        public void DeleteFile()
        {
            FilePath = "";
            DirectoryPath = "";
            Item.Delete();
            ExtensionCode = -1;
        }

        public string GetFileName()
        {
            if (Item != null)
            {
                return Item.Name;
            }
            else
            {
                return null;
            }
        }

        public string GetFilePath()
        {
            if (Item != null)
            {
                return Item.FullName;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Byte To Byte Comparison
        /// using Parallel.For
        /// </summary>
        /// <param name="compare"></param>
        /// <returns></returns>
        public bool CompareByteToByte(FileList compare)
        {
            bool success = true;

            if (this.Item.Length != compare.Item.Length)
            {
                return false;
            }
            if(this.ExtensionCode != compare.ExtensionCode)
            {
                return false;
            }

            long fileLength = Item.Length;
            const int size = 0x1000000;

            Parallel.For(0, fileLength / size, x =>
                {
                    var start = (int)x * size;

                    if (start >= fileLength)
                    {
                        return;
                    }

                    using (FileStream sourceFile = File.OpenRead(this.FilePath))
                    {
                        using (FileStream compareFile = File.OpenRead(compare.FilePath))
                        {
                            var bufferSource = new byte[size];
                            var bufferCompare = new byte[size];

                            sourceFile.Position = start;
                            compareFile.Position = start;

                            int cnt = sourceFile.Read(bufferSource, 0, size);
                            compareFile.Read(bufferCompare, 0, size);

                            for (int i = 0; i < cnt; i++)
                            {
                                if (bufferSource[i] != bufferCompare[i])
                                {
                                    success = false;
                                    return;
                                }
                            }
                        }
                    }
                });
            return success;
        }
    }
}
