   M S B A M L   `   `   `  ����J  FAccount Manager, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:Account_Manager.ViewAccount_Manager.View  5   	       Account_Manager.View.Help   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   4local"clr-namespace:Account_Manager.View     5   	   X TFontAwesome.Sharp, Version=6.3.0.0, Culture=neutral, PublicKeyToken=d16d1e4e568ec10fFfa=http://schemas.awesome.incremented/wpf/xaml/fontawesome.sharp  5   	     � Title$  Hilfecenter��5	   	   
������  � AllowsTransparency$
 True��5   	    � WindowStyle$
 None=�5   	   $	��760��5   	   $	��520��5   	   $��10(�5   	   $	��760��5   	   $	��520��5   	   
������� � WindowStartupLocation$ CenterScreen=�5   	    � 
ResizeMode$ CanResizeWithGrip=�5   	    � Triggers 5      :� 5   
    :� RoutedEvent$ Loaded��6   .[�5      �� .��5      �� .��5      W�  �� TargetProperty$ Opacity�6&    W� From 06J   		 W� To	 16S   
 g� Duration$
 0:0:1D�6Z   5      5      5      .��5       �� -   5        ���	#F21E1E1E �� CornerRadius$ 10��5    $   $��1q�6g   ���	#FF3C3C3C._�5!   
   �  � ColumnDefinitions 5"      �� 5#      $��10 �6#   �� 5$      $	��160 �6#   �� 5%      $��10 �6#   �� 5&      $��* �6#   �� 5'      $��15 �6#   �� 5(      $��10 �6#    � RowDefinitions 5+      �� 5,      $��10 �6    �� 5-      $��15 �6    �� 5.      $��10 �6    �� 5/      $��* �6    �� 50      $��10 �6    .+�53      �� $��1��6   $��1��6)    �� Orientation$ 
Horizontal=�66   $
��Left=�6O   $��Center=�6j   .+�54      �� $��15��6   $��15��6$   $)��#/Assets/Icon/AccountManagerIcon.png��6/   $��0 0 5 0q�6\   �� 55      $��Hilfecenter��6   $��16(�6/   $��Center=�6=   56      �� 58      $��1��6   $��3��6%   $��1��62   $��1q�6C   
������� �� Padding$ 5q�6o   $ 5��6{   ._�59      �� $ Vertical=�6   .+�5:      �� -   5         ��Name$ Help_howSafe��5:   �   $��0 0 0 10q�6     � Cursor$
 Hand��62   
����  �$
��Wrap=�6R   $%��Wie sicher ist Account Manager?��6f   $��14(�6�   $��	Underline{�6�   6�   �� 5;      -   5        $ Help_addAccount��5;   �   $��0 0 0 10q�6    $
 Hand��62   
����  �$
��Wrap=�6R   $(��"Wie füge ich einen Account hinzu?��6f   $��14(�6�   $��	Underline{�6�   6�   �� 5<      -   5        $ Help_delAccount��5<   �   $��0 0 0 10q�6    $
 Hand��62   
����  �$
��Wrap=�6R   $$��Wie lösche ich einen Account?��6f   $��14(�6�   $��	Underline{�6�   6�   �� 5=      -   5        $ Help_sortAccount��5=   �   $��0 0 0 10q�6    $
 Hand��62   
����  �$
��Wrap=�6R   $0��*Wie kann ich angelegte Accounts sortieren?��6f   $��14(�6�   $��	Underline{�6�   6  �� 5>      -   5        $ Help_searchAccount��5>   �   $��0 0 0 10q�6    $
 Hand��62   
����  �$
��Wrap=�6R   $2��,Wie suche ich nach einem angelegten Account?��6f   $��14(�6�   $��	Underline{�6�   6  �� 5?      -   5        $ Help_editAccounts��5?   �   $��0 0 0 10q�6    $
 Hand��62   
����  �$
��Wrap=�6R   $2��,Wie bearbeite ich meine angelegten Accounts?��6f   $��14(�6�   $��	Underline{�6�   6	  �� 5@      -   5        $ Help_changeProfil��5@   �   $��0 0 0 10q�6    $
 Hand��62   
����  �$
��Wrap=�6R   $!��Wie wechsel ich mein Konto?��6f   $��14(�6�   $��	Underline{�6�   6�   �� 5A      -	   5        $ Help_showFiles��5A   �   $��0 0 0 10q�6    $
 Hand��62   
����  �$
��Wrap=�6R   $2��,Wie zeige ich meine angehängten Dateien an?��6f   $��14(�6�   $��	Underline{�6�   6  �� 5B      -
   5        $ Help_usePasswordGen��5B   �   $��0 0 0 10q�6    $
 Hand��62   
����  �$
��Wrap=�6R   $,��&Wie benutze ich den Passwortgenerator?��6f   $��14(�6�   $��	Underline{�6�   6  �� 5D      -   5        $ Help_profilImg��5D   �   $��0 0 0 10q�6    $
 Hand��62   
����  �$
��Wrap=�6R   $&�� Wie ändere ich mein Profilbild?��6f   $��14(�6�   $��	Underline{�6�   6�   �� 5E      -   5        $ Help_changeUserPassword��5E   �   $��0 0 0 10q�6    $
 Hand��62   
����  �$
��Wrap=�6R   $$��Wie ändere ich mein Passwort?��6f   $��14(�6�   $��	Underline{�6�   6  �� 5F      -   5        $ Help_resetUserPassword��5F   �   $��0 0 0 10q�6    $
 Hand��62   
����  �$
��Wrap=�6R   $*��$Wie setze ich mein Passwort zurück?��6f   $��14(�6�   $��	Underline{�6�   6
  �� 5G      -   5        $ Help_changeUserUsername��5G   �   $��0 0 0 10q�6    $
 Hand��62   
����  �$
��Wrap=�6R   $'��!Wie funktionieren die Kategorien?��6f   $��14(�6�   $��	Underline{�6�   6
  �� 5J      -   5        $ Help_changelog��5J   �   $��0 0 0 10q�6    $
 Hand��62   
����  �$
��Wrap=�6R   $��Versionsverlauf��6f   $��14(�6}   $��	Underline{�6�   6�   5K      5L      �� 5N      $��3��6   $��2��6%   $��3��69   $��1��6F   
�������$��1q�6o   $ 5��6�   ._�5O      �� .+�5P      �� -   5         ��Name$ Help_howSafe_text��5P      $y�	Collapsed=�68   ._�5Q      �� $ Vertical=�6%   .+�5R      �� $��16(�6(   $
��Bold"�66   $
��Wrap=�6H    �� Padding$ 10q�6\   !Wie sicher ist Account Manager?5T      �� 5U      $
��Wrap=�6(   $��14(�6<   $ 10q�6J   FDSobald du ein Passwort angelegt hast wird es SHA-256 verschlüsselt.�� 5V   e   �� 6q   ��SHA-256 ist eine kryptologische Hashfunktion, wobei SHA für „sicherer Hashalgorithmus“ (secure hash algorithm) und 256 für die Länge des Hashwerts in Bit steht. Kryptologische Hashfunktionen erzeugen irreversible, eindeutige Hashwerte.�� 5W     �� 6  usDurch diese verschlüsselung ist es ohne den passenden 'Key' nahezu unmöglich deine Passwörter zu entschlüsseln.�� 5X   �   �� 6�   ��Zudem werden deine angelegten Account-Informationen Lokal auf deinem Computer gespeichert, und sind somit sicher vor Serverseitigen Datenlecks.5Z      5[      5\      �� 5^      -   5        $ Help_addAccount_text��5^      $y�	Collapsed=�6;   ._�5_      �� $ Vertical=�6%   .+�5`      �� $��16(�6(   $
��Bold"�66   $
��Wrap=�6H   $ 10q�6\   $"Wie füge ich einen Account hinzu?5b      �� 5c   "   $
��Wrap=�6,   $ 10q�6@   $��14(�6M   NLUm einen Account hinzuzufügen drücke auf den Button mit dem Grünen Plus. �� 5e   "   $'��!/Assets/Img/help_addaccount_1.png��6(   $��Uniform=�6S   �� 6g   �� 6s   ��Es erscheinen Eingabefelder die du nun ausfüllen kannst. Leergelassene Felder werden automatisch durch "/" beim speichern ersetzt. �� 5g   "   $'��!/Assets/Img/help_addaccount_2.png��6(   $��Uniform=�6S   �� 6g   �� 6s   hfHier kannst du Dateien anhängen. Diese werden dann Kopiert und in deinem Account Manager hinterlegt. �� 5i   "   $'��!/Assets/Img/help_addaccount_3.png��6(   $��Uniform=�6S   �� 6g   �� 6s   =;Um deine Eingabe zu speichern drücke nun auf "Speichern". �� 5k   "   $'��!/Assets/Img/help_addaccount_4.png��6(   $��Uniform=�6S   �� 6g   �� 6s   :8Jetzt wird dein angelegter Account in der Liste anzeigt.5m      5n      5o      �� 5q      -   5        $ Help_delAccount_text��5q      $y�	Collapsed=�6;   ._�5r      �� $ Vertical=�6%   .+�5s      �� $��16(�6(   $
��Bold"�66   $
��Wrap=�6H   $ 10q�6\    Wie lösche ich einen Account?5u      �� 5v      $
��Wrap=�6(   $ 10q�6<   $��14(�6I   KIUm einen Account zu löschen drücke auf den Button mit dem Roten Minus. �� 5x   "   $'��!/Assets/Img/help_delaccount_1.png��6(   $��Uniform=�6S   �� 6g   �� 6s   ��Außerdem kannst du durch einen Rechtsklick auf einen Eintrag, ein Contextmenü öffnen. In dem du auch die Möglichkeit hast den Eintrag zu löschen oder zu bearbeiten. �� 5{   "   $'��!/Assets/Img/help_delaccount_2.png��6(   $��Uniform=�6S   �� 6g   �� 6s   ��Anschließend wirst du gefragt ob du sicher bist und diesen Eintrag löschen möchtest. Wenn du dies Bestätigst wird der Eintrag unwiederruflich gelöscht. �� 5~   "   $'��!/Assets/Img/help_delaccount_3.png��6(   $��Uniform=�6S   �� 6g   �� 6s   5      5�      5�      �� 5�      -   5        $ Help_sortAccount_text��5�      $y�	Collapsed=�6<   ._�5�      �� $ Vertical=�6%   .+�5�      �� $��16(�6(   $
��Bold"�66   $
��Wrap=�6H   $ 10q�6\   ,*Wie kann ich angelegte Accounts sortieren?5�      �� 5�      $
��Wrap=�6(   $ 10q�6<   $��14(�6I   _]Um deine Accounts in der Liste zu sortieren, drücke einfach auf die Überschrift der Spalte.�� 5�   }   20Die Einträge werden dann A-Z oder Z-A sortiert.�� 5�   Q   5�      5�      5�      �� 5�      -   5        $ Help_searchAccount_text��5�      $y�	Collapsed=�6>   ._�5�      �� $ Vertical=�6%   .+�5�      �� $��16(�6(   $
��Bold"�66   $
��Wrap=�6H   $ 10q�6\   .,Wie suche ich nach einem angelegten Account?5�      �� 5�      $
��Wrap=�6(   $ 10q�6<   $��14(�6I   PNUm nach einen Eintrag zu suchen kannst du auf den Button mir der Lupe klicken.�� 5�   p   RPEs wird sich ein Eingabefeld öffnen in dem du nach einem Eintrag suchen kannst.�� 5�   q   5�      5�      5�      �� 5�      -   5        $ Help_editAccounts_text��5�      $y�	Collapsed=�6=   ._�5�      �� $ Vertical=�6%   .+�5�      �� $��16(�6(   $
��Bold"�66   $
��Wrap=�6H   $ 10q�6\   .,Wie bearbeite ich meine angelegten Accounts?5�      �� 5�      $
��Wrap=�6(   $ 10q�6<   $��14(�6I   ��Um ein Eintrag zu bearbeiten kannst du mit einem Rechtsklick auf den Eintrag ein Contextmenü öffnen, wo du die Möglichkeit hast zwischen dem Bearbeiten und Löschen des Eintrags hast.�� 5�   s   5�      5�      5�      �� 5�      -   5        $ Help_changeProfil_text��5�      $y�	Collapsed=�6=   ._�5�      �� $ Vertical=�6%   .+�5�      �� $��16(�6(   $
��Bold"�66   $
��Wrap=�6H   $ 10q�6\   Wie wechsel ich mein Konto?5�      �� 5�   "   $
��Wrap=�6,   $ 10q�6@   $��14(�6M   ?=Um das Benutzerkonto zu wechseln klicke einfach auf Abmelden.�� 5�   c   ECDanach wirst du gebeten einen Benuternamen und Passwort einzugeben.5�      5�      5�      �� 5�      -   5        $ Help_showFiles_text��5�      $y�	Collapsed=�6:   ._�5�      �� $ Vertical=�6%   .+�5�      �� $��16(�6(   $
��Bold"�66   $
��Wrap=�6H   $ 10q�6\   -+Wie zeige ich meine angehängen Dateien an?5�      �� 5�      $
��Wrap=�6(   $ 10q�6<   $��14(�6I   hfUm deine angeängten Dateien anzuzeigen kannst du auf den Button mit dem Auge über der Liste klicken.�� 5�   �   ^\Dann erscheint eine neue Spalte in der Liste in der du einen Direktlink zu den Dateien hast.�� 5�   ~   5�      5�      5�      �� 5�      -   5        $ Help_usePasswordGen_text��5�      $y�	Collapsed=�6?   ._�5�      �� $ Vertical=�6%   .+�5�      �� $��16(�6(   $
��Bold"�66   $
��Wrap=�6H   $ 10q�6\   (&Wie benutze ich den Passwortgenerator?5�      �� 5�      $
��Wrap=�6(   $ 10q�6<   $��14(�6I   86Dazu kannst du auf den Button mit dem Schloss klicken.�� 5�   X   [YDanach kannst du eine Auswahl an Einstellungen vornehmen und dann auf Generieren klicken.�� 5�   {   DBNun sollte eine Benachrechtigung kommen in der du gesagt bekommst,�� 5�   d   20dass dein Passwort in deiner Zwischenablage ist.5�      5�      5�      �� 5�      -   5        $ Help_profilImg_text��5�      $y�	Collapsed=�6:   ._�5�      �� $ Vertical=�6%   .+�5�      �� $��16(�6(   $
��Bold"�66   $
��Wrap=�6H   $ 10q�6\   " Wie ändere ich mein Profilbild?5�      �� 5�      $
��Wrap=�6(   $ 10q�6<   $��14(�6I   PNUm dein Profilbild zu ändern kannst du auf dein Aktuelles Profilbild klicken.�� 5�   o   LJDann öffnet sich ein Fenster in dem du dein neues Bild auswählen kannst.�� 5�   j   5�      5�      5�      �� 5�      -   5        $" Help_changeUserPassword_text��5�      $y�	Collapsed=�6C   ._�5�      �� $ Vertical=�6%   .+�5�      �� $��16(�6(   $
��Bold"�66   $
��Wrap=�6H   $ 10q�6\   &$Wie setze ich mein Passwort zurück?5�      �� 5�      $
��Wrap=�6(   $ 10q�6<   $��14(�6I   dbUm dein Passwort zurückzusetzen musst du auf dem Login Fenster auf "Passwort vergessen?" klicken.�� 5�   �   ��Dann wirst du die Möglichkeit haben mit deinem Benutzernamen, E-Mail und die Antwort auf die Sicherheitsfrage dein Passwort zurückzusetzen.5�      5�      5�      �� 5�      -   5        $! Help_resetUserPassword_text��5�      $y�	Collapsed=�6B   ._�5�      �� $ Vertical=�6%   .+�5�      �� $��16(�6(   $
��Bold"�66   $
��Wrap=�6H   $ 10q�6\    Wie ändere ich mein Passwort?5�      �� 5�      $
��Wrap=�6(   $ 10q�6<   $��14(�6I   ��Um deine Benutzerdaten zu ändern klicke einfach auf das Symbol mit dem Menschen mit dem Zahnrad rechts neben dem Benutzerpanel.�� 5�   �   [YDort wirst du dann die Möglichkeit haben deine Benuterdaten zu ändern und zu Speichern.�� 5�   y   5�      5�      5�      �� 5�      -   5        $" Help_changeUserUsername_text��5�      $y�	Collapsed=�6C   ._�5�      �� $ Vertical=�6%   .+�5�      �� $��16(�6(   $
��Bold"�66   $
��Wrap=�6H   $ 10q�6\   #!Wie funktionieren die Kategorien?5�      �� 5�      $
��Wrap=�6(   $ 10q�6<   $��14(�6I   QOMit den Kategorien kannst du deinen angeleten Accounts eine Kategorie zuweisen.�� 5�   r   42Damit hast du es leichter sie schneller zu finden.�� 5�   U   [YDu kannst dann über der Tabelle auf die einzelnen Kategorien drücken um sie anzuzeigen.5�      5�      5�      �� 5�      -   5        $ Help_changelog_text��5�      $y�	Collapsed=�6:   ._�5      �� $ Vertical=�6%   .+�5     �� $��16(�6(   $
��Bold"�66   $
��Wrap=�6H   $ 10q�6\   Aktuelle änderungen5     �� 5     $
��Wrap=�6(   $ 10q�6<   $��14(�6I   =;Hier wirst du immer Aktuelle änderungen nachlesen können.�� 5  [   &$Oder du besuchst den Discord Server!5     5     5	     �� 5     -   5        $ Help_defaulttext��5     $y�Visible=�67   ._�5     �� $ Vertical=�6%   .+�5     �� $
��Wrap=�6(   $ 10q�6<   $��14(�6I   �� 5     $)��#/Assets/Icon/AccountManagerIcon.png��6$   $��80��6Q   $��80��6]   $��Uniform=�6h   �� 6|   Account Manager Hilfecenter�� 5  9   �� 6E   KINutze die Navigation auf der Linken seite um zu den Themen zu navigieren.�� 5  g   �� 6s   FDBei weiteren Fragen stehen wir dir gerne auf Discord zur Verfügung!�� 5  a   �� 6m   	Discord: �� 5  '   -   5        $#��https://discord.gg/nGR4aWucqz?�5  1   .�6�   Discord.gg/DezzyCode6�   5     5     5     5     5     �� 5     $��3��6   $��3��6&   $A��;DESIGN AND CODE BY DEZZYCODE (DENNY VIKIC) - COPYRIGHT 2024��66   $��8(�6y   ���	#FF292929$��Center=�6�   $��Bottom=�6�   $��0 0 0 10q�6�   !  FontAwesome.Sharp.IconImage  5     -    5        $��4��5     $
 Hand��6+   $��1��69   �  �FontAwesome.Sharp.IconImageBase`1[[FontAwesome.Sharp.IconChar, FontAwesome.Sharp, Version=6.3.0.0, Culture=neutral, PublicKeyToken=d16d1e4e568ec10f]]   Icon$ Xmark=�6F   $��15��6S   $��15��6_      
Foreground
 �����6�   5     5     5     