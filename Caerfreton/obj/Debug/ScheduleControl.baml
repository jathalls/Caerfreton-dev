   M S B A M L   `   `   `  ����[  WSystem.Windows.Forms, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089Y@clr-namespace:System.Windows.Forms;assembly=System.Windows.FormsSystem.Windows.Forms  5       
Caerfreton    Caerfreton.ScheduleControl   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Owf@clr-namespace:System.Windows.Forms;assembly=System.Windows.Forms     5      .��5	      � -   5          �Name$  ScheduleControlGrid��5	       � RowDefinitions 5
   
   �� 5      $��30 �6   �� 5      $��75 �6   �� 5      $	��100 �6   �� 5      $
��103* �6   .+�5   
   ��  �� Orientation$ 
Horizontal=�5      $��0��5      .+�5      �� $��Name:��6   �� 5      -   5         ��Name$ NameTextBox��5      $��Stretch=�5      ��5      ��  �� Path$ NeedDep.ShortDescription� �� Mode$ TwoWay=�5      �� 5   
   $ Vertical=�5      $��1��5      .+�5      �� $ 
Horizontal=�5       .+�5"      �� $��Start Time:��5#      7  1System.Windows.Forms.Integration.WindowsFormsHost  5$      $��30��6#   $	��100��6/      Child. 5%      )   #System.Windows.Forms.DateTimePicker  -   5        StartDateTimePicker��5&      5'      �� 5(      $��	Duration:��5)      $��20,0,0,0q�6)   �� 5*      -   5        $ DurationText��5+      $��80��5,      $��0��5-      $��Right=�5.      $��Center=�5/      �� 50      -   5         ��Name$ DurationUnitsComboBox��51      $��60��52      .@�54      �� $
��Mins��6#   �� 55      $	��Hrs��6#   56      59      �� 5:      $ 
Horizontal=�5;      .+�5=      �� $��
 End Time:��5>      $��1,0,0,0q�6*     5?      $��30��6#   $	��100��6/   . 5@        -   5        EndDateTimePicker��5A      5B      5C      5D      �� 5F   
   -   5        $ NotesTextBox��5H      $��2��5G      ��5I      �� $ NeedDep.LongDescription�$ TwoWay=��� 5L   
   $��3��5M      $ Vertical=�5N      .+�5O      �� $ 
Horizontal=�5P      .+�5Q      �� $ Vertical=�5R      $��10,0,0,0q�6,   .+�5S      	� -   5         	�Name$ DailyRadioButton��5T      $��Daily��5U      	 d� 	IsChecked$
	 TrueY�5V      	� 5W      -	   5        $ WeeklyRadioButton��5X      $��Weekly��5Y      	� 5Z      -
   5        $ MonthlyRadioButton��5[      $��Monthly��5\      	� 5]      -   5        $ YearlyRadioButton��5^      $��Yearly��5_      5`      �� 5b      $��10,0,0,0q�5c      $ Vertical=�5d      .+�5e      �� $ 
Horizontal=�5f      .+�5g      	� -   5        $ EveryRadioButton��5g   H   $��Every ��6&   $
	 TrueY�67   6H   �� 5h      -   5        $ RepeatTextBox��5h   "   $��20��69   $��1��6D   �� 5i      -   5        
 ��Name$
 RepeatUnits��5i       $��Day(s)��65   5j      �� 5l      $ 
Horizontal=�6!   .+�5m      	� -   5        $ EveryWorkdayRadioButton��5m   >   $��Every Workday��6&   6>   5n      �� 5p      $ 
Horizontal=�6!   .+�5q      	� -   5        $ WeekendsRadioButton��5q   9   $��Weekends��6&   69   5r      �� 5t      $ 
Horizontal=�6!   .+�5u      	� -   5        $ EveryDayRadioButton��5u   6   $��Every��6&   66   5v      �� 5w      $ 
Horizontal=�6!   .+�5x      �� -   5         ��Name$ MonCheckBox��5x   1   $	��Mon��6#   61   �� 5y      -   5        $ TueCheckBox��5y   1   $	��Tue��6#   61   �� 5z      -   5        $ WedCheckBox��5z   1   $	��Wed��6#   61   �� 5{      -   5        $ ThuCheckBox��5{   1   $	��Thu��6#   61   �� 5|      -   5        $ FriCheckBox��5|   1   $	��Fri��6#   61   �� 5}      -   5        $ SatCheckBox��5}   1   $	��Sat��6#   61   �� 5~      -   5        $ SunCheckBox��5~   1   $	��Sun��6#   61   5�      5�      �� 5�      $ Vertical=�5�      $��	-60,0,0,0q�6,   .+�5�      �� $ 
Horizontal=�5�      .+�5�      �� $��Start Date:��5�      (  "System.Windows.Controls.DatePicker  5�      -   5          Name$ StartDatePicker��5�      5�      �� 5�      $ 
Horizontal=�5�      .+�5�      �� $��	End Date:��5�        5�      -   5        $ EndDatePicker��5�      $��5,0,0,0q�64   5�      5�      5�      5�      5�      5�      