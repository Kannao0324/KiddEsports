   M S B A M L   `   `   `  ���� F  BKiddEsports, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:KiddEsportsKiddEsports      KiddEsports.TeamPanel   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     +localclr-namespace:KiddEsports     .��� 
�������  � ColumnDefinitions  �� $��3* ���  � RowDefinitions �� $��6* ���  � 	Resources    
CoolButton �� 
TargetType �� Property �� Value��%�   &	        �� " ��.���  � ��
 ���_���  � ��
 �������  � ��$ Segoe UI)���  � ��$ DemiBold"���  � ��
 �������  � ��$ 2q�.+�&   System.Windows.Controls.DataGrid  -     Name$ dgvTeams��   
IsReadOnly$
 True��$��5q��� $��1��$��5q�$��2��.+��� .��ID:�� -    ��Name$ txtId��	 �� 
IsReadOnly$
	 True��$	��0,1q��� .��Name:�� -   $ txtName��$	��0,1q��� .��Primary Contact:�� -   $ txtPrimaryContact��$	��0,1q��� .��Phone:�� -   $ txtPhone��$	��0,1q��� .��Email:�� -   $ txtEmail��$	��0,1q��� .��Conpetition Points:�� -   $ txtCompPoints��$	��0,1q��� -   
 ��Name$
 btnNew��#��[  $��
30,15,30,5q�$��5q�.��New�� -	   $
 btnSave��#��[  $��	30,5,30,5q�$��5q�.��Save�� -
   $
 	btnDelete��#��[  
���  ��$��	30,5,30,5q�$��5q�.��Delete