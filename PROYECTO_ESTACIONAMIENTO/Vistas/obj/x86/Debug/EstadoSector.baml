   M S B A M L   `   `   `  ����A  =Vistas, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:VistasVistas  5   	       Vistas.EstadoSector   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   $svcclr-namespace:Vistas     5   	   -   5          � Title$  EstadoSector��5   	    � AllowsTransparency . $	��229��69   $	��365��6F    � WindowStyle$
 None=�6R    � 
ResizeMode$ NoResize=�6e    � WindowStartupLocation$ CenterScreen=�5   	    � 	Resources 5       
  Tiempo � XPath   Vistas.ConversorDeEstados  Idconversor��%�  &	        &	 m    � 5   
   $ /tiempos��6)   .��5	      ��<tiempos xmlns="">
                    <tiempo value="0" />
                    <tiempo value="15" />
                    <tiempo value="30" />
                    <tiempo value="60" />
                    <tiempo value="90" />
                    <tiempo value="120" />
                </tiempos>        5        5   
   6!   5      .��5   
   �� $��Stretch=�6   ��5   
   �� 5       �� ImageSource$( "/Vistas;component/images/fondo.png��6   ._�5   
   � ���	#622815A0 � RowDefinitions 5      �� 5      $��40 �6    �� 5      .+�5      �� -   5        $��border1��5   c   
�������$��0��6.   $��30��6<   $
��Left=�6H   $	��Top=�6r   $	��357��6�   ._�5       �� -   5        $��stackPanel3��5       	 �� Orientation$	 
Horizontal=�61   $��Right=�6J   .+�5!      �� -   5        
 ��Name$
 btnMinimize��5!      $��0,5,0,0q�62   $��-��6C    � Cursor$
 Hand��6O     btn_minimizar#��[ 6w   �� 5"      -   5        $
 btnClose��5"      $��4,5,0,0q�6/   $��x��6@     
btn_cerrar#��[ 6c   5#      5$      �� 5%      $	 Vertical=�6   $��1��60   .+�5&      �� $	 
Horizontal=�6   $��Center=�66   .+�5'      �� 
�������$
��Bold"�63   $��18(�6E   .��6S   Informacion de Sector6j   5(      �� 5)      $	 
Horizontal=�6   $��Center=�66   $	��109��6S   .+�5*      �� -   5        $��	cbxTiempo��5*      $	��108��6/   $��30��6;   ��6G   ��  �� Source# [   �� XPath$ tiempo/@value��5+      �� 5,      $	 
Horizontal=�6   .+�5-      �� .��6   Valor:6$   �� 5.      $��40��6    $��46��6,   ��67   ��  �� ElementName$ 	cbxTiempo�� �� Path$ SelectedValue� �� 	Converter# [ 5/      50      51      52      53      