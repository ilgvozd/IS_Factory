   M S B A M L   `   `   `  ����B  >Factory, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:FactoryFactory  5   	       Factory.PageRecipient   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:Factory     5   	   -   5          � Title$+  %Страница кладовщика��5   	    � WindowStartupLocation$ CenterScreen=�5	   	   $	��450��5
   	   $	��800��6    � Icon$  /Resources/icon_clothe.ico��5   	   .��5      �� .@�5   
   �� $��Моя страница��6   .��5      � .+�5      �� -   5         ��Name$ image_myphoto��5      $	��200��5      $	��200��6"   $	��Top=�5      $
��Left=�5      $��	60,25,0,0q�5      $
��Fill=�5       � Cursor$
 Hand��5      $��/Resources/person.png��5      y�5      �� *
Visibility+ �� UpdateSourceTrigger$ PropertyChanged=�5      �� 5      $	��220��5      $	��500��6"   $��281,15,63,171q�5      .+�5      ��  �� Orientation$ 
Horizontal=�6!   .+�5       �� $��Фамилия:��5!      $
��Left=�5"      $��25��5#      $��70��6)   $��14(�5$      $
��Bold"�5%      �� 5&      -   5         ��Name$ label_surname��5'      $��30��5(      $	��300��6)   $��12(�5)      $	��Top=�5*      5+      �� 5,      $ 
Horizontal=�6!   .+�5-      �� $��Имя:��5.      $
��Left=�5/      $��25��50      $��35��6)   $��14(�51      $
��Bold"�52      �� 53      -   5        $ 
label_name��54      $��30��55      $	��300��6)   $��12(�56      $	��Top=�57      58      �� 59      $ 
Horizontal=�6!   .+�5:      �� $��Отчество:��5;      $
��Left=�5<      $��25��5=      $��70��6%   $��14(�5>      $
��Bold"�5?      �� 5@      -   5        $ label_patronymic��5A      $��30��5B      $	��300��6)   $��12(�5C      $	��Top=�5D      5E      �� 5F      $ 
Horizontal=�6!   .+�5G      �� $ ��Дата рождения:��5H      $
��Left=�5I      $��25��5J      $	��110��6%   $��14(�5K      $
��Bold"�5L      �� 5M      -   5        $ 
label_date��5N      $��30��5O      $	��300��6)   $��12(�5P      $	��Top=�5Q      5R      �� 5S      $ 
Horizontal=�6!   .+�5T      �� $"��Номер телефона:��5U      $
��Left=�5V      $��25��5W      $	��120��6%   $��14(�5X      $
��Bold"�5Y      �� 5Z      -   5        $ label_number��5[      $��30��5\      $	��300��6)   $��12(�5]      $	��Top=�5^      5_      �� 5`      $ 
Horizontal=�6!   .+�5a      �� $��Почта:��5b      $
��Left=�5c      $��25��5d      $��45��6%   $��14(�5e      $
��Bold"�5f      �� 5g      -   5        $ label_email��5h      $��30��5i      $	��300��6)   $��12(�5j      $	��Top=�5k      5l      �� 5m      $ 
Horizontal=�6!   .+�5n      �� $��Должность:��5o      $
��Left=�5p      $��25��5q      $��85��6%   $��14(�5r      $
��Bold"�5s      �� 5t      -	   5        $ 
label_post��5u      $��30��5v      $	��300��6)   $	��Top=�5w      $��12(�5x      5y      5z      �� 5{      -
   5        $ 
image_exit��5|      $	��100��5}      $	��100��6"   $��Bottom=�5~      $��Right=�5      $
��Fill=�5�      $
 Hand��5�      $��\Resources\exit.png��5�      y�5�      �� *
Visibility+$ PropertyChanged=�5�      5�      5�      �� 5�   
   $��Поступления��6   $��20��5�      $��90��6   $��Center=�5�      $��Right=�5�      .��5�      � $��
6,10,14,10q�6   .+�5�      &   System.Windows.Controls.DataGrid  -   5          Name$ 	dgReceipt��5�      	   AutoGenerateColumns	 .  
   
IsReadOnly
 . $��0,35,0,0q�5�      $	��Top=�5�      $
��Left=�5�      $	��200��5�      $
��auto��6)      Columns 5�      0  *System.Windows.Controls.DataGridTextColumn  5�      ,  &System.Windows.Controls.DataGridColumn   Header$ Id��6-   1  +System.Windows.Controls.DataGridBoundColumn   Binding 69   ��  �� Path$ 
id_receipt�  5�      $ Модель��6-    6=   �� $ Model_clothes.name_model�  5�      $ Принимающий��6-    5�      `� 5�   "    �� StringFormat$  {0} {1} {2}��6/   .1�5�   &   �� $ Employee.surname_employee�6.   �� 5�   &   $ Employee.name_employee�6.   �� 5�   &   $" Employee.patronymic_employee�6.   5�   #   5�        5�      $% Дата поступления��6-    6G   �� $ date_receipt�$ {0:dd.MM.yyyy}��  5�      $ Количество��6-    6A   �� $ amount�4  .System.Windows.Controls.DataGridTemplateColumn  5�         Width5  /System.Windows.Controls.DataGridLengthConverter$
 auto 61      CellTemplate 5�      �� 5�   "   .R�5�   &   ��  ��Name$ BtnEdit��5�   )   -   5        $ ��Редактировать��5�   )   $
��Left=�5�   )   $��35��5�   )   $��90��65   ���	#FF0ABABA
�������$��12(�5�   )      ButtonTemplateCircle#���   5�   )   5�   #   5�      5�      �� 5�      -   5        $ Btn_add��5�      $��Добавить��5�      $
��Left=�5�      $��
23,268,0,0q�5�      $	��Top=�5�      $��66��5�      $	��120��6%   ���	#FF07B124
�������$��14(�5�      #���   5�      �� 5�      -   5        $ 
Btn_delete��5�      $��Удалить��5�      $
��Left=�5�      $��160,268,0,0q�5�      $	��Top=�5�      $��66��5�      $	��120��6%   
����������	#FFED0E0E$��14(�5�      #���   5�      �� 5�      -   5        $ img_refresh��5�      $��30��5�      $��30��6!   $
��Fill=�5�      $
 Hand��5�      $��/Resources/refreshBtn.png��5�      $	��Top=�5�      $��Right=�5�      $��0,0,10,0q�5�      y�5�      �� *
Visibility+$ PropertyChanged=�5�      5�      5�      �� 5�   
   $��Модели��6   $��20��5�      $��90��6   $��Center=�5�      $��Right=�5�      .��5�      � $��
6,10,14,10q�6   .+�5�        -   5        $ dgModel_clothes��5�      	 .  
 . $��
0,35,0,150q�5�      $
��Left=�5�       5�        5�      $ Id��6-    69   �� $ id_model�  5�      $ 
Товар��6-    6<   �� $ Type_product.name_product�  5�      $# Название модели��6-    6F   �� $ 
name_model�  5�      $ Цена��6-    6;   �� $ price_model�  5�      $
 auto 61    5�      �� 5�   "   .R�5�   &   �� $ BtnEdit��5�   )   -   5        $ ��Редактировать��5�   )   $
��Left=�5�   )   $��35��5�   )   $��90��65   ���	#FF0ABABA
�������$��12(�5�   )   #���   5�   )   5�   #   5�      5�      �� 5�      -   5        $ Btn_add_model��5�      $��Добавить��5�      $
��Left=�5�      $��
23,268,0,0q�5�      $	��Top=�5�      $��66��5�      $	��120��6%   ���	#FF07B124
�������$��14(�5     #���   5     �� 5     -   5        $ Btn_delete_model��5     $��Удалить��5     $
��Left=�5     $��160,268,0,0q�5     $	��Top=�5     $��66��5	     $	��120��6%   
����������	#FFED0E0E$��14(�5     #���   5     �� 5     -   5        $ img_refresh_model��5     $��30��5     $��30��6!   $
��Fill=�5     $
 Hand��5     $��/Resources/refreshBtn.png��5     $	��Top=�5     $��Right=�5     $��0,0,10,0q�5     y�5     �� *
Visibility+$ PropertyChanged=�5     5     5     5     5     