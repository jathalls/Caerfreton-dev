   M S B A M L   `   `   `  ����E  ACaerfreton, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:Caerfreton
Caerfreton  5      #    Caerfreton.BasicPersonControl   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      'myclr-namespace:Caerfreton     5      .��5	      �   � RowDefinitions  5
   
   �� 5      $��80 �6   �� 5      $	��220 �6   �� 5      $
��110* �6   .+�5   
      Caerfreton.NameControl  -   5          Name$ FullnameControl��5      $��0��5      $��0,5,10,0q�5         NameDep 5      ��  �� Path$ NameDep� �� Mode$ TwoWay=�5         Caerfreton.AddressControl  5   
   -   5          Name$ FullAddressControl��5      $��1��5      $��0,5,10,0q�5   )   $	��Top=�5      $	��220��5         
AddressDep 5      �� $ 
AddressDep�$ TwoWay=�5      &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ ContactDetailsDatagrid��5      $��2��5      5!      5$      5%      