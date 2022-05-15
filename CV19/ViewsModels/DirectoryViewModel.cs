using CV19.ViewsModels.Base;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CV19.ViewsModels
{
    public class DirectoryViewModel : BaseViewModel
    {
        private readonly DirectoryInfo _DirectoryInfo;

        public IEnumerable<DirectoryViewModel> SubDirectories =>
            _DirectoryInfo.EnumerateDirectories()
            .Select(dir => new DirectoryViewModel(dir.FullName));
        public IEnumerable<FileViewModel> Files =>
            _DirectoryInfo.EnumerateFiles()
            .Select(file => new FileViewModel(file.FullName));

        public IEnumerable<object> DirectoryItems =>
            SubDirectories.Cast<object>().Concat(Files.Cast<object>());

        public string Name => _DirectoryInfo.Name;
        public string Path => _DirectoryInfo.FullName;
        public DateTime CreationTime => _DirectoryInfo.CreationTime;

        public DirectoryViewModel(string path)
        {
            _DirectoryInfo = new DirectoryInfo(path);

        }
    }

    public class FileViewModel : BaseViewModel
    {
        private readonly FileInfo _FileInfo;

        public string Name => _FileInfo.Name;
        public string Path => _FileInfo.FullName;
        public DateTime CreationTime => _FileInfo.CreationTime;
        public FileViewModel(string path)
        {
            _FileInfo = new FileInfo(path);

        }
    }
}
