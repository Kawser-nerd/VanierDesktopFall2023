   M S B A M L   `   `   `  ����D  @week4cls1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:week4cls1	week4cls1  5   	       week4cls1.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:week4cls1     5   	     � Title$  Mini Calculator��5   	   $	��750��6!   $	��800��6.   .��5	      � ���	#FFD3F3F7.+�5
   
   �� -   5         ��Name$ label��5
      $��Mini Calculator��6   $
��Left=�69   $��	94,75,0,0q�6T   $	��Top=�6g    J� RenderTransformOrigin$ 3.272,0.871&�6   $��18(�6�   $��Britannic Bold)�6�   �� 5   
   -   5        $ label1��5      $��
Number One��6    $
��Left=�65   $��
94,143,0,0q�6P   $	��Top=�6d   $��14(�6|   �� 5   
   -   5        $ label2��5      $��Number Two
��6    $
��Left=�6?   $��
94,191,0,0q�6Z   $	��Top=�6n   $��14(�6�   $��26��6�   �� 5   
   -   5         ��Name$ 
textBoxOne��5      $
��Left=�6&   $��225,145,0,0q�6A    �� TextWrapping$
 Wrap=�6V   $	��Top=�6j   $	��175��6�   $��24��6�   �� 5   
   -   5        $ 
textBoxTwo��5      $
��Left=�6&   $��225,194,0,0q�6A   $
 Wrap=�6V   $	��Top=�6j   $	��175��6�   $��20��6�   �� 5   
   -   5         ��Name$ image��5      $
��Left=�6   $	��172��6:   $��
475,48,0,0q�6G   $	��Top=�6[   $	��160��6s   $ 0.5,0.5&�6   $M��G/stock-vector-vector-calculator-cartoon-isolated-drawing-1730868052.jpg��6�   z�5      V� 5      .~�5      �� �� 5      �� 5       �� Angle$ 0.647Q�6&   T� 5      5      5      �� 5   
   -   5         ��Name$ comboBox��5      $
��Left=�6%   $��225,239,0,0q�6@   $	��Top=�6U   $	��175��6m   $��14(�6�    �� SelectedIndex$ 1��6�   ��6y   Z� .@�5      �� $��Addition��6   �� 5      $��Substraction��6   �� 5      $��Multiplication��6   �� 5      $��Division��6   �� 5      $��No Operation��6   5       �� 5!   
   -   5        	 ��Name$	 button��5!      $��Result��6!   $
��Left=�62   $��225,304,0,0q�6M   $	��Top=�6b   $	��175��6z   $��35��6�   $��16(�6�   ���	#FFB6D9F36�   	� 5"   
   -	   5        
 	�Name$
 radioButton��5"      $��Addition��6,   $
��Left=�6?   $��490,251,0,0q�6Z   $	��Top=�6o   	� 5#   
   -
   5        $
 radioButton1��5#      $��Substraction��6,   $
��Left=�6C   $��620,249,0,0q�6^   $	��Top=�6s   	� 5$   
   -   5        $
 radioButton2��5$      $��Multiplication��6,   $
��Left=�6E   $��490,279,0,0q�6`   $	��Top=�6u   	� 5%   
   -   5        $
 radioButton3��5%      $��Division��6,   $
��Left=�6?   $��620,279,0,0q�6Z   $	��Top=�6o   �� 5&   
   -   5        $	 button_radio��5&      $��RadioResult��6'   $
��Left=�6=   $��536,314,0,0q�6X   $	��Top=�6m   $��41��6�   $	��107��6�   ���	#FFD3FFF8$��14(�6�   6�   �� 5(   
   $��75,367,425,160q�6   ���	#FFCAF5E4$	��300��6D   $	��250��6P   .+�5)      �� -   5         ��Name$ checkBoxOne��5)      $��Addition��6,   $��14(�6?   $��5,5,0,5q�6M   6^   �� 5+      -   5        $ checkBoxTwo��5+      $��Substraction��6,   $��14(�6C   $��5,5,0,5q�6Q   6b   �� 5,      -   5        $ checkBoxThree��5,      $��Multiplication��6.   $��14(�6G   $��5,5,0,5q�6U   6f   �� 5-      -   5        $ checkBoxFour��5-      $��Division��6-   $��14(�6@   $��5,5,0,5q�6N   6_   �� 5.      -   5        $	 buttonChkBx��5.      $��CheckBox Result��6*   $��14(�6D   $��5,5,0,5q�6R   ���	#FF8ACECA���	#FFEA342B6�   50      52      53      