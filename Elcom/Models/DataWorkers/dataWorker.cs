using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Elcom.Models
{
    public abstract class DataWorker
    {
        // Получаем пути к папкам шаблонов и сохраненных файлов
        protected string TempFilePath = ConfigSpace.FilesPath;
        protected string TemplatesPath = ConfigSpace.TemplatesPath;
        protected string ImportPath = ConfigSpace.ImportPath;

        protected string Name;

        public abstract void DoWork(DataSet data);
    }
}
