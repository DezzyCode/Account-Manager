   M S B A M L   `   `   `  ���� J  FAccount Manager, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:Account_Manager.ModelAccount_Manager.Model  %    Account_Manager.View.MainWindow   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     X TFontAwesome.Sharp, Version=6.3.0.0, Culture=neutral, PublicKeyToken=d16d1e4e568ec10fFfa=http://schemas.awesome.incremented/wpf/xaml/fontawesome.sharp  /model#clr-namespace:Account_Manager.Model    � Title$  Account Manager�� � AllowsTransparency$
 True��
������  � WindowStyle$
 None=� � 
ResizeMode$ CanResizeWithGrip=�$	��900��$
��1600��$	��900��$
��1600�� � WindowStartupLocation$ CenterScreen=� � 	Resources  �� MergedDictionaries �� Source*   $Account_Manager.Model.ColorConverter   ColorConverter��  �� $ /Styles/Buttons.xaml?��� $ /Styles/DataGrid.xaml?��� $ /Styles/Shared.xaml?�%   &	           � Triggers :� 	 :� RoutedEvent$	 Loaded��.[��� .���� .��W� 
 �� TargetProperty$
 Opacity� W� From 0	 W� To 1 g� Duration$ 0:0:1D�.���� -    ��Name$ 
MainBorder��  Border.Primary#���   �� CornerRadius$ 10��$��1q����	#FF3C3C3C._��  � ColumnDefinitions �� $��10 ��� $	��240 ��� $��10 ��� $��30 ��� $��10 ��� $	��830 ��� $��* ��� $	��160 ��� $��10 � � RowDefinitions �� $��10 ��� $��40 ��� $��30 ��� $��40 ��� $��10 ��� $��* ��� $��10 �.+��� -   $ DragBar��
������ $��0��$��9��$��0��$��5���� -   $ UserProfilBorder��$��1��$��3��$��1��  Border.Secoundary#��[ $ 5 5 5 5��._��  �� $��10 ��� $��90 ��� $��10 ��� $	��120 ��� $��0 ��� $��10 � �� $��10 ��� $��30 ��� $��30 ��� $��30 ��� $��10 �.+��� $��1��$��3��$��1�� �� Orientation$ 
Horizontal=�$
��Left=�$��Center=�.+��� -    ��Name$ UserProfilImageBorder��$|�False��$��90��$��90��  Button.Gray80.Over100#��[ $��Center=�$��Center=�.���� .+��� -    ��Name$ UserProfilImage��$��UniformToFill=�$��80��$��80�� � Cursor$
 Hand��$y�	Collapsed=�!  FontAwesome.Sharp.IconImage  -     Name$ DefualtUserProfilImage���  �FontAwesome.Sharp.IconImageBase`1[[FontAwesome.Sharp.IconChar, FontAwesome.Sharp, Version=6.3.0.0, Culture=neutral, PublicKeyToken=d16d1e4e568ec10f]]   Icon$ 
UserCircle=�$��80��$��80��$
 Hand��   IconFont$ Solid=�  	white-220   
Foreground# [ �� $��1��$��3��$ 
Horizontal=�$��Center=�$��0 0 0 0q�.+��� -    ��Name$ Username��$��Luzifer��$��Normal"�$��WrapWithOverflow=�#��[ $��14(�$2��,pack://application:,,,/assets/fonts/#Poppins)��� $��2��$��3��$��2��$ 
Horizontal=�$	��Top=�$��0 0 0 0q�.+��� -   $ StoredAccounts��$��666 Accounts��  Foreground.Detail#��[ $��12(�$2��,pack://application:,,,/assets/fonts/#Poppins)��� -	   $ 
SignOutBtn��$|�False�� � ToolTip$ Abmelden��$��3��$��3��$��2��#��[ $	��120��$��30��$��Bottom=�.���� $ 
Horizontal=�$��Center=�$��Center=�.+�  $ SignOut=�# [ $��15��$��15���� $��Abmelden��#��[ $��12(�$2��,pack://application:,,,/assets/fonts/#Poppins)��� -
   $ UserSettingsWindow��$
