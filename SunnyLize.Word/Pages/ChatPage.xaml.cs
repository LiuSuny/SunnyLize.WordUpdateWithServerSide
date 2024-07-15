
using SunnyLize.Word.Core;
using System;
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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SunnyLize.Word
{
    
    /// <summary>
    /// Interaction logic for ChatPage.xaml
    /// </summary>
    public partial class ChatPage : BasePage<ChatMessageListViewModel>
    {

        #region Constructor
        /// <summary>
        /// Default ctor
        /// </summary>
        public ChatPage() : base()
        {
            InitializeComponent();

        }

        /// <summary>
        /// ctor with prameter
        /// </summary>
        /// <param name="specificViewModel"></param>

        public ChatPage(ChatMessageListViewModel specificViewModel = null) : base(specificViewModel)
        {
            InitializeComponent();

        }

        #endregion

        #region Override Method

        protected override void OnviewModelChange()
        {
            //run a check to make sure UI exist first before it implament the changes
            if (ChatMessageList == null)
                return;
            //fade in chat message list
            var storyboard = new Storyboard();
            storyboard.AddFadeIn(1);
            storyboard.Begin(ChatMessageList);

            //Making the message box focus
            MessageText.Focus();
        }

        #endregion

        /// <summary>
        /// Preview the input into the message box and respond as require
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MessageText_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            //First we get the textbox
            var textbox = sender as TextBox;

            //checked if the press key is enter

            if(e.Key == Key.Enter)
            {
                if (Keyboard.Modifiers.HasFlag(ModifierKeys.Control))
                {


                    //send message
                    //ViewModel.Send();

                    //Add a new line at the point where the cursor is
                    var index = textbox.CaretIndex;

                    //Insert a new line
                    textbox.Text = textbox.Text.Insert(index, Environment.NewLine);

                    //shift the caret forward to the newline
                    textbox.CaretIndex = index + Environment.NewLine.Length;

                    //making this key as handled by us
                    e.Handled = true;
                }
                else
                    //otherwise send the meeeage
                    ViewModel.Send();
                    
                //Make the key as handle
                   e.Handled = true;
            }

        }
    }
}
