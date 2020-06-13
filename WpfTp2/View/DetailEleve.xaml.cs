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
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfTp2.View
{
    /// <summary>
    /// Logique d'interaction pour DetailEleve.xaml
    /// </summary>
    public partial class DetailEleve : UserControl
    {
        NoteCommand _noteCommand;
        public DetailEleve()
        {
            InitializeComponent();
            _noteCommand = new NoteCommand(new ProNetDbContext());
        }
    }
}