��Left=�$��0�� J� IsHitTestVisible$ False��$��5��$��3��$��1��  
cr-default# [ #���  ._��  �� $��10 ��� $	��210 ��� $��10 ��� $	��210 ��� $��10 ��� $��40 ��� $��10 ��� $��40 ��� $��10 ��� $��40 ��� $��10 ��� $��40 ��� $��10 ��� $��40 ��� $��10 ��� $	��120 ��� $��10 � �� $��10 ��� $��45 ��� $��0 ��� $��45 ��� $��10 �.+��� -   $ UserSettingsBox_1��$y�Visible=�$��1��$��1��$��3��  gray-80#���  # [ ._��� $ Vertical=�$��Center=�.+��� $��0 10 0 0q�$��30��$	��195��$ Benutername��  cr-5# [ 
�������._��� $ 
Horizontal=�$��Center=�$��Center=�.+��� -   $ CurrentUsername��$
��auto��$	��165�� �� Padding$ 5q�$��12(� 	 Foreground.Secoundary#��� 	 $2��,pack://application:,,,/assets/fonts/#Poppins)�
������   $ 
UserCircle=�$ Solid=�$��20��$��20�� 
 gray-30# [
 �� $��0 10 0 0q�$��30��$	��195��$ E-Mail��# [ 
�������._��� $ 
Horizontal=�$��Center=�.+��� -    ��Name$ CurrentEmail��$��Center=�$��5q�$��30��$	��165��
������ $��0q�  $ MailBulk=�$ Solid=�$��20��$��20��# [
 �� -   $ UserSettingsBox_2��$y�Visible=�$��3��$��1��$��3��#���  # [ ._��� $ Vertical=�.+��� $��0 10 0 0q�$��30��$	��195��$ Neues Passwort��# [ 
�������._��� $ 
Horizontal=�$��Center=�.+�G� -    G�Name$ CurrentPassword��$��Center=�$��30��$��5q�$	��165��
������ $��0q�  $	 Key=�$ Solid=�$��20��$��20��# [
 �� $��0 10 0 0q�$��30��$	��195��$  Neues Passwort wiederholen��# [ 
�������._��� $ 
Horizontal=�$��Center=�.+�G� -   $ RepeatPassword��$��Center=�$��30��$	��165��$��5q�
������ $��0q�  $ Recycle=�$ Solid=�$��20��$��20��# [
 �� -   $ DumpThisDataBase��$|�False��$ Datenbank Exportieren��#��[ $��5��$��1��$��2��$
��Left=�$	��Top=�$��40��$��40��.��  $ Database=�
 �����$��20��$��20���� -   $ DeleteDataBase��$|�False��$ Datenbank löschen��#��[ $��5��$��2��$��2��$
��Left=�$��Bottom=�$��40��$��40��.��  $ Trash=�
 �����$��20��$��20���� -   $ CreateDatabaseBackup��$|�False��$ Backup erstellen��#��[ $��7��$��1��$��2��$
��Left=�$	��Top=�$��40��$��40��.��  $ CloudArrowDown=�
 �����$��20��$��20���� -   $ LoadDatabaseBackup��$|�False��$ Backup Laden��#��[ $��7��$��2��$��2��$
��Left=�$��Bottom=�$��40��$��40��.��  $ CloudArrowUp=�
 �����$��20��$��20���� -   $ 	ExportCSV��$|�False��$ CSV erstellen��#��[ $��9��$��1��$��2��$
��Left=�$	��Top=�$��40��$��40��.��  $ 
FileExport=�
 �����$��20��$��20���� -   $ 	ImportCSV��$|�False��$ 	CSV Laden��#��[ $��9��$��2��$��2��$
��Left=�$��Bottom=�$��40��$��40��.��  $ 
FileImport=�
 �����$��20��$��20��d� -     d�Name$  SortAZ�� ' #ToggleButton.Checked100.Unchecked80#��[ $|�False��$ 	Sortieren��$��11��$��1��$��2��$
��Left=�$	��Top=�$��40��$��40��.��  $ ArrowDownAZ=�
 �����$��20��$��20��d� -   $  ShowInfo��#��[ $|�False��$ Info Anzeigen��$��13��$��1��$��2��$
��Left=�$	��Top=�$��40��$��40��.��  $	 Eye=�
 �����$��20��$��20���� -   $ AutosavePath��$|�False��$ Autosave-Pfad��#��[ $��11��$��2��$��2��$
��Left=�$��Bottom=�$��40��$��40��.��  -   $ AutoSaveIcon��$
 Save=�
 �����$��20��$��20��! � ContextMenu! �� .@�m� -   " m�Name$" DeaktivateAutosave��$��Autosave Deaktivieren���� -   $ CostumBorderColor��$|�False��$ Fensterfarbe anpassen��#��[ $��13��$��2��$��2��$��Bottom=�$��40��.��  $ 
EyeDropper=�$��20��$��20��# [ �� -   $ SaveUserSettings��$|�False��#��[ $��15��$��1��$��2��$	��Top=�$��40��.���� $��	Speichern��$��12(�$2��,pack://application:,,,/assets/fonts/#Poppins)��� -   $ CloseUserSettings��$|�False��#��[ $��15��$��2��$��2��$��Bottom=�$��40��.���� $��
Schließen��$��12(�$2��,pack://application:,,,/assets/fonts/#Poppins)��� -   $ AddDelLockBorder��$��3��$��1��$��3��._��� $ Vertical=�$
��Left=�.+��� .+��� -    $ AddAccountBtn��$|�False��$ Eintrag hinzufügen��  Button.Gray60.Over80#��[ $��30��$��30��$	��Top=�.���� $ 
Horizontal=�$��Center=�$��Center=�.+�  $
 Plus=�
 � � �$��15��$��15���� $��	0 10 0 10q�.+��� -!   $ PasswordGenerationBtn��$|�False��$ Passwort generieren��#��[ $��30��$��30��$��Center=�.���� $ 
Horizontal=�$��Center=�$��Center=�.+�  $
 Lock=�# [ $��15��$��15���� .+��� -"   $ UserSettings��$|�False��$ 	Statistik��#��[ $��30��$��30��$��Bottom=�.���� $ 
Horizontal=�$��Center=�$��Center=�.+�  $
 Gear=�# [ $��15��$��15���� -#   $ 	AddWindow��$
��Left=�$��0��$ False��$��5��$��3��$��1��# [ #���  ._��  �� $��10 ��� $	��210 ��� $��10 ��� $	��210 ��� $��10 ��� $	��160 ��� $��60 ��� $	��100 ��� $��10 � �� $��10 ��� $��30 ��� $��30 ��� $��30 ��� $��10 �.+��� $��1��$��1��$��1��$��25��$	��210��# [ 
�������$	��Top=�._��� $��Center=�.+��� -$   $ Tb_app��
������ $��0q�$��Center=�$��	Anwendung��
�������$��Italic$�$2��,pack://application:,,,/assets/fonts/#Poppins)�$	��200��$��20���� $��3��$��1��$��1��$��25��$	��210��# [ 
�������$	��Top=�._��� $��Center=�.+��� -%   $ Tb_link��
������ $��0q�$��Center=�$��Website��
�������$��Italic$�$2��,pack://application:,,,/assets/fonts/#Poppins)�$	��200��$��20���� $��1��$��2��$��25��$	��210��# [ 
�������$��Center=�._��� $��Center=�.+��� -&   $ Tb_appusername��
������ $��0q�$��Center=�$��Benutzername��$��Italic$�$2��,pack://application:,,,/assets/fonts/#Poppins)�$	��200��$��20��
��������� -'   $ Tb_apppassword_pwSafty��$��1��$��3��$��25��$	��210��# [ 
�������$��Bottom=�._��� $��Center=�.+��� -(   $ Tb_apppassword��
������ $��0q�$��Center=�$��Passwort��$��Italic$�$2��,pack://application:,,,/assets/fonts/#Poppins)�$	��200��$��20��
��������� $��3��$��2��$��25��$	��210��# [ 
�������$��Center=�._��� $��Center=�.+��� -)   $ Tb_appemail��
������ $��0q�$��Center=�$��E-Mail��$��Italic$�$2��,pack://application:,,,/assets/fonts/#Poppins)�$	��200��$��20��
��������� -*   $! Tb_appemailpassword_pwSafty��$��3��$��3��$��25��$	��210��# [ 
�������$��Bottom=�._��� $��Center=�.+��� -+   $ Tb_appemailpassword��
������ $��0q�$��Center=�$��E-Mail Passwort��$��Italic$�$2��,pack://application:,,,/assets/fonts/#Poppins)�$	��200��$��20��
��������� $��5��$��1��$��2��$
��57.5��$	��160��# [ 
�������$	��Top=�._��� $��Center=�.+��� -,   $ 
Tb_appinfo��
������ $��0q�$��5q�$
��Info��$��Italic$�$2��,pack://application:,,,/assets/fonts/#Poppins)�# �� TextWrapping$
# Wrap=�$	��160��$��60��
��������� $��5��$��3��$��25��$	��160��# [ 
�������$��Bottom=�._��� $��Center=�.+��� --   $ ��Name$$ 	Cb_appTag��  ComboBoxFlatStyle#��[ $2��,pack://application:,,,/assets/fonts/#Poppins)�$��5q�$��25��$	��155��$��Right=�$��0q�.@��� ${�False��$y�	Collapsed=�% �� 
IsSelected$
% True��
�������$2��,pack://application:,,,/assets/fonts/#Poppins)�$��Italic$�.��	Kategorie�� $��Spiele���� $��Soziale Medien���� $��	Streaming���� $��Shopping���� $��Finanzen���� $��Sonstige���� -.   $ 	StoreFile��$|�False��$ Datei angängen��$��6��$��1��$��2��#��[ $��40��$��40��$	��Top=�$��Center=�.���� $ 
Horizontal=�$��Center=�$��Center=�.+�  -/   $ StoreFileIcon��$
 File=�$��25��$��25��# [ �� -0   $ ColorPickerBtn��$|�False��$ Farblich markieren��$��6��$��2��$��2��$��0 0 0 0q�#��[ $��40��$��40��$��Bottom=�$��Center=�.���� $ 
Horizontal=�$��Center=�$��Center=�.+�  -1   $ ColorPickerIcon��$ EyeDropperEmpty=�$��25��$��25��# [ �� -2   $ AccountAddBtn��$|�False��$��7��$��1��$��2��$��0 0 0 10q�#��[ $	��100��$��40��$	��Top=�$
��Left=�.���� $ 
Horizontal=�$��Center=�$��Center=�.+��� $��	Speichern��#��[ $��12(�$2��,pack://application:,,,/assets/fonts/#Poppins)��� -3   $ AccountAddCancelBtn��$|�False��$��7��$��2��$��2��#��[ $	��100��$��40��$��Bottom=�$��Right=�.���� $ 
Horizontal=�$��Center=�$��Center=�.+��� $��
Schließen��#��[ $��12(�$2��,pack://application:,,,/assets/fonts/#Poppins)��� -4   $ 
EditWindow��$
��Left=�$��0��$ False��$��5��$��3��$��1��# [ #���  ._��  �� $��10 ��� $	��210 ��� $��10 ��� $	��210 ��� $��10 ��� $	��160 ��� $��60 ��� $	��100 ��� $��10 � �� $��10 ��� $��30 ��� $��30 ��� $��30 ��� $��10 �.+��� $��1��$��1��$��1��$��25��$	��210��# [ 
�������$	��Top=�._��� $��Center=�.+��� -5   $ Tb_app_edit��
������ $��0q�$��Center=�$��	Anwendung��
�������$��Italic$�$2��,pack://application:,,,/assets/fonts/#Poppins)�$	��200��$��20���� $��3��$��1��$��1��$��25��$	��210��# [ 
�������$	��Top=�._��� $��Center=�.+��� -6   $ Tb_link_edit��
������ $��0q�$��Center=�$��Website��
�������$��Italic$�$2��,pack://application:,,,/assets/fonts/#Poppins)�$	��200��$��20���� $��1��$��2��$��25��$	��210��# [ 
�������$��Center=�._��� $��Center=�.+��� -7   $ Tb_appusername_edit��
������ $��0q�$��Center=�$��Benutzername��$��Italic$�$2��,pack://application:,,,/assets/fonts/#Poppins)�$	��200��$��20��
��������� -8   $! Tb_apppassword_pwSafty_edit��$��1��$��3��$��25��$	��210��# [ 
�������$��Bottom=�._��� $��Center=�.+�G� -9   $ Tb_apppassword_edit��
������ $��0q�$��Center=�& G� PasswordChar$	& ●��' G� Password$' Passwort��$��Italic$�$2��,pack://application:,,,/assets/fonts/#Poppins)�$	��200��$��20��
��������� $��3��$��2��$��25��$	��210��# [ 
�������$��Center=�._��� $��Center=�.+��� -:   $ Tb_appemail_edit��
������ $��0q�$��Center=�$��E-Mail��$��Italic$�$2��,pack://application:,,,/assets/fonts/#Poppins)�$	��200��$��20��
��������� -;   $&  Tb_appemailpassword_pwSafty_edit��$��3��$��3��$��25��$	��210��# [ 
�������$��Bottom=�._��� $��Center=�.+�G� -<   $ Tb_appemailpassword_edit��
������ $��0q�$��Center=�$	& ●��$' E-Mail Passwort��$��Italic$�$2��,pack://application:,,,/assets/fonts/#Poppins)�$	��200��$��20��
��������� $��5��$��1��$��2��$
��57.5��$	��160��# [ 
�������$	��Top=�._��� $��Center=�.+��� -=   $ Tb_appinfo_edit��
������ $��0q�$��5q�$
��Info��$��Italic$�$2��,pack://application:,,,/assets/fonts/#Poppins)�$
# Wrap=�$	��160��$��60��
��������� $��5��$��3��$��25��$	��160��# [ 
�������$��Bottom=�._��� $��Center=�.+��� ->   $$ Cb_appTag_edit��#��[ $2��,pack://application:,,,/assets/fonts/#Poppins)�$��5q�$��25��$	��155��$��Right=�$��0q�.@��� ${�False��$y�	Collapsed=�$
% True��
�������$2��,pack://application:,,,/assets/fonts/#Poppins)�$��Italic$�.��	Kategorie�� $��Spiele���� $��Soziale Medien���� $��	Streaming���� $��Shopping���� $��Finanzen���� $��Sonstige���� -?   $ StoreFile_edit��$|�False��$ Datei ersetzen��$��6��$��1��$��2��#��[ $��40��$��40��$	��Top=�$��Center=�.���� $ 
Horizontal=�$��Center=�$��Center=�.+�  -@   $ StoreFileIcon_edit��$
 File=�$��25��$��25��# [ �� -A   $ ColorPickerBtn_edit��$|�False��$ Farblich markieren��$��6��$��2��$��2��$��0 0 0 0q�#��[ $��40��$��40��$��Bottom=�$��Center=�.���� $ 
Horizontal=�$��Center=�$��Center=�.+�  -B   $ ColorPickerIcon_edit��$ EyeDropperEmpty=�$��25��$��25��# [ �� -C   $ AccountAddBtn_edit��$|�False��$��6��$��2��$��1��$��2��$��0 0 0 10q�#��[ $	��100��$��40��$	��Top=�$��Right=�.���� $ 
Horizontal=�$��Center=�$��Center=�.+��� $��	Speichern��#��[ $��12(�$2��,pack://application:,,,/assets/fonts/#Poppins)��� -D   $ AccountAddCancelBtn_edit��$|�False��$��6��$��2��$��2��$��2��#��[ $	��100��$��40��$��Bottom=�$��Right=�.���� $ 
Horizontal=�$��Center=�$��Center=�.+��� $��
Schließen��#��[ $��12(�$2��,pack://application:,,,/assets/fonts/#Poppins)��� -E   $ PasswordGeneratorWindow��$
��Left=�$��0��$ False��$��5��$��3��$��1��# [ #���  ._�� $  �� �� $��10 ��� $	��100 ��� $��10 ��� $	��140 ��� $��10 ��� $	��140 ��� $��10 ��� $	��140 ��� $��10 � �� $��10 ��� $��30 ��� $��30 ��� $��30 ��� $��10 �.+��� $��1��$��1��$��3��
������ # [ ._��� $ Vertical=�$��Center=�$��Center=�.+�	� -F   ( 	�Name$
( rb_8��  ButtonLikeRadioButtonStyle2#��[ $��12(�$��	8 Zeichen��) d� 	IsChecked$
) TrueY�#��[ $	��100��$��20��$��0 0 0 3q�	� -G   $( rb_12��#��[ $��12(�$��
12 Zeichen��#��[ $	��100��$��20��$��0 0 0 3q�	� -H   $( rb_16��#��[ $��12(�$��
16 Zeichen��#��[ $	��100��$��20��$��0 0 0 3q�	� -I   $( rb_20��#��[ $��12(�$��
20 Zeichen��#��[ $	��100��$��20���� $��3��$��1��$��3��
������ # [ ._��� $ Vertical=�$��Center=�$��Center=�.+�d� -J   $  cb_sonderzeichen��  ToggleButtonStyle#��[ $��20��$	��140��$
) TrueY�$��12(�$��Sonderzeichen��#��[ $��0 0 0 3q�d� -K   $  cb_grosbuchstaben��#��[ $��20��$	��140��$
) TrueY�$��12(�$��Großbuchstaben��#��[ $��0 0 0 3q�d� -L   $  cb_kleinbuchstaben��#��[ $��20��$	��140��$
) TrueY�$��12(�$��Kleinbuchstaben��#��[ $��0 0 0 3q�d� -M   $  	cb_zahlen��#��[ $��20��$	��140��$
) TrueY�$��12(�$��Zahlen��#��[ �� $��5��$��3��$��1��$��2��$��40��$	��290��$ 5��
�������$
��Left=�$	��Top=�._��� $ 
Horizontal=�.+��� -N   $ GeneratedPasswortBox��
�������$��16(�$	��235��$��10 0 0 0q�$��Center=�  -O   $ GeneratedPasswordCopyBtn��$
 Copy=�$ Kopieren��$��20��$��20�� �#333$
 Hand��$��15 0 0 0q��� -P   $ GeneratePasswordBtn��$|�False��$��5��$��2��$��2��$��0 0 0 0q�#��[ $	��140��$��40��$��Bottom=�$
��Left=�.���� $ 
Horizontal=�$��Center=�$��Center=�.+��� $��
Generieren��#��[ $��12(�$2��,pack://application:,,,/assets/fonts/#Poppins)��� -Q   $ GeneratePasswordCancelBtn��$|�False��$��7��$��2��$��2��#��[ $	��140��$��40��$��Bottom=�$
��Left=�.���� $ 
Horizontal=�$��Center=�$��Center=�.+��� $��
Schließen��#��[ $��12(�$2��,pack://application:,,,/assets/fonts/#Poppins)��� -R   $ DataExportWindow��$
��Left=�$��0��$ False��$��5��$��3��$��1��# [ #���  ._��  �� $��10 ��� $��20 ��� $��10 ��� $	��140 ��� $��10 ��� $��15 ��� $��0 � �� $��10 ��� $��90 ��� $��10 �.+��� $��1��$��1��$��Exportieren��$��14(�$2��,pack://application:,,,/assets/fonts/#Poppins)�
�������$��Center=�* � LayoutTransform* �� + �� Angle$	+ -90Q��� -S   $ CloseExportBtn��$��5��$��1�� ! Button.Trans.Over40.Pressed20#��[ $��15��$��90��$��Center=�$��Center=�$��Center=�.���� $ 
Horizontal=�$��Center=�$��0 0 0 0q�.+�  $ 	CaretLeft=�
 �����$��10��$��10��$��0 0 0 0q��� -T   $ ExportAsExcelBtn��$��3��$��1��#��[ $	��140��$��28��$
��Left=�$
��Left=�$	��Top=�.���� $ 
Horizontal=�$
��Left=�$��5 0 0 0q�.+�  $ FileText=�
 �����$��15��$��15��$��0 0 5 0q��� $��Als Excel (.xlsx)��
�������$��12(�$��Center=��� -U   $ ExportAsTextBtn��$��3��$��1��#��[ $	��140��$��28��$
��Left=�$
��Left=�$��Center=�.���� $ 
Horizontal=�$
��Left=�$��5 0 0 0q�.+�  $ 	FileExcel=�
 �����$��15��$��15��$��0 0 5 0q��� $��Als Text (.txt)��
�������$��12(�$��Center=��� -V   $ ExportAsJsonBtn��$��3��$��1��#��[ $	��140��$��28��$
��Left=�$
��Left=�$��Bottom=�.���� $ 
Horizontal=�$
��Left=�$��5 0 0 0q�.+�  $ FileContract=�
 �����$��15��$��15��$��0 0 5 0q��� $��Als Json (.json)��
�������$��12(�$��Center=��� -W   $ WindowOperationBorder��$��6��$��2��$��1��$��1��$��Right=�._��  �� $��40 ��� $��40 ��� $��40 ��� $��40 � �� $��50 �.+��� -X   $ HelpBtn��$|�False��#��[ $��0��$��40��$��40��
������ $��0q�$��Right=�$	��Top=�.��  $ QuestionCircle=�$ Solid=�# [ $��15��$��15��$��0 0 0 0q��� -Y   $ WindowMinimizeBtn��$|�False��#��[ $��1��$��40��$��40��
������ $��0q�$��Right=�$	��Top=�.��  $ WindowMinimize=�# [ $��15��$��15��$��0 10 0 0q��� -Z   $ WindowMaximize��$|�False��#��[ $��2��$��40��$��40��
������ $��0q�$��Right=�$	��Top=�.��  $ WindowMaximize=�# [ $��15��$��15��$��0 0 0 0q��� -[   $ WindowCloseBtn��$|�False��#��[ $��3��$��40��$��40��
������ $��0q�$��Right=�$	��Top=�.��  $ Xmark=�# [ $��15��$��15��$��0 0 0 0q��� -\   $ DataGridBorder��$��1��$��7��$��5��#���  $ 5��._��  �� $��5 ��� $��* ��� $��30 ��� $��5 � �� $��50 ��� $��* ��� $��5 �.+��� -]   , ��Name$, CategoriePanel��$��1��$ 
Horizontal=�$
��Left=�$��Center=�$��40��.+�	� -^   $( DataGridAllFilter��$��5 0 0 0q�  ButtonLikeRadioButtonStyle#��[ $��30��$
��auto��$��Center=�$��Center=�.���� $
��Alle��$2��,pack://application:,,,/assets/fonts/#Poppins)�  	white-140#��[ $��10(�$ 	15 5 15 5q�	� -_   $( DataGridGamesFilter��$��5 0 0 0q�#��[ $��30��$
��auto��$��Center=�$��Center=�.���� $��Spiele��$2��,pack://application:,,,/assets/fonts/#Poppins)�#��[ $��10(�$ 	15 5 15 5q�	� -`   $( DataGridSocialMediaFilter��$��5 0 0 0q�#��[ $��30��$
��auto��$��Center=�$��Center=�.���� $��Soziale Medien��$2��,pack://application:,,,/assets/fonts/#Poppins)�#��[ $��10(�$ 	15 5 15 5q�	� -a   $( DataGridStreamingFilter��$��5 0 0 0q�#��[ $��30��$
��auto��$��Center=�$��Center=�.���� $��	Streaming��$2��,pack://application:,,,/assets/fonts/#Poppins)�#��[ $��10(�$ 	15 5 15 5q�	� -b   $( DataGridShoppingFilter��$��5 0 0 0q�#��[ $��30��$
��auto��$��Center=�$��Center=�.���� $��Shopping��$2��,pack://application:,,,/assets/fonts/#Poppins)�#��[ $��10(�$ 	15 5 15 5q�	� -c   $( DataGridMoneyFilter��$��5 0 0 0q�#��[ $��30��$
��auto��$��Center=�$��Center=�.���� $��Finanzen��$2��,pack://application:,,,/assets/fonts/#Poppins)�#��[ $��10(�$ 	15 5 15 5q�	� -d   $( DataGridRestFilter��$��5 0 0 0q�#��[ $��30��$
��auto��$��Center=�$��Center=�.���� $��Sonstige��$2��,pack://application:,,,/assets/fonts/#Poppins)�#��[ $��10(�$ 	15 5 15 5q��� -e   $ DataGridOperations��$��1��$��2��$��0 0 5 0q�._��� $ 
Horizontal=�$��Right=�$��Center=�.+��� -f   $ SearchBoxBorder��$ Eintrag suchen��$��30��$��30��  gray-50#��[ # [ ._��� $ 
Horizontal=�$��Center=�$��Center=�.+��� -g   $ SearchBoxTxt��$��0��$��30��$��Center=�$
��Left=�
������ $��0q�  -h   $ SearchBoxIcon��$ Search=�# [ $��15��$��15��&   System.Windows.Controls.DataGrid  -i   -  Name$- Datagrid��  DataGridColumnHeaderStyle.   ColumnHeaderStyle#. �    DataGridRowStyle/   RowStyle#/ �    DataGridCellStyle0   	CellStyle#0 �  $��14(�$2��,pack://application:,,,/assets/fonts/#Poppins)�$��5q�$��0q�1   AutoGenerateColumns$1 False��2 �� AlternationCount$2 2��3   CanUserAddRows$3 False��4   CanUserDeleteRows$4 False��5   CanUserReorderColumns$5 False��6   CanUserResizeColumns$
6 True��7   CanUserResizeRows$7 False��8   CanUserSortColumns$
8 True��9   HeadersVisibility$9 Column=�:   SelectionMode$: Single=�;   SelectionUnit$; FullRow=�<   
IsReadOnly$
< True��=   HorizontalGridLinesBrush
= ���� >   VerticalGridLinesBrush
> ���� 
������ 
���   �?   RowHeaderWidth$? 0Q�"@   VerticalScrollBarVisibility$@ Disabled=�$A   HorizontalScrollBarVisibility$A Disabled=�B   GridLinesVisibility$B 
Horizontal=�C   MinRowHeight$C 35Q�D   EnableRowVirtualization$
D True��E   ColumnHeaderHeight$E 50Q�$��1��$��2��$��1��$��2��F   ColumnsF 4  .System.Windows.Controls.DataGridTemplateColumn  ,  &System.Windows.Controls.DataGridColumnG   Header$G 	Kategorie��H   
IsReadOnly$
H True��I   Width5  /System.Windows.Controls.DataGridLengthConverter$I * J   
Visibility$J 	Collapsed=�K   CellTemplateK �� .R��� $|�False��  	Btn-Trans#��[ $ Doppelklick zum Kopieren��$��30��$	��160��.���� $ 
Horizontal=�$��Center=�.+��� $
 True������ *AppTag+  $G 	Anwendung��L   SortMemberPath$L Application��$
H True��$	I 200 K �� .R��� -j   $|�False��#��[ $ Doppelklick zum Kopieren��$
��auto��$
��auto��.���� $ 
Horizontal=�.+�  $ EntryRowColor��$��	15 0 15 0q�$ Circle=�$��8��$��8��$ Solid=� �� *
AppColor+M �� 	Converter#M [  �� $
 True��$	��200��$
��auto��$
��Wrap=����� *Application+  $G Website��$
H True��$I * K �� .R��� -k   $|�False�� " Button.Trans.Over140.Pressed80#��[ $ Doppelklick zum Kopieren��$��30��$
��auto��.���� $��Center=�$��Center=�.+�  $
 Link=�$ Solid=�$��16��$��16��
 ������� $ False��$y�	Collapsed=����� *	AppLink+  $G Benutzername��$L AppUsername��$
H True��$I * K �� .R��� $ GridInfoCell��-l   $|�False��#��[ $ Doppelklick zum Kopieren��$
��auto��$
��auto��.���� $ 
Horizontal=�$��Center=�.+�  $
 User=�$ Solid=�$��16��$��16��
 ������� $ False��$	��130��$ 	10 0 10 0q�$
��Wrap=�$y�	Collapsed=����� *AppUsername+  $G Passwort��$
H True��$I * K �� .R��� -m   $|�False��#��[ $ Doppelklick zum Kopieren��$��30��$
��auto��.���� $ 
Horizontal=�$��Center=�.+�  $	 Key=�$��16��$��16��
 ������� $ False��$y�	Collapsed=����� *AppPassword+  $G E-Mail��$
H True��$I * K �� .R��� -n   $|�False��#��[ $ Doppelklick zum Kopieren��$��30��$
��auto��.���� $ 
Horizontal=�$��Center=�.+�  $ At=�$��16��$��16��
 ������� $ False��$y�	Collapsed=����� *
AppEmail+  $G E-Mail Passwort��$
H True��$I * K �� .R��� -o   $|�False��#��[ $ Doppelklick zum Kopieren��$��30��$
��auto��.���� $ 
Horizontal=�$��Center=�.+�  $	 Key=�$��16��$��16��
 ������� $ False��$y�	Collapsed=����� *AppEmailPassword+  $
G Info��$
H True��$I * K �� .R��� $ GridInfoCell��-p   $|�False��#��[ $
��auto��$
��auto�� �� *	AppInfo+.���� $ 
Horizontal=�$��Center=�.+�  $ ExclamationCircle=�$ Solid=�$��16��$��16��
 ������� $
 True��$	��130��$ 	10 0 10 0q�$
��Wrap=�$y�	Collapsed=����� *	AppInfo+  $G Dateien��$
H True��$I * K �� .R��� -q   $|�False��#��[ $ Doppelklick zum Kopieren��$��30��$
��auto��.���� $��Center=�$��Center=�.+�  $
 File=�$ Solid=�$��16��$��16��
 ������� $ False��$y�	Collapsed=����� *
AppFiles+  $G Optionen��$
H True��N   CanUserResize$N False��$I * K �� .R��� $ 
Horizontal=�$��Center=�.+��� -r   $ Eintrag bearbeiten��$|�False��$��5 0 0 0q�#��[ $��30��$��35��$y�Visible=�.��  $
 Gear=�$��16��$��16�� �	#FFBEDCBE�� $ 
CopyRowBtn��-s   $ Eintrag kopieren��$|�False��$��5 0 5 0q�#��[ $��30��$��35��$y�Visible=�.��  $ Share=�$��16��$��16��# [ �� -t   $ Eintrag löschen��$|�False��$��0 0 5 0q�#��[ $��30��$��35��$y�Visible=�.��  $ Trash=�$��16��$��16�� �	#FFDCBEBE�� -u   $ NotifyBorder��$ false��O J� Opacity$O 0Q�$ 5 5 5 5��$��1q����	#FF505050$	��300��$	��300�����	#FF1E1E1E$��0��$��20��$��0��$��20��$��Center=�$��Bottom=�$��0 0 0 0q�._��� $ Vertical=�.+��� $ 
Horizontal=�.+��� $��10 0 0 0q�$)��#/Assets/Icon/AccountManagerIcon.png��$��20��$��20���� -v   $ NotifyHeaderTxt��$ 10q�$��Benachrechtigung!��$
��Wrap=�$��Center=�$
��Left=�$2��,pack://application:,,,/assets/fonts/#Poppins)�$��14(�#��[ �� $��1��$	��280������ P �� EndPoint$P 0.0,1&�Q �� 
StartPoint$Q 1.0,0&�.��� R � Color$R Transparent��� $R Transparent��S � Offset$S 1Q�� $R 	Gainsboro��$	S 0.5Q��� -w   $ 	NotifyTxt��$ 10q�$\��VHallo, ich bin eine Benachrechtigung! Und ich muss dir was ganz ganz dringendes sagen!��$
��Wrap=�$��Center=�$
��Left=�$2��,pack://application:,,,/assets/fonts/#Poppins)�$��13(�#��[ �� -x   $ QuestBoxWindow��$
��Left=�$��0��$ False��$��5��$��3��$��1��# [ #���  ���	#FF646464$��0q�._��  �� $��10 ��� $��50 ��� $��* ��� $��10 � �� $��10 ��� $��50 ��� $��* ��� $��10 �.+�  -y   $ QuestBoxIcon��$��1��$��1��$ Warning=�$��40��$��40�� �	#FFBE8200$��Right=��� -z   $ QuestBoxQuest��$��2��$��1��$��Center=�$��Center=�#��[ $
��Wrap=�$��13(�$2��,pack://application:,,,/assets/fonts/#Poppins)��� $ 
Horizontal=�$��1��$��2��$��2��$��Bottom=�$��Center=�.+��� -{   $ ComfirmQuestBox��$|�False��$��0 0 20 0q�#��[ $��30��$	��110��T �� 	IsDefault$
T True��$y�Visible=�.��  $ CheckCircle=�$��20��$��20��
 � � ��� -|   $ CancelQuestBox��$|�False��$��20 0 0 0q�#��[ $��30��$	��110��$y�Visible=�.��  $ XmarkCircle=�$��20��$��20��
 �  ���� -}   $ 
AppVersion��$��0 0 5 0q�$��7��$��7��$��v1.0.1��#��[	 $��10(�$��Center=�$��Right=