   M S B A M L   `   `   `  ����  
Caerfreton2    ,Caerfreton.MemberSupplementaryDetailsControl   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      .��5      �   � RowDefinitions  5	   
   �� 5
      $��30 �6   �� 5      $��30 �6   �� 5      $��30 �6   �� 5      $��30 �6   �� 5      $��30 �6   �� 5      $��30 �6   �� 5      $��30 �6   �� 5      $��30 �6   �� 5      $��30 �6   �� 5      $��30 �6    � ColumnDefinitions 5   
   �� 5      $	��100 �6   �� 5      $
��200* �6   �� 5      $	��100 �6   �� 5      $
��200* �6   .+�5   
   �� $��0��5      $��0��5      $��Gender��5       �� 5"   
   $��0��5#      $��2��5$      $��Date Of Birth��5%      �� 5'   
   $��1��5(      $��0��5)      $��	NI Number��5*      �� 5,   
   $��1��5-      $��2��5.      $��Mothers Maiden��5/      �� 51   
   $��2��52      $��0��53      $��	User Name��54      �� 56   
   $��2��57      $��2��58      $��Password��59      �� 5;   
   $��0��5<      $��0��5=      $�� ��5>      �� 5@   
   $��3��5A      $��0��5B      $��	Bank Card��5C      �� 5E   
   $��3��5F      $��2��5G      $��Expiry Date��5H      �� 5J   
   $��4��5K      $��0��5L      $��
Occupation��5M      �� 5O   
   $��4��5P      $��2��5Q      $��Blood Group��5R      �� 5T   
   $��5��5U      $��0��5V      $��
Height (m)��5W      �� 5Y   
   $��5��5Z      $��2��5[      $��Weight (kg)��5\      �� 5^   
   $��6��5_      $��0��5`      $��	Member No��5a      �� 5c   
   $��6��5d      $��2��5e      $��Date Joined��5f      �� 5h   
   $��7��5i      $��0��5j      $��Date Approved��5k      �� 5m   
   $��7��5n      $��2��5o      $��	Date left��5p      �� 5r   
   $��8��5s      $��0��5t      $��CU Hours a/c��5u      �� 5w   
   $��8��5x      $��2��5y      $��CU Money a/c��5z      �� 5}   
   $��0��5~      $��1��5      ��5�      ��  �� Path$ PersonalDetailsDep.Gender� �� Mode$ TwoWay=�(  "System.Windows.Controls.DatePicker  5�   
   $��0��5�      $��3��5�         Text 5�      �� $$ PersonalDetailsDep.DateOfBirth�$ TwoWay=��� 5�   
   $��1��5�      $��1��5�      ��5�      �� $! PersonalDetailsDep.NINumber�$ TwoWay=��� 5�   
   $��1��5�      $��3��5�      ��5�      �� $* $PersonalDetailsDep.MothersMaidenName�$ TwoWay=��� 5�   
   $��2��5�      $��1��5�      ��5�      �� $! PersonalDetailsDep.UserName�$ TwoWay=��� 5�   
   $��2��5�      $��3��5�      ��5�      �� $! PersonalDetailsDep.Password�$ TwoWay=��� 5�   
   $��3��5�      $��1��5�      ��5�      �� $' !PersonalDetailsDep.BankCardNumber�$ TwoWay=�  5�   
   $��3��5�      $��3��5�       5�      �� $# PersonalDetailsDep.ExpiryDate�$ TwoWay=��� 5�   
   $��4��5�      $��1��5�      ��5�      �� $# PersonalDetailsDep.Occupation�$ TwoWay=��� 5�   
   $��4��5�      $��3��5�      ��5�      �� $" PersonalDetailsDep.BloodType�$ TwoWay=��� 5�   
   $��5��5�      $��1��5�      ��5�      �� $" PersonalDetailsDep.Height_m_�$ TwoWay=��� 5�   
   $��5��5�      $��3��5�      ��5�      �� $$ PersonalDetailsDep.Weight_kgs_�$ TwoWay=��� 5�   
   $��6��5�      $��1��5�      ��5�      �� $% PersonalDetailsDep.MemberNumber�$ TwoWay=�  5�   
   $��6��5�      $��3��5�       5�      �� $# PersonalDetailsDep.DateJoined�$ TwoWay=�  5�   
   $��7��5�      $��1��5�       5�      �� $% PersonaldetailsDep.DateAccepted�$ TwoWay=�  5�   
   $��7��5�      $��3��5�       5�      �� $! PersonalDetailsDep.DateLeft�$ TwoWay=��� 5�   
   $��8��5�      $��1��5�      ��5�      �� $' !PersonalDetailsDep.CUHoursAccount�$ TwoWay=��� 5�   
   $��8��5�      $��3��5�      ��5�      �� $' !PersonalDetailsDep.CUMoneyAccount�$ TwoWay=�5�      5�      