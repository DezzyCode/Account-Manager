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

namespace Account_Manager.View
{
    public partial class Help : Window
    {
        public Help()
        {
            InitializeComponent();

            Help_defaulttext.Visibility = Visibility.Visible;
        }

        private void Help_addAccount_MouseDown(object sender, MouseButtonEventArgs e)
        {
            CloseAllHelpText();
            Help_addAccount_text.Visibility = Visibility.Visible;
            Help_addAccount.Foreground = new SolidColorBrush(Colors.Gainsboro);
        }

        private void Help_delAccount_MouseDown(object sender, MouseButtonEventArgs e)
        {
            CloseAllHelpText();
            Help_delAccount_text.Visibility = Visibility.Visible;
            Help_delAccount.Foreground = new SolidColorBrush(Colors.Gainsboro);
        }

        private void Help_sortAccount_MouseDown(object sender, MouseButtonEventArgs e)
        {
            CloseAllHelpText();
            Help_sortAccount_text.Visibility = Visibility.Visible;
            Help_sortAccount.Foreground = new SolidColorBrush(Colors.Gainsboro);
        }

        private void Help_changelog_MouseDown(object sender, MouseButtonEventArgs e)
        {
            CloseAllHelpText();
            Help_changelog_text.Visibility = Visibility.Visible;
            Help_changelog.Foreground = new SolidColorBrush(Colors.Gainsboro);
        }

        private void Help_profilImg_MouseDown(object sender, MouseButtonEventArgs e)
        {
            CloseAllHelpText();
            Help_profilImg_text.Visibility = Visibility.Visible;
            Help_profilImg.Foreground = new SolidColorBrush(Colors.Gainsboro);
        }

        private void Help_searchAccount_MouseDown(object sender, MouseButtonEventArgs e)
        {
            CloseAllHelpText();
            Help_searchAccount_text.Visibility = Visibility.Visible;
            Help_searchAccount.Foreground = new SolidColorBrush(Colors.Gainsboro);
        }

        private void Help_changeProfil_MouseDown(object sender, MouseButtonEventArgs e)
        {
            CloseAllHelpText();
            Help_changeProfil_text.Visibility = Visibility.Visible;
            Help_changeProfil.Foreground = new SolidColorBrush(Colors.Gainsboro);
        }

        private void Help_showFiles_MouseDown(object sender, MouseButtonEventArgs e)
        {
            CloseAllHelpText();
            Help_showFiles_text.Visibility = Visibility.Visible;
            Help_showFiles.Foreground = new SolidColorBrush(Colors.Gainsboro);
        }

        private void Help_changeUserPassword_MouseDown(object sender, MouseButtonEventArgs e)
        {
            CloseAllHelpText();
            Help_changeUserPassword_text.Visibility = Visibility.Visible;
            Help_changeUserPassword.Foreground = new SolidColorBrush(Colors.Gainsboro);
        }

        private void Help_changeUserUsername_MouseDown(object sender, MouseButtonEventArgs e)
        {
            CloseAllHelpText();
            Help_changeUserUsername_text.Visibility = Visibility.Visible;
            Help_changeUserUsername.Foreground = new SolidColorBrush(Colors.Gainsboro);
        }

        private void Help_usePasswordGen_MouseDown(object sender, MouseButtonEventArgs e)
        {
            CloseAllHelpText();
            Help_usePasswordGen_text.Visibility = Visibility.Visible;
            Help_usePasswordGen.Foreground = new SolidColorBrush(Colors.Gainsboro);
        }

        private void Help_howSafe_MouseDown(object sender, MouseButtonEventArgs e)
        {
            CloseAllHelpText();
            Help_howSafe_text.Visibility = Visibility.Visible;
            Help_howSafe.Foreground = new SolidColorBrush(Colors.Gainsboro);
        }

        private void Help_editAccounts_MouseDown(object sender, MouseButtonEventArgs e)
        {
            CloseAllHelpText();
            Help_editAccounts_text.Visibility = Visibility.Visible;
            Help_editAccounts.Foreground = new SolidColorBrush(Colors.Gainsboro);
        }

        private void Help_resetUserPassword_MouseDown(object sender, MouseButtonEventArgs e)
        {
            CloseAllHelpText();
            Help_resetUserPassword_text.Visibility = Visibility.Visible;
            Help_resetUserPassword.Foreground = new SolidColorBrush(Colors.Gainsboro);
        }

        private void CloseAllHelpText()
        {
            var helpTextElements = new[]
            {
                Help_howSafe_text,
                Help_addAccount_text,
                Help_delAccount_text,
                Help_sortAccount_text,
                Help_changelog_text,
                Help_defaulttext,
                Help_profilImg_text,
                Help_resetUserPassword_text,
                Help_editAccounts_text,
                Help_usePasswordGen_text,
                Help_changeUserUsername_text,
                Help_changeUserPassword_text,
                Help_showFiles_text,
                Help_changeProfil_text,
                Help_searchAccount_text
            };

            foreach (var helpTextElement in helpTextElements)
            {
                helpTextElement.Visibility = Visibility.Collapsed;
            }

            UIElement[] helpLinksElements = new UIElement[]
            {
                Help_howSafe,
                Help_addAccount,
                Help_sortAccount,
                Help_delAccount,
                Help_changelog,
                Help_defaulttext,
                Help_profilImg,
                Help_resetUserPassword,
                Help_editAccounts,
                Help_usePasswordGen,
                Help_changeUserUsername,
                Help_changeUserPassword,
                Help_showFiles,
                Help_changeProfil,
                Help_searchAccount
            };

            foreach (var helpLinkElement in helpLinksElements)
            {
                if (helpLinkElement is TextBlock textBlock)
                {
                    textBlock.Foreground = new SolidColorBrush(Colors.Blue);
                }
            }
        }
        private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            try
            {
                // Öffnen Sie den Link in der Standard-Webbrowser-Anwendung
                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                {
                    FileName = e.Uri.AbsoluteUri,
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {
            }

            // Markieren Sie den Link als bearbeitet, um zu verhindern, dass der Standardwebbrowser geöffnet wird.
            e.Handled = true;
        }

        private void IconImage_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
    }
}
