   M S B A M L   `   `   `  ����B  >Midterm, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:MidtermMidterm  5   	       Midterm.OptionsWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:Midterm     5   	   -   5          � Title$  HomePage��5      $	��400��6   $��Center=�6    $��Center=�6;   $��14(�6�    � WindowStyle$ ThreeDBorderWindow=�6�   
���iii�$	��624��6�    � 	Resources 5	         OptionsMenu �� 
TargetType �� Triggers P� Property P� Value �� Property �� Value��%  &	        �� 5
   
   " m�6$    5      P� 5       �@J�IsMouseOver$
 True��61   . �5      ��  � ��
 �OO/�6K   5      P� 5       �@J�IsMouseOver$ False��61   . �5      ��  � ��
 �����6D   5      5      5      	 � ContextMenu	 5      �� 5   
   .@�5      m� -   5        $��	insertItm��5   '   $��Insert��6   ${�False��68   6L   m� 5      -   5        $��	updateItm��5   '   $��Update��6   ${�False��68   6L   m� 5      -   5        $��	deleteItm��5   '   $��Delete��6   ${�False��68   6L   5      .��5      � .+�5   
   ]� $��Stretch=�6   $	��Top=�62   .+�5   
   o� -   5        
 o�Name$
 MenuMain��5      $
��Left=�6!   $
��Left=�6C   $	��Top=�6Y   $��23��6q   $��Stretch=�6}   $��14(�6�   
���   ����	#FFFFFDFD$
}�True��6�    J� SnapsToDevicePixels$
 True��6�   4  .System.Windows.Automation.AutomationProperties   IsOffscreenBehavior$ Onscreen=�6   J� OpacityMask �	#FFA7A7A7.@�5      m� -   5         m�Name$ MenuFile��5      $��_File��6)   $��Center=�68   $��Bottom=�6U   $��10,0,8,0q�6p   
���   �
���   �$��1,1,1,1q�6�   .@�5       m� -   5        $ MenuNew��5       $
��_New��60   
���   �
���   �
�������$y�Visible=�6x   m� 5!      -   5        $ MenuSave��5!      $��_Save��61   
���   �$
}�True��6S   
�������
���   �6z   �� 5"      6   m� 5#      -	   5        $ QuitMenu��5#      $��_Quit��61   
���   �$
}�True��6S   
���   �
�������6�   5$      m� 5%      -
   5        $ MenuEdit��5%      $��_Edit��6)   $��8,0,8,0q�68   
���   �
���   �$��1,1,1,1q�6q   .@�5&      m� -   5        $ 
InsertMenu��5&      $��_Insert��63   
�������
���   �
���   �6~   m� 5'      -   5        $ 
UpdateMenu��5'      $��_Update��63   
�������
���   �
���   �6~   m� 5(      -   5        $ 
DeleteMenu��5(      $��_Delete��63   
���   �
�������
���   �6~   5)      m� 5*      -   5        $ MenuHomepage��5*      $��Homepage��6-   $��8,0,8,0q�6?   
���   �
���   �$��1,1,1,1q�6x   .@�5+      m� -   5        $ ViewCustomers��5+      $��View Customers��66   
�������
���   �
���   �6�   m� 5,      -   5        $ ViewFlights��5,      $��View Flights��60   
���   �
�������
���   �6�   m� 5-      -   5        $ ViewAirlines��5-      $��View Airlines��65   
���   �
���   �
�������6�   m� 5.      -   5        $ ViewPassengers��5.      $��View Passengers��63   
���   �
�������
���   �6�   5/      m� 50      -   5        $ MenuHelp��50      $��_Help��6)   $��8,0,8,0q�68   
���   �
���   �6q   51      52      �� 53   
   -   5         ��Name$ stkPanel��53       �� Orientation$ Vertical=�6'   $	��Top=�6?   $��	0,114,0,0q�6W   $	��660��6j   $	��171��6v   .+�54      �� -   5         ��Name$ viewCustomerBtn��54      $��View Customers��6.   $	��150��6G   $��16(�6T   $��40��6b   $��Stretch=�6�   $��Stretch=�6�   �� 55      -   5        $ viewFlightsBtn��55      $��View Flights��6-   $	��150��6D   $��16(�6P   $��40��6^   $��5,0,5,0q�6j   $��Center=�6{   $��Center=�6�   6�   �� 56      -   5        $ viewPassengersBtn��56      $�� View Passengers��60   $	��150��6K   $��45��6W   $��16(�6c    J� RenderTransformOrigin$ 0.516,1.174&�6�   �� 57      -   5        $ viewAirlinesBtn��57      $��View Airlines��6.   $	��150��6F   $��49��6R   $��16(�6^   6m   58      59      5:      