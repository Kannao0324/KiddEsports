   M S B A M L   `   `   `  ���� F  BKiddEsports, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:KiddEsportsKiddEsports      KiddEsports.EventsPanel   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     +localclr-namespace:KiddEsports     .��� 
�������  � ColumnDefinitions  �� $��3* ���  � RowDefinitions �� $��6* ���  � 	Resources    
CoolButton �� 
TargetType �� Property �� Value��%�   &	        �� " ��.���  � ��
 ���_���  � ��
 �������  � ��$ Segoe UI)���  � ��$ DemiBold"���  � ��
 �������  � ��$ 2q�.+�&   System.Windows.Controls.DataGrid  -     Name$ 	dgvEvents��   
IsReadOnly$
 True��$��5q��� $��1��$��2��$��5q�.+��� .��ID:�� -    ��Name$ txtId��	 �� 
IsReadOnly$
	 True��$	��0.2q��� .��Event Name:�� -   $ txtName��$	��0,2q��� .��	Location:�� -   $ txtLocation��$	��0,2q��� .��Date:(  "System.Windows.Controls.DatePicker  -   
  Name$
 dpDate���� -    ��Name$ btnNew��#��[  $��30,120,30,10q�$��5q�.��New�� -   $ btnSave��#��[  $��30,10,30,10q�$��5q�.��Save�� -   $ 	btnDelete��#��[  
���  ��$��1��$
��Left=�$��20,10,20,10q�$��10q�$	��100��.��Delete