   M S B A M L   `   `   `  ����
  Vistas    Vistas.WinListadoDeVentas   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � WindowStartupLocation$  CenterScreen=�5   	    � Title$ WinListadoDeVentas��5   	   $	��551��6$   $	��843��61   .��5      � .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ dgVentas��5         AutoGenerateColumns . $��10,32,10,118q�5
      �� 5   
   $��Desde:��6   $
��Left=�5      $��Bottom=�5      $��	16,0,0,45q�5      (  "System.Windows.Controls.DatePicker  5   
   -   5          Name$ dpFechaInicio��5      $
��Left=�5      $��Bottom=�5      $��
63,0,20,45q�5      �� 5   
   $��Hasta:��6   $
��Left=�5      $��Bottom=�5      $��
217,0,0,45q�5        5   
   -   5        $ 
dpFechaFin��5      $
��Left=�5      $��Bottom=�5      $��
265,0,0,45q�5      $��24��6)   �� 5   
   -   5        $��Aplicar Filtro��5      $
��Left=�5      $��Bottom=�5       $��
112,0,0,12q�5!      5"      �� 5$   
   -   5        $��Borrar Filtros��5$      $
��Left=�5%      $��Bottom=�5&      $��
201,0,0,12q�5'      5(      �� 5-   
   -   5        $��Imprimir��5-      $
��Left=�5.      $��Bottom=�5/      $��
726,0,0,88q�50      $��23��52      $��59��53      �� 56   
   -   5         ��Name$ lblTotal��56      $��$��57      $
��Left=�58      $��Bottom=�59      $��	497,0,0,6q�5:      $	��150��5;      �� 5=   
   -   5        $��label1��5A      $"��LISTADO DE VENTAS REALIZADAS��5=      $��28��5>      $
��Left=�5?      $��	12,-2,0,0q�5@      $	��Top=�5B      $	��192��5C      �� 5D   
   -	   5        $��label2��5H      $��Monto total de ventas: ��5D      $��28��5E      $
��Left=�5F      $��375,480,0,0q�5G      $	��Top=�5I      $	��135��5J      �� 5K   
   -
   5        $��label3��5O      $#��Filtrado por rango de fechas:��5K      $��29��5L      $
��Left=�5M      $��
10,400,0,0q�5N      $	��Top=�5P      $	��162��5Q      �� 5R   
   -   5        $��label4��5V      $��Imprimir Listado:��5R      $��29��5S      $
��Left=�5T      $��614,400,0,0q�5U      $	��Top=�5W      $	��106��5X      5Y      5Z      