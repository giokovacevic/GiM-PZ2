   M S B A M L   `   `   `  ����I  ENetworkService, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:NetworkServiceNetworkService  5      C&clr-namespace:NetworkService.ViewModelNetworkService.ViewModel  5      ;"clr-namespace:NetworkService.ViewsNetworkService.Views  5          NetworkService.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      .localclr-namespace:NetworkService     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      <	viewModel&clr-namespace:NetworkService.ViewModel     5      4views"clr-namespace:NetworkService.Views     5      -   5        $��MainWindowRef��5        � Title$!  Network Service Application��5	      $	��700��5
      $	��520��5       � WindowStyle$
 None=�5   	    � 
ResizeMode$ NoResize=�5   	    � DataContext 5      2   ,NetworkService.ViewModel.MainWindowViewModel  5   
    � 	Resources 5       �� DataType7   1NetworkService.ViewModel.NetworkEntitiesViewModel.   (NetworkService.Views.NetworkEntitiesView6   0NetworkService.ViewModel.NetworkDisplayViewModel-   'NetworkService.Views.NetworkDisplayView8   2NetworkService.ViewModel.MeasurementGraphViewModel/   )NetworkService.Views.MeasurementGraphView   NoHoverButtonStyle �� 
TargetType �� Property �� Value	 �� ImageSource
 �� 
TargetType ��Name �� Triggers��%W  (��       5      *, +)(�� 2     5      *, +)(�� d     5      *, +)&	  �     �� 5   
   "  6   .R�5        5      �� 5   
   "  6   .R�5        5      �� 5   
   "  6   .R�5        5      �� 5   
   " ��6+   .�5       ��  � �� 5!      �� 5"      $	 ./Assets/active.png��6!   5$      �� 5%       � �� 5&      �� 5'      "
 ��6&   .R�5(      �� $ border��6!   #��z��5)   !   #��z��5*   !   #��z��5+   !   ._�5,      �� $��Center=�6/   $��Center=�5-   /   5.       5/      52      54      55      56      .��5:      �  � RowDefinitions 5;   
   �� 5<      $��40 �6   6*   �� 5=      $��2 �6   6)   �� 5>      $��* �6   6)   .+�5@   
   � $��0��6    � ColumnDefinitions 5A      �� 5B      $	��400 �6#   61   �� 5C      $��* �6#   6/   �� 5D      $��* �6#   6/   �� 5E      $��* �6#   6/   �� 5F      $��* �6#   6/   �� 5G      $��* �6#   6/   �� 5H      $��* �6#   6/   .+�5J      �� -   5         ��Name$ 
labelTitle��5J      $��0��6(   $��Center=�68   $��20(�6p   $��
5, 0, 0, 0q�6~   ��6S   �� *
AppTitle+6�   �� 5K      $��1��6   #��[  6%    � Cursor$
 Hand��6R   $
��nemv��6   ��6`   �� *
NavCommand+��5L      �� 5M      $	 ./Assets/home.png��6!   6C   5O      �� 5P      $��2��6   #��[  6%   $
 Hand��6Q   $
��ndmv��6~   ��6_   �� *
NavCommand+��5Q      �� 5R      $	 ./Assets/display.png��6!   6F   5T      �� 5U      $��3��6   #��[  6%   $
 Hand��6Q   $
��mgmv��6~   ��6_   �� *
NavCommand+��5V      �� 5W      $	 ./Assets/graphs.png��6!   6E   5Y      �� 5Z      $��4��6   #��[  6%   $
 Hand��6Q   ��5[      �� 5\      $	 ./Assets/undo.png��6!   6C   5^      �� 5_      $��5��6   #��[  6%   $
 Hand��6Q   ��6_   �� *PrevCommand+��5`      �� 5a      $	 ./Assets/back.png��6!   6C   5c      �� 5d      $��6��6   #��[  6%   $
 Hand��6Q   ��6_   �� *ExitCommand+��6   ��  �� ElementName$ MainWindowRef����5e      �� 5f      $	 ./Assets/exit.png��6!   6C   5h      5i      �� 5j   
   $��1��6   
�������61   �� 5k   
   $��2��6   ��6&   �� *CurrentViewModel+5l      5m      