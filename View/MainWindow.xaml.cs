using Account_Manager.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OfficeOpenXml;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Resources;
using System.Security.Cryptography;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using Button = System.Windows.Controls.Button;
using Clipboard = System.Windows.Clipboard;
using LicenseContext = OfficeOpenXml.LicenseContext;
using OpenFileDialog = Microsoft.Win32.OpenFileDialog;
using Path = System.IO.Path;
using SaveFileDialog = Microsoft.Win32.SaveFileDialog;
using TextBox = System.Windows.Controls.TextBox;
using Window = System.Windows.Window;

namespace Account_Manager.View
{
    public partial class MainWindow : Window
    {
        public static string folderPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "data");
        public static string filePath = Path.Combine(folderPath, "data.json");
        public static string assetsFolderPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Assets", "Img");
        public static string profilImageFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Assets", "Img", "Profils");
        private static readonly ResourceManager ResourceManager = new ResourceManager("Account_Manager.VersionResources", Assembly.GetExecutingAssembly());
        public string? selectedFilePath;
        public static string? DecryptKey = LogedInUser.CurrentUser;

        public MainWindow()
        {
            InitializeComponent();
            InitializeUser();
        }

        //Functionen
        private bool UserSettingsOpen = false;
        private bool AddWindowOpen = false;
        private bool PasswordGenWindowOpen = false;
        private bool NotifyShow = false;
        private bool isAnimationInProgress = false;
        private bool EditWindowOpen = false;
        private bool ExportMenuOpen = false;
        private bool DataExportWindowOpen = false;
        private bool SortAZSetting;

