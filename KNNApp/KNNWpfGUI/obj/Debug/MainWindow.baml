   M S B A M L   `   `   `  ����D  @KNNWpfGUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:KNNWpfGUI	KNNWpfGUI  5   	       KNNWpfGUI.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:KNNWpfGUI     5   	     � Title$  KNNApp��5   	   $	��600��6   $	��800��6%   .��5	      � -   5         �Name$ Details��5	       � ColumnDefinitions 5
   
   �� 5      $��20 �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $
��Auto �6   �� 5      $��20 �6    � RowDefinitions 5   
   �� 5      $��20 �6   �� 5      $��50 �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $
��Auto �6   �� 5      $��20 �6   .+�5!   
   � $��1��6   $��2��6$   $��1��68   .+�5"      �� $��36(�6   $��Comic Sans MS)�6&   Iris Dataset6P   5#      � 5$   
   $��1��6   $��2��6$   $��2��68   .+�5%      �� -   5         ��Name$ IrisInfoButton��5%   .   
������  � Cursor$
 Help��6c   .��5&      � .+�5'      �� $��
irises.png��6   5(      5)      5*      � 5+   
   $��6��6   $��1��6$   .+�5,      �� -   5         ��Name$ AccuracyLabel��5,      $��Courier New)�6J   ��6+   ��  �� Path$ Hello�6J   5-      � 5.   
   $��5��6   $��1��6$   .+�5/      �� -   5        $ GetAccuracyButton��5/   ,   $��KNN Accuracy��6    J� RenderTransformOrigin$ 0.5,0.5&�6g   $��Comic Sans MS)�6�   $
 Hand��6�   ��50      �� 51      	 �� EndPoint$	 0.5,1&�6*   
 �� 
StartPoint$
 0.5,0&�6;   .��52      �  � Color$ Black��6'    � Offset$ 0Q�65   � 53      $ 	#FF97ECD5��6'   $ 1Q�69   54      56      57      � 58   
   $��1��6   $��3��6$   $��3��68   $��5��6E   .+�59      �� $��24(�6   $��Comic Sans MS)�6&   Training Data6P   &   System.Windows.Controls.DataGrid  5:      -   5        $��irisTrainDataBinding��5:      65   5;      � 5<   
   $��4��6   $��3��6$   $��3��68   $��5��6E   .+�5=      �� $��24(�6   $��Comic Sans MS)�6&   Testing Data6O     5>      -   5        $��irisTestDataBinding��5>      64   5?      5A      5B      