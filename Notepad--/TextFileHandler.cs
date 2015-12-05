using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notepad__
{
    class TextFileHandler
    {
        private string fileName;
        public string FileName { get; set; }

        private bool _isChanged = false;
        public bool isDirty
        {
            get
            {
                return _isChanged;
            }
            set
            {
                _isChanged = value;
            }
        }
        public void Dirty() { _isChanged = true; }
        public void Clean() { _isChanged = false; }

        public TextFileHandler()
        {
        }

    }
}
