   M S B A M L   `   `   `  ����E  AClasesBase, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;,clr-namespace:ClasesBase;assembly=ClasesBase
ClasesBase  5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R8clr-namespace:System.ComponentModel;assembly=WindowsBaseSystem.ComponentModel 5   	   
 Vistas#   Vistas.VistaPreviaDeImpresion   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   IcoleccionUsuario,clr-namespace:ClasesBase;assembly=ClasesBase     5   	   ScomponentModel8clr-namespace:System.ComponentModel;assembly=WindowsBase     5   	     � Title$  VistaPreviaDeImpresion��5   	   $	��366��6(   $	��474��65    � 	Resources 5         	list_user S� 
ObjectType!   ClasesBase.TrabajarUsuarios S� 
MethodName  
vista_user �� Source �� SortDescriptions+  %System.ComponentModel.SortDescription   PropertyName   	Direction��%�   &	        &	 0     7   S� 5   
   "  6/   $ TraerUsuario��6g   �� 5	   
   8    5
        5      $ user_userName��61   $ 	Ascending=�6N   5      5      .��5   
   �� .+�5   
   -�  �� Left$ 12��6   
	 �� Top$	 28��6.   $	��250��6>   .��5      /� -   5        
 �Name$
 DocMain��5      .T�5      J� .*�6   Listado de Usuarios61   �� 5      .r�5      �� ��6   ��  �� Source# [  �� View 5      �� 5      P�5      �� 5      $��Apellido��6)    �� Width$ 90��6j    �� DisplayMemberBinding 6;   ��  �� Path$ Apellido�6w   �� 5      $��Nombre��6)   $ 90��6f    69   �� $ Nombre�6s   �� 5      $��Usuario��6)   $ 90��6i    6:   �� $ UserName�6v   �� 5      $��Contraseña��6)   $ 90��6l    6=   �� $ Password�6y   5      5!      5"      5#      5%      �� 5&   
   -   5        $��btnPrint��5&      $��Imprimir��6!   $	��100��6K   5'      5)      