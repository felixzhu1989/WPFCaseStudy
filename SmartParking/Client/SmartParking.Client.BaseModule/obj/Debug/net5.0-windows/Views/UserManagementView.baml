   M S B A M L   `   `   `  ����Y  USmartParking.Client.BaseModule, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullO,clr-namespace:SmartParking.Client.BaseModuleSmartParking.Client.BaseModule  5      =    7SmartParking.Client.BaseModule.Views.UserManagementView   5      W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      >local,clr-namespace:SmartParking.Client.BaseModule     5      T PPrism.Wpf, Version=8.1.97.5141, Culture=neutral, PublicKeyToken=40ee6c3a2184dc59$prismhttp://prismlibrary.com/  5      !  Prism.Mvvm.ViewModelLocator    AutoWireViewModel  True5       � 	Resources 5       �� MergedDictionaries �� Source�� 5   
    5      �� 5      $[ Upack://application:,,,/SmartParking.Client.Assets;component/Styles/BaseResources.xaml?�6%   �� 5      $Z Tpack://application:,,,/SmartParking.Client.Assets;component/Styles/ButtonStyles.xaml?�6%   �� 5      $Z Tpack://application:,,,/SmartParking.Client.Assets;component/Styles/TextBoxStyle.xaml?�6%   %    5      .��5      � $��20q�6    � RowDefinitions 5   
   �� 5      $��50 �6   �� 5      .+�5   
   �� $��0,0,0,1q�6   
�������5      �� 5   
   $��0��6   $�� ��5      $��Center=�5      $	��300��5      $
��Left=�5          SearchTextBoxStyle#���   5!      �� 5"   
   $��0��6    �� Orientation$ 
Horizontal=�5#      $��Center=�5$      $��Right=�5%      .+�5&      �� $��Refresh��6     IconWithContentButtonStyle#��[ 5'      $	��100��5(      
 � Tag$	 ��5)      $	��5,0q�5*      ��5+      �� *RefreshCommand+�� 5,      $	��Add��6   #��[ 5-      $	��100��5.      $	 ��5/      
��� E����51      �� *
AddCommand+52      � 53   
   $��1��6    54      �� 55      $��30 �6    �� 56      .+�58      �� 
�������6   � 59      $��0��6    � ColumnDefinitions 5:      �� 5;      $��40 �6'   �� 5<      $	��120 �6'   �� 5=      $��2* �6'   �� 5>      �� 5?      $	��150 �6'   .+�5A      �� $	��No.��6   
�������$��Center=�5C      $��Center=�5D      �� 5E      $��Avatar��6   
�������$��0��5G      $��1��5H      $��Center=�5I      $��Center=�5J      �� 5K      $��UserInfo��6   
�������$��0��5M      $��2��5N      $��Center=�5O      $��Center=�5P      �� 5Q      $
��Role��6   
�������$��0��5S      $��3��5T      $��Center=�5U      $��Center=�5V      �� 5W      $��	Operation��6   
�������$��0��5Y      $��4��5Z      $��Center=�5[      $��Center=�5\      5]      �� 5^      $��1��6   ��5_      �� *
UserList+��5`      �� 5a      .R�5b      �  �Name$
 root��6    5c      �� 5d   "   $��40 �63   �� 5e   "   $	��120 �63   �� 5f   "   $��2* �63   �� 5g   "   �� 5h   "   $	��150 �63   .+�5j      �� 
�������$��0,0,0,1q�5k   %   $��10��5l   %   	 J� SnapsToDevicePixels$
	 True��5m   %   �� 5n      $��0��6(   $��Center=�5p   (   $��Center=�5q   (   ��5o   (   �� *Index+5q   (   �� 5r      $��1��6%   $��40��5s   %   $��40��5t   %   
 �� CornerRadius$
 20��5u   %   
�������$��2q�5w   %    J� Effect 5x   "   3  -System.Windows.Media.Effects.DropShadowEffect  5y   &      
BlurRadius$ 10Q�67      ShadowDepth$ 0Q�5z   7      	Direction$ 0Q�5{   7      Color$
 Gray��5|   7      Opacity$	 0.3Q�5}   7   ��5   "   �� 5�   &    �� ImageSource 61   �� *
UserIcon+5�      �� 5�      $��2��6)   $
��0,10q�5�   )   $��Center=�5�   )   $��Center=�5�   )   .+�5�   "   �� $ 
Horizontal=�6-   .+�5�   &   �� $��Center=�5�   0   ��5�   0   �� *
RealName+ �� StringFormat$ RealName: {0}��5�   0   �� 5�   &   $��State: Valid��60   
���iii�$��Center=�5�   0   $
��10,0q�5�   0   5�   #   �� 5�   "   $ 
Horizontal=�6-   .+�5�   &   �� $��Center=�5�   0   
���iii���5�   0   �� *
UserName+$ UserName: {0}��5�   0   �� 5�   &   $��Center=�5�   0   
���iii�$
��10,0q�5�   0   ��5�   0   �� *Age+$ Age: {0}��5�   0   5�   #   �� 5�   "   �� 5�   "   $�[��6&    �� 5�   "    �� Command 6,   �� *
PwdCommand+ �� CommandParameter 5�   ,   �� *UserId+.�6P   Reset Password6`    �� 5�   "   $�]��6&   5�   #   5�      �� 5�      $��3��6)   $��Center=�5�   )   $��Center=�5�   )   .+�5�   "   �� ��6/   �� *Roles+��5�   &   �� 5�   *   .R�5�   .   � 5�   +   ��5�   &   �� 5�   *   .R�5�   .   �� $��3q�5�   8   ��5�   8   �� *
RoleName+5�   8   5�   +   5�   #   �� 5�   "   $
��Left=�6,   $��0,5,0,0q�5�   ,   �� 5�   "   $�[��6&    �� 5�   "    6,   �� *RoleCommand+ 5�   ,   �� .�6I   
Reset Role6U    �� 5�   "   $�]��6&   5�   #   5�      �� 5�      $��4��6)   $��Center=�5�   )   $��Center=�5�   )   $ Vertical=�5�   )   .+�5�   "   �� $	��0,2q�6,   �� 5�   &    60   �� *EditCommand+ 5�   0   �� .�6M   Edit6S   5�   #   �� 5�   "   $	��0,2q�6,   �� 5�   &    60   �� *DeleteCommand+ 5�   0   �� .�6M   Delete6U   5�   #   5�      5�       �� Triggers 5�      P� 5�       P� Property �@J�IsMouseOver P� Value$
 True��6=   . �5�   "   ��  �� 
TargetName$
 root��6)    �� Property � �� �� Value
 ����6f   5�      5�      5�      5�      5�      5�      