   M S B A M L   `   `   `  ����F  BKiddEsports, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:KiddEsportsKiddEsports  5          KiddEsports.TeamPanel   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      +localclr-namespace:KiddEsports     5      .��5
      � 
�������  � ColumnDefinitions  5   
   �� 5      $��3* �6   �� 5       � RowDefinitions 5   
   �� 5      $��6* �6   �� 5       � 	Resources 5   
      
CoolButton �� 
TargetType �� Property �� Value��%  &	        �� 5      " ��6'   .�5      ��  � ��
 ���_�6/   �� 5       � ��
 �����6/   �� 5       � ��$ Segoe UI)�6/   �� 5       � ��$ DemiBold"�6/   �� 5       � ��
 �����60   �� 5       � ��$ 2q�64   5      5      .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ dgvTeams��5         
IsReadOnly$
 True��6%   $��5q�67   6B   �� 5    
   $��1��6   $��5q�6%   $��2��60   .+�5!      �� .��6   ID:6   �� 5"      -   5         ��Name$ txtId��5"      	 �� 
IsReadOnly$
	 True��6%   $	��0,1q�67   �� 5#      .��6   Name:6   �� 5$      -   5        $ txtName��5$      $	��0,1q�6'   �� 5%      .��6   Primary Contact:6&   �� 5&      -   5        $ txtPrimaryContact��5&      $	��0,1q�61   �� 5'      .��6   Phone:6   �� 5(      -   5        $ txtPhone��5(      $	��0,1q�6(   �� 5)      .��6   Email:6   �� 5*      -   5        $ txtEmail��5*      $	��0,1q�6(   �� 5+      .��6   Conpetition Points:6)   �� 5,      -   5        $ txtCompPoints��5,      $	��0,1q�6-   �� 5-      -   5        
 ��Name$
 btnNew��5-      #��[  6%   $��
30,15,30,5q�6I   $��5q�6^   .��6   New6�   �� 5.      -	   5        $
 btnSave��5.      #��[  6&   $��	30,5,30,5q�6K   $��5q�6^   .��6�   Save6�   �� 5/      -
   5        $
 	btnDelete��5/      #��[  6(   
���  ��$��	30,5,30,5q�6]   $��5q�6p   .��6�   Delete6�   50      51      52      