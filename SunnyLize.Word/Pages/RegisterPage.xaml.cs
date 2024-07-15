
using SunnyLize.Word.Core;
using System.Collections.Generic;
using System.Linq;
using System.Security;
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

namespace SunnyLize.Word
{
    /// <summary>
    /// Interaction logic for RegisterPage.xaml
    /// </summary>
    public partial class RegisterPage : BasePage<RegisterViewModel>, IHavePassword
    {
        #region Constructor
        /// <summary>
        /// default ctor
        /// </summary>
        public RegisterPage()
        {
            InitializeComponent();


        }

        /// <summary>
        /// ctor with specific view model
        /// </summary>
        public RegisterPage(RegisterViewModel specificViewModel) :base(specificViewModel)
        {
            InitializeComponent();


        }
        #endregion
        /// <summary>
        /// The secure password for this login page
        /// </summary>
        public SecureString SecurePassword => PasswordText.SecurePassword;
       





        //Testing around our animation
        //private void NextButton_Click(object sender, RoutedEventArgs e)
        //{
        //    this.AniminateOut();
        //}


    }
}
