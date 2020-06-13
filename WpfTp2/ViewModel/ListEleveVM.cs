using BusinessLayer.ProjectNet.Queries;
using Model.ProjectNet;
using Model.ProjectNet.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfTp2.ViewModel.Common;

namespace WpfTp2.ViewModel
{
    public class ListEleveVM : BaseVM
    {

        private ObservableCollection<DetailEleveVM> _eleves = null;
        private DetailEleveVM _selectedEleve;
        private EleveQuery query;
        private ProNetDbContext _context = new ProNetDbContext();

        public ListEleveVM()
        {
            _eleves = new ObservableCollection<DetailEleveVM>();
            query = new EleveQuery(_context);
            query.GetAll().ToList().ForEach(e => _eleves.Add(new DetailEleveVM(e)));

            if(_eleves != null && _eleves.Count > 0)
            {
                _selectedEleve = _eleves.ElementAt(0);
            }
            
        }


        public ObservableCollection<DetailEleveVM> Eleves
        {
            get { return _eleves; }
            set
            {
                _eleves = value;
                OnPropertyChanged("Eleves");
            }
        }

        public DetailEleveVM SelectedEleve
        {
            get { return _selectedEleve;  }
            set
            {
                _selectedEleve = value;
                OnPropertyChanged("SelectedEleve");
            }
        }
    }
}
