   M S B A M L   `   `   `  ����L  HMeteringSimulator, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:MeteringSimulatorMeteringSimulator  5          MeteringSimulator.App   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      1localclr-namespace:MeteringSimulator     5        �� 	Resources  5         ComboBoxToggleButton �� 
TargetType � ColumnDefinitions ��Name �� CornerRadius F�Name  ComboBoxTextBox �� 
TargetType �� Property �� Value	 �� 	ClickMode
 d� 	IsChecked �� Path �� Mode �� RelativeSource J� IsHitTestVisible �� SelectionBoxItem �� SelectionBoxItemTemplate ��Name �� 
IsReadOnly �� 
IsReadOnly �� SelectionBrush �� IsDropDownOpen � AllowsTransparency J� SnapsToDevicePixels � ActualWidth �� MaxDropDownHeight K� IsItemsHost-  'System.Windows.Input.KeyboardNavigation   DirectionalNavigation �� Triggers P� Property P� Value �� 
TargetName  P� 
SourceName! �� Triggers" �� Padding��%L  &	        &	     '�� c    7   7  '�� �
    �� 5   
   " d�67   .R�5      �  5	      �� 5
      �� 5      $��20 �6'   .+�5      �� $ Border��5      $��2��5      $ 0��5      
���   �
�������$��1q�5      �� 5      $��0��5      $ 0��5      $��1q�5      
���   �
�������$��0,0,1,0q�5      F� 5      $ Arrow��5      $��1��5      
�������$��Center=�5      $��Center=�5       =����        �    �� � 	= ��[ � z �� � z     � 	=  	= 	5!      5#      5$      �� 5&   
   " ��62   .R�5'      �� $ PART_ContentHost��6   |�.  #��z��6A   5(      �� 5*   
   " ��6*   .�5+      ��  �@J�SnapsToDevicePixels . 64   �� 5,       �@�OverridesDefaultStyle . 66   �� 5-       � ��$
 Auto=�6K   �� 5.       � ��$
 Auto=�6I   �� 5/       � �� . 6>   �� 50       � ��$	 120��6)   �� 51       � ��$ 20��6*   �� 52       � ��
 �����6+   �� 53       � �� 54      �� 55      " ��6&   .R�56      � .+�57      d� $��ToggleButton��58      8��  $��2��5:      |�.  $	 Press=�5=      
 5<      �� $ IsDropDownOpen�$ TwoWay=� �� *TemplatedParent+5>      �� 5?      $��ContentSite��6/    .  #��z 6\   #��z 5@      #��z��5A      $��3,3,23,3q�5B      $��Center=�5C      $
��Left=�5D      �� 5E      $ PART_EditableTextBox��6&   8�� $
��Left=�5H      $��Center=�5I      $��3,3,23,3q�5J      |�. 
���   �
�������$y�Hidden=�5N      # z 5O      
������� �	#FF3F3F3F��5F      Z� 5O   [   � 5P      $��Popup��5Q      $��Bottom=�5R      #��z 5S       . |�.  $��Slide=�5V      .��5X   "   � $��DropDown��6'    . #��z 5Z      #��z 5[      .+�5\   &   �� $ DropDownBorder��5]   !   
���   �$��1q�5`   !   
�������5a   !   �� 5b   &   $��4,6,4,6q�63    . .��5c   *   ��  . $ 	Contained=�6H   5d   '   5e   #   5f      5g       5h      P� 5i       �@��HasItems .  . �5j   "   �� $ DropDownBorder��6)    � ��$ 95��6Z   5k      P� 5l       � {� .  . �5m   "   ��  � �� �#8888886?   5n      P� 5o       �@��
IsGrouping . . �5p   "   ��  � �� .  6R   5q      P� 5r      $  Popup��6&    �@�AllowsTransparency . . �5s   "   �� $ DropDownBorder��6)    �@��CornerRadius$ 0��6]   �� 5t   "   $ DropDownBorder��6)    � ��$ 0,2,0,0q�6W   5u      P� 5v       �@��
IsEditable . . �5w   "   ��  � �� .  6>   �� 5x   "   $ PART_EditableTextBox��6)    � y�$ Visible=�6a   �� 5y   "   $ ContentSite��6)    � y�$ Hidden=�6X   5z      5|      5~      ! 5      5�      �� 5�   
   " ��6.   .�5�      ��  �@J�SnapsToDevicePixels . 64   �� 5�       � ��
 �����6+   �� 5�       �@�OverridesDefaultStyle . 66   �� 5�       � �� 5�      �� 5�      " ��6&   .R�5�      �� $��Border��6!   $" 2q�5�       . ._�5�      �� 5�       5�      P� 5�       �@��IsHighlighted . . �5�   "   �� $ Border��6)    � �� �	#FF4F4F4F6S   5�      P� 5�       � {� .  . �5�   "   ��  � �� �#8888886?   5�      5�      5�      5�      5�      5�      