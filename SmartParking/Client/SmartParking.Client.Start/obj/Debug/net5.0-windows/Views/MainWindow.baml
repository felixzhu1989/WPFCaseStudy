   M S B A M L   `   `   `  ����T  PSmartParking.Client.Start, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:SmartParking.Client.StartSmartParking.Client.Start  5   	   0    *SmartParking.Client.Start.Views.MainWindow   5   	   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   9local'clr-namespace:SmartParking.Client.Start     5   	   Z VPrism.Unity.Wpf, Version=8.1.97.5141, Culture=neutral, PublicKeyToken=40ee6c3a2184dc59T PPrism.Wpf, Version=8.1.97.5141, Culture=neutral, PublicKeyToken=40ee6c3a2184dc59&prismhttp://prismlibrary.com/   5   	     � Title$  
MainWindow��5	   	   $	��850��5
   	   $
��1400��5   	   
������  � WindowStartupLocation$ CenterScreen=�5   	   '  !System.Windows.Shell.WindowChrome   WindowChrome 5        5   
      NonClientFrameEdges$
 None=�6      GlassFrameThickness$ -1q�5         ResizeBorderThickness$ 0q�5       � 	Resources 5       �� 
TargetType   TabCloseButtonTemp ��Name	 �� CornerRadius
 �� Triggers P� Property P� Value �� 
TargetName �� Property �� Value �� 
TargetType � ColumnDefinitions �Name ��Name �� Value �� Binding �� Triggers��%[  &	        '�� �    7   �� 5   
   " ��6   .R�5      �� $
 back��5      $��Center=�5      $��Center=�5      $	 3��5      
������ ._�5      F� +����        � z  z �     z � z     	$��2q�5      #��z��5      $��1��5      5       
 5!      P� 5"       �@J�IsMouseOver$
 True��5#      . �5$      �� $
 back��5&       � ��
 ���� 5'      5)      �� 5*   
   " ��6   .�5+      ��  � �� 5,      �� *DataContext.PageTitle+�� 5-       � ��
 ���� 5.      �� 5/       � ��$	 2,0q�50      6#   �� 52       � �� 53      �� 54      " ��6&   .R�55      � #��z��6    56      �� 57   "   �� 58   "   $
��Auto �63   $��30��59   3   $��10��5:   3   .+�5<      �� #��z��6(   $��Center=�5=   (   $��5,2,2,2q�5>   (   � 5?      $ 
close_grid��5@   #   $��1��5?   #   $��30��5A   #   $y�	Collapsed=�5B   #   .+�5C   "   �� $ 	close_btn��5E   )   #��z��5C   )   8��  $y�	Collapsed=�5F   )   ��5G   )   �� *DataContext.CloseCommand+��5H   )   �� *DataContext.NavUri+5I      5J      
 5K      �� 5M      $
 True��5N   *    5M   *   �� *DataContext.IsCanClose+.a�5O   "   �� $ 
close_grid��6)    � y�$ Visible=�5Q   )   5R      P� 5S       �@J�IsMouseOver$
 True��5T   &   . �5U   "   �� $ 	close_btn��6)    � y�$ Visible=�5W   )   5X      P� 5Y       �@��
IsSelected$
 True��5Z   &   . �5[   "   �� $ 	close_btn��6)    � y�$ Visible=�5]   )   5^      5`      5b       5c      P� 5d       �@J�IsMouseOver$
 True��5e      . �5f      ��  � ��
 �����5g      5h      P� 5i       �@��
IsSelected$
 True��5j      . �5k      ��  � �� �#2499D55l      �� 5m       � ��
 �����5n      5o      5q      5r      .��5t      � 
������ $��1q�5u      .+�5v   
   ]� .+�5w      � $
��Left=�6   $	��230��5x      
������� � RowDefinitions 5z      �� 5{      $
��Auto �6$   �� 5|      .+�5~      �� .+�5      �� $\��Vpack://application:,,,/SmartParking.Client.Assets;component/Images/Halton_Logo_RGB.png��6   $	��200��5�      $��0,30,0,0q�5�      �� 5�      $��Smart Parking��6    ���#2499D5$��20(�5�       $
��Bold"�5�       $��Center=�5�       $
��0,30q�5�       5�      �� 5�      $��1��6!   !  Prism.Regions.RegionManager   
RegionName$ LeftMenuTreeRegion��5�   !   5�      � 5�       5�      �� 5�      $��70 �6$   �� 5�      .+�5�      �� $ MainHeaderRegion��6!   �� 5�      $��1��6   $��0,1,0,0q�5�      $ MainContentRegion��5�      5�      5�      5�      5�      5�      