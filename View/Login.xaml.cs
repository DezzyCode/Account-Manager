using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
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
using System.Windows.Shapes;
using Account_Manager.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Path = System.IO.Path;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net;
using System.Security.Cryptography;
using Microsoft.VisualBasic.ApplicationServices;
using User = Account_Manager.Model.User;

namespace Account_Manager.View
{
    public partial class Login : Window
    {
        public static string folderPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "data");
        public static string filePath = Path.Combine(folderPath, "data.json");
        public static string assetsFolderPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Assets", "Img");

        public Login()
        {
            InitializeComponent();
            CheckDataFolder();
            LoadRememberedUser();
        }
        private void CheckDataFolder()
        {
            try
            {
                if (!Directory.Exists(folderPath) || !File.Exists(filePath))
                {
                    LoginPage.Visibility = Visibility.Collapsed;
                    RegistPage.Visibility = Visibility.Visible;
                    ResetPasswordPage.Visibility = Visibility.Collapsed;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void SaveRememberedUser(User user)
        {
            try
            {
                // Überprüfe, ob die Datei bereits existiert
                if (File.Exists(filePath))
                {
                    // Lese den aktuellen Inhalt der JSON-Datei
                    string existingJsonContent = File.ReadAllText(filePath);

                    // Deserialisiere den Inhalt in ein spezifisches Objekt
                    UserData existingData = JsonConvert.DeserializeObject<UserData>(existingJsonContent) ?? new UserData();

                    // Suche den Benutzer in der Liste und aktualisiere RememberMe
                    User existingUser = existingData.Users?.FirstOrDefault(u => u.Username == user.Username) ?? new User();

                    // Setze RememberMe auf true für den ausgewählten Benutzer
                    existingUser.RememberMe = cb_rememberMe.IsChecked == true;

                    // Setze RememberMe auf false für alle anderen Benutzer
                    if (existingData?.Users != null)
                    {
                        foreach (var otherUser in existingData.Users)
                        {
                            if (otherUser != existingUser)
                            {
                                otherUser.RememberMe = false;
                            }
                        }
                    }

                    // Speichere die aktualisierten Benutzerdaten
                    string updatedJsonContent = JsonConvert.SerializeObject(existingData, Formatting.Indented);
                    File.WriteAllText(filePath, updatedJsonContent);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private async void LoadRememberedUser()
        {
            try
            {
                // Überprüfe, ob die Datei bereits existiert
                if (File.Exists(filePath))
                {
                    // Lese den aktuellen Inhalt der JSON-Datei
                    string existingJsonContent = File.ReadAllText(filePath);

                    // Deserialisiere den Inhalt in ein spezifisches Objekt
                    UserData? existingData = JsonConvert.DeserializeObject<UserData>(existingJsonContent) ?? new UserData();

                    // Suche den Benutzer in der Liste
                    User? rememberedUser = existingData?.Users?.FirstOrDefault(u => u.RememberMe);
                    if (rememberedUser != null)
                    {
                        Tb_Username.Text = rememberedUser.Username;
                        Tb_password.Password = Decrypt(rememberedUser.Password, GenerateKey(rememberedUser.Username));
                        cb_rememberMe.IsChecked = true;

                        if (rememberedUser.RememberMe)
                        {
                            LoginControl.Visibility = Visibility.Collapsed;
                            await Task.Delay(1000);
                            SignUserIn();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void tb_login_username_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateProfileImage();
        }
        private void UpdateProfileImage()
        {   
            try
            {
                string username = Tb_Username.Text.Trim();

                // Laden Sie die vorhandenen UserData aus der data.json
                UserData userData = LoadUserData(username);

                // Finden Sie den Benutzer mit dem angegebenen Benutzernamen
                User? loggedInUser = userData?.Users?.FirstOrDefault(user => user.Username == username);

                if (loggedInUser != null)
                {
                    UserSettings firstUserSettings = loggedInUser.Settings?.FirstOrDefault();

                    if (firstUserSettings != null && !string.IsNullOrWhiteSpace(firstUserSettings.ProfileImagePath) && IsImageFile(firstUserSettings.ProfileImagePath))
                    {
                        // Wenn ein gültiger Bildpfad in der JSON vorhanden ist, lade und zeige das Bild an
                        Dispatcher.Invoke(() =>
                        {
                            BitmapImage bitmap = new BitmapImage(new Uri(Path.GetFullPath(firstUserSettings.ProfileImagePath)));
                            LoginUserImg.Source = bitmap;
                            LoginUserImg.Visibility = Visibility.Visible;
                            DefaultLoginUserImg.Visibility = Visibility.Collapsed;
                        });
                    }
                }
                else
                {
                    LoginUserImg.Visibility = Visibility.Collapsed;
                    DefaultLoginUserImg.Visibility = Visibility.Visible;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Fehler beim Aktualisieren des Profilbilds: {ex.Message}", "Fehler", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public static UserData LoadUserData(string username)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(filePath) && File.Exists(filePath))
                {
                    string jsonContent = File.ReadAllText(filePath);
                    return JsonConvert.DeserializeObject<UserData>(jsonContent);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Fehler beim Laden der Benutzerdaten: {ex.Message}", "Fehler", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            return null;
        }
        private bool IsImageFile(string filePath)
        {
            string[] supportedExtensions = { ".bmp", ".jpg", ".jpeg", ".gif", ".png" };
            string extension = Path.GetExtension(filePath);

            return supportedExtensions.Contains(extension, StringComparer.OrdinalIgnoreCase);
        }
        static byte[] GenerateKey(string password)
        {
            const int iterations = 10000;
            const int KeySize = 256;

            using (var deriveBytes = new Rfc2898DeriveBytes(password, salt: new byte[8], iterations: iterations))
            {
                return deriveBytes.GetBytes(KeySize / 8);
            }
        }
        static string Encrypt(string text, byte[] key)
        {
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = key;
                aesAlg.IV = new byte[16];

                ICryptoTransform encrypteor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                byte[] encrytedBytes;

                using (var msEncrypt = new System.IO.MemoryStream())
                {
                    using (var csEncrypt = new CryptoStream(msEncrypt, encrypteor, CryptoStreamMode.Write))
                    using (var swEncrypt = new System.IO.StreamWriter(csEncrypt))
                    {
                        swEncrypt.Write(text);
                    }

                    encrytedBytes = msEncrypt.ToArray();
                }

                return Convert.ToBase64String(encrytedBytes);
            }
        }
        static string Decrypt(string cipherText, byte[] key)
        {
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = key;
                aesAlg.IV = new byte[16];

                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                cipherText = cipherText.Trim();

                try
                {
                    byte[] cipherTextBytes = Convert.FromBase64String(cipherText);

                    string decryptedText;

                    using (var msDecrypt = new System.IO.MemoryStream(cipherTextBytes))
                    using (var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    using (var srDecrypt = new System.IO.StreamReader(csDecrypt))
                    {
                        decryptedText = srDecrypt.ReadToEnd();
                    }

                    return decryptedText;
                }
                catch (FormatException ex)
                {

                    return ex.Message;
                }
            }
        }

        //Login
        private void SignInBtn_Click(object sender, RoutedEventArgs e)
        {
            SignUserIn();
        }
        private void SignUserIn()
        {
            string enteredUsername = Tb_Username.Text;
            string enteredPassword = Tb_password.Password;

            try
            {
                // Überprüfe, ob die Datei bereits existiert
                if (File.Exists(filePath))
                {
                    // Lese den aktuellen Inhalt der JSON-Datei
                    string existingJsonContent = File.ReadAllText(filePath);

                    // Deserialisiere den Inhalt in ein spezifisches Objekt
                    UserData? existingData = JsonConvert.DeserializeObject<UserData>(existingJsonContent);

                    // Überprüfe, ob der Benutzer existiert und das Passwort übereinstimmt
                    if (existingData?.Users != null)
                    {
                        User? foundUser = existingData.Users.FirstOrDefault(user =>
                            (user.Username == enteredUsername && Decrypt(user.Password, GenerateKey(enteredUsername)) == enteredPassword));

                        if (foundUser != null)
                        {
                            SaveRememberedUser(foundUser);
                            LogedInUser.CurrentUser = foundUser.Username;
                            LogedInUserPassword.CurrentPassword = Decrypt(foundUser.Password, GenerateKey(foundUser.Username));

                            MainWindow main = new MainWindow();
                            main.Show();
                            this.Close();
                        }
                        else
                        {
                            infobox.Text = "Falscher Benutzername oder falsches Passwort.";
                        }
                    }
                    else
                    {
                        infobox.Text = "Keine Benutzer in der Datenbank gefunden.";
                    }
                }
                else
                {
                    infobox.Text = "Datenbankdatei nicht gefunden.";
                }
            }
            catch (Exception ex)
            {
                infobox.Text = $"Fehler beim Anmelden: {ex.Message}";
            }
        }
        private void LoginCloseBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void Discord_MouseDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                // Discord-Link öffnen
                Process.Start(new ProcessStartInfo("https://discord.gg/qznAt9Nygd")
                {
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {
                // Fehlerbehandlung, falls das Öffnen fehlschlägt
                MessageBox.Show($"Fehler beim Öffnen des Links: {ex.Message}");
            }
        }
        private void Instagram_MouseDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                // Discord-Link öffnen
                Process.Start(new ProcessStartInfo("https://www.instagram.com/de.vxy/")
                {
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {
                // Fehlerbehandlung, falls das Öffnen fehlschlägt
                MessageBox.Show($"Fehler beim Öffnen des Links: {ex.Message}");
            }
        }
        private void Youtube_MouseDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                // Discord-Link öffnen
                Process.Start(new ProcessStartInfo("https://www.youtube.de/dezzycode")
                {
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {
                // Fehlerbehandlung, falls das Öffnen fehlschlägt
                MessageBox.Show($"Fehler beim Öffnen des Links: {ex.Message}");
            }
        }
        private void RegistBtn_Click(object sender, RoutedEventArgs e)
        {
            LoginPage.Visibility = Visibility.Collapsed;
            RegistPage.Visibility = Visibility.Visible;
        }
        private void LogoBorder_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
       
        //Regist
        private async void SignUpBtn_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(Tb_regist_Username.Text) || string.IsNullOrEmpty(Tb_regist_email.Text) || string.IsNullOrEmpty(Tb_regist_password.Password))
            {
                infobox_regist.Text = "Bitte füllen Sie alle Felder aus.";
            }
            else
            {
                CreateDataFolderAndFile(
                    Tb_regist_Username.Text,
                    Tb_regist_email.Text,
                    Tb_regist_password.Password,
                    (cb_regist_saftyquest.SelectedItem as ComboBoxItem)?.Content.ToString(),
                    Tb_regist_saftyanswer.Text
                );
                Tb_Username.Text = Tb_regist_Username.Text;
                Tb_password.Password = Tb_regist_password.Password;
                cb_rememberMe.IsChecked = true;
                SignUserIn();
            }
        }
        private void CreateDataFolderAndFile(string username, string email, string password, string saftyQuest, string saftyAnswer)
        {
            try
            {
                // Überprüfe, ob eine gültige E-Mail-Adresse angegeben wurde
                if (!IsValidEmail(email))
                {
                    infobox_regist.Foreground = new SolidColorBrush(Colors.Red);
                    infobox_regist.Text = "Ungültige E-Mail-Adresse.";
                    return;
                }

                Directory.CreateDirectory(folderPath);

                // Initialisiere existingData
                UserData? existingData = new UserData();

                // Überprüfe, ob die Datei bereits existiert
                if (File.Exists(filePath))
                {
                    // Lese den aktuellen Inhalt der JSON-Datei
                    string existingJsonContent = File.ReadAllText(filePath);

                    // Deserialisiere den Inhalt in ein spezifisches Objekt
                    existingData = JsonConvert.DeserializeObject<UserData>(existingJsonContent);
                }

                // Überprüfe, ob der Benutzer bereits existiert
                if (existingData?.Users != null && existingData.Users.Any(user => user.Username == username))
                {
                    infobox_regist.Foreground = new SolidColorBrush(Colors.Red);
                    infobox_regist.Text = "Benutzer existiert bereits.";
                    return; // Beende die Methode, da der Benutzer bereits existiert
                }

                // Füge den neuen Benutzer zum Array "Users" hinzu
                User newUser = new User
                {
                    Username = username,
                    Email = Encrypt(email, GenerateKey(username)),
                    Password = Encrypt(password, GenerateKey(username)),
                    SaftyQuest = saftyQuest,
                    SaftyQuestAnswer = Encrypt(saftyAnswer, GenerateKey(username)),
                    Settings = new List<UserSettings>{new UserSettings{}},
                    Data = new List<UserDataDetails>() // Initialisiere mit einer leeren Liste von UserDataDetails
                };

                // Füge den neuen Benutzer zum Array "Users" hinzu, ohne die vorhandenen Daten zu überschreiben
                List<User> updatedUsers = existingData?.Users?.ToList() ?? new List<User>();
                updatedUsers.Add(newUser);
                existingData.Users = updatedUsers.ToArray();

                // Konvertiere das aktualisierte Objekt in JSON-Format
                string updatedJsonContent = JsonConvert.SerializeObject(existingData, Formatting.Indented);

                // Schreibe den aktualisierten JSON-Inhalt zurück in die Datei
                File.WriteAllText(filePath, updatedJsonContent);

                RegistPage.Visibility = Visibility.Collapsed;
                LoginPage.Visibility = Visibility.Visible;

                infobox_regist.Foreground = new SolidColorBrush(Colors.Green);
                infobox_regist.Text = "Benutzerinformationen wurden erfolgreich gespeichert.";

            }
            catch (Exception ex)
            {
                infobox_regist.Foreground = new SolidColorBrush(Colors.Red);
                infobox_regist.Text = $"Fehler beim Speichern: {ex.Message}";
            }
        }
        private bool IsValidEmail(string email)
        {
            try
            {
                var mailAddress = new System.Net.Mail.MailAddress(email);
                return true;
            }
            catch
            {
                return false;
            }
        }
        private void RegistCloseBtn_Click(object sender, RoutedEventArgs e)
        {
           this.Close();
        }
        private void HelpBtn_Click(object sender, RoutedEventArgs e)
        {
            Help help = new Help();
            help.Show();
        }
        private void ResetPassword_Click(object sender, RoutedEventArgs e)
        {
            LoginPage.Visibility = Visibility.Collapsed;
            RegistPage.Visibility = Visibility.Collapsed;
            ResetPasswordPage.Visibility = Visibility.Visible;
        }
        private void ResetPwBtn_Click(object sender, RoutedEventArgs e)
        {
            string enteredUsername = Tb_resetpw_Username.Text;
            string enteredEmail = Tb_resetpw_email.Text;
            string enteredSaftyAns = Tb_resetpw_saftyanswer.Text;
            string enteredPassword = Tb_resetpw_password.Password;

            Tb_Username.Text = string.Empty;
            Tb_password.Password = string.Empty;

            try
            {
                // Überprüfe, ob die Datei bereits existiert
                if (File.Exists(filePath))
                {
                    // Lese den aktuellen Inhalt der JSON-Datei
                    string existingJsonContent = File.ReadAllText(filePath);

                    // Deserialisiere den Inhalt in ein spezifisches Objekt
                    UserData existingData = JsonConvert.DeserializeObject<UserData>(existingJsonContent);

                    // Überprüfe, ob der Benutzer existiert und das Passwort übereinstimmt
                    if (existingData?.Users != null)
                    {
                        User foundUser = existingData.Users.FirstOrDefault(user =>
                            user.Username == enteredUsername &&
                            Decrypt(user.Email, GenerateKey(enteredUsername)) == enteredEmail &&
                            Decrypt(user.SaftyQuestAnswer, GenerateKey(enteredUsername)).Equals(enteredSaftyAns, StringComparison.OrdinalIgnoreCase));

                        if (foundUser != null)
                        {
                            // Aktualisiere Benutzerinformationen
                            foundUser.Password = Encrypt(enteredPassword, GenerateKey(foundUser.Username));

                            // Speichere die aktualisierten Daten zurück in die JSON-Datei
                            File.WriteAllText(filePath, JsonConvert.SerializeObject(existingData, Formatting.Indented));

                            RegistPage.Visibility = Visibility.Collapsed;
                            ResetPasswordPage.Visibility = Visibility.Collapsed;
                            LoginPage.Visibility = Visibility.Visible;

                            LogedInUser.CurrentUser = string.Empty;
                            LogedInUserPassword.CurrentPassword = string.Empty;

                            Tb_Username.Text = foundUser.Username;
                            Tb_password.Password = Decrypt(foundUser.Password, GenerateKey(enteredUsername));
                            cb_rememberMe.IsChecked = true;
                        }
                        else
                        {
                            infobox_resetpw.Text = "Benutzername, E-Mail oder Antwort falsch.";
                        }
                    }
                    else
                    {
                        infobox_resetpw.Text = "Keine Benutzer in der Datenbank gefunden.";
                    }
                }
                else
                {
                    infobox_resetpw.Text = "Datenbankdatei nicht gefunden.";
                }
            }
            catch (Exception ex)
            {
                infobox_resetpw.Text = $"Fehler beim Anmelden: {ex.Message}";
            }
        }
        private void Tb_resetpw_Username_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                // Überprüfe, ob die Datei bereits existiert
                if (File.Exists(filePath))
                {
                    // Lese den aktuellen Inhalt der JSON-Datei
                    string existingJsonContent = File.ReadAllText(filePath);

                    // Deserialisiere den Inhalt in ein spezifisches Objekt
                    UserData? existingData = JsonConvert.DeserializeObject<UserData>(existingJsonContent);

                    // Überprüfe, ob der Benutzer existiert und das Passwort übereinstimmt
                    if (existingData?.Users != null)
                    {
                        User? foundUser = existingData.Users.FirstOrDefault(user =>
                            user.Username == Tb_resetpw_Username.Text);

                        if (foundUser != null)
                        {
                            Tb_resetpw_quest.Text = foundUser.SaftyQuest;
                        }
                        else
                        {
                            Tb_resetpw_quest.Text = string.Empty;
                        }
                    }
                    else
                    {
                        infobox_resetpw.Text = "Keine Benutzer in der Datenbank gefunden.";
                    }
                }
                else
                {
                    infobox_resetpw.Text = "Datenbankdatei nicht gefunden.";
                }
            }
            catch (Exception ex)
            {
                infobox_resetpw.Text = $"Fehler beim Anmelden: {ex.Message}";
            }
        }
    }
}
