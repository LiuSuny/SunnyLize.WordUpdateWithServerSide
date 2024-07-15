
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
    /// Interaction logic for LoginPage.xaml
    /// </summary>
    public partial class LoginPage : BasePage<LoginViewModel>, IHavePassword
    {
        #region Constructor
        /// <summary>
        /// Default ctor
        /// </summary>
        public LoginPage()
        {
            InitializeComponent();


        }

        /// <summary>
        /// ctor with specific view models
        /// </summary>
        public LoginPage(LoginViewModel specificViewModel) : base(specificViewModel) { InitializeComponent(); }
       

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
