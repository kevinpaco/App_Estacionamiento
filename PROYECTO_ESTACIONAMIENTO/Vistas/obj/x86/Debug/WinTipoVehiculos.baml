   M S B A M L   `   `   `  ����E  AClasesBase, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;,clr-namespace:ClasesBase;assembly=ClasesBase
ClasesBase  5   	   
 Vistas   Vistas.WinTipoVehiculos   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   :svc,clr-namespace:ClasesBase;assembly=ClasesBase    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   -   5          � Title$  WinTipoVehiculos��5   	   $	��376��6"   $	��646��6/    � WindowStyle$
 None=�6;    � 
ResizeMode$ NoResize=�5   	    � WindowStartupLocation$ CenterScreen=�5   	    � 	Resources 5	         trabajarVehiculos S� 
ObjectType&    ClasesBase.TrabajarTiposVehiculo S� 
MethodName��%@   &	        S� 5   
   "  67   $ TraerTiposVehiculo��6g   5      .��5      �� ��5   
   �� 5       �� ImageSource$  /images/app_background.jpg��6    j� Stretch$
 Fill=�6B   ._�5   
   �� ��5      �� 5      .��5      � 	 � Color$	 #462AD8��6#   
 � Offset$
 0Q�5   #   � 5      $	 #DA34AE��6#   $

 0.75Q�5   #   � 5      $	 #462AD8��6#   $
 1Q�5   #   5      ��5      �� 5       �� 
StartPoint$	 0,1&�6&    �� EndPoint$	 1,0&�5   &   .��5      � $	 #060531��6#   $
 0Q�5    #   � 5!      $	 	#622815A0��6#   $

 0.75Q�5"   #   5#      ._�5%      �  � RowDefinitions 5&      �� 5(      $��32 �6$   �� 5*      $��* �6$    � ColumnDefinitions 5-      �� 5.      $��* �6'   �� 5/      $��25 �6'   �� 50      $��25 �6'   �� 51      $��5 �6'   .+�56      �� $��Tipo de Vehiculos��6   
�������$��Center=�58      $��Elephant)�59      $��18(�5:      $��Center=�5;      $��4��5<      5=      �� 5@      -   5         ��Name$ btnMinimize��5@      $��-��6.    � Cursor$
 Hand��6:   $��1��6H   $��Center=�6X     btn_minimizar#��[ 5A   3   �� 5D      -   5        $ btnClose��5D      $��x��6+   $��Center=�67   $
 Hand��6R   $��2��6`     
btn_cerrar#��[ 5E   0   � 5H      $��1��6   $��2��6$    5I      �� 5J      $
��Auto �6(   �� 5K      $��* �6(   �� 5L      $
��Auto �6(   .+�5O      &   System.Windows.Controls.DataGrid  -   5        $��VehiculosDataGrid��5O         AutoGenerateColumns .  $
��Bold"�6T   ���	#46000000$	��199��5P   y   $��15,15,6,260q�6�   ��6    ��  �� Source# [     Columns 5S      0  *System.Windows.Controls.DataGridTextColumn  5T      ,  &System.Windows.Controls.DataGridColumn   Header$ Codigo��61      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 5V   1      
IsReadOnly . 1  +System.Windows.Controls.DataGridBoundColumn   Binding 5U   1   �� *Codigo+   HeaderStyle 5X   "   �� 5Y   &    �� 
TargetType=  7System.Windows.Controls.Primitives.DataGridColumnHeader"  6,   .�5Z   *   ��  �� Property � �� �� Value$ Center=�5[   1   5\   '   5^        5_      $ Descripcion��61   $ * 5a   1    .  5`   1   �� *Descripcion+ 5c   "   �� 5d   &   "  6,   .�5e   *   ��  � ��$ Center=�5f   1   5g   '   5i        5j      $ Tarifa��61   $ * 5l   1    .  5k   1   �� *Tarifa+ 5n   "   �� 5o   &   "  6,   .�5p   *   ��  � ��$ Center=�5q   1   5r   '   5t      5w      �� 5z      -   5        $��lblTotalVehiculos��5~      $��Total registrados: XXXXX��5z      $��28��5{      $
��Left=�5|      $��
15,231,0,0q�5}      $	��Top=�5      $	��143��5�      $
��Bold"�5�      $��Italic$�5�      
�������5�      5�      5�      5�      5�      5�      