   M S B A M L   `   `   `  ���� F  BKiddEsports, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:KiddEsportsKiddEsports      KiddEsports.ViewResult   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     +localclr-namespace:KiddEsports       � Title$  
ViewResult��$	��450��$	��800��.��� 
������� � ColumnDefinitions �� $��3* ���  � RowDefinitions �� $��6* ���  � 	Resources    
CoolButton �� 
TargetType �� Property �� Value��%�   &	        �� " ��.���  � ��
 ���_���  � ��
 �������  � ��$ Segoe UI)���  � ��$ DemiBold"���  � ��
 �������  � ��$ 2q�.+�&   System.Windows.Controls.DataGrid  -     Name$ dgvTeamResults��   
IsReadOnly$
 True��$��5q��� $��1��$��5q�$��2��.+��� .��ID:�� -   	 ��Name$	 txtId��
 �� 
IsReadOnly$

 True��$	��0,1q��� .��Event:�� -    ��Name$ cboEvent��$	��0,1q� �� SelectedValuePath$ Content�� �� SelectedValue �� *	VMEvent+ �� Mode$ TwoWay=��� .��Game:�� -   $ cboGame��$	��0,1q�$ Content�� �� *VMGame+$ TwoWay=��� .��	Team 1:�� -   $ cboTeam1��$	��0,1q�$ Content�� �� *	VMTeam1+$ TwoWay=��� .��	Team 2:�� -   $ cboTeam2��$	��0,1q�$ Content�� �� *	VMTeam2+$ TwoWay=��� .��	Result:�� -   $ 	cboResult��$	��0,1q�$ Content�� �� *
VMResult+$ TwoWay=��� -    ��Name$ 	btnUpdate��#��[  $��30,10,30,10q�$��5q�.��Update�� -	   $ 	btnDelete��#��[  
���  ��$��30,10,30,10q�$��5q�.��Delete��  �� Orientation$ 
Horizontal=�$��1��$��0��