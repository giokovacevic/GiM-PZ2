   M S B A M L   `   `   `  ����I  ENetworkService, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:NetworkService.ViewsNetworkService.Views  5      C&clr-namespace:NetworkService.ViewModelNetworkService.ViewModel  5      /    )NetworkService.Views.MeasurementGraphView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      4local"clr-namespace:NetworkService.Views     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      <	viewModel&clr-namespace:NetworkService.ViewModel     5        � DataContext  5      8   2NetworkService.ViewModel.MeasurementGraphViewModel  5   
   .��5      �  � ColumnDefinitions 5   
   �� 5      $	��250 �6   6-   �� 5      $��2 �6   6+   �� 5      $��* �6   6+   .+�5   
   �� -   5        $��ComboBoxMeters��5   #   $��0��6   $��36��69   $	��210��6E   $��Center=�6Q   $	��Top=�6n   $��16(�6�    �� DisplayMemberPath$
 Name��6�   $��
0, 5, 0, 0q�6�   ��6�   �� *Meters+6  �� 5   
   $��1��6   
�������64   �� 5   
   -   5         ��Name$ GraphCanvas��5   !   $��2��6   
�������$��Stretch=�6M   $��Stretch=�6i   5      5      