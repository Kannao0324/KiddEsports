   M S B A M L   `   `   `  ���� F  BKiddEsports, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:KiddEsportsKiddEsports      KiddEsports.Reports   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     +localclr-namespace:KiddEsports       � Title$  Reports��$	��450��$	��800��.��� 
������� � ColumnDefinitions �� $��3* ���  � RowDefinitions �� $��6* ���  � 	Resources    
CoolButton �� 
TargetType �� Property �� Value��%�   &	        �� " ��.���  � ��
 ���_���  � ��
 �������  � ��$ Segoe UI)���  � ��$ DemiBold"���  � ��
 �������  � ��$ 2q�.+�&   System.Windows.Controls.DataGrid  -     Name$ 
dgvReports��   
IsReadOnly$
 True��$��5q��� $��1��$��5q�$��2��.+��� -   	 ��Name$	 	lblSearch��$��10(�$��0,10,0,0q�$
��Left=�.��Search By Team 1 Name:�� -   
 ��Name$
 	txtFilter��$��5,0,5,5q��� -   $	 	lblExport��$��10(�$��0,10,0,0q�$
��Left=�.��Report Type:�� -    ��Name$ 	cboExport�� �� 
IsReadOnly$
 True��$	��140��$��0,10,0,0q� �� SelectedValuePath$ Content�� �� SelectedValue �� *
VMExport+ �� Mode$ TwoWay=��� -    ��Name$ 	btnExport��#��[  $��30,10,30,10q�$��5q�.��Export