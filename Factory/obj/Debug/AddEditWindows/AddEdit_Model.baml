   M S B A M L   `   `   `  ����B  >Factory, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:FactoryFactory  5   	       Factory.AddEdit_Model   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:Factory     5   	   -   5          �Name$  addEditModel��5	   	    � Title$ AddEdit_Model��5   	   $	��300��5
   	   $	��450��6    � WindowStartupLocation$ CenterScreen=�5   	    � Icon$  /Resources/icon_clothe.ico��5   	   .��5      � $	��250��6   $	��450��6   .+�5   
   �� $��80��6   $	��425��6!   $��Center=�5      $��Center=�5      .+�5      ��  �� Orientation$ 
Horizontal=�6   .+�5      �� $��Товар:��5      $��25��5      $	��130��6!   $��14(�5      $
��Bold"�5      �� 5      -   5         ��Name$ cBox_product��5      $��25��5      $	��290��6!   $��Center=�5       �� SelectedValuePath$ 
id_product��5      $��12(�5      $��5,0,0,0q�5       �� SelectedValue 5      �� *
id_product+��5      �� 5       .R�5!      �� ��6(   �� *name_product+5"      5$      5%      �� 5&      $ 
Horizontal=�6   .+�5'      �� $$��Название модели:��5(      $
��Left=�5)      $��25��5*      $	��130��6!   $��14(�5+      $
��Bold"�5,      �� 5-      -   5         ��Name$ tbox_nameModel��5.      $��25��50      $	��290��6!   $��Center=�51      $��12(�52      $��5,0,0,0q�53      ��5/      �� *
name_model+53      54      �� 55      $ 
Horizontal=�6   .+�56      �� $��	Цена:��57      $
��Left=�58      $��25��59      $	��130��6!   $��14(�5:      $
��Bold"�5;      �� 5<      -   5        $ 
tbox_price��5=      $��25��5?      $	��290��6!   $��Center=�5@      $��12(�5A      $��5,0,0,0q�5B      ��5>      �� *price_model+5B      5C      5D      �� 5E   
   -   5        	 ��Name$	 Btn_save��5F         ButtonTemplateCircle#���   5G      $��Сохранить��5H      $��Center=�5I      $��Bottom=�5J      $��0,0,0,0q�5K      $��44��5L      $	��200��6   
����������	#FF0FC61A$��16(�5O      5P      5Q      5R      