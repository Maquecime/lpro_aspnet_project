using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfTp2.ViewModel.Common;

namespace WpfTp2.ViewModel
{
    class HomeVM : BaseVM
    {
        private ListEleveVM _listeEleveVM = null;

        public HomeVM()
        {
            _listeEleveVM = new ListEleveVM();
        }

        public ListEleveVM ListEleveVM
        {
            get { return _listeEleveVM; }
            set { _listeEleveVM = value; }
        }
    }
}
