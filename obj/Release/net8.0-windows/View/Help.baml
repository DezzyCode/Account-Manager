   M S B A M L   `   `   `  ���� J  FAccount Manager, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:Account_Manager.ViewAccount_Manager.View      Account_Manager.View.Help   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     4local"clr-namespace:Account_Manager.View     X TFontAwesome.Sharp, Version=6.3.0.0, Culture=neutral, PublicKeyToken=d16d1e4e568ec10fFfa=http://schemas.awesome.incremented/wpf/xaml/fontawesome.sharp    � Title$  Hilfecenter��
������  � AllowsTransparency$
 True�� � WindowStyle$
 None=�$	��760��$	��520��$��10(�$	��760��$	��520��
������� � WindowStartupLocation$ CenterScreen=� � 
ResizeMode$ CanResizeWithGrip=� � Triggers :�  :� RoutedEvent$ Loaded��.[��� .���� .��W�  �� TargetProperty$ Opacity� W� From 0		 W� To	 1
 g� Duration$
 0:0:1D�.���� -   ���	#F21E1E1E �� CornerRadius$ 10��$��1q����	#FF3C3C3C._��  � ColumnDefinitions �� $��10 ��� $	��160 ��� $��10 ��� $��* ��� $��15 ��� $��10 � � RowDefinitions �� $��10 ��� $��15 ��� $��10 ��� $��* ��� $��10 �.+��� $��1��$��1�� �� Orientation$ 
Horizontal=�$
��Left=�$��Center=�.+��� $��15��$��15��$)��#/Assets/Icon/AccountManagerIcon.png��$��0 0 5 0q��� $��Hilfecenter��$��16(�$��Center=��� $��1��$��3��$��1��$��1q�
������� �� Padding$ 5q�$ 5��._��� $ Vertical=�.+��� -    ��Name$ Help_howSafe��$��0 0 0 10q� � Cursor$
 Hand��
����  �$
��Wrap=�$%��Wie sicher ist Account Manager?��$��14(�$��	Underline{��� -   $ Help_addAccount��$��0 0 0 10q�$
 Hand��
����  �$
��Wrap=�$(��"Wie füge ich einen Account hinzu?��$��14(�$��	Underline{��� -   $ Help_delAccount��$��0 0 0 10q�$
 Hand��
����  �$
��Wrap=�$$��Wie lösche ich einen Account?��$��14(�$��	Underline{��� -   $ Help_sortAccount��$��0 0 0 10q�$
 Hand��
����  �$
��Wrap=�$0��*Wie kann ich angelegte Accounts sortieren?��$��14(�$��	Underline{��� -   $ Help_searchAccount��$��0 0 0 10q�$
 Hand��
����  �$
��Wrap=�$2��,Wie suche ich nach einem angelegten Account?��$��14(�$��	Underline{��� -   $ Help_editAccounts��$��0 0 0 10q�$
 Hand��
����  �$
��Wrap=�$2��,Wie bearbeite ich meine angelegten Accounts?��$��14(�$��	Underline{��� -   $ Help_changeProfil��$��0 0 0 10q�$
 Hand��
����  �$
��Wrap=�$!��Wie wechsel ich mein Konto?��$��14(�$��	Underline{��� -	   $ Help_showFiles��$��0 0 0 10q�$
 Hand��
����  �$
��Wrap=�$2��,Wie zeige ich meine angehängten Dateien an?��$��14(�$��	Underline{��� -
   $ Help_usePasswordGen��$��0 0 0 10q�$
 Hand��
����  �$
��Wrap=�$,��&Wie benutze ich den Passwortgenerator?��$��14(�$��	Underline{��� -   $ Help_profilImg��$��0 0 0 10q�$
 Hand��
����  �$
��Wrap=�$&�� Wie ändere ich mein Profilbild?��$��14(�$��	Underline{��� -   $ Help_changeUserPassword��$��0 0 0 10q�$
 Hand��
����  �$
��Wrap=�$$��Wie ändere ich mein Passwort?��$��14(�$��	Underline{��� -   $ Help_resetUserPassword��$��0 0 0 10q�$
 Hand��
����  �$
��Wrap=�$*��$Wie setze ich mein Passwort zurück?��$��14(�$��	Underline{��� -   $ Help_changeUserUsername��$��0 0 0 10q�$
 Hand��
����  �$
��Wrap=�$'��!Wie funktionieren die Kategorien?��$��14(�$��	Underline{��� -   $ Help_changelog��$��0 0 0 10q�$
 Hand��
����  �$
��Wrap=�$��Versionsverlauf��$��14(�$��	Underline{��� $��3��$��2��$��3��$��1��
�������$��1q�$ 5��._��� .+��� -    ��Name$ Help_howSafe_text��$y�	Collapsed=�._��� $ Vertical=�.+��� $��16(�$
��Bold"�$
��Wrap=� �� Padding$ 10q�!Wie sicher ist Account Manager?�� $
��Wrap=�$��14(�$ 10q�FDSobald du ein Passwort angelegt hast wird es SHA-256 verschlüsselt.�� �� ��SHA-256 ist eine kryptologische Hashfunktion, wobei SHA für „sicherer Hashalgorithmus“ (secure hash algorithm) und 256 für die Länge des Hashwerts in Bit steht. Kryptologische Hashfunktionen erzeugen irreversible, eindeutige Hashwerte.�� �� usDurch diese verschlüsselung ist es ohne den passenden 'Key' nahezu unmöglich deine Passwörter zu entschlüsseln.�� �� ��Zudem werden deine angelegten Account-Informationen Lokal auf deinem Computer gespeichert, und sind somit sicher vor Serverseitigen Datenlecks.�� -   $ Help_addAccount_text��$y�	Collapsed=�._��� $ Vertical=�.+��� $��16(�$
��Bold"�$
��Wrap=�$ 10q�$"Wie füge ich einen Account hinzu?�� $
��Wrap=�$ 10q�$��14(�NLUm einen Account hinzuzufügen drücke auf den Button mit dem Grünen Plus. �� $'��!/Assets/Img/help_addaccount_1.png��$��Uniform=��� �� ��Es erscheinen Eingabefelder die du nun ausfüllen kannst. Leergelassene Felder werden automatisch durch "/" beim speichern ersetzt. �� $'��!/Assets/Img/help_addaccount_2.png��$��Uniform=��� �� hfHier kannst du Dateien anhängen. Diese werden dann Kopiert und in deinem Account Manager hinterlegt. �� $'��!/Assets/Img/help_addaccount_3.png��$��Uniform=��� �� =;Um deine Eingabe zu speichern drücke nun auf "Speichern". �� $'��!/Assets/Img/help_addaccount_4.png��$��Uniform=��� �� :8Jetzt wird dein angelegter Account in der Liste anzeigt.�� -   $ Help_delAccount_text��$y�	Collapsed=�._��� $ Vertical=�.+��� $��16(�$
��Bold"�$
��Wrap=�$ 10q� Wie lösche ich einen Account?�� $
��Wrap=�$ 10q�$��14(�KIUm einen Account zu löschen drücke auf den Button mit dem Roten Minus. �� $'��!/Assets/Img/help_delaccount_1.png��$��Uniform=��� �� ��Außerdem kannst du durch einen Rechtsklick auf einen Eintrag, ein Contextmenü öffnen. In dem du auch die Möglichkeit hast den Eintrag zu löschen oder zu bearbeiten. �� $'��!/Assets/Img/help_delaccount_2.png��$��Uniform=��� �� ��Anschließend wirst du gefragt ob du sicher bist und diesen Eintrag löschen möchtest. Wenn du dies Bestätigst wird der Eintrag unwiederruflich gelöscht. �� $'��!/Assets/Img/help_delaccount_3.png��$��Uniform=��� �� �� -   $ Help_sortAccount_text��$y�	Collapsed=�._��� $ Vertical=�.+��� $��16(�$
��Bold"�$
��Wrap=�$ 10q�,*Wie kann ich angelegte Accounts sortieren?�� $
��Wrap=�$ 10q�$��14(�_]Um deine Accounts in der Liste zu sortieren, drücke einfach auf die Überschrift der Spalte.�� 20Die Einträge werden dann A-Z oder Z-A sortiert.�� �� -   $ Help_searchAccount_text��$y�	Collapsed=�._��� $ Vertical=�.+��� $��16(�$
��Bold"�$
��Wrap=�$ 10q�.,Wie suche ich nach einem angelegten Account?�� $
��Wrap=�$ 10q�$��14(�PNUm nach einen Eintrag zu suchen kannst du auf den Button mir der Lupe klicken.�� RPEs wird sich ein Eingabefeld öffnen in dem du nach einem Eintrag suchen kannst.�� �� -   $ Help_editAccounts_text��$y�	Collapsed=�._��� $ Vertical=�.+��� $��16(�$
��Bold"�$
��Wrap=�$ 10q�.,Wie bearbeite ich meine angelegten Accounts?�� $
��Wrap=�$ 10q�$��14(���Um ein Eintrag zu bearbeiten kannst du mit einem Rechtsklick auf den Eintrag ein Contextmenü öffnen, wo du die Möglichkeit hast zwischen dem Bearbeiten und Löschen des Eintrags hast.�� �� -   $ Help_changeProfil_text��$y�	Collapsed=�._��� $ Vertical=�.+��� $��16(�$
��Bold"�$
��Wrap=�$ 10q�Wie wechsel ich mein Konto?�� $
��Wrap=�$ 10q�$��14(�?=Um das Benutzerkonto zu wechseln klicke einfach auf Abmelden.�� ECDanach wirst du gebeten einen Benuternamen und Passwort einzugeben.�� -   $ Help_showFiles_text��$y�	Collapsed=�._��� $ Vertical=�.+��� $��16(�$
��Bold"�$
��Wrap=�$ 10q�-+Wie zeige ich meine angehängen Dateien an?�� $
��Wrap=�$ 10q�$��14(�hfUm deine angeängten Dateien anzuzeigen kannst du auf den Button mit dem Auge über der Liste klicken.�� ^\Dann erscheint eine neue Spalte in der Liste in der du einen Direktlink zu den Dateien hast.�� �� -   $ Help_usePasswordGen_text��$y�	Collapsed=�._��� $ Vertical=�.+��� $��16(�$
��Bold"�$
��Wrap=�$ 10q�(&Wie benutze ich den Passwortgenerator?�� $
��Wrap=�$ 10q�$��14(�86Dazu kannst du auf den Button mit dem Schloss klicken.�� [YDanach kannst du eine Auswahl an Einstellungen vornehmen und dann auf Generieren klicken.�� DBNun sollte eine Benachrechtigung kommen in der du gesagt bekommst,�� 20dass dein Passwort in deiner Zwischenablage ist.�� -   $ Help_profilImg_text��$y�	Collapsed=�._��� $ Vertical=�.+��� $��16(�$
��Bold"�$
��Wrap=�$ 10q�" Wie ändere ich mein Profilbild?�� $
��Wrap=�$ 10q�$��14(�PNUm dein Profilbild zu ändern kannst du auf dein Aktuelles Profilbild klicken.�� LJDann öffnet sich ein Fenster in dem du dein neues Bild auswählen kannst.�� �� -   $" Help_changeUserPassword_text��$y�	Collapsed=�._��� $ Vertical=�.+��� $��16(�$
��Bold"�$
��Wrap=�$ 10q�&$Wie setze ich mein Passwort zurück?�� $
��Wrap=�$ 10q�$��14(�dbUm dein Passwort zurückzusetzen musst du auf dem Login Fenster auf "Passwort vergessen?" klicken.�� ��Dann wirst du die Möglichkeit haben mit deinem Benutzernamen, E-Mail und die Antwort auf die Sicherheitsfrage dein Passwort zurückzusetzen.�� -   $! Help_resetUserPassword_text��$y�	Collapsed=�._��� $ Vertical=�.+��� $��16(�$
��Bold"�$
��Wrap=�$ 10q� Wie ändere ich mein Passwort?�� $
��Wrap=�$ 10q�$��14(���Um deine Benutzerdaten zu ändern klicke einfach auf das Symbol mit dem Menschen mit dem Zahnrad rechts neben dem Benutzerpanel.�� [YDort wirst du dann die Möglichkeit haben deine Benuterdaten zu ändern und zu Speichern.�� �� -   $" Help_changeUserUsername_text��$y�	Collapsed=�._��� $ Vertical=�.+��� $��16(�$
��Bold"�$
��Wrap=�$ 10q�#!Wie funktionieren die Kategorien?�� $
��Wrap=�$ 10q�$��14(�QOMit den Kategorien kannst du deinen angeleten Accounts eine Kategorie zuweisen.�� 42Damit hast du es leichter sie schneller zu finden.�� [YDu kannst dann über der Tabelle auf die einzelnen Kategorien drücken um sie anzuzeigen.�� -   $ Help_changelog_text��$y�	Collapsed=�._��� $ Vertical=�.+��� $��16(�$
��Bold"�$
��Wrap=�$ 10q�Aktuelle änderungen�� $
��Wrap=�$ 10q�$��14(�=;Hier wirst du immer Aktuelle änderungen nachlesen können.�� &$Oder du besuchst den Discord Server!�� -   $ Help_defaulttext��$y�Visible=�._��� $ Vertical=�.+��� $
��Wrap=�$ 10q�$��14(��� $)��#/Assets/Icon/AccountManagerIcon.png��$��80��$��80��$��Uniform=��� Account Manager Hilfecenter�� �� KINutze die Navigation auf der Linken seite um zu den Themen zu navigieren.�� �� FDBei weiteren Fragen stehen wir dir gerne auf Discord zur Verfügung!�� �� 	Discord: �� -   $#��https://discord.gg/nGR4aWucqz?�.�Discord.gg/DezzyCode�� $��3��$��3��$A��;DESIGN AND CODE BY DEZZYCODE (DENNY VIKIC) - COPYRIGHT 2024��$��8(����	#FF292929$��Center=�$��Bottom=�$��0 0 0 10q�!  FontAwesome.Sharp.IconImage  -    $��4��$
 Hand��$��1���  �FontAwesome.Sharp.IconImageBase`1[[FontAwesome.Sharp.IconChar, FontAwesome.Sharp, Version=6.3.0.0, Culture=neutral, PublicKeyToken=d16d1e4e568ec10f]]   Icon$ Xmark=�$��15��$��15��   
Foreground
 �����