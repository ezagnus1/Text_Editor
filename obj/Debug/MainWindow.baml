   M S B A M L   `   `   `  ����H  DFinalProject2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:FinalProject2FinalProject2  5   	       FinalProject2.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:FinalProject2     5   	   -   5        $��TextEditorWindow��5   	     � Title$  Kedit ~ (new document)��5
   	    � Icon$ icons_/main_icon.png��6(   $��347.576��6E   $	��800��6V    J� CommandBindings 5      )  #System.Windows.Input.CommandBinding  5   
   -   5           Command$ ApplicationCommands.Open��5      6<     5   
   -   5        $ ApplicationCommands.Save��5      6<     5   
   -   5        $  ApplicationCommands.SaveAs��5      6>     5   
   -   5        $ ApplicationCommands.Help��5      6<   .��5      � .+�5   
   ]�  %� IsVirtualizing .  .+�5      c� $	��Top=�6   .@�5      �� $��ApplicationCommands.Open��6   .��5      �� $��icons_/open_file_icon.png��6   $��16��6?   $��16��6J   5      �� 5      $��ApplicationCommands.Save��6   .��5      �� $��icons_/save_icon.png��6   $��16��6:   $��16��6E   5      �� 5      $ ��ApplicationCommands.SaveAs��6   .��5      �� $��icons_/save_as_icon.png��6   $��16��6=   $��16��6H   5      �� 5      -   5        $��cmbx1��5      $��0q�6y   $	��178��6�   .@�5      �� .��5      ��  �� Orientation$ 
Horizontal=�6%   .+�5       �� Open6.   5!      5"      �� 5#      .��5$      �� $ 
Horizontal=�6&   .+�5&      �� Save6.   5'      5(      �� 5)      .��5*      �� $ 
Horizontal=�6%   .+�5+      �� 	Save As61   5,      5-      �� 5.      .��5/      �� $ 
Horizontal=�6%   .+�50      �� Help6.   51      52      53      �� 54      $��ApplicationCommands.Help��6   .��55      �� $��icons_/help_icon.png��6   $��16��6:   $��16��6E   56      57      �� 5:      -   5        $��scrollViewer��5:   �   $��Visible=�6   $��Visible=�6A   $��1,71,0,0q�6i   $
��Auto��6{   $��Stretch=�6�   .��5<      &   System.Windows.Controls.DataGrid  -   5          Name$ datagrid��5<   �   "   VerticalScrollBarVisibility$ Visible=�6   $   HorizontalScrollBarVisibility$ Visible=�6E   	   HeadersVisibility$
	 None=�6m   
   AutoGenerateColumns
 .  $
��Auto��6�   ��6�   ��    Columns 5>      0  *System.Windows.Controls.DataGridTextColumn  5@         
Foreground
 �**��,  &System.Windows.Controls.DataGridColumn   
IsReadOnly .    Width5  /System.Windows.Controls.DataGridLengthConverter$ 80 6R   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6]   �� *line_number+6�     5B      $	 595 6-    69   �� *data+6U     5D      
 �P��$ 90 6@    6K   �� *suffix+6i   5H      5J      5K      �� 5M   
   -	   5         ��Name$ label1��5M      $��Path:��6    $
��Left=�60   $��	20,33,0,0q�6K   $	��Top=�6^   $
��Auto��6v   �� 5N   
   -
   5        $ label2��5N      $��Current Line:��6    $
��Left=�68   $��
387,33,0,0q�6S   $	��Top=�6g   $
��Auto��6   �� 5O   
   -   5        $ label3��5O      $��Size:��6    $
��Left=�60   $��
606,33,0,0q�6K   $	��Top=�6_   $
��Auto��6w    J� RenderTransformOrigin$ 7.329,0.252&�6�   �� 5P   
   $��Commandline ====>��6   $
��Left=�6/   $��	20,64,0,0q�6J   $	��Top=�6]   $	��133��6u   ���	#FFCB08086�   �� 5Q   
   -   5         ��Name$ command_box��5Q      $
��Left=�6'   $��23��6B   $��
172,64,0,0q�6N    �� TextWrapping$
 Wrap=�6b   $	��Top=�6v   $	��404��6�   6�   5R      5T      