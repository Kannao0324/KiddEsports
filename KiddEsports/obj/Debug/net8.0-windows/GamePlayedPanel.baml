   M S B A M L   `   `   `  ����F  BKiddEsports, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:KiddEsportsKiddEsports  5      !    KiddEsports.GamePlayedPanel   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      +localclr-namespace:KiddEsports     5      .��5	      � 
�������  � ColumnDefinitions  5
   
   �� 5      $��3* �6   �� 5       � RowDefinitions 5   
   �� 5      $��6* �6   �� 5       � 	Resources 5   
      
CoolButton �� 
TargetType �� Property �� Value��%  &	        �� 5      " ��6'   .�5      ��  � ��
 ���_�6/   �� 5       � ��
 �����6/   �� 5       � ��$ Segoe UI)�6/   �� 5       � ��$ DemiBold"�6/   �� 5       � ��
 �����60   �� 5       � ��$ 2q�64   5      5      .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ dgvGamePlayed��5         
IsReadOnly$
 True��6*   $��5q�6<   6G   �� 5   
   $��1��6   $��2��6%   $��5q�66   .+�5       �� .��6   ID:6   �� 5!      -   5         ��Name$ txtId��5!      	 �� 
IsReadOnly$
	 True��6%   $	��0,2q�67   �� 5"      .��6   
Game Name:6    �� 5#      -   5        $ txtName��5#      $	��0,2q�6'   �� 5$      .��6   
Game Type:6    �� 5%      -   5        
 ��Name$
 cboGameTypes��5%       �� 
IsReadOnly$
 True��6-   $	��0,2q�6?    �� SelectedValuePath$ Content��5&   E    �� SelectedValue 5'      �� *VMGameTypes+ �� Mode$ TwoWay=��� 5)      -   5         ��Name$ btnNew��5)      #��[  6%   $��30,160,30,10q�6I   $��5q�6`   .��6�   New6�   �� 5*      -   5        $ btnSave��5*      #��[  6&   $��30,10,30,10q�6J   $��5q�6`   .��6�   Save6�   5,      �� 5-   
   -   5        $ 	btnDelete��5-      #��[  6$   
���  ��$��1��6Y   $
��Left=�6f   $��20,10,20,10q�5.      $��10q�6   $	��100��6B   .��6N   Delete6V   50      51      