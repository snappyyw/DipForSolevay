   M S B A M L   `   `   `  ����>  :Dip, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:SolevayApp.WindowsSolevayApp.Windows  5   	   $    SolevayApp.Windows.AdminWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:SolevayApp.Windows     5   	     � Title$*  $Главное окно админа��5   	   $	��450��6%   $	��800��62   .��5	      � .+�5
   
   �� 
�������$��1q�6%   $��Center=�69   $��68��6V   $��0,-1,0,0q�6b   $	��Top=�6t   $	��799��6�   ���	#FFE1F0FF._�5      �� -   5        $��lable��5      $
��Left=�6!   $��9,0,0,0q�6<   $��Center=�6M   $��24(�6h   5      &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ 	dateGrid1��5      $��
0,71,208,3q�6&      AutoGenerateColumns .     Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Роль��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6L   1  +System.Windows.Controls.DataGridBoundColumn   Binding 63   �� *role+6L     5      $ 
Логин��6%   $ * 6N    64   �� *login+6N     5      $ ФИО��6%   $ * 6J    62   �� *FIO+6J     5      $: 4Дата начала рабты в компании��6%   $ * 6j    6K   �� *
start_date+6j   5      �� 5   
   -   5        $��Добавить��5      $
��Left=�6$   $	��Top=�6?   $��53��6W   $	��193��6c   ���	#FF546B82
������� J� Opacity$ 0.995Q�6�   $��20(�6�   $��
597,82,0,0q�6�   ��6�   Z� 6�   �� 5   
   -   5        $��
Выйти��5      $
��Left=�6!   $	��Top=�6<   $��53��6T   $	��193��6`   ���	#FF546B82
�������$ 0.995Q�6�   $��20(�6�   $��597,367,0,0q�6�   ��6�   Z� 6�   �� 5   
   -   5        $��Изменить��5      $
��Left=�6$   $	��Top=�6?   $��53��6W   $	��193��6c   ���	#FF546B82
�������$ 0.995Q�6�   $��20(�6�   $��597,140,0,0q�6�   ��6�   Z� 6�   �� 5   
   -   5        $��Удалить��5      $
��Left=�6#   $	��Top=�6>   $��53��6V   $	��193��6b   ���	#FF546B82
�������$ 0.995Q�6�   $��20(�6�   $��597,198,0,0q�6�   ��6�   Z� 6�   �� 5   
   -   5        $��Обновить��5      $
��Left=�6$   $	��Top=�6?   $��53��6W   $	��193��6c   ���	#FF546B82
�������$ 0.995Q�6�   $��20(�6�   $��597,256,0,0q�6�   ��6�   Z� 6�   5      5      