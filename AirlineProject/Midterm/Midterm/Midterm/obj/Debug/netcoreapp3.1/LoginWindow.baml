   M S B A M L   `   `   `  ����B  >Midterm, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:MidtermMidterm  5   	       Midterm.LoginWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:Midterm     5   	     � Title$  Login��5   	   $	��300��6   $	��450��6$    � WindowStyle$ ThreeDBorderWindow=�60   
�������$��Center=�6j   $��Center=�6�    � WindowStartupLocation$ CenterScreen=�6�    � 
ResizeMode$ NoResize=�6�   .��5	      � 4  .System.Windows.Automation.AutomationProperties   HelpText$ 
Login here��6   $��Center=�66   $	��450��6S   $	��266��6_   $��Bottom=�6l   $��0,0,0,9q�6�    � RowDefinitions 5
   
   �� 5      �� 5       � ColumnDefinitions 5   
   �� 5      $
��112* �6   �� 5      $
��223* �6   ��5   
   �� 5       �� EndPoint$ 0.5,1&�6"    �� 
StartPoint$ 0.5,0&�63   .��5      � 	 � Color$	 
LightCoral��6   � 5      
 � Offset$
 1Q�6   5      .+�5   
   �� -   5         ��Name$ labelUsername��5      $��	Username:��6'   $��Center=�6;   $��Stretch=�6W   $��Right=�6z   $��19(�6�   $��30��6�   $
��Bold"�6�   $��Stretch=�6�   $��0,10,5,0q�6�   �� 5   
   -   5        $ labelPassword��5      $��	Password:��6'   $	��Top=�6;   $��19(�6S   $
��Bold"�6a   $��Stretch=�6s   $��48��6�   $	��104��6�   $��1��6�   $��Stretch=�6�   $��Right=�6�   $��0,0,10,0q�6�   �� 5   
   -   5         ��Name$ 
txtboxUser��5       �� TextWrapping$
 Wrap=�6&   $��1��6:   $��16(�6J   $��26��6X   $��	1,10,20,0q�6d   $��Stretch=�6w    �� 	UndoLimit$ 98��6�   $��Center=�6�   G� 5   
   -   5         G�Name$ textboxPass��5      $��1��6+   $��1��6;   $��	1,10,20,0q�6H   $	��Top=�6[   $��16(�6s   $��26��6�   �� 5   
   -   5         ��Name$ loginBtn��5      $��1��6#   $��Login��60   $	��Top=�6X   $��16(�6p   $��27��6~   $��78��6�   $
��Left=�6�   $��
109,81,0,0q�6�   $��2��6�   �� 5   
   -   5        $ clearBtn��5      $��1��6#   $��1��63   $��Clear��6@   $��	0,81,0,25q�6P   $��77��6c   $��Center=�6n   $��16(�6�   $��27��6�   5      5      