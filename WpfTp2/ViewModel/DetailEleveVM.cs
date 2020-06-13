using BusinessLayer.ProjectNet.Commands;
using Model.ProjectNet;
using Model.ProjectNet.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using WpfTp2.ViewModel.Common;

namespace WpfTp2.ViewModel
{
    public class DetailEleveVM : BaseVM
    {
        private int _id;
        private string _nom;
        private string _prenom;
        private double _moyenne;
        private int _nbAbsences;
        private NoteCommand _noteCommand;
        private RelayCommand _addOperation;

        public DetailEleveVM(Eleve e)
        {
            _id = e.Id;
            _noteCommand = new NoteCommand(new ProNetDbContext());
            _nom = e.Nom;
            _prenom = e.Prenom;
            _moyenne = (from n in e.Notes
                        select n.NoteValue).Average();
            _nbAbsences = (from a in e.Absences
                        select a).Count();
        }

        public string Nom
        {
            get { return _nom; }
            set { _nom = value; }
        }

        public string Prenom
        {
            get { return _prenom; }
            set { _prenom = value; }
        }

        public Double Moyenne
        {
            get { return _moyenne ; }
        }

        public int NbAbsences
        {
            get { return _nbAbsences;  }
        }

        public ICommand AddOperation
        {
            get
            {
                if (_addOperation == null)
                    _addOperation = new RelayCommand(() => this.AddNoteOperation());
                return _addOperation;
            }
        }

        private void AddNoteOperation()
        {
            View.AddNoteOperation operationWindow = new View.AddNoteOperation();
            operationWindow.DataContext = this;
            operationWindow.ShowDialog();
        }
    }
}
