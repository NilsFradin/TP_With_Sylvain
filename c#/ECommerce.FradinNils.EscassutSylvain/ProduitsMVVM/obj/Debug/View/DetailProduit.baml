   M S B A M L   `   `   `  ����G  CProduitsMVVM, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:ProduitsMVVM.ViewProduitsMVVM.View  5      5clr-namespace:ProduitsMVVM.ViewProduitsMVVM.View  5      %    ProduitsMVVM.View.DetailProduit   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      1localclr-namespace:ProduitsMVVM.View     5      .myclr-namespace:ProduitsMVVM.View     5      .��5
      �   � RowDefinitions  5   
   �� 5      $��35 �6   6*   �� 5      $	��100 �6   6+   �� 5      6   �� 5      $��30 �6   6*    � ColumnDefinitions 5   
   �� 5      6!   �� 5      6!   �� 5      6!   �� 5      6!   .+�5   
   �� $��0��6   $��4��6    $��0��64   $��Stretch=�6A   
�������$
��Bold"�6v   .��6�   FICHE PRODUIT6�   �� 5   
   $��0��6   $��1��6%   $��2��62    �� Orientation$ Vertical=�6F   $	��5pxq�6]   .+�5      �� .��6   Code :6   �� 5      ��6   �� *Code+6.   �� 5      .��6   
Libellé :6   �� 5      ��6   �� *	Libelle+61   5      �� 5    
   $��2��6   $��1��6%   $��2��62   $ Vertical=�6F   $	��5pxq�6]   .+�5!      �� .��6   Prix :6   �� 5"      ��6   �� *Prix+6.   �� 5#      .��6   	Stock :6   �� 5$      ��6   �� *Stock+6/   5%      �� 5&   
   $��0��6   $��2��6%   $��4��62   $ Vertical=�6F   .+�5'      �� .��6   Description :6#   �� 5(       �� TextWrapping$
 Wrap=�6    �� AcceptsReturn . " �� VerticalScrollBarVisibility$ Visible=�6?   ��6e   �� *Description+6�   5)      �� 5*   
   $��1��6   $��3��6!   $��2��6.   ��6B   �� *ActionModifier+.��6e   
Modifier6o   5+      5,      