   M S B A M L   `   `   `  ����N  JSurfaceApplication1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:SurfaceApplication1SurfaceApplication1  5      '    !SurfaceApplication1.MenuDataSheet   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      e aMicrosoft.Surface.Presentation, Version=2.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e351s)http://schemas.microsoft.com/surface/2008  5      1	myProject!clr-namespace:SurfaceApplication1  5      G  AMicrosoft.Surface.Presentation.Controls.ScatterContentControlBase    	CanRotate  .  
�����F�$	��820��5	   `   $	��670��6l      CanScale .  $��Stretch=�6�    � 	Resources 5       �� 
TargetType   DataSheetInputs �� Property �� Value��%�   &	        �� 5   
   " ��6   .�5      ��  � ��$ 14(�6)   �� 5       � ��$
 Bold"�6+   �� 5       � ��$	 Top=�62   5      5      .��5      �� -   5        $��DataSheetTabControl��5   6   $��10q�6   $	��800��6   $	��660��6)   .@�5   
   �� -   5        $��DataSheetTab��5      $��Summary��6&   .��5      �� $��Hidden=�6   .��5      � -   5        $��	DataSheet��5       � ShowGridLines . $	��608��69   $	��Top=�6F    � RowDefinitions 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5       �� 5!      �� 5"       � ColumnDefinitions 5$      �� 5%      $
��180* �6'   �� 5&      $
��600* �6'   .+�5)      �� #��[  6    $	��Top=�6I   Parts Registry ID5+      �� 5-      $��1��6    #��[  6-   $	��Top=�6V   Common Name5/      �� 51      $��2��6    #��[  6-   $	��Top=�6V   
Category53      �� 55      $��3��6    #��[  6-   $	��Top=�6V   Sub-Category57      �� 59      $��4��6    #��[  6-   $	��Top=�6V   Availability5;      �� 5=      $��5��6    #��[  6-   $	��Top=�6V   
Usefulness5?      �� 5A      $��6��6    #��[  6-   $	��Top=�6V   Assembly Compatibility5C      �� 5E      $��7��6    #��[  6-   $	��Top=�6V   	Chassis5G      5I      5J      5K      �� 5M   
   -   5        $��Sequence��5M      .��5N      � -   5        $��SeqTab��5N      $	��Top=�6!   $	��608��69    5O      �� 5P      $	��31* �6$   �� 5Q      $
��577* �6$    5S      �� 5T      $
��180* �6'   �� 5U      $
��600* �6'   .+�5X      �� $��0��6   #��[  6)   $	��Top=�6R   Length5Z      �� 5\      -   5        $��GeneSequence��5\      $��1��60   $��1��6=   5]      �� 5_      $��1��6   	 �� Orientation$	 Vertical=�6*   .+�5`      �� #��[  6   $	��Top=�6E   
Sequence5b      ;  5Microsoft.Surface.Presentation.Controls.SurfaceButton  5d      -   5        $��CopySequence��5d   &   
�������$��0, 10, 0, 0q�6t   $��18(�6�   $	��150��6�   $��Center=�6�   $��Center=�6�   $��Center=�6�   .��6  Copy Sequence5f      5g      5h      5i      �� 5j   
   -   5        $��Author Info��5j      .��5k      � -	   5        $��
AuthorInfo��5k       . $	��608��6:   $	��Top=�6G    5l      �� 5m      $
��202* �6$   �� 5n      $
��202* �6$   �� 5o      $
��202* �6$    5r      �� 5s      $
��180* �6'   �� 5t      $
��612* �6'   .+�5w      �� #��[  6   $	��Top=�6E   	Author(s)5y      �� 5{      $��1��6   #��[  6)   $	��Top=�6R   Group5}      �� 5      $��2��6   #��[  6)   $	��Top=�6R   Date5�      5�      5�      �� 5�   
   -
   5        $��Publications��5�      .��5�      <  6Microsoft.Surface.Presentation.Controls.SurfaceListBox  -   5        $��Publictions��5�      5�      5�      5�      5�      