        private async void ManageWindows(string window)
        {
            if (window == "questBox")
            {
                if (PasswordGenWindowOpen)
                {
                    ClosePasswordGenWindow();
                    await Task.Delay(300);
                }
                if (AddWindowOpen)
                {
                    CloseAddWindow();
                    await Task.Delay(300);
                }
                if (EditWindowOpen)
                {
                    CloseEditWindow();
                    await Task.Delay(300);
                }
                if (UserSettingsOpen)
                {
                    CloseSettingsWindow();
                    await Task.Delay(300);
                }
                if (DataExportWindowOpen)
                {
                    CloseDataExportWindow();
                    await Task.Delay(300);
                }
            }
            if (window == "charts")
            {
                if (PasswordGenWindowOpen)
                {
                    ClosePasswordGenWindow();
                    await Task.Delay(300);
                }
                if (AddWindowOpen)
                {
                    CloseAddWindow();
                    await Task.Delay(300);
                }
                if (EditWindowOpen)
                {
                    CloseEditWindow();
                    await Task.Delay(300);
                }
                if (UserSettingsOpen)
                {
                    CloseSettingsWindow();
                    await Task.Delay(300);
                }
                if (DataExportWindowOpen)
                {
                    CloseDataExportWindow();
                    await Task.Delay(300);
                }
            }
            if (window == "settings")
            {
                if (PasswordGenWindowOpen)
                {
                    ClosePasswordGenWindow();
                    await Task.Delay(300);
                }
                if (AddWindowOpen)
                {
                    CloseAddWindow();
                    await Task.Delay(300);
                }
                if (EditWindowOpen)
                {
                    CloseEditWindow();
                    await Task.Delay(300);
                }
                if (DataExportWindowOpen)
                {
                    CloseDataExportWindow();
                    await Task.Delay(300);
                }
                if (!UserSettingsOpen)
                {
                    OpenSettingsWindow();
                }
                else
                {
                    CloseSettingsWindow();
                }
            }
            if (window == "exportdata")
            {
                if (PasswordGenWindowOpen)
                {
                    ClosePasswordGenWindow();
                    await Task.Delay(300);
                }
                if (AddWindowOpen)
                {
                    CloseAddWindow();
                    await Task.Delay(300);
                }
                if (EditWindowOpen)
                {
                    CloseEditWindow();
                    await Task.Delay(300);
                }
                if (UserSettingsOpen)
                {
                    CloseSettingsWindow();
                    await Task.Delay(300);
                }
                if (!DataExportWindowOpen)
                {
                    OpenDataExportWindow();
                }
                else
                {
                    CloseDataExportWindow();
                }
            }
            else if (window == "add")
            {
                if (PasswordGenWindowOpen)
                {
                    ClosePasswordGenWindow();
                    await Task.Delay(300);
                }
                if (UserSettingsOpen)
                {
                    CloseSettingsWindow();
                    await Task.Delay(300);
                }
                if (EditWindowOpen)
                {
                    CloseEditWindow();
                    await Task.Delay(300);
                }
                if (DataExportWindowOpen)
                {
                    CloseDataExportWindow();
                    await Task.Delay(300);
                }
                if (!AddWindowOpen)
                {
                    OpenAddWindow();
                }
                else
                {
                    CloseAddWindow();
                }
            }
            else if (window == "pwgen")
            {
                if (AddWindowOpen)
                {
                    CloseAddWindow();
                    await Task.Delay(300);
                }
                if (UserSettingsOpen)
                {
                    CloseSettingsWindow();
                    await Task.Delay(300);
                }
                if (EditWindowOpen)
                {
                    CloseEditWindow();
                    await Task.Delay(300);
                }
                if (DataExportWindowOpen)
                {
                    CloseDataExportWindow();
                    await Task.Delay(300);
                }
                if (!PasswordGenWindowOpen)
                {
                    OpenPasswordGenWindow();
                }
                else
                {
                    ClosePasswordGenWindow();
                }
            }
            else if (window == "edit")
            {
                if (AddWindowOpen)
                {
                    CloseAddWindow();
                    await Task.Delay(300);
                }
                if (UserSettingsOpen)
                {
                    CloseSettingsWindow();
                    await Task.Delay(300);
                }
                if (PasswordGenWindowOpen)
                {
                    ClosePasswordGenWindow();
                    await Task.Delay(300);
                }
                if (DataExportWindowOpen)
                {
                    CloseDataExportWindow();
                    await Task.Delay(300);
                }
                if (!EditWindowOpen)
                {
                    OpenEditWindow();
                }
                else
                {
                    CloseEditWindow();
                }
            }
        }
        public void InitializeUser()
        {
            string currentUser = LogedInUser.CurrentUser;

            if (!string.IsNullOrEmpty(currentUser))
            {
                try
                {
                    string jsonContent = File.ReadAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "data", "data.json"));

                    var userData = JsonConvert.DeserializeObject<UserData>(jsonContent);

                    var currentUserData = userData?.Users?.FirstOrDefault(user => user?.Username == currentUser);

                    if (currentUserData != null)
                    {
                        string userEmail = currentUserData.Email;
                        string userPassword = currentUserData.Password;
                        var showInfoSetting = currentUserData.Settings.FirstOrDefault();
                        var sortAZSetting = currentUserData.Settings.FirstOrDefault();
                        var AutoSaveSettings = currentUserData.Settings.FirstOrDefault();

                        CurrentUsername.Text = currentUser;
                        CurrentPassword.Password = Decrypt(userPassword, GenerateKey(DecryptKey));
                        RepeatPassword.Password = Decrypt(userPassword, GenerateKey(DecryptKey));
                        CurrentEmail.Text = Decrypt(userEmail, GenerateKey(DecryptKey));

                        ShowInfo.IsChecked = showInfoSetting.ShowGridInfo;
                        SortAZ.IsChecked = sortAZSetting.SortAZ;

                        if (AutoSaveSettings.AutoSavePath != null)
                        {
                            AutosavePath.Background = new SolidColorBrush(Color.FromRgb(100, 100, 100));
                        }

                        SortAZSetting = sortAZSetting.SortAZ;

                        Username.Text = LogedInUser.CurrentUser;
                        AppVersion.Text = GetAppVersion();
                        DataGridAllFilter.IsChecked = true;

                        InitializeUserProfileImage();
                        RefreshDataGrid();
                        CountAccountsFunc();

                        if (sortAZSetting.SortAZ)
                        {
                            var column = Datagrid.Columns.FirstOrDefault(c => c.SortMemberPath == "Application");
                            if (column != null)
                            {
                                Datagrid.Items.SortDescriptions.Clear();
                                Datagrid.Items.SortDescriptions.Add(new SortDescription(column.SortMemberPath, ListSortDirection.Ascending));
                                column.SortDirection = ListSortDirection.Ascending;
                            }
                        }
                        else
                        {
                            Datagrid.Items.SortDescriptions.Clear();
                        }

                        var customBorderColor = LoadUserCustomBorderColor(LogedInUser.CurrentUser);
                        if (customBorderColor != null)
                        {
                            MainBorder.Background = new SolidColorBrush(customBorderColor.Value);
                        }
                        else
                        {
                            MainBorder.Background = new SolidColorBrush(Color.FromArgb(220, 30, 30, 30));
                        }
                    }
                    else
                    {
                        Notify("Info", $"Benutzer '{currentUser}' nicht gefunden.", 5);
                    }
                }
                catch (Exception ex)
                {
                    Notify("Fehler!", $"Fehler beim Lesen der Datei: {ex.Message}", 5);
                }
            }
            else
            {
                Notify("Info", "Es ist kein Benutzer angemeldet.", 5);
            }
        }
        public User? GetUserByUsername(string? username)
        {
            if (string.IsNullOrEmpty(username))
            {
                // Rückgabe von null, wenn der Benutzername ungültig ist
                return null;
            }

            try
            {
                // Lese den aktuellen Inhalt der JSON-Datei
                string jsonContent = File.ReadAllText(Path.Combine(folderPath, filePath));

                // Deserialisiere den Inhalt in ein spezifisches Objekt
                var userData = JsonConvert.DeserializeObject<UserData>(jsonContent);

                // Finde den Benutzer mit dem angegebenen Benutzernamen
                var user = userData?.Users?.FirstOrDefault(u => u?.Username == username);

                return user;
            }
            catch (Exception ex)
            {
                // Behandlung von Fehlern beim Lesen oder Deserialisieren der Datei
                Console.WriteLine($"Fehler beim Lesen der Datei: {ex.Message}");
                return null;
            }
        }
        public static UserData? LoadUserData(string username)
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

            }

            return null;
        }
        private void SaveUserData(UserData userData)
        {
            try
            {
                // Überprüfen Sie, ob der Ordner vorhanden ist, andernfalls erstellen Sie ihn
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }

                // Serialisieren und in die JSON-Datei schreiben
                string jsonContent = JsonConvert.SerializeObject(userData, Formatting.Indented);
                File.WriteAllText(filePath, jsonContent);
            }
            catch (Exception ex)
            {
                Notify("Fehler!", $"Fehler beim Speichern der Benutzerdaten.", 5);
            }
        }
        public System.Windows.Media.Color? LoadUserCustomBorderColor(string username)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(filePath) && File.Exists(filePath))
                {
                    string jsonContent = File.ReadAllText(filePath);
                    var userData = JsonConvert.DeserializeObject<UserData>(jsonContent);

                    var loggedInUser = userData?.Users?.FirstOrDefault(user => user?.Username == username);

                    if (loggedInUser != null && loggedInUser.Settings != null && loggedInUser.Settings.Count > 0)
                    {
                        var customBorderColor = loggedInUser.Settings[0].CustomBorderColor;

                        if (customBorderColor != null && customBorderColor.Length == 4)
                        {
                            return System.Windows.Media.Color.FromArgb(byte.Parse(customBorderColor[0]), byte.Parse(customBorderColor[1]), byte.Parse(customBorderColor[2]), byte.Parse(customBorderColor[3]));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions if needed
            }

            return null;
        }
        public class AlphabeticalSortConverter : IValueConverter
        {
            public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            {
                return value?.ToString().ToLowerInvariant();
            }

            public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            {
                throw new NotImplementedException();
            }
        }

        //WindowOperations
        private void WindowMinimizeBtn_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }
        private void WindowMaximize_Click(object sender, RoutedEventArgs e)
        {
            if (this.WindowState == WindowState.Normal)
            {
                this.WindowState = WindowState.Maximized;
            }
            else
            {
                this.WindowState = WindowState.Normal;
            }
        }
        private void WindowCloseBtn_Click(object sender, RoutedEventArgs e)
        {
            // Lade vorhandene UserData aus der data.json
            UserData? userData = LoadUserData(LogedInUser.CurrentUser);

            // Finden Sie den Benutzer mit dem angegebenen Benutzernamen
            User? loggedInUser = userData.Users.FirstOrDefault(user => user.Username == LogedInUser.CurrentUser);

            UserSettings firstUserSettings = loggedInUser.Settings?.FirstOrDefault();

            if (firstUserSettings.AutoSavePath != null)
            {
                AutoSave();
            }

            DoubleAnimation widthAnimation = new DoubleAnimation
            {
                From = 1280,
                To = 0,
                Duration = TimeSpan.FromSeconds(0.3),
                EasingFunction = new QuadraticEase { EasingMode = EasingMode.EaseInOut }
            };

            DoubleAnimation heightAnimation = new DoubleAnimation
            {
                From = 720,
                To = 0,
                Duration = TimeSpan.FromSeconds(0.3),
                EasingFunction = new QuadraticEase { EasingMode = EasingMode.EaseInOut }
            };

            Storyboard storyboard = new Storyboard();
            storyboard.Children.Add(widthAnimation);
            storyboard.Children.Add(heightAnimation);

            Storyboard.SetTarget(widthAnimation, MainBorder);
            Storyboard.SetTarget(heightAnimation, MainBorder);
            Storyboard.SetTargetProperty(widthAnimation, new PropertyPath(WidthProperty));
            Storyboard.SetTargetProperty(heightAnimation, new PropertyPath(HeightProperty));

            widthAnimation.Completed += (s, args) =>
            {
                this.Close();
            };

            storyboard.Begin();
        }
        private void DragBar_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.WindowState = WindowState.Normal;
            this.DragMove();
        }
        public static string GetAppVersion()
        {
            try
            {
                string version = ResourceManager.GetString("AppVersion");
                return version ?? "Version nicht gefunden";
            }
            catch (Exception ex)
            {
                return $"Fehler beim Lesen der Version: {ex.Message}";
            }
        }
        private void HelpBtn_Click(object sender, RoutedEventArgs e)
        {
            Help help = new Help();
            help.Show();
        }

        //Profil
        public int CountAccountsFunc()
        {
            try
            {
                if (File.Exists(filePath))
                {
                    string jsonContent = File.ReadAllText(filePath);

                    UserData? userData = JsonConvert.DeserializeObject<UserData>(jsonContent);

                    User? loggedInUser = userData?.Users?.FirstOrDefault(user => user.Username == LogedInUser.CurrentUser);

                    if (loggedInUser != null && loggedInUser.Data != null)
                    {
                        int count = loggedInUser.Data.Count;
                        StoredAccounts.Text = $"{count} Accounts";
                        return count;
                    }
                }
            }
            catch (Exception ex)
            {
                Notify("Fehler!", $"Fehler beim Zählen der Benutzerdaten: {ex.Message}", 5);
            }

            return -1;
        }
        private void UserProfilImageBorder_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Image Files (*.bmp;*.jpg;*.jpeg;*.gif;*.bmp)|*.png;*.jpg;*.jpeg;*.gif;*.png|All files (*.*)|*.*",
                Title = "Wähle ein Profilbild"
            };

            if (openFileDialog.ShowDialog() == true)
            {
                try
                {
                    string imagePath = openFileDialog.FileName;

                    try
                    {
                        if (!Directory.Exists(profilImageFolder))
                        {
                            Directory.CreateDirectory(profilImageFolder);
                        }

                        string uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(imagePath);
                        string destinationPath = Path.Combine(profilImageFolder, uniqueFileName);

                        File.Copy(imagePath, destinationPath, true);

                        // Speichern Sie den Profilbildpfad in der data.json mit der eindeutigen Dateinamen
                        SaveProfileImagePath(LogedInUser.CurrentUser, destinationPath);

                        // Lade und zeige das ausgewählte Bild an
                        SetImage(destinationPath, UserProfilImage);
                    }
                    catch (Exception ex)
                    {
                        Notify("Fehler!", $"Fehler beim Kopieren der Datei: {ex.Message}", 5);
                    }
                }
                catch (Exception ex)
                {
                    Notify("Fehler!", $"Fehler beim Laden des Profilbilds: {ex.Message}", 5);
                }
            }
        }
        private void SignOutBtn_Click(object sender, RoutedEventArgs e)
        {
            SaveCurrentUserData();

            LogedInUserPassword.CurrentPassword = string.Empty;
            LogedInUser.CurrentUser = string.Empty;

            Login login = new Login();
            login.Show();

            this.Close();
        }
        private void SaveProfileImagePath(string username, string imagePath)
        {
            try
            {
                // Lade vorhandene UserData aus der data.json
                UserData? userData = LoadUserData(LogedInUser.CurrentUser);

                // Finden Sie den Benutzer mit dem angegebenen Benutzernamen
                User? loggedInUser = userData.Users.FirstOrDefault(user => user.Username == username);

                UserSettings firstUserSettings = loggedInUser.Settings?.FirstOrDefault();

                if (loggedInUser != null)
                {
                    // Überprüfen Sie, ob die Datei existiert und ein gültiges Bild ist
                    if (File.Exists(imagePath) && IsImageFile(imagePath))
                    {
                        //Kopieren des Bildes in Assets ordner


                        // Aktualisieren Sie den Profilbildpfad
                        firstUserSettings.ProfileImagePath = imagePath;


                        // Speichern Sie die aktualisierten Benutzerdaten
                        SaveUserData(userData);
                        InitializeUserProfileImage();
                    }
                    else
                    {
                        Notify("Warnung", "Ungültige Bilddatei ausgewählt. Das Profilbild wurde nicht geändert.", 5);
                    }
                }
            }
            catch (Exception ex)
            {
                Notify("Fehler!", $"Fehler beim Speichern des Profilbildpfads: {ex.Message}", 5);
            }
        }
        private void SetImage(string imagePath, Image imageControl)
        {
            try
            {
                BitmapImage bitmap = new BitmapImage();

                if (File.Exists(imagePath) && IsImageFile(imagePath))
                {
                    // Wenn die Datei existiert und ein gültiges Bild ist, lade es
                    bitmap.BeginInit();
                    bitmap.UriSource = new Uri(imagePath, UriKind.Absolute);
                }
                else
                {
                    DefualtUserProfilImage.Visibility = Visibility.Visible;
                    UserProfilImage.Visibility = Visibility.Collapsed;
                }

                bitmap.EndInit();
                imageControl.Source = bitmap;
            }
            catch (Exception ex)
            {
                Notify("Fehler", $"Fehler beim Laden des Bilds: {ex.Message}", 5);
            }
        }
        private bool IsImageFile(string filePath)
        {
            try
            {
                // Überprüfen Sie die Dateierweiterung, um festzustellen, ob es sich um ein Bild handelt
                string extension = Path.GetExtension(filePath)?.ToLower();
                string[] validExtensions = { ".jpg", ".jpeg", ".png", ".gif", ".bmp" };

                return !string.IsNullOrEmpty(extension) && validExtensions.Contains(extension);
            }
            catch
            {
                return false;
            }
        }
        private void InitializeUserProfileImage()
        {
            try
            {
                // Laden Sie die vorhandenen UserData aus der data.json
                UserData? userData = LoadUserData(LogedInUser.CurrentUser);

                // Finden Sie den Benutzer mit dem angegebenen Benutzernamen
                User? loggedInUser = userData?.Users?.FirstOrDefault(user => user.Username == LogedInUser.CurrentUser);

                UserSettings firstUserSettings = loggedInUser.Settings?.FirstOrDefault();

                if (loggedInUser != null)
                {
                    // Überprüfen Sie, ob ein Profilbildpfad angegeben ist
                    if (!string.IsNullOrWhiteSpace(firstUserSettings.ProfileImagePath) && IsImageFile(firstUserSettings.ProfileImagePath))
                    {
                        // Wenn ein gültiger Bildpfad vorhanden ist, lade und zeige das Bild an
                        UserProfilImage.Visibility = Visibility.Visible;
                        DefualtUserProfilImage.Visibility = Visibility.Collapsed;
                        SetImage(firstUserSettings.ProfileImagePath, UserProfilImage);
                    }
                    else
                    {
                        // Wenn kein gültiger Bildpfad angegeben ist oder der Pfad null ist, lade das Standardprofilbild
                        LoadDefaultProfileImage();
                    }
                }
            }
            catch (Exception ex)
            {
                Notify("Fehler", $"Fehler beim Initialisieren des Profilbilds: {ex.Message}", 5);
            }
        }
        private void LoadDefaultProfileImage()
        {
            UserProfilImage.Visibility = Visibility.Collapsed;
            DefualtUserProfilImage.Visibility = Visibility.Visible;
        }
        private void UserSettings_Click(object sender, RoutedEventArgs e)
        {
            ManageWindows("settings");
        }
        private void OpenSettingsWindow()
        {
            UserSettingsOpen = true;

            DoubleAnimation widthAnimation = new DoubleAnimation
            {
                From = 0,
                To = 830,
                Duration = TimeSpan.FromSeconds(0.3),
                EasingFunction = new QuadraticEase { EasingMode = EasingMode.EaseInOut }
            };

            Storyboard storyboard = new Storyboard();
            storyboard.Children.Add(widthAnimation);

            Storyboard.SetTarget(widthAnimation, UserSettingsWindow);
            Storyboard.SetTargetProperty(widthAnimation, new PropertyPath(WidthProperty));

            widthAnimation.Completed += (s, args) =>
            {
                UserSettingsWindow.IsHitTestVisible = true;
            };

            UserSettings.Background = new SolidColorBrush(Color.FromRgb(80, 80, 80));
            storyboard.Begin();
        }
        private void CloseSettingsWindow()
        {
            UserSettingsOpen = false;

            DoubleAnimation widthAnimation = new DoubleAnimation
            {
                From = 830,
                To = 0,
                Duration = TimeSpan.FromSeconds(0.3),
                EasingFunction = new QuadraticEase { EasingMode = EasingMode.EaseInOut }
            };

            Storyboard storyboard = new Storyboard();
            storyboard.Children.Add(widthAnimation);

            Storyboard.SetTarget(widthAnimation, UserSettingsWindow);
            Storyboard.SetTargetProperty(widthAnimation, new PropertyPath(WidthProperty));

            widthAnimation.Completed += (s, args) =>
            {
                UserSettingsWindow.IsHitTestVisible = false;
            };

            UserSettings.Background = new SolidColorBrush(Color.FromRgb(60, 60, 60));
            storyboard.Begin();
        }
        private void DumpThisDataBase_Click(object sender, RoutedEventArgs e)
        {
            ManageWindows("exportdata");
        }
        private void CloseExportBtn_Click(object sender, RoutedEventArgs e)
        {
            CloseDataExportWindow();
        }
        private void OpenDataExportWindow()
        {
            DataExportWindowOpen = true;

            DoubleAnimation widthAnimation = new DoubleAnimation
            {
                From = 0,
                To = 205,
                Duration = TimeSpan.FromSeconds(0.3),
                EasingFunction = new QuadraticEase { EasingMode = EasingMode.EaseInOut }
            };

            Storyboard storyboard = new Storyboard();
            storyboard.Children.Add(widthAnimation);

            Storyboard.SetTarget(widthAnimation, DataExportWindow);
            Storyboard.SetTargetProperty(widthAnimation, new PropertyPath(WidthProperty));

            widthAnimation.Completed += (s, args) =>
            {
                DataExportWindow.IsHitTestVisible = true;
            };

            storyboard.Begin();
        }
        private void CloseDataExportWindow()
        {
            DataExportWindowOpen = false;

            DoubleAnimation widthAnimation = new DoubleAnimation
            {
                From = 205,
                To = 0,
                Duration = TimeSpan.FromSeconds(0.3),
                EasingFunction = new QuadraticEase { EasingMode = EasingMode.EaseInOut }
            };

            Storyboard storyboard = new Storyboard();
            storyboard.Children.Add(widthAnimation);

            Storyboard.SetTarget(widthAnimation, DataExportWindow);
            Storyboard.SetTargetProperty(widthAnimation, new PropertyPath(WidthProperty));

            widthAnimation.Completed += (s, args) =>
            {
                DataExportWindow.IsHitTestVisible = false;
            };

            storyboard.Begin();
        }
        private void ExportAsTextBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Überprüfen, ob die Datei bereits existiert
                if (File.Exists(filePath))
                {
                    try
                    {
                        string jsonText = File.ReadAllText(filePath);
                        JObject jsonRoot = JObject.Parse(jsonText);
                        JToken user = jsonRoot["Users"].FirstOrDefault(u => u["Username"]?.ToString() == LogedInUser.CurrentUser);

                        if (user != null)
                        {
                            JToken userData = user["Data"];

                            // Öffnen des SaveFileDialog
                            SaveFileDialog saveFileDialog = new SaveFileDialog();
                            saveFileDialog.Filter = "Textdatei (*.txt)|*.txt";
                            saveFileDialog.Title = "Speicherort wählen";
                            saveFileDialog.FileName = $"{LogedInUser.CurrentUser} - {DateTime.Now.ToString("MM-dd-yyyy")}";

                            if (saveFileDialog.ShowDialog() == true)
                            {
                                string outputFilePath = saveFileDialog.FileName;

                                using (StreamWriter writer = new StreamWriter(outputFilePath))
                                {
                                    foreach (JToken dataItem in userData)
                                    {
                                        writer.WriteLine($"Application: {dataItem["Application"]}");
                                        writer.WriteLine($"AppUsername: {dataItem["AppUsername"]}");
                                        writer.WriteLine($"AppPassword: {Decrypt(dataItem["AppPassword"].ToString(), GenerateKey(DecryptKey))}");
                                        writer.WriteLine($"AppEmail: {Decrypt(dataItem["AppEmail"].ToString(), GenerateKey(DecryptKey))}");
                                        writer.WriteLine($"AppEmailPassword: {Decrypt(dataItem["AppEmailPassword"].ToString(), GenerateKey(DecryptKey))}");
                                        writer.WriteLine($"AppInfo: {dataItem["AppInfo"]}");
                                        writer.WriteLine();
                                    }
                                }

                                Notify("Exportieren", $"Die Daten wurden erfolgreich in '{outputFilePath}' gespeichert.", 5);
                            }
                        }
                        else
                        {
                            Notify("Info", $"Benutzer '{LogedInUser.CurrentUser}' nicht gefunden.", 5);
                        }
                    }
                    catch (Exception ex)
                    {
                        Notify("Fehler!", $"Fehler beim Laden und Speichern der Daten: {ex.Message}", 5);
                    }
                }
            }
            catch (Exception ex)
            {
                Notify("Fehler!", "Datenbank nicht gefunden...", 5);
            }
        }
        private void ExportAsExcelBtn_Click(object sender, RoutedEventArgs e)
        {
            // Setzen des Lizenzkontexts vor der Verwendung von EPPlus
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            try
            {
                // Überprüfen, ob die Datei bereits existiert
                if (File.Exists(filePath))
                {
                    try
                    {
                        string jsonText = File.ReadAllText(filePath);
                        JObject jsonRoot = JObject.Parse(jsonText);
                        JToken user = jsonRoot["Users"].FirstOrDefault(u => u["Username"]?.ToString() == LogedInUser.CurrentUser);

                        if (user != null)
                        {
                            JToken userData = user["Data"];

                            // Öffnen des SaveFileDialog
                            SaveFileDialog saveFileDialog = new SaveFileDialog();
                            saveFileDialog.Filter = "Excel-Datei (*.xlsx)|*.xlsx"; // Filter auf Excel ändern
                            saveFileDialog.Title = "Speicherort wählen";
                            saveFileDialog.FileName = $"{LogedInUser.CurrentUser} - {DateTime.Now.ToString("MM-dd-yyyy")}.xlsx"; // Dateierweiterung ändern

                            if (saveFileDialog.ShowDialog() == true)
                            {
                                string outputFilePath = saveFileDialog.FileName;

                                // Erstellen einer neuen ExcelPackage
                                using (ExcelPackage excelPackage = new ExcelPackage())
                                {
                                    // Hinzufügen eines Arbeitsblatts
                                    ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets.Add("UserData");

                                    // Überschriften hinzufügen
                                    worksheet.Cells[1, 1].Value = "Application";
                                    worksheet.Cells[1, 2].Value = "AppUsername";
                                    worksheet.Cells[1, 3].Value = "AppPassword";
                                    worksheet.Cells[1, 4].Value = "AppEmail";
                                    worksheet.Cells[1, 5].Value = "AppEmailPassword";
                                    worksheet.Cells[1, 6].Value = "AppInfo";

                                    int row = 2;

                                    foreach (JToken dataItem in userData)
                                    {
                                        // Daten in die Tabelle einfügen
                                        worksheet.Cells[row, 1].Value = dataItem["Application"].ToString();
                                        worksheet.Cells[row, 2].Value = dataItem["AppUsername"].ToString();
                                        worksheet.Cells[row, 3].Value = Decrypt(dataItem["AppPassword"].ToString(), GenerateKey(DecryptKey));
                                        worksheet.Cells[row, 4].Value = Decrypt(dataItem["AppEmail"].ToString(), GenerateKey(DecryptKey));
                                        worksheet.Cells[row, 5].Value = Decrypt(dataItem["AppEmailPassword"].ToString(), GenerateKey(DecryptKey));
                                        worksheet.Cells[row, 6].Value = dataItem["AppInfo"].ToString();

                                        row++;
                                    }

                                    // Erstellen einer Tabelle mit Daten
                                    var dataRange = worksheet.Cells["A1:F" + (row - 1)];
                                    var table = worksheet.Tables.Add(dataRange, "UserDataTable");

                                    // Stil der Tabelle festlegen
                                    table.TableStyle = OfficeOpenXml.Table.TableStyles.Light1;

                                    // Speichern der Excel-Datei
                                    excelPackage.SaveAs(new FileInfo(outputFilePath));
                                }

                                Notify("Exportieren", $"Die Daten wurden erfolgreich in '{outputFilePath}' gespeichert.", 5);
                            }
                        }
                        else
                        {
                            Notify("Info", $"Benutzer '{LogedInUser.CurrentUser}' nicht gefunden.", 5);
                        }
                    }
                    catch (Exception ex)
                    {
                        Notify("Fehler!", $"Fehler beim Laden und Speichern der Daten: {ex.Message}", 5);
                    }
                }
            }
            catch (Exception ex)
            {
                Notify("Fehler!", "Datenbank nicht gefunden...", 5);
            }

        }
        private void ExportAsJsonBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Überprüfen, ob die Datei bereits existiert
                if (File.Exists(filePath))
                {
                    try
                    {
                        string jsonText = File.ReadAllText(filePath);
                        JObject jsonRoot = JObject.Parse(jsonText);
                        JToken user = jsonRoot["Users"].FirstOrDefault(u => u["Username"]?.ToString() == LogedInUser.CurrentUser);

                        if (user != null)
                        {
                            JToken userData = user["Data"];

                            // Öffnen des SaveFileDialog
                            SaveFileDialog saveFileDialog = new SaveFileDialog();
                            saveFileDialog.Filter = "JSON-Datei (*.json)|*.json"; // Filter auf JSON ändern
                            saveFileDialog.Title = "Speicherort wählen";
                            saveFileDialog.FileName = $"{LogedInUser.CurrentUser} - {DateTime.Now.ToString("MM-dd-yyyy")}.json"; // Dateierweiterung ändern

                            if (saveFileDialog.ShowDialog() == true)
                            {
                                string outputFilePath = saveFileDialog.FileName;

                                // Erstellen eines neuen JObject für den Export
                                JObject exportData = new JObject();
                                JArray userDataArray = new JArray();

                                foreach (JToken dataItem in userData)
                                {
                                    // Erstellen eines neuen JObjects für jeden Datenpunkt
                                    JObject userDataObject = new JObject();
                                    userDataObject["Application"] = dataItem["Application"];
                                    userDataObject["AppUsername"] = dataItem["AppUsername"];
                                    userDataObject["AppPassword"] = Decrypt(dataItem["AppPassword"].ToString(), GenerateKey(DecryptKey));
                                    userDataObject["AppEmail"] = Decrypt(dataItem["AppEmail"].ToString(), GenerateKey(DecryptKey));
                                    userDataObject["AppEmailPassword"] = Decrypt(dataItem["AppEmailPassword"].ToString(), GenerateKey(DecryptKey));
                                    userDataObject["AppInfo"] = dataItem["AppInfo"];

                                    // Hinzufügen des Datenpunkts zum Array
                                    userDataArray.Add(userDataObject);
                                }

                                // Hinzufügen des Benutzers zum exportierten JSON
                                exportData["User"] = userDataArray;

                                // Schreiben des exportierten JSON in die Datei
                                File.WriteAllText(outputFilePath, exportData.ToString());

                                Notify("Exportieren", $"Die Daten wurden erfolgreich in '{outputFilePath}' gespeichert.", 5);
                            }
                        }
                        else
                        {
                            Notify("Info", $"Benutzer '{LogedInUser.CurrentUser}' nicht gefunden.", 5);
                        }
                    }
                    catch (Exception ex)
                    {
                        Notify("Fehler!", $"Fehler beim Laden und Speichern der Daten: {ex.Message}", 5);
                    }
                }
            }
            catch (Exception ex)
            {
                Notify("Fehler!", "Datenbank nicht gefunden...", 5);
            }

        }
        private void CloseUserSettings_Click(object sender, RoutedEventArgs e)
        {
            CloseSettingsWindow();
        }
        private void SaveUserSettings_Click(object sender, EventArgs e)
        {
            string currentUser = LogedInUser.CurrentUser;

            if (!string.IsNullOrEmpty(currentUser))
            {
                try
                {
                    string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "data", "data.json");
                    string jsonContent = File.ReadAllText(filePath);

                    // Deserialisiere den JSON-Text in ein Objekt
                    var userData = JsonConvert.DeserializeObject<UserData>(jsonContent);

                    // Finde den Benutzer in der Liste
                    var currentUserData = userData?.Users?.FirstOrDefault(user => user?.Username == currentUser);

                    if (currentUserData != null)
                    {
                        // Aktualisiere die Benutzerdaten
                        currentUserData.Username = CurrentUsername.Text;
                        currentUserData.Email = Encrypt(CurrentEmail.Text, GenerateKey(DecryptKey));
                        currentUserData.Password = Encrypt(CurrentPassword.Password, GenerateKey(DecryptKey));

                        if (RepeatPassword.Password == CurrentPassword.Password)
                        {
                            // Serialisiere die aktualisierten Daten zurück in JSON
                            string updatedJsonContent = JsonConvert.SerializeObject(userData, Formatting.Indented);

                            // Schreibe die Daten zurück in die JSON-Datei
                            File.WriteAllText(filePath, updatedJsonContent);

                            CloseSettingsWindow();

                            // Benachrichtige über erfolgreiche Speicherung
                            Notify("Benutzerkonto", "Benutzereinstellungen erfolgreich gespeichert.", 5);
                        }
                        else
                        {
                            Notify("Info", "Die Passwöter stimmen nicht überein!", 5);
                        }
                    }
                    else
                    {
                        Notify("Fehler!", $"Benutzer '{currentUser}' nicht gefunden.", 5);
                    }
                }
                catch (Exception ex)
                {
                    Notify("Fehler!", $"Fehler beim Speichern der Benutzereinstellungen: {ex.Message}", 5);
                }
            }
            else
            {
                Notify("Info", "Es ist kein Benutzer angemeldet.", 5);
            }
        }
        private async void DeleteDataBase_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Überprüfen, ob der Ordner existiert
                if (Directory.Exists(folderPath))
                {

                    if (await QuestBox("Wollen sie die Datenbank wirklich unwiederruflich löschen?"))
                    {
                        try
                        {
                            // Laden Sie die JSON-Daten aus der Datei
                            string jsonContent = File.ReadAllText(filePath);
                            UserData userData = JsonConvert.DeserializeObject<UserData>(jsonContent);

                            if (userData != null && userData.Users != null)
                            {
                                string usernameToDelete = LogedInUser.CurrentUser;  // Geben Sie den zu löschenden Benutzernamen ein

                                // Konvertieren Sie das Array in eine Liste für die Verwendung von RemoveAll
                                List<User> userList = userData.Users.ToList();

                                // Entfernen Sie alle Benutzer mit dem angegebenen Benutzernamen
                                userList.RemoveAll(user => user.Username == usernameToDelete);

                                // Konvertieren Sie die Liste wieder in ein Array
                                userData.Users = userList.ToArray();

                                // Speichern Sie die aktualisierten Daten zurück in die Datei
                                string updatedJson = JsonConvert.SerializeObject(userData, Formatting.Indented);
                                File.WriteAllText(filePath, updatedJson);

                                Login login = new Login();
                                login.Show();
                                this.Close();
                                Console.WriteLine($"Benutzer mit dem Benutzernamen '{usernameToDelete}' wurde erfolgreich gelöscht.");
                            }
                            else
                            {
                                Console.WriteLine($"Benutzerliste nicht gefunden.");
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Fehler beim Löschen des Benutzers: {ex.Message}");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Notify("Fehler", "Fehler beim Löschen der Datenbank: " + ex.Message, 5);
            }
        }
        private void ShowInfo_Checked(object sender, RoutedEventArgs e)
        {
            // Lade Benutzerdaten
            var userData = LoadUserData(LogedInUser.CurrentUser);

            // Überprüfen, ob der Benutzer angemeldet ist und Benutzerdaten geladen wurden
            if (userData != null)
            {
                // Das erste UserSettings-Objekt wird verwendet (Annahme: Es gibt nur eins)
                var settings = userData.Users?.FirstOrDefault(u => u.Username == LogedInUser.CurrentUser)?.Settings?.FirstOrDefault();

                // Überprüfen, ob ShowGridInfo true oder false ist
                if (settings != null)
                {
                    // Setze ShowGridInfo auf true
                    settings.ShowGridInfo = true;

                    // Speichere die Änderungen in der JSON-Datei
                    SaveUserData(userData);
                    RefreshDataGrid();
                }
            }
        }
        private void ShowInfo_Unchecked(object sender, RoutedEventArgs e)
        {
            // Lade Benutzerdaten
            var userData = LoadUserData(LogedInUser.CurrentUser);

            // Überprüfen, ob der Benutzer angemeldet ist und Benutzerdaten geladen wurden
            if (userData != null)
            {
                // Das erste UserSettings-Objekt wird verwendet (Annahme: Es gibt nur eins)
                var settings = userData.Users?.FirstOrDefault(u => u.Username == LogedInUser.CurrentUser)?.Settings?.FirstOrDefault();

                // Überprüfen, ob ShowGridInfo true oder false ist
                if (settings != null)
                {
                    // Setze ShowGridInfo auf false
                    settings.ShowGridInfo = false;

                    // Speichere die Änderungen in der JSON-Datei
                    SaveUserData(userData);
                    RefreshDataGrid();
                }
            }
        }
        private void SortAZ_Checked(object sender, RoutedEventArgs e)
        {
            // Lade Benutzerdaten
            var userData = LoadUserData(LogedInUser.CurrentUser);

            // Überprüfen, ob der Benutzer angemeldet ist und Benutzerdaten geladen wurden
            if (userData != null)
            {
                // Das erste UserSettings-Objekt wird verwendet (Annahme: Es gibt nur eins)
                var settings = userData.Users?.FirstOrDefault(u => u.Username == LogedInUser.CurrentUser)?.Settings?.FirstOrDefault();

                // Überprüfen, ob ShowGridInfo true oder false ist
                if (settings != null)
                {
                    // Setze ShowGridInfo auf true
                    settings.SortAZ = true;

                    // Speichere die Änderungen in der JSON-Datei
                    SaveUserData(userData);
                    RefreshDataGrid();

                    SortAZSetting = true;

                    var column = Datagrid.Columns.FirstOrDefault(c => c.SortMemberPath == "Application");
                    if (column != null)
                    {
                        Datagrid.Items.SortDescriptions.Clear();
                        Datagrid.Items.SortDescriptions.Add(new SortDescription(column.SortMemberPath, ListSortDirection.Ascending));
                        column.SortDirection = ListSortDirection.Ascending;
                    }
                }
            }
        }
        private void SortAZ_Unchecked(object sender, RoutedEventArgs e)
        {
            // Lade Benutzerdaten
            var userData = LoadUserData(LogedInUser.CurrentUser);

            // Überprüfen, ob der Benutzer angemeldet ist und Benutzerdaten geladen wurden
            if (userData != null)
            {
                // Das erste UserSettings-Objekt wird verwendet (Annahme: Es gibt nur eins)
                var settings = userData.Users?.FirstOrDefault(u => u.Username == LogedInUser.CurrentUser)?.Settings?.FirstOrDefault();

                // Überprüfen, ob ShowGridInfo true oder false ist
                if (settings != null)
                {
                    // Setze ShowGridInfo auf false
                    settings.SortAZ = false;

                    // Speichere die Änderungen in der JSON-Datei
                    SaveUserData(userData);
                    RefreshDataGrid();

                    SortAZSetting = false;

                    Datagrid.Items.SortDescriptions.Clear();

                }
            }
        }
        private void GridInfoCell_Loaded(object sender, RoutedEventArgs e)
        {
            // Annahme: Du hast eine Instanz deines Benutzers, z.B., durch eine Singleton-Klasse wie LogedInUser
            string? loggedInUsername = LogedInUser.CurrentUser;

            // Der Auslöser des Ereignisses (Sender) wird als Button interpretiert
            var button = sender as System.Windows.Controls.Button;

            // Überprüfen, ob das Sender-Objekt ein Button ist und der Benutzer angemeldet ist
            if (button != null && loggedInUsername != null)
            {
                // Das erste UserSettings-Objekt wird verwendet (Annahme: Es gibt nur eins)
                var user = GetUserByUsername(loggedInUsername);

                if (user != null && user.Settings != null && user.Settings.Count > 0)
                {
                    var settings = user.Settings[0];

                    // Überprüfen, ob ShowGridInfo true oder false ist
                    if (settings.ShowGridInfo)
                    {
                        // Hier die Logik für die Anzeige, wenn ShowGridInfo true ist
                        var stackPanel = button.Content as StackPanel;

                        // Überprüfen, ob das StackPanel nicht null ist
                        if (stackPanel != null)
                        {
                            // Das zweite Kind (TextBlock) wird sichtbar
                            stackPanel.Children[0].Visibility = Visibility.Collapsed;
                            stackPanel.Children[1].Visibility = Visibility.Visible;
                        }
                    }
                    else
                    {
                        // Hier die Logik für die Anzeige, wenn ShowGridInfo false ist
                        var stackPanel = button.Content as StackPanel;

                        // Überprüfen, ob das StackPanel nicht null ist
                        if (stackPanel != null)
                        {
                            // Das zweite Kind (TextBlock) wird unsichtbar
                            stackPanel.Children[0].Visibility = Visibility.Visible;
                            stackPanel.Children[1].Visibility = Visibility.Collapsed;
                        }
                    }
                }
                else
                {
                    // Fehlermeldung oder Benachrichtigung, dass Benutzer oder Einstellungen nicht gefunden wurden
                }
            }
        }
        private void CostumBorderColor_Click(object sender, RoutedEventArgs e)
        {

            System.Windows.Forms.ColorDialog colorDialog = new System.Windows.Forms.ColorDialog();

            if (colorDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                double brightnessScale = 0.25;

                byte scaledR = (byte)(colorDialog.Color.R * brightnessScale);
                byte scaledG = (byte)(colorDialog.Color.G * brightnessScale);
                byte scaledB = (byte)(colorDialog.Color.B * brightnessScale);

                System.Windows.Media.Color wpfColor = System.Windows.Media.Color.FromArgb(230, scaledR, scaledG, scaledB);

                MainBorder.Background = new SolidColorBrush(wpfColor);

                try
                {
                    if (File.Exists(filePath))
                    {
                        string existingJsonContent = File.ReadAllText(filePath);

                        UserData existingData = JsonConvert.DeserializeObject<UserData>(existingJsonContent);

                        User loggedInUser = existingData?.Users?.FirstOrDefault(user =>
                            user.Username == LogedInUser.CurrentUser || user.Email == LogedInUser.CurrentUser);

                        if (loggedInUser != null)
                        {
                            string[] customColor = new string[] { "231", scaledR.ToString(), scaledG.ToString(), scaledB.ToString() };

                            UserSettings userSettings = new UserSettings
                            {
                                CustomBorderColor = customColor
                            };

                            // Überprüfen, ob benutzerdefinierte Farbe vorhanden ist
                            if (loggedInUser.Settings != null && loggedInUser.Settings.Count > 0)
                            {
                                loggedInUser.Settings[0].CustomBorderColor = customColor;
                            }
                            else
                            {
                                // Falls nicht, erstellen Sie eine neue Liste von Einstellungen
                                loggedInUser.Settings = new List<UserSettings> { userSettings };
                            }

                            WriteJsonFile(filePath, JsonConvert.SerializeObject(existingData, Formatting.Indented));
                        }
                        else
                        {
                            Notify("Fehler", "Benutzer nicht gefunden.", 5);
                        }
                    }
                    else
                    {
                        Notify("Fehler", "Datenbankdatei nicht gefunden.", 5);
                    }
                }
                catch (Exception ex)
                {
                    Notify("Fehler", $"Fehler beim Aktualisieren der Daten: {ex.Message}", 5);
                }
            }
        }
        private void CreateDatabaseBackup_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Überprüfen, ob die Datei bereits existiert
                if (File.Exists(filePath))
                {
                    try
                    {
                        string jsonText = File.ReadAllText(filePath);
                        JObject jsonRoot = JObject.Parse(jsonText);
                        JToken user = jsonRoot["Users"].FirstOrDefault(u => u["Username"]?.ToString() == LogedInUser.CurrentUser);

                        if (user != null)
                        {
                            // Erstellen eines neuen JObjects nur mit den benötigten Informationen
                            JObject backupData = new JObject
                            {
                                { "Username", user["Username"] },
                                { "Settings", user["Settings"] },
                                { "Data", user["Data"] }
                            };

                            // Öffnen des SaveFileDialog
                            SaveFileDialog saveFileDialog = new SaveFileDialog();
                            saveFileDialog.Title = "Speicherort für Backup wählen";
                            saveFileDialog.FileName = $"backup_{DateTime.Now.ToString("MM-dd-yyyy")}.json"; // Ändere den Dateinamen nach Bedarf

                            if (saveFileDialog.ShowDialog() == true)
                            {
                                string outputFilePath = saveFileDialog.FileName;

                                // Speichern des Backups in einer neuen Datei
                                File.WriteAllText(outputFilePath, backupData.ToString());

                                Notify("Backup", $"Das Backup wurde erfolgreich in '{outputFilePath}' gespeichert.", 5);
                            }
                        }
                        else
                        {
                            Notify("Info", $"Benutzer '{LogedInUser.CurrentUser}' nicht gefunden.", 5);
                        }
                    }
                    catch (Exception ex)
                    {
                        Notify("Fehler!", $"Fehler beim Laden und Speichern der Daten: {ex.Message}", 5);
                    }
                }
            }
            catch (Exception ex)
            {
                Notify("Fehler!", "Datenbank nicht gefunden...", 5);
            }
        }
        private void LoadDatabaseBackup_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Öffnen des OpenFileDialog
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Title = "Backup-Datei auswählen";
                openFileDialog.Filter = "JSON-Dateien (*.json)|*.json";

                if (openFileDialog.ShowDialog() == true)
                {
                    string backupFilePath = openFileDialog.FileName;

                    // Überprüfen, ob die Backup-Datei existiert
                    if (File.Exists(backupFilePath))
                    {
                        try
                        {
                            // Einlesen des Backup-JSONs
                            string backupJsonText = File.ReadAllText(backupFilePath);
                            JObject backupUser = JObject.Parse(backupJsonText);

                            // Einlesen der vorhandenen Daten
                            string jsonText = File.ReadAllText(filePath);
                            JObject jsonRoot = JObject.Parse(jsonText);

                            // Finden des Benutzers in der vorhandenen Datenstruktur
                            JToken existingUser = jsonRoot["Users"].FirstOrDefault(u => u["Username"]?.ToString() == backupUser["Username"]?.ToString());

                            if (existingUser != null)
                            {
                                // Kopieren der Benutzerdaten (außer Passwort)
                                existingUser["Settings"] = backupUser["Settings"];
                                existingUser["Data"] = backupUser["Data"];

                                File.WriteAllText(filePath, jsonRoot.ToString());


                                InitializeUserProfileImage();
                                RefreshDataGrid();
                                CountAccountsFunc();

                                var customBorderColor = LoadUserCustomBorderColor(LogedInUser.CurrentUser);

                                if (customBorderColor != null)
                                {
                                    MainBorder.Background = new SolidColorBrush(customBorderColor.Value);
                                }

                                Notify("Restore", $"Das Backup wurde erfolgreich wiederhergestellt.", 5);
                            }
                            else
                            {
                                Notify("Info", $"Benutzer '{backupUser["Username"]}' nicht in den vorhandenen Daten gefunden.", 5);
                            }
                        }
                        catch (Exception ex)
                        {
                            Notify("Fehler!", $"Fehler beim Laden und Speichern der Daten: {ex.Message}", 5);
                        }
                    }
                    else
                    {
                        Notify("Info", $"Die Backup-Datei '{backupFilePath}' existiert nicht.", 5);
                    }
                }
            }
            catch (Exception ex)
            {
                Notify("Fehler!", $"Fehler beim Laden des Backups: {ex.Message}", 5);
            }

        }
        private void ExportCSV_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Überprüfen, ob die Datei bereits existiert
                if (File.Exists(filePath))
                {
                    try
                    {
                        string jsonText = File.ReadAllText(filePath);
                        JObject jsonRoot = JObject.Parse(jsonText);
                        JToken user = jsonRoot["Users"].FirstOrDefault(u => u["Username"]?.ToString() == LogedInUser.CurrentUser);

                        if (user != null)
                        {
                            JToken userData = user["Data"];

                            // Öffnen des SaveFileDialog
                            SaveFileDialog saveFileDialog = new SaveFileDialog();
                            saveFileDialog.Filter = "CSV datei (*.csv)|*.csv";
                            saveFileDialog.Title = "Speicherort wählen";
                            saveFileDialog.FileName = $"{LogedInUser.CurrentUser} - {DateTime.Now.ToString("MM-dd-yyyy")}";

                            if (saveFileDialog.ShowDialog() == true)
                            {
                                string outputFilePath = saveFileDialog.FileName;

                                using (StreamWriter writer = new StreamWriter(outputFilePath, false, Encoding.UTF8))
                                {
                                    // Schreiben der CSV-Header
                                    writer.WriteLine("name,url,username,password,note");

                                    foreach (JToken dataItem in userData)
                                    {
                                        // Schreiben der Daten in CSV-Format
                                        writer.WriteLine($"{dataItem["Application"]},{dataItem["AppLink"]},{dataItem["AppUsername"]},{Decrypt(dataItem["AppPassword"].ToString(), GenerateKey(DecryptKey))},{dataItem["AppInfo"]}");
                                    }
                                }

                                Notify("Exportieren", $"Die Daten wurden erfolgreich in '{outputFilePath}' gespeichert.", 5);
                            }
                        }
                        else
                        {
                            Notify("Info", $"Benutzer '{LogedInUser.CurrentUser}' nicht gefunden.", 5);
                        }
                    }
                    catch (Exception ex)
                    {
                        Notify("Fehler!", $"Fehler beim Laden und Speichern der Daten: {ex.Message}", 5);
                    }
                }
            }
            catch (Exception ex)
            {
                Notify("Fehler!", "Datenbank nicht gefunden...", 5);
            }
        }
        private void ImportCSV_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Öffnen des OpenFileDialog
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "CSV-Dateien (*.csv)|*.csv";
                openFileDialog.Title = "CSV-Datei auswählen";

                if (openFileDialog.ShowDialog() == true)
                {
                    string CSVFilePath = openFileDialog.FileName;

                    // Überprüfen, ob die CSV-Datei Daten enthält
                    if (new FileInfo(CSVFilePath).Length == 0)
                    {
                        Notify("Fehler!", "Die ausgewählte Datei ist leer.", 5);
                        return;
                    }

                    // Lesen der vorhandenen JSON-Datei
                    string existingJsonContent = File.ReadAllText(filePath);

                    // Überprüfen, ob die JSON-Daten nicht leer sind
                    if (string.IsNullOrWhiteSpace(existingJsonContent))
                    {
                        Notify("Fehler!", "Die ausgewählte Datei enthält keine gültigen JSON-Daten.", 5);
                        return;
                    }

                    UserData existingData = JsonConvert.DeserializeObject<UserData>(existingJsonContent);

                    // Hinzufügen der importierten Daten zur vorhandenen JSON-Datenstruktur
                    User loggedInUser = existingData?.Users?.FirstOrDefault(user =>
                        user.Username == LogedInUser.CurrentUser || user.Email == LogedInUser.CurrentUser);

                    int maxId = loggedInUser.Data?.Any() == true ? loggedInUser.Data.Max(entry => int.TryParse(entry.ID, out int id) ? id : 0) : 0;

                    // Einlesen der CSV-Datei
                    List<UserDataDetails> importedData = new List<UserDataDetails>();
                    using (StreamReader reader = new StreamReader(CSVFilePath, Encoding.UTF8))
                    {
                        // Überspringen des Headers
                        reader.ReadLine(); // erste Zeile überspringen

                        while (!reader.EndOfStream)
                        {
                            string line = reader.ReadLine();
                            string[] parts = line.Split(',');

                            // Hier können Sie die Teile der Zeile verarbeiten
                            string application = parts[0];
                            string appLink = parts[1];
                            string appUsername = parts[2];
                            string appPassword = parts[3];
                            string appInfo = parts[4];

                            // Erstellen eines UserDataDetails-Objekts für jeden Eintrag
                            UserDataDetails userDataDetails = new UserDataDetails
                            {
                                ID = (maxId + 1).ToString(),
                                Application = application,
                                AppLink = appLink,
                                AppUsername = appUsername,
                                AppPassword = Encrypt(appPassword, GenerateKey(DecryptKey)),
                                AppEmail = "/",
                                AppEmailPassword = "/",
                                AppInfo = appInfo,
                                AppTag = "Sonstige",
                                AppColor = new string[] { "255", "137", "0", "0" }
                            };

                            // Hinzufügen des UserDataDetails-Objekts zur Liste
                            importedData.Add(userDataDetails);
                        }
                    }

                    if (loggedInUser != null)
                    {
                        loggedInUser.Data ??= new List<UserDataDetails>();
                        loggedInUser.Data.AddRange(importedData);

                        // Speichern der aktualisierten JSON-Daten in der Datei
                        WriteJsonFile(filePath, JsonConvert.SerializeObject(existingData, Formatting.Indented));

                        Notify("Importieren", $"Die Daten aus '{CSVFilePath}' wurden erfolgreich importiert und in die JSON-Datei geschrieben.", 5);
                        RefreshDataGrid();
                    }
                    else
                    {
                        Notify("Fehler", "Benutzer nicht gefunden.", 5);
                    }
                }
            }
            catch (Exception ex)
            {
                Notify("Fehler!", $"Fehler beim Importieren und Schreiben der Daten in die JSON-Datei: {ex.Message}", 5);
                Clipboard.SetText(ex.Message);
            }
        }
        private void AutosavePath_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Überprüfen, ob die Datei bereits existiert
                if (File.Exists(filePath))
                {
                    try
                    {
                        string jsonText = File.ReadAllText(filePath);
                        JObject jsonRoot = JObject.Parse(jsonText);
                        JToken user = jsonRoot["Users"].FirstOrDefault(u => u["Username"]?.ToString() == LogedInUser.CurrentUser);

                        if (user != null)
                        {
                            JToken userData = user["Data"];

                            // Öffnen des SaveFileDialog
                            SaveFileDialog saveFileDialog = new SaveFileDialog();
                            saveFileDialog.Filter = "Textdatei (*.txt)|*.txt";
                            saveFileDialog.Title = "Speicherort wählen";
                            saveFileDialog.FileName = $"Autosave-{DateTime.Now.ToString("MM-dd-yyyy")}";

                            if (saveFileDialog.ShowDialog() == true)
                            {
                                string outputFilePath = saveFileDialog.FileName;

                                StoreAutoSavePath(outputFilePath);
                            }
                        }
                        else
                        {
                            Notify("Info", $"Benutzer '{LogedInUser.CurrentUser}' nicht gefunden.", 5);
                        }
                    }
                    catch (Exception ex)
                    {
                        Notify("Fehler!", $"Fehler beim Speichern des Pfades: {ex.Message}", 5);
                    }
                }
            }
            catch (Exception ex)
            {
                Notify("Fehler!", "Datenbank nicht gefunden...", 5);
            }
        }
        private void StoreAutoSavePath(string autosavepath)
        {
            try
            {
                // Lade vorhandene UserData aus der data.json
                UserData? userData = LoadUserData(LogedInUser.CurrentUser);

                // Finden Sie den Benutzer mit dem angegebenen Benutzernamen
                User? loggedInUser = userData.Users.FirstOrDefault(user => user.Username == LogedInUser.CurrentUser);

                UserSettings firstUserSettings = loggedInUser.Settings?.FirstOrDefault();

                if (loggedInUser != null)
                {
                    firstUserSettings.AutoSavePath = autosavepath;
                    SaveUserData(userData);
                    AutosavePath.Background = new SolidColorBrush(Color.FromRgb(100, 100, 100));
                }
            }
            catch (Exception ex)
            {
                Notify("Fehler!", $"Fehler beim Speichern des Pfades: {ex.Message}", 5);
            }
        }
        private void AutoSave()
        {
            try
            {
                // Lade vorhandene UserData aus der data.json
                UserData? userData = LoadUserData(LogedInUser.CurrentUser);

                // Finden Sie den Benutzer mit dem angegebenen Benutzernamen
                User? loggedInUser = userData.Users.FirstOrDefault(user => user.Username == LogedInUser.CurrentUser);

                UserSettings firstUserSettings = loggedInUser.Settings?.FirstOrDefault();

                if (loggedInUser != null)
                {
                    try
                    {
                        string jsonText = File.ReadAllText(filePath);
                        JObject jsonRoot = JObject.Parse(jsonText);
                        JToken user = jsonRoot["Users"].FirstOrDefault(u => u["Username"]?.ToString() == LogedInUser.CurrentUser);

                        if (user != null)
                        {
                            JToken uuserData = user["Data"];

                                using (StreamWriter writer = new StreamWriter(firstUserSettings.AutoSavePath))
                                {
                                    foreach (JToken dataItem in uuserData)
                                    {
                                        writer.WriteLine($"Application: {dataItem["Application"]}");
                                        writer.WriteLine($"AppUsername: {dataItem["AppUsername"]}");
                                        writer.WriteLine($"AppPassword: {Decrypt(dataItem["AppPassword"].ToString(), GenerateKey(DecryptKey))}");
                                        writer.WriteLine($"AppEmail: {Decrypt(dataItem["AppEmail"].ToString(), GenerateKey(DecryptKey))}");
                                        writer.WriteLine($"AppEmailPassword: {Decrypt(dataItem["AppEmailPassword"].ToString(), GenerateKey(DecryptKey))}");
                                        writer.WriteLine($"AppInfo: {dataItem["AppInfo"]}");
                                        writer.WriteLine();
                                    }
                                }
                        }
                        else
                        {
                            Notify("Info", $"Benutzer '{LogedInUser.CurrentUser}' nicht gefunden.", 5);
                        }
                    }
                    catch (Exception ex)
                    {
                        Notify("Fehler!", $"Fehler beim Laden und Speichern der Daten: {ex.Message}", 5);
                    }
                }
            }
            catch (Exception ex)
            {
                Notify("Fehler!", $"Fehler beim Speichern des Pfades: {ex.Message}", 5);
            }
        }
        private void DeaktivateAutosave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Lade vorhandene UserData aus der data.json
                UserData? userData = LoadUserData(LogedInUser.CurrentUser);

                // Finden Sie den Benutzer mit dem angegebenen Benutzernamen
                User? loggedInUser = userData.Users.FirstOrDefault(user => user.Username == LogedInUser.CurrentUser);

                UserSettings firstUserSettings = loggedInUser.Settings?.FirstOrDefault();

                if (loggedInUser != null)
                {
                    firstUserSettings.AutoSavePath = null;
                    SaveUserData(userData);
                    AutosavePath.Background = new SolidColorBrush(Color.FromRgb(80, 80, 80));
                }
            }
            catch (Exception ex)
            {
                Notify("Fehler!", $"Fehler beim Speichern des Pfades: {ex.Message}", 5);
            }
        }

        //AddWindow
        private void AddAccountBtn_Click(object sender, RoutedEventArgs e)
        {
            ManageWindows("add");
        }
        private void AccountAddCancelBtn_Click(object sender, RoutedEventArgs e)
        {
            CloseAddWindow();
        }
        private void OpenAddWindow()
        {
            AddWindowOpen = true;
            AccountAddBtn.Focusable = true;
            AccountAddBtn.IsDefault = true;

            DoubleAnimation widthAnimation = new DoubleAnimation
            {
                From = 0,
                To = 780,
                Duration = TimeSpan.FromSeconds(0.3),
                EasingFunction = new QuadraticEase { EasingMode = EasingMode.EaseInOut }
            };

            Storyboard storyboard = new Storyboard();
            storyboard.Children.Add(widthAnimation);

            Storyboard.SetTarget(widthAnimation, AddWindow);
            Storyboard.SetTargetProperty(widthAnimation, new PropertyPath(WidthProperty));

            widthAnimation.Completed += (s, args) =>
            {
                AddWindow.IsHitTestVisible = true;
            };

            AddAccountBtn.Background = new SolidColorBrush(Color.FromRgb(80, 80, 80));
            storyboard.Begin();
        }
        private void CloseAddWindow()
        {
            AddWindowOpen = false;
            AccountAddBtn.Focusable = false;
            AccountAddBtn.IsDefault = false;

            DoubleAnimation widthAnimation = new DoubleAnimation
            {
                From = 780,
                To = 0,
                Duration = TimeSpan.FromSeconds(0.3),
                EasingFunction = new QuadraticEase { EasingMode = EasingMode.EaseInOut }
            };

            Storyboard storyboard = new Storyboard();
            storyboard.Children.Add(widthAnimation);

            Storyboard.SetTarget(widthAnimation, AddWindow);
            Storyboard.SetTargetProperty(widthAnimation, new PropertyPath(WidthProperty));

            widthAnimation.Completed += (s, args) =>
            {
                AddWindow.IsHitTestVisible = false;
            };

            AddAccountBtn.Background = new SolidColorBrush(Color.FromRgb(60, 60, 60));
            storyboard.Begin();
        }
        private void AccountAddBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (File.Exists(filePath))
                {
                    string existingJsonContent = File.ReadAllText(filePath);

                    UserData existingData = JsonConvert.DeserializeObject<UserData>(existingJsonContent);

                    User loggedInUser = existingData?.Users?.FirstOrDefault(user =>
                        user.Username == LogedInUser.CurrentUser || user.Email == LogedInUser.CurrentUser);

                    if (loggedInUser != null)
                    {
                        System.Windows.Media.Color selectedColor = Colors.Gainsboro;

                        if (ColorPickerIcon.Foreground is SolidColorBrush solidColorBrush)
                        {
                            selectedColor = solidColorBrush.Color;
                        }

                        int maxId = loggedInUser.Data?.Any() == true ? loggedInUser.Data.Max(entry => int.TryParse(entry.ID, out int id) ? id : 0) : 0;

                        string application = GetValidatedInput(Tb_app, "Anwendung");
                        string applink = GetValidatedInput(Tb_link, "Link");
                        string appUsername = GetValidatedInput(Tb_appusername, "Benutzername");
                        string appPassword = GetEncryptInput(Tb_apppassword, "Passwort");
                        string appEmail = GetEncryptInput(Tb_appemail, "E-Mail");
                        string appEmailPassword = GetEncryptInput(Tb_appemailpassword, "E-Mail Passwort");
                        string appInfo = GetValidatedInput(Tb_appinfo, "Info");
                        string appTag = Cb_appTag.SelectedItem != null ? (Cb_appTag.SelectedItem as ComboBoxItem)?.Content.ToString() : string.Empty;
                        string appFilePath = CopySelectedFile(maxId, GetValidatedInput(Tb_app, "Anwendung"));
                        string[] appColor = new string[] { selectedColor.A.ToString(), selectedColor.R.ToString(), selectedColor.G.ToString(), selectedColor.B.ToString() };

                        // Setze appFilePath auf null, wenn keine Datei ausgewählt wurde
                        if (string.IsNullOrEmpty(selectedFilePath))
                        {
                            appFilePath = null;
                        }

                        if (appTag == null || appTag == "Kategorie")
                        {
                            appTag = "Sonstige";
                        }

                        UserDataDetails userDataDetails = new UserDataDetails
                        {
                            ID = (maxId + 1).ToString(),
                            Application = application,
                            AppLink = applink,
                            AppUsername = appUsername,
                            AppPassword = appPassword,
                            AppEmail = appEmail,
                            AppEmailPassword = appEmailPassword,
                            AppInfo = appInfo,
                            AppTag = appTag,
                            AppFiles = appFilePath,
                            AppColor = appColor
                        };

                        loggedInUser.Data ??= new List<UserDataDetails>();
                        loggedInUser.Data.Add(userDataDetails);

                        WriteJsonFile(filePath, JsonConvert.SerializeObject(existingData, Formatting.Indented));

                        Cb_appTag.SelectedIndex = 0;
                        selectedFilePath = null;

                        ResetInputFields();
                        RefreshDataGrid();
                        CountAccountsFunc();
                        Notify("Account Hinzufügen", "Account wurde erfolgreich angelegt!", 5);
                        StoreFileIcon.Foreground = new SolidColorBrush(Colors.Gainsboro);
                        ColorPickerIcon.Foreground = new SolidColorBrush(Colors.Gainsboro);
                        DataGridAllFilter.IsChecked = true;
                        CloseAddWindow();
                    }
                    else
                    {
                        Notify("Fehler", "Benutzer nicht gefunden.", 5);
                    }
                }
                else
                {
                    Notify("Fehler", "Datenbankdatei nicht gefunden.", 5);
                }
            }
            catch (Exception ex)
            {
                Notify("Fehler", $"Fehler beim Aktualisieren der Daten: {ex.Message}", 5);
            }
        }
        private string GetValidatedInput(TextBox textBox, string placeholder)
        {
            string fieldValue = textBox.Text.Trim();

            // Überprüfen, ob der eingegebene Wert dem Placeholder entspricht
            if (string.IsNullOrWhiteSpace(fieldValue) || fieldValue.Equals(placeholder))
            {
                return "/";
            }
            return fieldValue;
        }
        private string GetEncryptInput(TextBox textBox, string placeholder)
        {
            // Überprüfen, ob der eingegebene Wert dem Placeholder entspricht
            if (string.IsNullOrWhiteSpace(textBox.Text.Trim()) || textBox.Text.Trim().Equals(placeholder))
            {
                return "/";
            }
            else
            {
                return Encrypt(textBox.Text.Trim(), GenerateKey(DecryptKey));
            }
        }
        private string GetEncryptPasswordInput(PasswordBox passwordBox, string placeholder)
        {
            // Überprüfen, ob der eingegebene Wert dem Placeholder entspricht
            if (string.IsNullOrWhiteSpace(passwordBox.Password.Trim()) || passwordBox.Password.Trim().Equals(placeholder))
            {
                return "/";
            }
            else
            {
                return Encrypt(passwordBox.Password.Trim(), GenerateKey(DecryptKey));
            }
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

                if (cipherText != null)
                {
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
                        Console.WriteLine($"Error decoding Base64: {ex.Message}");
                        return null;
                    }
                }
                return null;
            }
        }
        private string CopySelectedFile(int maxId, string app)
        {
            string appFilePath = null;

            if (app == string.Empty || app == "/")
            {
                app = "Unbekannt";
            }

            if (!string.IsNullOrEmpty(selectedFilePath))
            {
                string entryId = (maxId + 1).ToString();
                string destinationFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "data", $"{LogedInUser.CurrentUser} - {app} - Files");

                try
                {
                    if (!Directory.Exists(destinationFolder))
                    {
                        Directory.CreateDirectory(destinationFolder);

                        string fileName = Path.GetFileName(selectedFilePath);
                        string destinationPath = Path.Combine(destinationFolder, fileName);

                        File.Copy(selectedFilePath, destinationPath, true);

                        appFilePath = destinationPath;
                    }
                    else
                    {
                        string fileName = Path.GetFileName(selectedFilePath);
                        string destinationPath = Path.Combine(destinationFolder, fileName);

                        File.Copy(selectedFilePath, destinationPath, true);

                        appFilePath = destinationPath;
                    }

                }
                catch (Exception ex)
                {
                    Notify("Fehler!", $"Fehler beim Kopieren der Datei: {ex.Message}", 5);
                }
            }

            return appFilePath;
        }
        private void WriteJsonFile(string filePath, string content)
        {
            try
            {
                File.WriteAllText(filePath, content);
            }
            catch (Exception ex)
            {
                Notify("Fehler!", $"Fehler beim Schreiben der Datei: {ex.Message}", 5);
            }
        }
        private void ResetInputFields()
        {
            SetPlaceholderText(Tb_app, "Anwendung");
            SetPlaceholderText(Tb_appusername, "Benutzername");
            SetPlaceholderText(Tb_apppassword, "Passwort");
            SetPlaceholderText(Tb_appemail, "E-Mail");
            SetPlaceholderText(Tb_appemailpassword, "E-Mail Passwort");
            SetPlaceholderText(Tb_appinfo, "Info");
            SetPlaceholderText(Tb_link, "Website");
        }
        private void SetPlaceholderText(TextBox textBox, string placeholder)
        {
            textBox.Text = placeholder;
            textBox.FontStyle = FontStyles.Italic;
            textBox.Foreground = new SolidColorBrush(Colors.Gray);
        }
        private void Tb_app_GotFocus(object sender, RoutedEventArgs e)
        {
            if (Tb_app.Text == "Anwendung")
            {
                Tb_app.Text = string.Empty;
                Tb_app.FontStyle = FontStyles.Normal;
                Tb_app.Foreground = new SolidColorBrush(Colors.Black);
            }
        }
        private void Tb_app_LostFocus(object sender, RoutedEventArgs e)
        {
            if (Tb_app.Text == "Anwendung" || Tb_app.Text == string.Empty)
            {
                Tb_app.Text = "Anwendung";
                Tb_app.FontStyle = FontStyles.Italic;
                Tb_app.Foreground = new SolidColorBrush(Colors.Gray);
            }
        }
        private void Tb_link_GotFocus(object sender, RoutedEventArgs e)
        {
            if (Tb_link.Text == "Website")
            {
                Tb_link.Text = string.Empty;
                Tb_link.FontStyle = FontStyles.Normal;
                Tb_link.Foreground = new SolidColorBrush(Colors.Black);
            }
        }
        private void Tb_link_LostFocus(object sender, RoutedEventArgs e)
        {
            if (Tb_link.Text == "Website" || Tb_link.Text == string.Empty)
            {
                Tb_link.Text = "Website";
                Tb_link.FontStyle = FontStyles.Italic;
                Tb_link.Foreground = new SolidColorBrush(Colors.Gray);
            }
        }
        private void Tb_appusername_GotFocus(object sender, RoutedEventArgs e)
        {
            if (Tb_appusername.Text == "Benutzername")
            {
                Tb_appusername.Text = string.Empty;
                Tb_appusername.FontStyle = FontStyles.Normal;
                Tb_appusername.Foreground = new SolidColorBrush(Colors.Black);
            }
        }
        private void Tb_appusername_LostFocus(object sender, RoutedEventArgs e)
        {
            if (Tb_appusername.Text == "Benutzername" || Tb_appusername.Text == string.Empty)
            {
                Tb_appusername.Text = "Benutzername";
                Tb_appusername.FontStyle = FontStyles.Italic;
                Tb_appusername.Foreground = new SolidColorBrush(Colors.Gray);
            }
        }
        private void Tb_appemail_GotFocus(object sender, RoutedEventArgs e)
        {
            if (Tb_appemail.Text == "E-Mail")
            {
                Tb_appemail.Text = string.Empty;
                Tb_appemail.FontStyle = FontStyles.Normal;
                Tb_appemail.Foreground = new SolidColorBrush(Colors.Black);
            }
        }
        private void Tb_appemail_LostFocus(object sender, RoutedEventArgs e)
        {
            if (Tb_appemail.Text == "E-Mail" || Tb_appemail.Text == string.Empty)
            {
                Tb_appemail.Text = "E-Mail";
                Tb_appemail.FontStyle = FontStyles.Italic;
                Tb_appemail.Foreground = new SolidColorBrush(Colors.Gray);
            }
        }
        private void Tb_appemailpassword_GotFocus(object sender, RoutedEventArgs e)
        {
            if (Tb_appemailpassword.Text == "E-Mail Passwort")
            {
                Tb_appemailpassword.Text = string.Empty;
                Tb_appemailpassword.FontStyle = FontStyles.Normal;
                Tb_appemailpassword.Foreground = new SolidColorBrush(Colors.Black);
            }
        }
        private void Tb_appemailpassword_LostFocus(object sender, RoutedEventArgs e)
        {
            if (Tb_appemailpassword.Text == "E-Mail Passwort" || Tb_appemailpassword.Text == string.Empty)
            {
                Tb_appemailpassword.Text = "E-Mail Passwort";
                Tb_appemailpassword.FontStyle = FontStyles.Italic;
                Tb_appemailpassword.Foreground = new SolidColorBrush(Colors.Gray);
            }
        }
        private void Tb_appinfo_GotFocus(object sender, RoutedEventArgs e)
        {
            if (Tb_appinfo.Text == "Info")
            {
                Tb_appinfo.Text = string.Empty;
                Tb_appinfo.FontStyle = FontStyles.Normal;
                Tb_appinfo.Foreground = new SolidColorBrush(Colors.Black);
            }
        }
        private void Tb_appinfo_LostFocus(object sender, RoutedEventArgs e)
        {
            if (Tb_appinfo.Text == "Info" || Tb_appinfo.Text == string.Empty)
            {
                Tb_appinfo.Text = "Info";
                Tb_appinfo.FontStyle = FontStyles.Italic;
                Tb_appinfo.Foreground = new SolidColorBrush(Colors.Gray);
            }
        }
        private void Tb_apppassword_GotFocus(object sender, RoutedEventArgs e)
        {
            if (Tb_apppassword.Text == "Passwort")
            {
                Tb_apppassword.Text = string.Empty;
                Tb_apppassword.FontStyle = FontStyles.Normal;
                Tb_apppassword.Foreground = new SolidColorBrush(Colors.Black);
            }
        }
        private void Tb_apppassword_LostFocus(object sender, RoutedEventArgs e)
        {
            if (Tb_apppassword.Text == "Passwort" || Tb_apppassword.Text == string.Empty)
            {
                Tb_apppassword.Text = "Passwort";
                Tb_apppassword.FontStyle = FontStyles.Italic;
                Tb_apppassword.Foreground = new SolidColorBrush(Colors.Gray);
            }
        }
        private void Tb_app_edit_GotFocus(object sender, RoutedEventArgs e)
        {
            if (Tb_app_edit.Text == "Anwendung")
            {
                Tb_app_edit.Text = string.Empty;
                Tb_app_edit.FontStyle = FontStyles.Normal;
                Tb_app_edit.Foreground = new SolidColorBrush(Colors.Black);
            }
        }
        private void Tb_app_edit_LostFocus(object sender, RoutedEventArgs e)
        {
            if (Tb_app_edit.Text == "Anwendung" || Tb_app_edit.Text == string.Empty)
            {
                Tb_app_edit.Text = "Anwendung";
                Tb_app_edit.FontStyle = FontStyles.Italic;
                Tb_app_edit.Foreground = new SolidColorBrush(Colors.Gray);
            }
        }
        private void Tb_link_edit_GotFocus(object sender, RoutedEventArgs e)
        {
            if (Tb_link_edit.Text == "Website")
            {
                Tb_link_edit.Text = string.Empty;
                Tb_link_edit.FontStyle = FontStyles.Normal;
                Tb_link_edit.Foreground = new SolidColorBrush(Colors.Black);
            }
        }
        private void Tb_link_edit_LostFocus(object sender, RoutedEventArgs e)
        {
            if (Tb_link_edit.Text == "Website" || Tb_link_edit.Text == string.Empty)
            {
                Tb_link_edit.Text = "Website";
                Tb_link_edit.FontStyle = FontStyles.Italic;
                Tb_link_edit.Foreground = new SolidColorBrush(Colors.Gray);
            }
        }
        private void Tb_appusername_edit_GotFocus(object sender, RoutedEventArgs e)
        {
            if (Tb_appusername_edit.Text == "Benutzername")
            {
                Tb_appusername_edit.Text = string.Empty;
                Tb_appusername_edit.FontStyle = FontStyles.Normal;
                Tb_appusername_edit.Foreground = new SolidColorBrush(Colors.Black);
            }
        }
        private void Tb_appusername_edit_LostFocus(object sender, RoutedEventArgs e)
        {
            if (Tb_appusername_edit.Text == "Benutzername" || Tb_appusername_edit.Text == string.Empty)
            {
                Tb_appusername_edit.Text = "Benutzername";
                Tb_appusername_edit.FontStyle = FontStyles.Italic;
                Tb_appusername_edit.Foreground = new SolidColorBrush(Colors.Gray);
            }
        }
        private void Tb_appemail_edit_GotFocus(object sender, RoutedEventArgs e)
        {
            if (Tb_appemail_edit.Text == "E-Mail")
            {
                Tb_appemail_edit.Text = string.Empty;
                Tb_appemail_edit.FontStyle = FontStyles.Normal;
                Tb_appemail_edit.Foreground = new SolidColorBrush(Colors.Black);
            }
        }
        private void Tb_appemail_edit_LostFocus(object sender, RoutedEventArgs e)
        {
            if (Tb_appemail_edit.Text == "E-Mail" || Tb_appemail_edit.Text == string.Empty)
            {
                Tb_appemail_edit.Text = "E-Mail";
                Tb_appemail_edit.FontStyle = FontStyles.Italic;
                Tb_appemail_edit.Foreground = new SolidColorBrush(Colors.Gray);
            }
        }
        private void Tb_appemailpassword_edit_GotFocus(object sender, RoutedEventArgs e)
        {
            if (Tb_appemailpassword_edit.Password == "E-Mail Passwort")
            {
                Tb_appemailpassword_edit.Password = string.Empty;
                Tb_appemailpassword_edit.FontStyle = FontStyles.Normal;
                Tb_appemailpassword_edit.Foreground = new SolidColorBrush(Colors.Black);
            }
        }
        private void Tb_appemailpassword_edit_LostFocus(object sender, RoutedEventArgs e)
        {
            if (Tb_appemailpassword_edit.Password == "E-Mail Passwort" || Tb_appemailpassword_edit.Password == string.Empty)
            {
                Tb_appemailpassword_edit.Password = "E-Mail Passwort";
                Tb_appemailpassword_edit.FontStyle = FontStyles.Italic;
                Tb_appemailpassword_edit.Foreground = new SolidColorBrush(Colors.Gray);
            }
        }
        private void Tb_appinfo_edit_GotFocus(object sender, RoutedEventArgs e)
        {
            if (Tb_appinfo_edit.Text == "Info")
            {
                Tb_appinfo_edit.Text = string.Empty;
                Tb_appinfo_edit.FontStyle = FontStyles.Normal;
                Tb_appinfo_edit.Foreground = new SolidColorBrush(Colors.Black);
            }
        }
        private void Tb_appinfo_edit_LostFocus(object sender, RoutedEventArgs e)
        {
            if (Tb_appinfo_edit.Text == "Info" || Tb_appinfo_edit.Text == string.Empty)
            {
                Tb_appinfo_edit.Text = "Info";
                Tb_appinfo_edit.FontStyle = FontStyles.Italic;
                Tb_appinfo_edit.Foreground = new SolidColorBrush(Colors.Gray);
            }
        }
        private void Tb_apppassword_edit_GotFocus(object sender, RoutedEventArgs e)
        {
            if (Tb_apppassword_edit.Password == "Passwort")
            {
                Tb_apppassword_edit.Password = string.Empty;
                Tb_apppassword_edit.FontStyle = FontStyles.Normal;
                Tb_apppassword_edit.Foreground = new SolidColorBrush(Colors.Black);
            }
        }
        private void Tb_apppassword_edit_LostFocus(object sender, RoutedEventArgs e)
        {
            if (Tb_apppassword_edit.Password == "Passwort" || Tb_apppassword_edit.Password == string.Empty)
            {
                Tb_apppassword_edit.Password = "Passwort";
                Tb_apppassword_edit.FontStyle = FontStyles.Italic;
                Tb_apppassword_edit.Foreground = new SolidColorBrush(Colors.Gray);
            }
        }
        private void StoreFile_Click(object sender, RoutedEventArgs e)
        {
            // Dialog zum Auswählen einer Datei anzeigen
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Alle Dateien (*.*)|*.*"; // Filter für alle Dateitypen

            if (openFileDialog.ShowDialog() == true)
            {
                // Dateipfad aus dem Dialog erhalten
                selectedFilePath = openFileDialog.FileName;
                StoreFileIcon.Foreground = new SolidColorBrush(Colors.Red);
            }
        }
        private void StoreFile_edit_Click(object sender, RoutedEventArgs e)
        {
            // Dialog zum Auswählen einer Datei anzeigen
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Alle Dateien (*.*)|*.*"; // Filter für alle Dateitypen

            if (openFileDialog.ShowDialog() == true)
            {
                // Dateipfad aus dem Dialog erhalten
                selectedFilePath = openFileDialog.FileName;
                StoreFileIcon_edit.Foreground = new SolidColorBrush(Colors.Red);
            }
        }
        private void Tb_appemailpassword_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Tb_appemailpassword.Text != "E-Mail Passwort")
            {
                int score = 0;

                // Überprüfe Länge
                if (Tb_appemailpassword.Text.Length >= 8)
                    score++;

                // Überprüfe Großbuchstaben
                if (Tb_appemailpassword.Text.Any(char.IsUpper))
                    score++;

                // Überprüfe Kleinbuchstaben
                if (Tb_appemailpassword.Text.Any(char.IsLower))
                    score++;

                // Überprüfe Zahlen
                if (Tb_appemailpassword.Text.Any(char.IsDigit))
                    score++;

                // Überprüfe Sonderzeichen
                if (Tb_appemailpassword.Text.Any(ch => !char.IsLetterOrDigit(ch)))
                    score++;

                // Bewertungsskala anpassen
                if (score <= 2)
                {
                    Tb_appemailpassword_pwSafty.BorderBrush = new SolidColorBrush(Colors.Red);
                    Tb_appemailpassword_pwSafty.BorderThickness = new Thickness(0, 0, 0, 3);
                }
                else if (score <= 4)
                {
                    Tb_appemailpassword_pwSafty.BorderBrush = new SolidColorBrush(Colors.Yellow);
                    Tb_appemailpassword_pwSafty.BorderThickness = new Thickness(0, 0, 0, 3);
                }
                else
                {
                    Tb_appemailpassword_pwSafty.BorderBrush = new SolidColorBrush(Colors.Green);
                    Tb_appemailpassword_pwSafty.BorderThickness = new Thickness(0, 0, 0, 3);
                }
            }
        }
        private void Tb_apppassword_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Tb_apppassword.Text != "Passwort")
            {
                int score = 0;

                // Überprüfe Länge
                if (Tb_apppassword.Text.Length >= 8)
                    score++;

                // Überprüfe Großbuchstaben
                if (Tb_apppassword.Text.Any(char.IsUpper))
                    score++;

                // Überprüfe Kleinbuchstaben
                if (Tb_apppassword.Text.Any(char.IsLower))
                    score++;

                // Überprüfe Zahlen
                if (Tb_apppassword.Text.Any(char.IsDigit))
                    score++;

                // Überprüfe Sonderzeichen
                if (Tb_apppassword.Text.Any(ch => !char.IsLetterOrDigit(ch)))
                    score++;

                // Bewertungsskala anpassen
                if (score <= 2)
                {
                    Tb_apppassword_pwSafty.BorderBrush = new SolidColorBrush(Colors.Red);
                    Tb_apppassword_pwSafty.BorderThickness = new Thickness(0, 0, 0, 3);
                }
                else if (score <= 4)
                {
                    Tb_apppassword_pwSafty.BorderBrush = new SolidColorBrush(Colors.Yellow);
                    Tb_apppassword_pwSafty.BorderThickness = new Thickness(0, 0, 0, 3);
                }
                else
                {
                    Tb_apppassword_pwSafty.BorderBrush = new SolidColorBrush(Colors.Green);
                    Tb_apppassword_pwSafty.BorderThickness = new Thickness(0, 0, 0, 3);
                }
            }
        }
        private void Tb_apppassword_edit_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (Tb_apppassword_edit.Password != "Passwort")
            {
                int score = 0;

                // Überprüfe Länge
                if (Tb_apppassword_edit.Password.Length >= 8)
                    score++;

                // Überprüfe Großbuchstaben
                if (Tb_apppassword_edit.Password.Any(char.IsUpper))
                    score++;

                // Überprüfe Kleinbuchstaben
                if (Tb_apppassword_edit.Password.Any(char.IsLower))
                    score++;

                // Überprüfe Zahlen
                if (Tb_apppassword_edit.Password.Any(char.IsDigit))
                    score++;

                // Überprüfe Sonderzeichen
                if (Tb_apppassword_edit.Password.Any(ch => !char.IsLetterOrDigit(ch)))
                    score++;

                // Bewertungsskala anpassen
                if (score <= 2)
                {
                    Tb_apppassword_pwSafty_edit.BorderBrush = new SolidColorBrush(Colors.Red);
                    Tb_apppassword_pwSafty_edit.BorderThickness = new Thickness(0, 0, 0, 3);
                }
                else if (score <= 4)
                {
                    Tb_apppassword_pwSafty_edit.BorderBrush = new SolidColorBrush(Colors.Yellow);
                    Tb_apppassword_pwSafty_edit.BorderThickness = new Thickness(0, 0, 0, 3);
                }
                else
                {
                    Tb_apppassword_pwSafty_edit.BorderBrush = new SolidColorBrush(Colors.Green);
                    Tb_apppassword_pwSafty_edit.BorderThickness = new Thickness(0, 0, 0, 3);
                }
            }
        }
        private void Tb_appemailpassword_edit_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (Tb_appemailpassword_edit.Password != "E-Mail Passwort")
            {
                int score = 0;

                // Überprüfe Länge
                if (Tb_appemailpassword_edit.Password.Length >= 8)
                    score++;

                // Überprüfe Großbuchstaben
                if (Tb_appemailpassword_edit.Password.Any(char.IsUpper))
                    score++;

                // Überprüfe Kleinbuchstaben
                if (Tb_appemailpassword_edit.Password.Any(char.IsLower))
                    score++;

                // Überprüfe Zahlen
                if (Tb_appemailpassword_edit.Password.Any(char.IsDigit))
                    score++;

                // Überprüfe Sonderzeichen
                if (Tb_appemailpassword_edit.Password.Any(ch => !char.IsLetterOrDigit(ch)))
                    score++;

                // Bewertungsskala anpassen
                if (score <= 2)
                {
                    Tb_appemailpassword_pwSafty_edit.BorderBrush = new SolidColorBrush(Colors.Red);
                    Tb_appemailpassword_pwSafty_edit.BorderThickness = new Thickness(0, 0, 0, 3);
                }
                else if (score <= 4)
                {
                    Tb_appemailpassword_pwSafty_edit.BorderBrush = new SolidColorBrush(Colors.Yellow);
                    Tb_appemailpassword_pwSafty_edit.BorderThickness = new Thickness(0, 0, 0, 3);
                }
                else
                {
                    Tb_appemailpassword_pwSafty_edit.BorderBrush = new SolidColorBrush(Colors.Green);
                    Tb_appemailpassword_pwSafty_edit.BorderThickness = new Thickness(0, 0, 0, 3);
                }
            }
        }

        //Password Generate
        private void PasswordGenerationBtn_Click(object sender, RoutedEventArgs e)
        {
            ManageWindows("pwgen");
        }
        private void GeneratePasswordCancelBtn_Click(object sender, RoutedEventArgs e)
        {
            ClosePasswordGenWindow();
        }
        private void OpenPasswordGenWindow()
        {
            PasswordGenWindowOpen = true;

            DoubleAnimation widthAnimation = new DoubleAnimation
            {
                From = 0,
                To = 570,
                Duration = TimeSpan.FromSeconds(0.3),
                EasingFunction = new QuadraticEase { EasingMode = EasingMode.EaseInOut }
            };

            Storyboard storyboard = new Storyboard();
            storyboard.Children.Add(widthAnimation);

            Storyboard.SetTarget(widthAnimation, PasswordGeneratorWindow);
            Storyboard.SetTargetProperty(widthAnimation, new PropertyPath(WidthProperty));

            widthAnimation.Completed += (s, args) =>
            {
                PasswordGeneratorWindow.IsHitTestVisible = true;
            };

            PasswordGenerationBtn.Background = new SolidColorBrush(Color.FromRgb(80, 80, 80));
            storyboard.Begin();
        }
        private void ClosePasswordGenWindow()
        {
            PasswordGenWindowOpen = false;

            DoubleAnimation widthAnimation = new DoubleAnimation
            {
                From = 570,
                To = 0,
                Duration = TimeSpan.FromSeconds(0.3),
                EasingFunction = new QuadraticEase { EasingMode = EasingMode.EaseInOut }
            };

            Storyboard storyboard = new Storyboard();
            storyboard.Children.Add(widthAnimation);

            Storyboard.SetTarget(widthAnimation, PasswordGeneratorWindow);
            Storyboard.SetTargetProperty(widthAnimation, new PropertyPath(WidthProperty));

            widthAnimation.Completed += (s, args) =>
            {
                PasswordGeneratorWindow.IsHitTestVisible = false;
                GeneratedPasswortBox.Text = string.Empty;
            };

            PasswordGenerationBtn.Background = new SolidColorBrush(Color.FromRgb(60, 60, 60));
            storyboard.Begin();
        }
        private void GeneratePasswordBtn_Click(object sender, RoutedEventArgs e)
        {
            int length = GetSelectedLength();
            bool useSpecialChars = cb_sonderzeichen.IsChecked ?? false;
            bool useUppercase = cb_grosbuchstaben.IsChecked ?? false;
            bool useLowercase = cb_kleinbuchstaben.IsChecked ?? false;
            bool useNumbers = cb_zahlen.IsChecked ?? false;

            if (length > 0 && (useSpecialChars || useUppercase || useLowercase || useNumbers))
            {
                string password = GenerateRandomPassword(length, useSpecialChars, useUppercase, useLowercase, useNumbers);
                GeneratedPasswortBox.Text = password;
            }
            else
            {
                Notify("Info", "Bitte wähle die Länge und mindestens eine Option aus.", 5);
            }
        }
        private void GeneratedPasswordCopyBtn_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (GeneratedPasswortBox.Text != string.Empty)
            {
                Clipboard.SetDataObject(GeneratedPasswortBox.Text);
                Notify("Kopieren", $"{GeneratedPasswortBox.Text} wurde in die Zwischenablage kopiert!", 5);
            }
            else
            {
                Notify("Kopieren", "Bitte generiere erst ein Paswort!", 5);
            }
        }
        private int GetSelectedLength()
        {
            if (rb_8.IsChecked == true) return 8;
            if (rb_12.IsChecked == true) return 12;
            if (rb_16.IsChecked == true) return 16;
            if (rb_20.IsChecked == true) return 20;

            // Standardlänge, falls keine der Optionen ausgewählt ist
            return 8;
        }
        private string GenerateRandomPassword(int length, bool useSpecialChars, bool useUppercase, bool useLowercase, bool useNumbers)
        {
            // Hier implementierst du die Logik zum Generieren eines zufälligen Passworts
            // Verwende die gewählten Optionen (useSpecialChars, useUppercase, useLowercase, useNumbers) und die Länge
            // Die vollständige Implementierung könnte etwas komplexer sein, je nach den genauen Anforderungen.

            // Beispiel: Nur Zahlen generieren
            string validChars = useNumbers ? "0123456789" : "";

            // Beispiel: Buchstaben hinzufügen (Groß- und Kleinschreibung)
            validChars += useUppercase ? "ABCDEFGHIJKLMNOPQRSTUVWXYZ" : "";
            validChars += useLowercase ? "abcdefghijklmnopqrstuvwxyz" : "";

            // Beispiel: Sonderzeichen hinzufügen
            validChars += useSpecialChars ? "!@#$%&*_+-,.?/" : "";

            // Hier wird das Passwort generiert (Beispiel)
            Random random = new Random();
            char[] password = new char[length];
            for (int i = 0; i < length; i++)
            {
                password[i] = validChars[random.Next(validChars.Length)];
            }

            return new string(password);
        }

        //Searchbox
        private bool SearchBoxOpen = false;
        private void SearchBoxBorder_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (!SearchBoxOpen)
            {
                OpenSearchBox();
            }
            else
            {
                CloseSearchBox();
            }
        }
        private void SearchBoxTxt_LostFocus(object sender, RoutedEventArgs e)
        {
            if (SearchBoxOpen)
            {
                CloseSearchBox();
            }
        }
        private void OpenSearchBox()
        {
            DoubleAnimation widthAnimation = new DoubleAnimation
            {
                From = 30,
                To = 180,
                Duration = TimeSpan.FromSeconds(0.3),
                EasingFunction = new QuadraticEase { EasingMode = EasingMode.EaseInOut }
            };

            DoubleAnimation width2Animation = new DoubleAnimation
            {
                From = 0,
                To = 150,
                Duration = TimeSpan.FromSeconds(0.3),
                EasingFunction = new QuadraticEase { EasingMode = EasingMode.EaseInOut }
            };

            Storyboard storyboard = new Storyboard();
            storyboard.Children.Add(widthAnimation);
            storyboard.Children.Add(width2Animation);

            Storyboard.SetTarget(widthAnimation, SearchBoxBorder);
            Storyboard.SetTarget(width2Animation, SearchBoxTxt);
            Storyboard.SetTargetProperty(widthAnimation, new PropertyPath(WidthProperty));
            Storyboard.SetTargetProperty(width2Animation, new PropertyPath(WidthProperty));

            storyboard.Begin();

            SearchBoxIcon.Foreground = new SolidColorBrush(Colors.Black);
            SearchBoxBorder.Background = new SolidColorBrush(Colors.Gainsboro);
            SearchBoxTxt.Focusable = true;
            SearchBoxTxt.Focus();
            SearchBoxOpen = true;
        }
        private void CloseSearchBox()
        {
            DoubleAnimation widthAnimation = new DoubleAnimation
            {
                From = 180,
                To = 30,
                Duration = TimeSpan.FromSeconds(0.3),
                EasingFunction = new QuadraticEase { EasingMode = EasingMode.EaseInOut }
            };

            DoubleAnimation width2Animation = new DoubleAnimation
            {
                From = 150,
                To = 0,
                Duration = TimeSpan.FromSeconds(0.3),
                EasingFunction = new QuadraticEase { EasingMode = EasingMode.EaseInOut }
            };

            Storyboard storyboard = new Storyboard();
            storyboard.Children.Add(widthAnimation);
            storyboard.Children.Add(width2Animation);

            Storyboard.SetTarget(widthAnimation, SearchBoxBorder);
            Storyboard.SetTarget(width2Animation, SearchBoxTxt);
            Storyboard.SetTargetProperty(widthAnimation, new PropertyPath(WidthProperty));
            Storyboard.SetTargetProperty(width2Animation, new PropertyPath(WidthProperty));

            storyboard.Begin();

            SearchBoxTxt.Width = 0;
            SearchBoxIcon.Foreground = new SolidColorBrush(Colors.Gainsboro);
            SearchBoxBorder.Background = new SolidColorBrush(Color.FromRgb(50, 50, 50));
            SearchBoxTxt.Focusable = false;
            SearchBoxOpen = false;
        }
        private void TbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            string searchText = SearchBoxTxt.Text.ToLower();

            var userData = LoadUserData(LogedInUser.CurrentUser);

            if (userData != null && userData.Users != null)
            {
                User? loggedInUser = userData.Users.FirstOrDefault(user => user.Username == LogedInUser.CurrentUser);

                if (loggedInUser != null && loggedInUser.Data != null)
                {
                    var filteredData = loggedInUser.Data
                        .Where(entry => entry.Application.ToLower().Contains(searchText) ||
                                        entry.AppUsername.ToLower().Contains(searchText) ||
                                        entry.AppEmail.ToLower().Contains(searchText))
                        .ToList();

                    Datagrid.ItemsSource = filteredData;
                }
            }
        }

        //Notify
        private System.Windows.Threading.DispatcherTimer? timer;
        private void Notify(string header, string msg, int time)
        {
            // Stop the existing timer and reset animations
            ResetAnimation();

            // Set the new message
            NotifyShow = true;
            NotifyBorder.Opacity = 1;
            NotifyBorder.Margin = new Thickness(0, 0, 0, -200); // Initial position off-screen
            NotifyHeaderTxt.Text = header;
            NotifyTxt.Text = msg;

            // Create the initial animation to bring the NotifyBorder on-screen
            ThicknessAnimation initialMarginAnimation = new ThicknessAnimation();
            initialMarginAnimation.To = new Thickness(0, 0, 0, 100);
            initialMarginAnimation.Duration = TimeSpan.FromSeconds(0.4);

            // Set up the Completed event handler
            initialMarginAnimation.Completed += (sender, e) =>
            {
                // Set the animation flag to indicate that it is in progress
                isAnimationInProgress = true;

                // Create or reset the timer
                timer = new System.Windows.Threading.DispatcherTimer();
                timer.Interval = TimeSpan.FromSeconds(time);
                timer.Tick += (timerSender, timerE) =>
                {
                    // Create a margin animation to move the NotifyBorder off-screen
                    ThicknessAnimation marginAnimation = new ThicknessAnimation();
                    marginAnimation.To = new Thickness(0, 0, 0, 0);
                    marginAnimation.Duration = TimeSpan.FromSeconds(0.4);

                    NotifyBorder.BeginAnimation(FrameworkElement.MarginProperty, marginAnimation);

                    // Create an opacity animation
                    DoubleAnimation opacityAnimation = new DoubleAnimation();
                    opacityAnimation.To = 0;
                    opacityAnimation.Duration = TimeSpan.FromSeconds(0.4);

                    // Apply the animation to the Opacity property
                    NotifyBorder.BeginAnimation(UIElement.OpacityProperty, opacityAnimation);

                    timer.Stop(); // Stop the timer after the time has elapsed

                    // Reset the animation flag after completion
                    isAnimationInProgress = false;
                };

                // Start the timer
                timer.Start();
            };

            NotifyBorder.BeginAnimation(FrameworkElement.MarginProperty, initialMarginAnimation);
        }
        private void ResetAnimation()
        {
            // Stop the existing timer (if any)
            if (timer != null)
            {
                timer.Stop();

                // Stop any ongoing animations
                NotifyBorder.BeginAnimation(FrameworkElement.MarginProperty, null);
                NotifyBorder.BeginAnimation(UIElement.OpacityProperty, null);
            }

            // Reset the animation flag
            isAnimationInProgress = false;
        }

        //MessageBox
        bool QuestBoxOpen = false;
        private TaskCompletionSource<bool> questBoxTaskCompletionSource;
        private async Task<bool> QuestBox(string quest)
        {
            if (PasswordGenWindowOpen || AddWindowOpen || EditWindowOpen || UserSettingsOpen)
            {
                ManageWindows("questBox");
                await Task.Delay(300);
            }
            CancelQuestBox.Visibility = Visibility.Collapsed;
            ComfirmQuestBox.Visibility = Visibility.Collapsed;
            QuestBoxQuest.Visibility = Visibility.Collapsed;
            QuestBoxIcon.Visibility = Visibility.Collapsed;
            QuestBoxOpen = true;

            DoubleAnimation widthAnimation = new DoubleAnimation
            {
                From = 0,
                To = 300,
                Duration = TimeSpan.FromSeconds(0.3),
                EasingFunction = new QuadraticEase { EasingMode = EasingMode.EaseInOut }
            };

            Storyboard storyboard = new Storyboard();
            storyboard.Children.Add(widthAnimation);

            Storyboard.SetTarget(widthAnimation, QuestBoxWindow);
            Storyboard.SetTargetProperty(widthAnimation, new PropertyPath(WidthProperty));

            widthAnimation.Completed += (s, args) =>
            {
                QuestBoxIcon.Visibility = Visibility.Visible;
                QuestBoxQuest.Text = quest;
                CancelQuestBox.Visibility = Visibility.Visible;
                ComfirmQuestBox.Visibility = Visibility.Visible;
                QuestBoxQuest.Visibility = Visibility.Visible;
                QuestBoxWindow.IsHitTestVisible = true;
            };

            storyboard.Begin();

            // Erstellen Sie ein TaskCompletionSource, um auf die Benutzerantwort zu warten
            questBoxTaskCompletionSource = new TaskCompletionSource<bool>();

            // Warten Sie auf die Benutzerantwort
            return await questBoxTaskCompletionSource.Task;
        }
        private void OnComfirmQuestBox(bool result)
        {
            // Setzen Sie das TaskCompletionSource-Objekt abhängig von der Benutzerantwort
            questBoxTaskCompletionSource?.SetResult(result);

            if (QuestBoxOpen)
            {
                CloseQuestBox();
            }
        }
        private void ComfirmQuestBox_Click(object sender, RoutedEventArgs e)
        {
            bool result = true;
            // Feuern Sie das benutzerdefinierte Event mit dem Ergebnis
            OnComfirmQuestBox(result);
        }
        private void CloseQuestBox()
        {
            CancelQuestBox.Visibility = Visibility.Collapsed;
            ComfirmQuestBox.Visibility = Visibility.Collapsed;
            QuestBoxQuest.Visibility = Visibility.Collapsed;
            QuestBoxIcon.Visibility = Visibility.Collapsed;
            QuestBoxQuest.Text = string.Empty;
            QuestBoxOpen = false;

            DoubleAnimation widthAnimation = new DoubleAnimation
            {
                From = 300,
                To = 0,
                Duration = TimeSpan.FromSeconds(0.2),
                EasingFunction = new QuadraticEase { EasingMode = EasingMode.EaseInOut }
            };

            Storyboard storyboard = new Storyboard();
            storyboard.Children.Add(widthAnimation);

            Storyboard.SetTarget(widthAnimation, QuestBoxWindow);
            Storyboard.SetTargetProperty(widthAnimation, new PropertyPath(WidthProperty));

            widthAnimation.Completed += (s, args) =>
            {
                QuestBoxWindow.IsHitTestVisible = false;
            };
            storyboard.Begin();
        }
        private void CancelQuestBox_Click(object sender, RoutedEventArgs e)
        {
            bool result = false;
            OnComfirmQuestBox(result);
            CloseQuestBox();
        }

        //DataGrid Edit
        private void OpenEditWindow()
        {
            EditWindowOpen = true;
            EditWindow.IsHitTestVisible = true;
            AccountAddBtn_edit.IsDefault = true;
            AccountAddBtn_edit.Focusable = true;

            DoubleAnimation widthAnimation = new DoubleAnimation
            {
                From = 0,
                To = 780,
                Duration = TimeSpan.FromSeconds(0.3),
                EasingFunction = new QuadraticEase { EasingMode = EasingMode.EaseInOut }
            };

            Storyboard storyboard = new Storyboard();
            storyboard.Children.Add(widthAnimation);

            Storyboard.SetTarget(widthAnimation, EditWindow);
            Storyboard.SetTargetProperty(widthAnimation, new PropertyPath(WidthProperty));

            storyboard.Begin();



            string existingJsonContent = File.ReadAllText(filePath);

            UserData existingData = JsonConvert.DeserializeObject<UserData>(existingJsonContent);

            User loggedInUser = existingData?.Users?.FirstOrDefault(user =>
                user.Username == LogedInUser.CurrentUser || user.Email == LogedInUser.CurrentUser);

            string selectedEntryId = GetSelectedEntryId();

            UserDataDetails existingEntry = loggedInUser.Data.FirstOrDefault(entry => entry.ID == selectedEntryId);

            if (existingEntry != null)
            {
                if (existingEntry.AppColor != null && existingEntry.AppColor.Length == 4)
                {
                    byte[] colorBytes = existingEntry.AppColor.Select(byte.Parse).ToArray();
                    ColorPickerIcon_edit.Foreground = new SolidColorBrush(Color.FromArgb(colorBytes[0], colorBytes[1], colorBytes[2], colorBytes[3]));
                }
                else
                {
                    ColorPickerIcon_edit.Foreground = new SolidColorBrush(Colors.Gainsboro);
                }
            }

            // Überprüfen, ob eine Zeile ausgewählt ist
            if (Datagrid.SelectedItems.Count > 0)
            {
                // Erhalten Sie den ausgewählten Eintrag
                var selectedEntry = Datagrid.SelectedItems[0] as UserDataDetails;

                if (selectedEntry != null)
                {
                    if (selectedEntry.Application == "/" || selectedEntry.Application == String.Empty)
                    {
                        Tb_app_edit.Text = "Anwendung";
                    }
                    else
                    {
                        Tb_app_edit.Text = selectedEntry.Application;
                    }

                    if (selectedEntry.AppLink == "/" || selectedEntry.AppLink == String.Empty)
                    {
                        Tb_link_edit.Text = "Website";
                    }
                    else
                    {
                        Tb_link_edit.Text = selectedEntry.AppLink;
                    }

                    if (selectedEntry.AppUsername == "/" || selectedEntry.AppUsername == String.Empty)
                    {
                        Tb_appusername_edit.Text = "Benutzername";
                    }
                    else
                    {
                        Tb_appusername_edit.Text = selectedEntry.AppUsername;
                    }

                    if (selectedEntry.AppPassword == "/" || selectedEntry.AppPassword == String.Empty)
                    {
                        Tb_apppassword_edit.Password = "Passwort";
                    }
                    else
                    {
                        Tb_apppassword_edit.Password = Decrypt(selectedEntry.AppPassword, GenerateKey(DecryptKey));
                    }

                    if (selectedEntry.AppEmail == "/" || selectedEntry.AppEmail == String.Empty)
                    {
                        Tb_appemail_edit.Text = "E-Mail";
                    }
                    else
                    {
                        Tb_appemail_edit.Text = Decrypt(selectedEntry.AppEmail, GenerateKey(DecryptKey));
                    }

                    if (selectedEntry.AppEmailPassword == "/" || selectedEntry.AppEmailPassword == String.Empty)
                    {
                        Tb_appemailpassword_edit.Password = "E-Mail Passwort";
                    }
                    else
                    {
                        Tb_appemailpassword_edit.Password = Decrypt(selectedEntry.AppEmailPassword, GenerateKey(DecryptKey));
                    }

                    if (selectedEntry.AppInfo == "/" || selectedEntry.AppInfo == String.Empty)
                    {
                        Tb_appinfo_edit.Text = "Info";
                    }
                    else
                    {
                        Tb_appinfo_edit.Text = selectedEntry.AppInfo;
                    }

                    if (selectedEntry.AppTag == "Kategorie")
                    {
                        Cb_appTag_edit.SelectedIndex = 6;
                    }
                    if (selectedEntry.AppTag == "Spiele")
                    {
                        Cb_appTag_edit.SelectedIndex = 1;
                    }
                    if (selectedEntry.AppTag == "Soziale Medien")
                    {
                        Cb_appTag_edit.SelectedIndex = 2;
                    }
                    if (selectedEntry.AppTag == "Streaming")
                    {
                        Cb_appTag_edit.SelectedIndex = 3;
                    }
                    if (selectedEntry.AppTag == "Shopping")
                    {
                        Cb_appTag_edit.SelectedIndex = 4;
                    }
                    if (selectedEntry.AppTag == "Finanzen")
                    {
                        Cb_appTag_edit.SelectedIndex = 5;
                    }
                    if (selectedEntry.AppTag == "Sonstige")
                    {
                        Cb_appTag_edit.SelectedIndex = 6;
                    }

                    Tb_app_edit.Foreground = new SolidColorBrush(Colors.Black);
                    Tb_link_edit.Foreground = new SolidColorBrush(Colors.Black);
                    Tb_appusername_edit.Foreground = new SolidColorBrush(Colors.Black);
                    Tb_apppassword_edit.Foreground = new SolidColorBrush(Colors.Black);
                    Tb_appemail_edit.Foreground = new SolidColorBrush(Colors.Black);
                    Tb_appemailpassword_edit.Foreground = new SolidColorBrush(Colors.Black);
                    Tb_appinfo_edit.Foreground = new SolidColorBrush(Colors.Black);
                }
            }
        }
        private void AccountAddBtn_edit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (File.Exists(filePath))
                {
                    string existingJsonContent = File.ReadAllText(filePath);

                    UserData existingData = JsonConvert.DeserializeObject<UserData>(existingJsonContent);

                    User loggedInUser = existingData?.Users?.FirstOrDefault(user =>
                        user.Username == LogedInUser.CurrentUser || user.Email == LogedInUser.CurrentUser);

                    int maxId = loggedInUser.Data?.Any() == true ? loggedInUser.Data.Max(entry => int.TryParse(entry.ID, out int id) ? id : 0) : 0;

                    if (loggedInUser != null)
                    {
                        System.Windows.Media.Color selectedColor = Colors.Gainsboro;

                        if (ColorPickerIcon_edit.Foreground is SolidColorBrush solidColorBrush)
                        {
                            selectedColor = solidColorBrush.Color;
                        }

                        // Finden Sie den Eintrag nach ID
                        string selectedEntryId = GetSelectedEntryId();

                        UserDataDetails existingEntry = loggedInUser.Data.FirstOrDefault(entry => entry.ID == selectedEntryId);

                        if (existingEntry != null)
                        {
                            string application = GetValidatedInput(Tb_app_edit, "Anwendung");
                            string applink = GetValidatedInput(Tb_link_edit, "Website");
                            string appUsername = GetValidatedInput(Tb_appusername_edit, "Benutzername");
                            string appPassword = GetEncryptPasswordInput(Tb_apppassword_edit, "Passwort");
                            string appEmail = GetEncryptInput(Tb_appemail_edit, "E-Mail");
                            string appEmailPassword = GetEncryptPasswordInput(Tb_appemailpassword_edit, "E-Mail Passwort");
                            string appTag = Cb_appTag_edit.SelectedItem != null ? (Cb_appTag_edit.SelectedItem as ComboBoxItem)?.Content.ToString() : string.Empty;
                            string appInfo = GetValidatedInput(Tb_appinfo_edit, "Info");
                            string appFilePath = CopySelectedFile(maxId, GetValidatedInput(Tb_app_edit, "Anwendung"));
                            string[] appColor = new string[] { selectedColor.A.ToString(), selectedColor.R.ToString(), selectedColor.G.ToString(), selectedColor.B.ToString() };

                            // Aktualisieren Sie die Eigenschaften des vorhandenen Eintrags
                            existingEntry.Application = application;
                            existingEntry.AppLink = applink;
                            existingEntry.AppUsername = appUsername;
                            existingEntry.AppPassword = appPassword;
                            existingEntry.AppEmail = appEmail;
                            existingEntry.AppEmailPassword = appEmailPassword;
                            existingEntry.AppTag = appTag;
                            existingEntry.AppInfo = appInfo;
                            existingEntry.AppFiles = appFilePath;
                            existingEntry.AppColor = appColor;

                            // Speichern Sie die aktualisierten Benutzerdaten
                            WriteJsonFile(filePath, JsonConvert.SerializeObject(existingData, Formatting.Indented));

                            selectedFilePath = null;

                            ResetInputFields();
                            RefreshDataGrid();
                            CountAccountsFunc();
                            Notify("Account Hinzufügen", "Account wurde erfolgreich geändert!", 5);
                            StoreFileIcon.Foreground = new SolidColorBrush(Colors.Gainsboro);
                            ColorPickerIcon_edit.Foreground = new SolidColorBrush(Colors.Gainsboro);
                            StoreFileIcon_edit.Foreground = new SolidColorBrush(Colors.Gainsboro);
                            CloseEditWindow();
                        }
                        else
                        {
                            Notify("Fehler!", "Eintrag nicht gefunden.", 5);
                        }
                    }
                    else
                    {
                        Notify("Fehler!", "Benutzer nicht gefunden.", 5);
                    }
                }
                else
                {
                    Notify("Fehler!", "Datenbankdatei nicht gefunden.", 5);
                }
            }
            catch (Exception ex)
            {
                Notify("Fehler!", $"Fehler beim Aktualisieren der Daten: {ex.Message}", 5);
            }
        }
        private string GetSelectedEntryId()
        {
            if (Datagrid.SelectedItems.Count > 0)
            {
                var selectedEntry = Datagrid.SelectedItems[0] as UserDataDetails;
                return selectedEntry?.ID;
            }

            return null;
        }
        private void CloseEditWindow()
        {
            EditWindowOpen = false;
            EditWindow.IsHitTestVisible = false;
            AccountAddBtn_edit.IsDefault = false;
            AccountAddBtn_edit.Focusable = false;

            DoubleAnimation widthAnimation = new DoubleAnimation
            {
                From = 780,
                To = 0,
                Duration = TimeSpan.FromSeconds(0.3),
                EasingFunction = new QuadraticEase { EasingMode = EasingMode.EaseInOut }
            };

            Storyboard storyboard = new Storyboard();
            storyboard.Children.Add(widthAnimation);

            Storyboard.SetTarget(widthAnimation, EditWindow);
            Storyboard.SetTargetProperty(widthAnimation, new PropertyPath(WidthProperty));

            storyboard.Begin();
        }
        private void AccountAddCancelBtn_edit_Click(object sender, RoutedEventArgs e)
        {
            CloseEditWindow();
        }
        public void RefreshDataGrid()
        {
            var userData = LoadUserData(LogedInUser.CurrentUser);
            if (userData != null && userData.Users != null)
            {
                User? loggedInUser = userData.Users.FirstOrDefault(user => user.Username == LogedInUser.CurrentUser);

                if (loggedInUser != null && loggedInUser.Data != null)
                {
                    Datagrid.ItemsSource = loggedInUser.Data;

                    ApplyFilters();
                }
            }
        }
        private void ApplyFilters()
        {
            if (DataGridAllFilter.IsChecked == true)
            {
                DataGridAllFilter.IsChecked = false;
                DataGridAllFilter.IsChecked = true;
            }
            if (DataGridGamesFilter.IsChecked == true)
            {
                DataGridGamesFilter.IsChecked = false;
                DataGridGamesFilter.IsChecked = true;
            }
            if (DataGridSocialMediaFilter.IsChecked == true)
            {
                DataGridSocialMediaFilter.IsChecked = false;
                DataGridSocialMediaFilter.IsChecked = true;
            }
            if (DataGridStreamingFilter.IsChecked == true)
            {
                DataGridStreamingFilter.IsChecked = false;
                DataGridStreamingFilter.IsChecked = true;
            }
            if (DataGridShoppingFilter.IsChecked == true)
            {
                DataGridShoppingFilter.IsChecked = false;
                DataGridShoppingFilter.IsChecked = true;
            }
            if (DataGridMoneyFilter.IsChecked == true)
            {
                DataGridMoneyFilter.IsChecked = false;
                DataGridMoneyFilter.IsChecked = true;
            }
            if (DataGridRestFilter.IsChecked == true)
            {
                DataGridRestFilter.IsChecked = false;
                DataGridRestFilter.IsChecked = true;
            }
        }
        public void SaveCurrentUserData()
        {
            // Extrahieren Sie die Daten direkt aus dem DataGrid
            List<UserDataDetails> dataGridItems = Datagrid.ItemsSource as List<UserDataDetails>;

            if (dataGridItems != null)
            {
                // Aktualisieren Sie die Daten im userData-Objekt
                var userData = LoadUserData(LogedInUser.CurrentUser);

                if (userData != null && userData.Users != null)
                {
                    User? loggedInUser = userData.Users.FirstOrDefault(user => user.Username == LogedInUser.CurrentUser);

                    if (loggedInUser != null)
                    {
                        // Aktualisieren Sie die Daten im userData-Objekt mit den Daten aus dem Datagrid
                        loggedInUser.Data = new List<UserDataDetails>(dataGridItems);

                        // Speichern Sie die aktualisierten Benutzerdaten
                        SaveUserData(userData);
                    }
                }
            }
        }
        private void DelAccountBtn_Click(object sender, RoutedEventArgs e)
        {
            DeleteAccount();
        }
        private async void DeleteAccount()
        {
            // Überprüfen, ob mindestens eine Zeile ausgewählt ist
            if (Datagrid.SelectedItems.Count == 0)
            {
                Notify("Info", "Bitte wählen Sie einen Eintrag zum Löschen aus.", 5);
                return;
            }

            var selectedEntry = Datagrid.SelectedItems[0] as UserDataDetails;

            if (selectedEntry != null)
            {
                var userData = LoadUserData(LogedInUser.CurrentUser);

                if (userData != null && userData.Users != null)
                {
                    User? loggedInUser = userData.Users.FirstOrDefault(user => user.Username == LogedInUser.CurrentUser);

                    if (loggedInUser != null && loggedInUser.Data != null)
                    {
                        // Finden Sie den Index des Eintrags mit der entsprechenden ID
                        int selectedIndex = loggedInUser.Data.FindIndex(entry => entry.ID == selectedEntry.ID);

                        if (selectedIndex != -1)
                        {
                            if (await QuestBox("Wollen Sie den Eintrag wirklich löschen?"))
                            {
                                // Entfernen Sie den Eintrag aus der Liste anhand des Index
                                loggedInUser.Data.RemoveAt(selectedIndex);

                                // Löschen Sie den zugehörigen Ordner
                                DeleteEntryFolder(selectedEntry);

                                // Speichern Sie die aktualisierten Benutzerdaten
                                SaveUserData(userData);

                                // Aktualisieren Sie die Anzeige
                                RefreshDataGrid();

                                CountAccountsFunc();

                                Notify("Account Löschen", "Der Eintrag wurde erfolgreich gelöscht.", 5);
                                return;
                            }
                        }
                    }
                }
            }
        }
        private void DeleteEntryFolder(UserDataDetails entry)
        {
            if (!string.IsNullOrEmpty(entry.AppFiles))
            {
                try
                {
                    // Extrahieren Sie den Ordnerpfad aus dem Dateipfad
                    string folderPath = Path.GetDirectoryName(entry.AppFiles);

                    // Überprüfen Sie, ob der Ordner existiert, bevor Sie ihn löschen
                    if (Directory.Exists(folderPath))
                    {
                        // Löschen Sie den Ordner und alle darin enthaltenen Dateien
                        Directory.Delete(folderPath, true);
                    }
                }
                catch (Exception ex)
                {
                    Notify("Fehler!", $"Fehler beim Löschen des Ordners: {ex.Message}", 5);
                }
            }
        }
        private void RowDelBtn_Click(object sender, RoutedEventArgs e)
        {
            DeleteAccount();
        }
        private void RowEditBtn_Click(object sender, RoutedEventArgs e)
        {
            ManageWindows("edit");
        }
        private void Datagrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (EditWindowOpen)
            {
                EditWindowOpen = !EditWindowOpen;
                CloseEditWindow();
            }
        }
        private void OpenLink_btn(object sender, MouseButtonEventArgs e)
        {
            if (sender is Button button && button.DataContext is UserDataDetails dataObject)
            {
                string columnText = dataObject.AppLink;

                if (Uri.IsWellFormedUriString(columnText, UriKind.Absolute))
                {
                    ProcessStartInfo psi = new ProcessStartInfo
                    {
                        FileName = columnText,
                        UseShellExecute = true
                    };

                    if (Process.Start(psi) == null)
                    {
                        Notify("Fehler!", "Standardbrowser konnte nicht gefunden werden.", 5);
                    }
                }
                else
                {
                    Notify("Info", "Ungültige URL.", 5);
                }
            }
        }
        private void FileLink_Click(object sender, MouseButtonEventArgs e)
        {
            if (sender is Button button && button.DataContext is UserDataDetails selectedData)
            {
                string filePath = selectedData.AppFiles;
                if (!string.IsNullOrEmpty(filePath))
                {
                    string folderPath = Path.GetDirectoryName(filePath);
                    if (Directory.Exists(folderPath))
                    {
                        System.Diagnostics.Process.Start("explorer.exe", folderPath);
                    }
                    else
                    {
                        Notify("Fehler!", "Der Ordner existiert nicht.", 5);
                    }
                }
                else
                {
                    Notify("Info", "Der Dateipfad ist leer.", 5);
                }
            }
        }
        private void CopyBtnPasswortFromCell_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var button = sender as System.Windows.Controls.Button;

            if (button != null)
            {
                var stackPanel = button.Content as StackPanel;

                if (stackPanel != null)
                {
                    // Find the TextBlock within the StackPanel
                    if (stackPanel.Children.Count > 1 && stackPanel.Children[1] is TextBlock textBlock)
                    {
                        string columnText = textBlock.Text;

                        if (!string.IsNullOrEmpty(columnText) && columnText != "/")
                        {
                            string decryptedText = columnText;

                            try
                            {
                                Clipboard.Clear();
                                //Clipboard.SetText(Decrypt(decryptedText, GenerateKey(DecryptKey)));
                                Clipboard.SetDataObject(Decrypt(decryptedText, GenerateKey(DecryptKey)));
                                Notify("Kopieren", "Passwort wurde in die Zwischenablage kopiert.", 5);
                            }
                            catch (Exception ex)
                            {
                                Notify("Fehler!", $"Das hat nicht geklappt... {ex.Message}", 5);
                            }
                        }
                        else
                        {
                            Notify("Info", "Dieser Eintrag ist leer.", 5);
                        }
                    }
                }
            }
        }
        private void CopyBtnEmailFromCell_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var button = sender as System.Windows.Controls.Button;

            if (button != null)
            {
                var stackPanel = button.Content as StackPanel;

                if (stackPanel != null)
                {
                    // Find the TextBlock within the StackPanel
                    if (stackPanel.Children.Count > 1 && stackPanel.Children[1] is TextBlock textBlock)
                    {
                        string columnText = textBlock.Text;

                        if (!string.IsNullOrEmpty(columnText) && columnText != "/")
                        {
                            string decryptedText = columnText;

                            try
                            {
                                Clipboard.Clear();
                                //Clipboard.SetText(Decrypt(decryptedText, GenerateKey(DecryptKey)));
                                Clipboard.SetDataObject(Decrypt(decryptedText, GenerateKey(DecryptKey)));
                                Notify("Kopieren", "E-Mail wurde in die Zwischenablage kopiert.", 5);
                            }
                            catch (Exception ex)
                            {
                                Notify("Fehler!", $"Das hat nicht geklappt... {ex.Message}", 5);
                            }
                        }
                        else
                        {
                            Notify("Info", "Dieser Eintrag ist leer.", 5);
                        }
                    }
                }
            }
        }
        private void CopyBtnUsernameFromCell_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var button = sender as System.Windows.Controls.Button;

            if (button != null)
            {
                var stackPanel = button.Content as StackPanel;

                if (stackPanel != null)
                {
                    if (stackPanel.Children.Count > 1 && stackPanel.Children[1] is TextBlock textBlock)
                    {
                        string columnText = textBlock.Text;

                        if (!string.IsNullOrEmpty(columnText) && columnText != "/")
                        {
                            string decryptedText = columnText;

                            try
                            {
                                Clipboard.Clear();
                                //Clipboard.SetText(decryptedText);
                                Clipboard.SetDataObject(decryptedText);
                                Notify("Kopieren", "Benutzername wurde in die Zwischenablage kopiert.", 5);
                            }
                            catch (Exception ex)
                            {
                                Notify("Fehler!", $"Das hat nicht geklappt... {ex.Message}", 5);
                            }
                        }
                        else
                        {
                            Notify("Info", "Dieser Eintrag ist leer.", 5);
                        }
                    }
                }
            }
        }
        private void CopyBtnApplicationFromCell_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var button = sender as System.Windows.Controls.Button;

            if (button != null)
            {
                var stackPanel = button.Content as StackPanel;

                if (stackPanel != null)
                {
                    if (stackPanel.Children.Count > 0 && stackPanel.Children[1] is TextBlock textBlock)
                    {
                        string columnText = textBlock.Text;

                        if (!string.IsNullOrEmpty(columnText) && columnText != "/")
                        {
                            string decryptedText = columnText;

                            try
                            {
                                Clipboard.Clear();
                                //Clipboard.SetText(decryptedText);
                                Clipboard.SetDataObject(decryptedText);
                                Notify("Kopieren", "Anwendung wurde in die Zwischenablage kopiert.", 5);
                            }
                            catch (Exception ex)
                            {
                                Notify("Fehler!", $"Das hat nicht geklappt... {ex.Message}", 5);
                            }
                        }
                        else
                        {
                            Notify("Info", "Dieser Eintrag ist leer.", 5);
                        }
                    }
                }
            }
        }
        private void CopyBtnAppInfoFromCell_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var button = sender as System.Windows.Controls.Button;

            if (button != null)
            {
                var stackPanel = button.Content as StackPanel;

                if (stackPanel != null)
                {
                    if (stackPanel.Children.Count > 0 && stackPanel.Children[1] is TextBlock textBlock)
                    {
                        string columnText = textBlock.Text;

                        if (!string.IsNullOrEmpty(columnText) && columnText != "/")
                        {
                            string decryptedText = columnText;

                            try
                            {
                                Clipboard.Clear();
                                Clipboard.SetDataObject(decryptedText);
                                //Clipboard.SetText(decryptedText);
                                Notify("Kopieren", "Anwendung wurde in die Zwischenablage kopiert.", 5);
                            }
                            catch (Exception ex)
                            {
                                Notify("Fehler!", $"Das hat nicht geklappt... {ex.Message}", 5);
                            }
                        }
                        else
                        {
                            Notify("Info", "Dieser Eintrag ist leer.", 5);
                        }
                    }
                }
            }
        }
        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            if (sender is System.Windows.Controls.RadioButton radioButton)
            {
                string radioButtonContent = (radioButton.Content as TextBlock)?.Text;

                // Sicherstellen, dass radioButtonContent nicht null ist
                if (radioButtonContent == null)
                {
                    return;
                }

                var userData = LoadUserData(LogedInUser.CurrentUser);

                if (userData != null && userData.Users != null)
                {
                    User? loggedInUser = userData.Users.FirstOrDefault(user => user.Username == LogedInUser.CurrentUser);

                    if (loggedInUser != null && loggedInUser.Data != null)
                    {
                        if (radioButtonContent == "Alle")
                        {
                            // Wenn "Alle" ausgewählt ist, setzen Sie die Datagrid.ItemsSource auf die vollständigen Daten
                            Datagrid.ItemsSource = loggedInUser.Data;
                        }
                        else
                        {
                            // Andernfalls filtern Sie die Daten nach dem ausgewählten RadioButton-Inhalt
                            var filteredData = loggedInUser.Data
                                .Where(entry => entry.AppTag != null && entry.AppTag.ToLower().Contains(radioButtonContent.ToLower()))
                                .ToList();

                            Datagrid.ItemsSource = filteredData;
                        }

                        if (SortAZSetting)
                        {
                            var column = Datagrid.Columns.FirstOrDefault(c => c.SortMemberPath == "Application");
                            if (column != null)
                            {
                                Datagrid.Items.SortDescriptions.Clear();
                                Datagrid.Items.SortDescriptions.Add(new SortDescription(column.SortMemberPath, ListSortDirection.Ascending));
                                column.SortDirection = ListSortDirection.Ascending;
                            }
                        }
                    }
                }
            }
        }
        private void ColorPicker_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.ColorDialog colorDialog = new System.Windows.Forms.ColorDialog();

            if (colorDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                System.Windows.Media.Color wpfColor = System.Windows.Media.Color.FromArgb(colorDialog.Color.A, colorDialog.Color.R, colorDialog.Color.G, colorDialog.Color.B);

                ColorPickerIcon.Foreground = new SolidColorBrush(wpfColor);
            }
        }
        private void ColorPickerBtn_edit_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.ColorDialog colorDialog = new System.Windows.Forms.ColorDialog();

            if (colorDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                System.Windows.Media.Color wpfColor2 = System.Windows.Media.Color.FromArgb(colorDialog.Color.A, colorDialog.Color.R, colorDialog.Color.G, colorDialog.Color.B);

                ColorPickerIcon_edit.Foreground = new SolidColorBrush(wpfColor2);
            }
        }
        private void CopyRowBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (File.Exists(filePath))
                {
                    string existingJsonContent = File.ReadAllText(filePath);

                    UserData existingData = JsonConvert.DeserializeObject<UserData>(existingJsonContent);

                    User loggedInUser = existingData?.Users?.FirstOrDefault(user =>
                        user.Username == LogedInUser.CurrentUser || user.Email == LogedInUser.CurrentUser);

                    if (loggedInUser != null)
                    {
                        // Finden Sie den Eintrag nach ID
                        string selectedEntryId = GetSelectedEntryId();

                        UserDataDetails existingEntry = loggedInUser.Data.FirstOrDefault(entry => entry.ID == selectedEntryId);

                        if (existingEntry != null)
                        {
                            Clipboard.SetDataObject($"Anwendung: {existingEntry.Application} | " +
                                $"Benutzername: {existingEntry.AppUsername} | " +
                                $"Passwort: {Decrypt(existingEntry.AppPassword, GenerateKey(DecryptKey))} | " +
                                $"Info: {existingEntry.AppInfo}");

                            Notify("Info", "Die Zeile wurde in die Zwischenablage kopiert.", 5);
                        }
                        else
                        {
                            Notify("Fehler!", "Eintrag nicht gefunden.", 5);
                        }
                    }
                    else
                    {
                        Notify("Fehler!", "Benutzer nicht gefunden.", 5);
                    }
                }
                else
                {
                    Notify("Fehler!", "Datenbankdatei nicht gefunden.", 5);
                }
            }
            catch (Exception ex)
            {
                Notify("Fehler!", $"Fehler beim Aktualisieren der Daten: {ex.Message}", 5);
            }
        }
    }
}