   M S B A M L   `   `   `  ����N  JSurfaceApplication1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:SurfaceApplication1SurfaceApplication1  5           SurfaceApplication1.Level1   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      e aMicrosoft.Surface.Presentation, Version=2.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e351s)http://schemas.microsoft.com/surface/2008  5      1	myProject!clr-namespace:SurfaceApplication1  5      -   5        G  AMicrosoft.Surface.Presentation.Controls.ScatterContentControlBase    CanMove  .    CanScale .     	CanRotate .  =  7Microsoft.Surface.Presentation.Controls.ScatterViewItem   IsTopmostOnActivation .     ShowsActivationEffects .  $��bottom=�5      $
��1920��6    $	��930��6-      Center$ 950,1425&�6:      Orientation$ 0Q�6L    � 	Resources 5       �� 
TargetType 	  Parts	 �� Property
 �� Value 
 TitlesA  ;Microsoft.Surface.Presentation.Controls.SurfaceScrollViewer 
 Scroll �� RelativeSource �� Mode �� AncestorType;  5Microsoft.Surface.Presentation.Controls.SurfaceWindow �� Path9  3Microsoft.Surface.Presentation.Controls.ScatterView  partsSV��%�  &	        &	     &	     &	 m    �� 5   
   " ��6   .�5      �� 	 � ��$
 18(�6)   �� 5      	 � ��$
 Black"�6+   �� 5      	 � ��

 �   �6+   �� 5      	 � ��$
 1��6)   �� 5      	 � ��$
 Center=�62   �� 5      	 � ��$
 Center=�64   5      �� 5   
   " ��6   .�5      �� 	 � ��$
 18(�6)   �� 5      	 � ��$
 Black"�6+   �� 5      	 � ��$
 1��6)   �� 5       	 � ��

 �   �6+   �� 5!      	 � ��$
 Center=�62   �� 5"      	 � ��$
 Center=�64   5#      �� 5$   
   "  6   .�5%      �� 	 � ��
 6)   ��  �� $ FindAncestor=�"  $ ActualWidth��� 5&      	 � ��$
 2��6)   �� 5'      	 � ��$

 auto��6'   �� 5(      	 � ��$

 10,0q�6'   �� 5)      	 � ��

 �   �6,   �� 5*      	 � ��$
 2q�60   �� 5+      	 � ��$
 Disabled=�6>   5,      �� 5-   
   "  6   .�5.      �� 	 � ��

 ���� 6,   �� 5/      	 � ��$
 2q�60   �� 50      	 � ��
 6&   ��  �� $ FindAncestor=�"  $ ActualWidth��� 51      	 � ��$	
 200��6'   �� 52      	 � ��
 �	#FFE5E5E56+   53      55      .��57      � -   5        $
��Main��57      ���	#FFFFFFFF$
��1920��6.    � ColumnDefinitions 58   
   �� 59      �� 5:      �� 5;      �� 5<       � RowDefinitions 5?   
   �� 5@      $��50 �6   �� 5A      $��50 �6   �� 5B      $	��200 �6   �� 5C      $��50 �6   �� 5D      .+�5G   
   �� $��0��6   $��4��6   ��5H      �� 5I       �� EndPoint$ 0.5,1&�6&    �� 
StartPoint$ 0.5,0&�67   .��5J      �  � Color$ 	#FFBBBBBB��6#    � Offset$ 0Q�65   � 5K      $ 	#FFFFFFFF��6#   $ 1Q�65   5L      5N      �� 5O   
   $��0��6   $��4��6!   $��Center=�5P      $��Center=�61   $��32(�5Q      $��Black"�6"   
���   �	Level 15S      �� 5V   
   $��0��6   #��[  6$   	Promoters6N   �� 5W   
   $��1��6   #��[  6$   RBS6H   �� 5X   
   $��2��6   #��[  6$   CDS6H   �� 5Y   
   $��3��6   #��[  6$   Terminators6P     5[   
   $��0��6    #��[ 60   .��5\        -   5        $��L1_prom��5\      #��[ 6,   6O   5]        5^   
   $��1��6    #��[ 60   .��5_        -   5        $��L1_rbs��5_      #��[ 6+   6N   5`        5a   
   $��2��6    #��[ 60   .��5b        -   5        $��L1_cds��5b      #��[ 6*   6M   5c        5d   
   $��3��6    #��[ 60   .��5e        -   5        $��L1_term��5e      #��[ 6+   5f      5g      �� 5j   
   $��3��6   $��4��6!   #��[ 65   Level 1 Permutations6k   �� 5l   
   -   5        $��L1_buildTabs��5l      $��3��6)   $��2��66   $��4��6G   $��
10,30,10,0q�6[   $��18(�6o   .@�5p      �� -   5        $��Manual��5p      .��5q        $��
10,10,10,0q�6(   #��[ 6<   .��5r        -	   5        $��	L1_manTab��5r   $   $	��550��65   #��[ 6B   5s      5t      5u      �� 5v      -
   5        $��	Automatic��5v      .��5w        $��
10,10,10,0q�6(   #��[ 6<   .��5x        -   5        $��
L1_permTab��5x   $   $	��550��66   #��[ 6C   5y      5z      5{      5|      ;  5Microsoft.Surface.Presentation.Controls.SurfaceButton  5~   
   -   5        $��	permMaker��5~      $��3��6+   $��3��68   $��Right=�6H   $��Generate permutations��6d   {�. $y�Visible=�6�   $��Center=�5      $��	0,11,20,1q�6T   $	��225��6g   
���   �$��Center=�6�   $��18(�6�    � ToolTip$&  Generates L1 Module permutations��5�      ��5�      �� 5�      $ 0.5,1&�6&   $ 0.5,0&�67   .��5�      � $ 	#FFF0F0F0��6#   $ 0Q�65   � 5�      $ 	#FFD9D9D9��6#   $ 1Q�65   5�      5�        5�   
   -   5        $��L1_SV��5�      $��1��6%   $��4��62   $��4��6C    J� 	AllowDrop . 6X   � 5�   
   -   5        $��ProgressIndicator��5�      $y�	Collapsed=�6(   $��4��6?   $��6��6S   ��5�      ��  �� ElementName$ L0��$ ActualWidth���6B   �� $ L0��$ ActualHeight�.+�5�      3   -SurfaceApplication1.CircularProgressIndicator  $��Center=�62   $��Center=�6M   5�      5�      5�      