   M S B A M L   `   `   `  ����F  BKiddEsports, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:KiddEsportsKiddEsports  5   	       KiddEsports.Reports   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:KiddEsports     5   	     � Title$  Reports��5   	   $	��450��6   $	��800��6&   .��5	      � 
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
   &   System.Windows.Controls.DataGrid  -   5          Name$ 
dgvReports��5         
IsReadOnly$
 True��6'   $��5q�69   6D   �� 5   
   $��1��6   $��5q�6%   $��2��60   .+�5       �� -   5        	 ��Name$	 	lblSearch��5       $��10(�6(   $��0,10,0,0q�66   $
��Left=�6H   .��6d   Search By Team 1 Name:6|   �� 5!      -   5        
 ��Name$
 	txtFilter��5!      $��5,0,5,5q�6*   6;   �� 5"      -   5        $	 	lblExport��5"      $��10(�6(   $��0,10,0,0q�66   $
��Left=�6H   .��6d   Report Type:6r   �� 5#      -   5         ��Name$ 	cboExport��5#       �� 
IsReadOnly$
 True��6*   $	��140��6<   $��0,10,0,0q�6I    �� SelectedValuePath$ Content��5$   6    �� SelectedValue 6R   �� *
VMExport+ �� Mode$ TwoWay=��� 5&      -   5         ��Name$ 	btnExport��5&      #��[  6(   $��30,10,30,10q�6M   $��5q�6c   .��6�   Export6�   5(      5+      5,      