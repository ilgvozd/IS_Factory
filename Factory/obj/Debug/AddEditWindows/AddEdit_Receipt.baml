   M S B A M L   `   `   `  ����B  >Factory, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:FactoryFactory  5   	       Factory.AddEdit_Receipt   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:Factory     5   	   -   5          �Name$  addEditReceipt��5	   	    � Title$ AddEdit_Receipt��5   	   $	��308��5
   	   $	��550��6    � WindowStartupLocation$ CenterScreen=�5   	    � Icon$  /Resources/icon_clothe.ico��5   	   .��5      � $	��250��6   $	��500��6   .+�5   
   �� $	��162��6   $	��500��6"   $
��Left=�5      $��Center=�5      .+�5      ��  �� Orientation$ 
Horizontal=�6   .+�5      �� $��Модель:��5      $��25��5      $	��130��6!   $��14(�5      $
��Bold"�5      �� 5      -   5         ��Name$ 
cBox_model��5      $��25��5      $	��290��6!    �� SelectedValuePath$ id_model��5      $��Center=�5      $��12(�5      $��5,0,0,0q�5       �� SelectedValue 5      �� *
id_model+��5      �� 5       .R�5!      �� ��6(   �� *
name_model+5"      5$      5%      �� 5&   
   $ 
Horizontal=�6   .+�5'      �� $��Принимающий:��5(      $
��Left=�5)      $��25��5*      $	��130��6!   $��14(�5+      $
��Bold"�5,      �� 5-      -   5        $ cBox_employee��5.      $��25��5/      $	��290��6!   $��Center=�50      $ id_employee��52      $��12(�53      $��5,0,0,0q�54       51      �� *id_employee+��55      �� 56      .R�57      �� ��58   "   `� 59   &    �� StringFormat$  {0} {1} {2}��63   .1�5:   *   �� 	 �� Path$	 surname_employee�62   �� 5;   *   $	 name_employee�62   �� 5<   *   $	 patronymic_employee�62   5=   '   5?      5@      5B      5C      �� 5D   
   $ 
Horizontal=�6   .+�5E      �� $&�� Дата поступления:��5F      $��25��5G      $	��135��6!   $��14(�5H      $
��Bold"�5I      (  "System.Windows.Controls.DatePicker  5J      -   5        
  Name$
 dP_date��5K      $��25��5M      $	��290��6!   $��Center=�5N      $��12(�5O      |�.     SelectedDate 5L      �� *date_receipt+ � 	Resources 5Q      :  4System.Windows.Controls.Primitives.DatePickerTextBox �� 
TargetType��%E   '        �� 5R      "  6   .�5S      -   5        5U      5V      5W      5X      �� 5Y   
   $ 
Horizontal=�6   .+�5Z      �� $��Количество:��5[      $
��Left=�5\      $��25��5]      $	��130��6!   $��14(�5^      $
��Bold"�5_      �� 5`      -   5         ��Name$ tbox_amount��5a      $��25��5c      $	��290��6!   $��Center=�5d      $��12(�5e      $��5,0,0,0q�5f      ��5b      �� *amount+5g      5h      5i      �� 5j   
   -   5         ��Name$ Btn_save��5k         ButtonTemplateCircle#���   5l      $��Сохранить��5m      $��Center=�5n      $��Bottom=�5o      $��0,0,0,0q�5p      $��44��5q      $	��200��6   
����������	#FF0FC61A$��16(�5t      5u      5v      5w      