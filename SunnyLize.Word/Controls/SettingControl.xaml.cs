
using SunnyLize.Word.Core;
using System.Windows.Controls;
using static SunnyLize.Word.DI;

namespace SunnyLize.Word
{
    /// <summary>
    /// Interaction logic for SettingControl.xaml
    /// </summary>
    public partial class SettingControl : UserControl
    {
        public SettingControl()
        {
            InitializeComponent();

            //Set the data context to settings menu
            DataContext = ViewModelSettings;
        }
    }
}
