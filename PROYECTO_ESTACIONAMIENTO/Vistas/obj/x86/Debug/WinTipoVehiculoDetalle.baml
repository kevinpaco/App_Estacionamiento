   M S B A M L   `   `   `  ����
  Vistas#    Vistas.WinTipoVehiculoDetalle   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  Detalles de Vehiculo��5   	   $	��352��5   	   $	��400��5   	    � WindowStyle$
 None=�5   	    � 
ResizeMode$ NoResize=�5   	    � WindowStartupLocation$ CenterScreen=�5	   	   
�������.��5      �� ._�5   
   � ���	#622815A0 J� OpacityMask
 �   � � RowDefinitions 5      �� 5      $
��Auto �6    �� 5      $��* �6    �� 5      $
��Auto �6    .+�5      �� -   5         ��Name$ btnMinimize��5      $��0q�5      $��-��5       � Cursor$
 Hand��5      $��0,5,32,0q�5         btn_minimizar#��[  5      �� 5      -   5        $ btnClose��5      $��0q�5      $��x��5      $
 Hand��5      $��0,4,6,0q�5         
btn_cerrar#��[ 5"      �� 5$      $��Detalles de Vehiculo��6   $��18(�5%      $
��Bold"�5&      $��Center=�5'      $��0,10,0,0q�5(      �� 5+      $��1��6   $��20q�5,      .+�5-      ��  �� Orientation$ 
Horizontal=�6   $
��0,10q�5.      .+�5/      �� $	��100��6    $��	TvCodigo:��50       �� 51      -   5        $��TvCodigoTextBox��51      $	��200��52      	 �� 
IsReadOnly	 . 53      54      �� 56      $ 
Horizontal=�6   $
��0,10q�57      .+�58      �� $	��100��6    $��Descripcion:��59       �� 5:      -   5        $��DescripcionTextBox��5:      $	��200��5;      	 . 5<      5=      �� 5?      $ 
Horizontal=�6   $
��0,10q�5@      .+�5A      �� $	��100��6    $��Tarifa:��5B       �� 5C      -   5        $��TarifaTextBox��5C      $	��200��5D      	 . 5E      5G      �� 5H      $ 
Horizontal=�6   $
��0,10q�5I      .+�5J      �� $	��100��6    $��Imagen:��5K       �� 5L      -   5        $��ImagenVehiculo��5L      $	��200��5M      $	��100��5N      $��UniformToFill=�5O      5P      5R      5S      ��5T   
   �� 5U      
 �� ImageSource$/
 )/Vistas;component/images/app_vehicles.png��6    j� Stretch$ UniformToFill=�5V       j� TileMode$
 None=�5W      5Y      5Z      