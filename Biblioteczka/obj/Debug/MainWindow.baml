   M S B A M L   `   `   `  ����G  CBiblioteczka, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:BiblioteczkaBiblioteczka  5   	       Biblioteczka.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:Biblioteczka     5   	   -   5        $��Window��5
        � 
ResizeMode$  NoResize=�5   	    � Title$ Biblioteczka��5
   	   $	��450��6,   $	��830��69   .��5      � .+�5   
   ��  �� Orientation$ Vertical=�6   $
��Left=�6,   $	��400��6G   $��	10,10,0,0q�6T   $	��Top=�6g   $	��220��6   ���	#FF9CD8F3.+�5      �� $��15(�6   $��Dodaj nową pozycję��6"   $
��Bold"�6?   $��5q�6Q   �� 5      $ 
Horizontal=�6   $��2q�62   $��Stretch=�6=   .+�5      �� $��Autor��6   $��55��6(   �� 5      -   5         ��Name$ authorTextBox��5      
�������$	��160��6D   $��Right=�6P   5      �� 5      $ 
Horizontal=�6   $��2q�62   $��Stretch=�6=   .+�5      �� $��Tytuł��6   $��55��6(   �� 5      -   5        $ tittleTextBox��5      
�������$	��160��6D   $��Right=�6P   5      �� 5      $ 
Horizontal=�6   $��2q�62   $��Stretch=�6=   .+�5      �� $��Gatunek��6   $��55��6*   �� 5      -   5         ��Name$ genreComboBox��5      
�������$	��160��6E   $��Right=�6Q   .@�5      �� $��Fantasy��6#   �� 5      $��Młodzieżowe��6#   �� 5      $��	Kryminał��6#   �� 5      $��Samorozwój��6#   �� 5      $��Si-Fi��6#   �� 5       $
��Inne��6#   5!      5"      �� 5#      $ 
Horizontal=�6   $��5q�62   $��Center=�6=   .+�5$      �� -   5         ��Name$ haveCheckBox��5$      $	��Mam��61   $��Center=�6?   
�������$	��140��6t   $��20��6�   $��Center=�6�   5%      �� 5&      $ 
Horizontal=�6   $��5q�62   $��Center=�6=   .+�5'      �� -   5        $ wantReadCheckBox��5'      $��Chcę przeczytać��65   $��Center=�6O   $	��140��6q   $��20��6}   $��Center=�6�   5(      �� 5)      $ 
Horizontal=�6   $��0,10,0,0q�62   .+�5*      �� -   5         ��Name$ 	addButton��5*      $��13(�6,   $	��100��6:   $��25��6F   $��5q�6R   $��Dodaj��6]   6m   �� 5+      -   5        $ 
editButton��5+      $��13(�6-   $	��100��6;   $��25��6G   $��5q�6S   $��Edytuj��6^   6o   5,      �� 5-      -	   5        $ deleteButton��5-      $��13(�6+   $	��100��69   $��25��6E   $
��60,5q�6Q   $��Usuń��6_   ���	#FFE24E4E6�   5.      &   System.Windows.Controls.DataGrid  5/   
   -
   5          Name$ booksDataGrid��5/      $
��Left=�6\   $	��365��6w   $��
235,45,0,0q�6�   $	��Top=�6�   $	��579��6�   ���	#FF9CD8F350      �� 51   
   $ 
Horizontal=�6   $
��Left=�6.   $��30��6I   $��
235,10,0,0q�6U   $	��Top=�6i   $	��579��6�   ���	#FF9CD8F3.+�52      �� $��3q�6   $��Wyszukiwanie��6   �� 53      -   5        $ keyComboBox��53      $��3q�6,   $	��120��68   �� 54      -   5        $ searchTextBox��54      $��3q�6-   $	��150��68   
�������6W   �� 55      -   5        $ showAllButton��55      $��	0,3,3,3.4q�6,   $��Pokaż wszystkie��6?   $	��100��6Y   6e   56      58      59      