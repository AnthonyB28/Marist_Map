   M S B A M L   `   `   `  ����  ItemCompare#    ItemCompare.ItemVisualization   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      e aMicrosoft.Surface.Presentation, Version=2.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e351s)http://schemas.microsoft.com/surface/2008  5      Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  5      $	��549��5        � 	Resources  5         GotTagStoryboard g� FillBehavior g� 	BeginTime �� 
TargetName �� TargetProperty �� KeyTime �� Value �� 	KeySpline O� KeyTime	 O� Value
 �� 	KeySpline  LoadedStoryboard g� DecelerationRatio g� 
SpeedRatio  ShowPanelStoryboard g� Duration R� KeyTime  System.Windows.Visibility   Visible R� Value  HidePanelStoryboard   Hidden��%x  &	        &	     &	 n    &	 A	    �� 5      $
 Stop=�5	      .��5
      �� $ 00:00:00X�6+   $ 
GotTagGlow��5   %   $H B(Shape.Fill).(GradientBrush.GradientStops)[2].(GradientStop.Color)�5   %   .g�5      �� $ 00:00:00.4000000��6&   $ 	#33CCCCCC��5      �� 5      $ 00:00:00.8000000��6&   $ 	#00CCCCCC��5      $ 0.5,0.5,0.5,1��5      5      U� 5      $ 00:00:00X�6,   $ 
GotTagGlow��5   &   $V P(UIElement.RenderTransform).(TransformGroup.Children)[0].(ScaleTransform.ScaleX)�5   &   .\�5      �� $ 00:00:00.4000000��6'   $		 1.4Q�5      �� 5      $ 00:00:00.8000000��6'   $	 0Q�5      $
 0.5,0.5,0.5,1��5      5      U� 5      $ 00:00:00X�6,   $ 
GotTagGlow��5   &   $V P(UIElement.RenderTransform).(TransformGroup.Children)[0].(ScaleTransform.ScaleY)�5   &   .\�5      �� $ 00:00:00.4000000��6'   $		 1.4Q�5       �� 5!      $ 00:00:00.8000000��6'   $	 0Q�5"      $
 0.5,0.5,0.5,1��5#      5$      U� 5%      $ 00:00:00X�6,   $ 
GotTagGlow��5&   &   $I C(Shape.Fill).(GradientBrush.GradientStops)[2].(GradientStop.Offset)�5'   &   .\�5(      �� $ 00:00:00.4000000��6'   $	 0.844Q�5)      �� 5*      $ 00:00:00.8000000��6'   $	 0.873Q�5+      $
 0.5,0.5,0.5,1��5,      5-      5.      �� 50      $ 00:00:00X�51      $ .5Q�52      $	 .55Q�53      .��54      U� $ 00:00:00X�6,   $
 grid��55   &   $V P(UIElement.RenderTransform).(TransformGroup.Children)[0].(ScaleTransform.ScaleX)�56   &   .\�57      �� $ 00:00:00.3000000��6'   $	 1Q�58      $
 0.402,0.209,0.5,1��59      5:      U� 5;      $ 00:00:00X�6,   $
 grid��5<   &   $V P(UIElement.RenderTransform).(TransformGroup.Children)[0].(ScaleTransform.ScaleY)�5=   &   .\�5>      �� $ 00:00:00.3000000��6'   $	 1Q�5?      $
 0.402,0.209,0.5,1��5@      5A      5B   
   �� 5D   	   $ 
00:00:00.6X�5E      .��5F      U� $ 00:00:00X�6&   $ InformationPanel��5G   &   $U O(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.X)�5H   &   .\�5I   
   �� $ 00:00:00.3000000��6   $	 30Q�5J      5K   	   T� 5L      $ 00:00:00X�6&   $ InformationPanel��6;   $ (UIElement.Visibility)�6d   $ 00:00:00.0010000D�6�   ..�5M   
   i� $ 00:00:00��6!   # Z 64   5N   	   5O      �� 5P      .��5Q      U� $ 00:00:00X�6&   $ InformationPanel��5R   &   $U O(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.X)�5S   &   .\�5T   
   �� $ 00:00:00.1000000��6   $	 0Q�5U      �� 5V   
   $ 00:00:00.4000000��6   $		 -30Q�5W      5X   	   T� 5Y      $ 00:00:00X�6&   $ InformationPanel��6;   $ (UIElement.Visibility)�6d   ..�5Z   
   i� $ 00:00:00��6!   # Z 64   i� 5[   
   $ 00:00:00.4000000��6!   # Z 6<   5\   	   5]      5_       � Triggers 5`      :� 5a       :� RoutedEvent$ s:TagVisualization.GotTag��6   .[�5b      �� -   5         ��Name$&  GotTagStoryboard_BeginStoryboard��5d       �� HandoffBehavior$ Compose=�5b      #��[  5c      5d      �� 5e      -   5        $) #ShowPanelStoryboard_BeginStoryboard��5g      $ Compose=�5e      #��[ 5f      5g      5h      :� 5i      $  s:TagVisualization.LostTag��6   .[�5j      �� $ Compose=�6   #��[ 5k      �� 5l       �� BeginStoryboardName$&  GotTagStoryboard_BeginStoryboard��6   5m      :� 5n      $ FrameworkElement.Loaded��6   .[�5o      �� $ Compose=�6   #��[ 5p      5q      .��5s      � -   5         �Name$
 grid��5s   	   $
��Auto��5t   	   $
��Auto��5u   	   $	��192��5v   	    J� RenderTransformOrigin$ 0.5,0.5&�5w   	    � ColumnDefinitions 5x      �� 5y      $��13 �6   �� 5z      $	��192 �6   �� 5{      $��* �6    � RowDefinitions 5}      �� 5~      $��93 �6   �� 5      $	��192 �6   �� 5�      $��* �6   z�5�      V� 5�      .~�5�   
   ��  �� ScaleX$ 1Q�6    �� ScaleY$ 1Q�6$   �� 5�   
    �� AngleX$ 0Q�6    �� AngleY$ 0Q�6#   �� 5�   
    �� Angle$ 0Q�6   T� 5�   
     T� X$  0Q�6   ! T� Y$! 0Q�6#   5�   	   .+�5�      A� -   5        " A�Name$" TagDownArea��5�        GlowRing#��[ 5�      $��21��5�      $��Stretch=�5�      $��Stretch=�5�      $	��192��5�      $	��192��5�      $��1��5�      $��1��5�      $��1��5�      $��1��5�      ��5�      Z� 5�      A� 5�      -   5        $" 
GotTagGlow��5�      $��Stretch=�5�      $��Stretch=�5�      $	��192��5�      $	��192��5�      $��1��5�      $��1��5�      $ 0.5,0.5&�5�      # J� IsHitTestVisible# .  z�5�      V� 5�   
   .~�5�      �� $	 1.4Q�6   $	 1.4Q�5�      �� 5�      $ 0Q�6   $ 0Q�5�      �� 5�      $ 0Q�6   T� 5�      $  0Q�6   $! 0Q�5�      5�      ��5�      
� 5�   
   .��5�      � $ � Color$$ 	#00FFFFFF��6   % � Offset$% 0.693Q�5�      � 5�      $$ 	#00FFFFFF��6   $% 1Q�5�      � 5�      $$ 	#00FFFFFF��6   $% 0.873Q�5�      5�      5�      �� 5�      -   5        & ��Name$& ItemName��5�      2  ,Microsoft.Surface.Presentation.SurfaceColors'   Accent4BrushKey#��� ' 5�      $��18(�5�      $��Segoe360)�5�      $��Center=�5�      $��Center=�5�      $��1��5�      $��1��5�      $��1��5�      $��1��5�      $��Place item here��5�      5�      � 5�      -   5        $ InformationPanel��5�      $	��278��5�      $	��497��5�      $y�Hidden=�5�      $��Stretch=�5�      $��1��5�      $��17,0,0,0q�5�      $	 0,0&�5�      $��3��5�      $��2��5�       5�      �� 5�   
   $
��Auto �6   �� 5�   
   $��* �6   z�5�      V� 5�   
   .~�5�      �� $ 1Q�6   $ 1Q�5�      �� 5�      $ 0Q�6   $ 0Q�5�      �� 5�      $ 0Q�6   T� 5�      $
  -257Q�6   $! 0Q�5�      5�      .+�5�      �� -   5        ( ��Name$( LeftBackground��5�        ItemBackgroundFill#��[ 5�      $��Stretch=�5�      $
��Auto��5�      $��1��5�      $��1��5�      �� 5�      -	   5        $& ItemBrandPanel��5�      $��Stretch=�5�      $��Bottom=�5�      $��	BrandText��5�        BrandTextStyle#��[ 5�      $��0,0,0,35q�5�      �� 5�      -
   5        $& ItemNamePanel��5�      $��Stretch=�5�      $��Bottom=�5�      $��SomePlaceHolderText��5�      $
��Wrap=�5�        HeadingLabelTextStyle#��[ 5�      $��0,0,0,3q�5�      A  ;Microsoft.Surface.Presentation.Controls.SurfaceScrollViewer  5�      $��Hidden=�6   $��Disabled=�5�      $��1��5�      $��1��5�      ��5�      Z� .��5�   	   � -   5        $ RowHost��5�      5�   	   5�      5�      5�      