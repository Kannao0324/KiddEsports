   M S B A M L   `   `   `  ���� F  BKiddEsports, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:KiddEsportsKiddEsports      KiddEsports.ResultInput   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     +localclr-namespace:KiddEsports     .��� 
�������  � ColumnDefinitions  �� $	��20* ��� $	��10* ��� $	��10* � � RowDefinitions �� $
��0.5* ��� $
��0.5* ��� $
��0.5* ��� $
��0.5* � � 	Resources    
CoolButton �� 
TargetType �� Property �� Value��%�   &	        �� " ��.���  � ��
 ���_���  � ��
 �������  � ��$ Segoe UI)���  � ��$ DemiBold"���  � ��
 �������  � ��$ 2q�.+��� $��0��$��0��.+��� -    ��Name$ lblTeam1��$��30,0,0,0q�$��20(�$
��Left=�.��Team 1 Name�� -    ��Name$ cboTeam1��$��30,0,0,0q�$��10q�$��20(��� $��0��$��1��$��2��.+��� -   $ lblEvent��$��	30,5,10,0q�$��20(�$
��Left=�.��Event�� -   $ cboEvent�� �� 
IsEditable$ False��$��	30,0,10,5q�$��10q�$
��Left=�$	��296���� $��1��$��0��$��2��.+��� $��Center=�$��10q�$��50(�.��VS�� $��2��$��0��.+��� -   $ lblTeam2��$��30,0,0,0q�$��20(�$
��Left=�.��Team 2 Name�� -   $ cboTeam2��$��30,0,0,0q�$��10q�$��20(��� $��1��$��1��$��2��.+��� -   $ lblGame��$��	30,5,10,0q�$��20(�$
��Left=�.��Game�� -   $ cboGame��$ False��$��	30,0,10,5q�$��10q�$
��Left=�$	��296���� $��2��$��1��$��2��.+��� -	   $ 	lblResult��$��20(�$��	30,5,10,0q�$
��Left=�.��Result�� -
   $ 	cboResult��$ False��$��	30,0,10,5q�$��10q�	 �� SelectedValuePath$	 Content��$
��Left=�$	��296��
 �� SelectedValue
 �� *
VMResult+ �� Mode$ TwoWay=��� $��4��$��1��.+��� -    ��Name$ btnView��#��[  $��20q�$��10q�.��View Result�� $��4��$��2��.+��� -   $ btnSave��#��[  $��20q�$��10q�.��Save