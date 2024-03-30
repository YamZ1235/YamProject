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
using Model;
namespace YamWpf
{
    /// <summary>
    /// Interaction logic for Managers.xaml
    /// </summary>
    public partial class Managers : Page
    {
        Management m;

        public Managers(Model.Management management)
        {
            InitializeComponent();
            m = management;
        }
    }
}
