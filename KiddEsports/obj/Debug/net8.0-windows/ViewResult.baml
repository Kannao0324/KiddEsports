   M S B A M L   `   `   `  ����F  BKiddEsports, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:KiddEsportsKiddEsports  5   	       KiddEsports.ViewResult   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:KiddEsports     5   	     � Title$  
ViewResult��5   	   $	��450��6   $	��800��6)   .��5	      � 
������� � ColumnDefinitions 5
   
   �� 5      $��3* �6   �� 5       � RowDefinitions 5   
   �� 5      $��6* �6   �� 5       � 	Resources 5   
      
CoolButton �� 
TargetType �� Property �� Value��%  &	        �� 5      " ��6'   .�5      ��  � ��
 ���_�6/   �� 5       � ��
 �����6/   �� 5       � ��$ Segoe UI)�6/   �� 5       � ��$ DemiBold"�6/   �� 5       � ��
 �����60   �� 5       � ��$ 2q�64   5      5      .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ dgvTeamResults��5         
IsReadOnly$
 True��6+   $��5q�6=   6H   �� 5   
   $��1��6   $��5q�6%   $��2��60   .+�5       �� .��6   ID:6   �� 5!      -   5        	 ��Name$	 txtId��5!      
 �� 
IsReadOnly$

 True��6%   $	��0,1q�67   �� 5"      .��6   Event:6   �� 5#      -   5         ��Name$ cboEvent��5#      $	��0,1q�6*    �� SelectedValuePath$ Content��67    �� SelectedValue 6S   �� *	VMEvent+ �� Mode$ TwoWay=��� 5$      .��6   Game:6   �� 5%      -   5        $ cboGame��5%      $	��0,1q�6)   $ Content��66    6R   �� *VMGame+$ TwoWay=��� 5&      .��6   	Team 1:6   �� 5'      -   5        $ cboTeam1��5'      $	��0,1q�6*   $ Content��67    6S   �� *	VMTeam1+$ TwoWay=��� 5(      .��6   	Team 2:6   �� 5)      -   5        $ cboTeam2��5)      $	��0,1q�6*   $ Content��67    6S   �� *	VMTeam2+$ TwoWay=��� 5*      .��6   	Result:6   �� 5+      -   5        $ 	cboResult��5+      $	��0,1q�6+   $ Content��68    5,      �� *
VMResult+$ TwoWay=��� 5-      -   5         ��Name$ 	btnUpdate��5-      #��[  6(   $��30,10,30,10q�6L   $��5q�6b   .��6�   Update6�   �� 5.      -	   5        $ 	btnDelete��5.      #��[  6(   
���  ��$��30,10,30,10q�6]   $��5q�6r   .��6�   Delete6�   5/      �� 50   
    �� Orientation$ 
Horizontal=�6   $��1��6.   $��0��6;   51      53      54      