   M S B A M L   `   `   `  ����  WpfBasic#    WpfBasic.ControlTemplateBasic   5      W SPresentationCore, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5        N� Title$  ControlTemplateBasic��5	       � 	Resources 5
         FocusVisual �� Property �� Value �� StrokeDashArray J� SnapsToDevicePixels  Button.Static.Background �� Color  Button.Static.Border  Button.MouseOver.Background  Button.MouseOver.Border  Button.Pressed.Background  Button.Pressed.Border  Button.Disabled.Background  Button.Disabled.Border 	 Button.Disabled.Foreground 
 ButtonStyle1 �� 
TargetType �� 
TargetType	 � RowDefinitions
 ��Name ��Name �� Triggers P� Property P� Value �� 
TargetName��%�  &	        &	 �     &	 �     &	     &	 8    &	 _    &	 �    &	 �    &	 �    &		 �    &	
 "    7   7  7  7  7  7  7  7  7  7 	 �� 5   
   .�5      ��  � �� 5      �� 5      .R�5      �� $��2q�6$   $	 1 2R�5   $   #��� ��5   $   $
 true��5   $   $��1��5   $   5      5      5      �� 5   
   $ 	#FFDDDDDD��5      �� 5   
   $ 	#FF707070��5      �� 5   
   $ 	#FFBEE6FD��5      �� 5   
   $ 	#FF3C7FB1��5      �� 5    
   $ 	#FFC4E5F6��5!      �� 5"   
   $ 	#FF2C628B��5#      �� 5$   
   $ 	#FFF4F4F4��5%      �� 5&   
   $ 	#FFADB2B5��5'      �� 5(   
   $ 	#FF838383��5)      �� 5*   
   " ��5+      .�5,      ��  �@�FocusVisualStyle8   5-      �� 5.       � ��8  5/      �� 50       � ��8  51      �� 52       � ��# � ��53      �� 54       � ��$ 1q�55      �� 56       � ��$ Center=�57      �� 58       � ��$ Center=�59      �� 5:       � ��$ 1q�5;      �� 5<       � �� 5=      �� 5>      " ��6&   .R�5?      � 	 5@      �� 5A   "   $
��Auto �60   �� 5B   "   .+�5D      �� $��0��6%   $��CustomerDefine��5E   %   �� 5F      $
 border��5G   %   $��1��5F   %   #��z��5H   %   #��z��5I   %   #��z��5J   %   $
 true��5K   %   ._�5L   "   �� $ contentPresenter��63   $|�False��5M   3   #��z��5N   3   #��z��5O   3   $
��True��5P   3   # z 5Q   3   #��z��5R   3   5S      5T       5U      P� 5V       �@��IsDefaulted$
 true��5W   &   . �5X   "   �� $ border��5Y   )   # � ��5Z   )    � ��5[      P� 5\       �@J�IsMouseOver$
 true��5]   &   . �5^   "   �� $ border��5_   )   8   � ��5`   )   �� 5a   "   $ border��5b   )   8   � ��5c   )   5d      P� 5e       � ��$
 true��5f   &   . �5g   "   �� $ border��5h   )   8   � ��5i   )   �� 5j   "   $ border��5k   )   8   � ��5l   )   5m      P� 5n       � {�$ false��5o   &   . �5p   "   �� $ border��5q   )   8   � ��5r   )   �� 5s   "   $ border��5t   )   8   � ��5u   )   �� 5v   "   $ contentPresenter��5w   )   8 	  � ��5x   )   5y      5{      5}      5~      5      .��5�      � .+�5�   
   �� $	��100��6   .+�5�      �� #��� 
 6   ��5�      �� 5�       �� Orientation$ 
Horizontal=�6!   .+�5�      �� $	��Bt1��6!   �� 5�      $	��Bt2��6!   �� 5�      $��Text1��6$   5�      5�      �� 5�      $��Button2��6   5�      5�      5�      