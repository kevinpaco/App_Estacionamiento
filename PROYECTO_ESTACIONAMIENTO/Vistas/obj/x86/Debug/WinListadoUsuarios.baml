   M S B A M L   `   `   `  ����E  AClasesBase, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;,clr-namespace:ClasesBase;assembly=ClasesBase
ClasesBase  5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R8clr-namespace:System.ComponentModel;assembly=WindowsBaseSystem.ComponentModel 5   	   
 Vistas   Vistas.WinListadoUsuarios   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   GcoleccionUsuario,clr-namespace:ClasesBase;assembly=ClasesBase    5   	   QcomponentModel8clr-namespace:System.ComponentModel;assembly=WindowsBase    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   -   5          � Title$  WinListadoUsuarios��5   	   $	��300��6$   $	��396��61    � WindowStyle$
 None=�6=    � 
ResizeMode$ NoResize=�6P    � WindowStartupLocation$ CenterScreen=�5   	    � 	Resources 5         	list_user S� 
ObjectType!   ClasesBase.TrabajarUsuarios S� 
MethodName  
vista_user �� Source �� SortDescriptions+  %System.ComponentModel.SortDescription	   PropertyName
   	Direction��%�   &	        &	 0     7   S� 5	   
   "  6/   $ TraerUsuario��6g   �� 5
   
   -   5        8    5        5      $	 user_userName��61   $
 
Descending=�6N   5      5      .��5      �� ��5   
   �� 5       �� ImageSource$ /images/app_customers.jpg��6    j� Stretch$
 Fill=�5      ._�5   
   �� ��5      �� 5      .��5      �  � Color$ #462AD8��6#    � Offset$ 0Q�63   � 5      $ #DA34AE��6#   $
 0.75Q�63   � 5      $ #462AD8��6#   $ 1Q�63   5      ��5      �� 5       �� 
StartPoint$	 0,1&�6&    �� EndPoint$	 1,0&�5   &   .��5       � $ #060531��6#   $ 0Q�5!   #   � 5"      $ 	#622815A0��6#   $
 0.75Q�5#   #   5$      ._�5&      �  � RowDefinitions 5'      �� 5)      $��32 �6$   �� 5+      $��* �6$    � ColumnDefinitions 5.      �� 5/      $��* �6'   �� 50      $��25 �6'   �� 51      $��25 �6'   �� 52      $��5 �6'   .+�56      �� -   5        $��
tituloForm��56      $��Filtrar Usuarios��6*   
�������$��Center=�6]   $��Elephant)�57      $��18(�6.   $��Center=�6<   58      �� 5;      -   5         ��Name$ btnMinimize��5;      $��0q�6.   $��-��6B    � Cursor$
 Hand��6N   $��1��6\   $	��0,5q�6l     btn_minimizar#��[ 5<   3   �� 5?      -   5        $ btnClose��5?      $��0q�6+   $��x��6?   $
 Hand��6K   $��2��6Y   $	��0,5q�6i     
btn_cerrar#��[ 5@   0   � 5C      $��1��6   $��
20,20,1,20q�6$   $��3��68    5D      �� 5E      $
��Auto �6(   �� 5F      $��* �6(   �� 5G      $
��Auto �6(   .+�5J      ��  �� Orientation$ Vertical=�6!   $��0,0,0,32q�68   $��2��6J   .+�5K      �� $ 
Horizontal=�6%   $��0,0,0,6q�6?   $��Center=�6P   .+�5L      �� $��	User Name��6$   �� 5M      -   5        $��	txtfilter��5M   '   $	��155��68   6D   5N      �� 5O      -   5        $��lts_user��5O   #   ��65   ��  �� Source# [  �� View 5P      �� 5Q   "   .P�5R   &   �� $��Username��65    �� Width$	 100��6G    �� DisplayMemberBinding 6S   �� *
UserName+�� 5S   &   $��Nombre��65   $	 100��6E    6Q   �� *Nombre+�� 5T   &   $	��Rol��65   $	 100��6B    6N   �� *Rol+5U   #   5W      5X      5Y      5Z      5[      5\      5]      