   M S B A M L   `   `   `  ����E  AClasesBase, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;,clr-namespace:ClasesBase;assembly=ClasesBase
ClasesBase  5   	   
 Vistas    Vistas.WinRegistrarEntrada   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   <svc,clr-namespace:ClasesBase;assembly=ClasesBase     5   	     � WindowStartupLocation$  CenterScreen=�5   	    � Title$ Registrar Entrada��5   	   $	��528��5   	   $	��400��5   	    � 	Resources 5	         desVehiculo S� 
ObjectType&    ClasesBase.TrabajarTiposVehiculo S� 
MethodName��%@   &	        S� 5
   
   "  62   $ TraerTiposVehiculo��6b   5      .��5      � $��10q�6   $	��442��5       � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   �� $��Fecha de Ingreso:��6   $��0��5       (  "System.Windows.Controls.DatePicker  5!   
   -   5        $��datePickerFecha��5"      $��1��5!      $��0,5,0,5q�5#      �� 5$   
   $��Hora de Ingreso:��6   $��2��5%      �� 5&   
   $��3��6    �� Orientation$ 
Horizontal=�5'      $��0,5,0,5q�5(      .+�5)      �� -   5        $��cmbHora��5)      $��60��5*      �� 5+      $��:��6   $��2,0,2,0q�5,      $��Center=�5-      �� 5.      -   5        $��
cmbMinutos��5.      $��60��5/      50      �� 53   
   $��DNI Cliente:��6   $��4��54      �� 55   
   -   5        $��txtDniCliente��56      $��5��55      $��0,5,0,5q�57      �� 5:   
   $��Numero Patente:��6   $��6��5;      �� 5<   
   -   5        $��
txtPatente��5=      $��7��5<      $��0,5,0,5q�5>      �� 5?   
   $��Tipo de Vehículo:��6   $��8��5@      �� 5A   
   -   5        $��cmbTipoVehiculo��5B      $��9��5A      $��0,5,0,5q�5C      6$   �� 5F   
   $��Tarifa:��6   $��10��5G      $��	0,0,274,0q�5H      �� 5I   
   -   5        $��	txtTarifa��5J      $��10��5I      $��
62,4,213,4q�5K      �� 5M   
   $��Zona:��6   $��12��5N      $��
0,7,298,99q�5O      �� 5P   
   -   5        $��	cmbSector��5Q      $��12��5P      $��	0,13,44,0q�5R      $��94��5S      $	��Top=�5T       �� DisplayMemberPath$ sec_descripcion��5U       �� SelectedValuePath$ 
sec_codigo��5V      $��Right=�6d   �� 5W      $��Sector:��6   $��12��5X      $��173,8,128,98q�5Y      �� 5Z   
   -	   5        $��cmbZona��5[      $��12��5Z      $��	49,12,0,0q�5\      $��96��5]      $	��Top=�5^      $ sec_descripcion��5_      $ 
sec_codigo��5`      $
��Left=�62   6M   �� 5c   
   -
   5        $��Registrar Entrada��5c      $��12��5d      $
��Left=�5f      $	��Top=�5g      $��
124,82,0,0q�5h      $��35��5i      $	��106��5j      5k      5l      