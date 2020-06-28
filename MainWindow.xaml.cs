using System;
using Microsoft.Win32;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using System.Collections;
using System.Collections.ObjectModel;

namespace FinalProject2
{
    public class datagrid_elements
    {
        public int line_number { get; set; }
        public string data { get; set; }
        public string suffix { get; set; }
    }

    public partial class MainWindow : Window
    {

        double MainWindowHeight, new_windowsize;
        public bool handle = true;
        ObservableCollection<datagrid_elements> data_list = new ObservableCollection<datagrid_elements>();
        string CurrentFilePath;
        int counter_size = 0, currentline=1, f_b_size=0;
        public MainWindow()
        {
            InitializeComponent();
            MainWindowHeight = TextEditorWindow.Height;
            new_windowsize = MainWindowHeight;
            for (int i = 0; i < 30; i++) { data_list.Add(new datagrid_elements { line_number = i+1, data = "", suffix = "=====" });}
            datagrid.ItemsSource = data_list;
            label2.Content = "Current Line: " + currentline;
            label3.Content = "Size: " + 30;
        }

        private void Open_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            label1.Content = "";
            label3.Content = "";
            label2.Content = "";
            counter_size = 0;
            data_list.Clear();
            datagrid.ItemsSource = null;
            string reader = "";
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.Filter = "All files (*.*)|*.*|Rich Text Format (*.rtf)|*.rtf";
            if (dlg.ShowDialog() == true)
            {
                FileStream fileStream = new FileStream(dlg.FileName, FileMode.Open);
                StreamReader file = new StreamReader(fileStream);
                while ((reader = file.ReadLine()) != null)
                {
                    counter_size++;
                    data_list.Add(new datagrid_elements { line_number = counter_size, data = reader, suffix = "=====" }) ;

                }
                CurrentFilePath = dlg.FileName;
                datagrid.ItemsSource = data_list;
                TextEditorWindow.Title = "Kedit ~ " + CurrentFilePath;
                label1.Content = "Path: " + CurrentFilePath;
                label2.Content = "Currentline: " + currentline;
                label3.Content = "Size: " + counter_size;
                fileStream.Close();
            }


        }

        private void Save_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            if (CurrentFilePath == null)
            {
                Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
                datagrid_elements tempgrid = new datagrid_elements();
                string temp_s = "";
                foreach (datagrid_elements element in datagrid.ItemsSource)
                {
                    temp_s += element.data + "\n";
                }
                dlg.Filter = "Text file (*.txt)|*.txt|All files (*.*)|*.*";
                if (dlg.ShowDialog() == true)
                {
                    File.WriteAllText(dlg.FileName, temp_s);

                }
            }

            else
            {
                string temp_s = "";
                foreach (datagrid_elements element in datagrid.ItemsSource)
                {
                    temp_s += element.data + "\n";
                }
                File.WriteAllText(CurrentFilePath, temp_s);

            }

        }

        private void SaveAs_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
            datagrid_elements tempgrid = new datagrid_elements();
            string temp_s = "";
            foreach (datagrid_elements element in datagrid.ItemsSource)
            {
                temp_s += element.data+"\n";
            }
            dlg.Filter = "Text file (*.txt)|*.txt|All files (*.*)|*.*";
            if (dlg.ShowDialog() == true)
            {
                File.WriteAllText(dlg.FileName, temp_s);
               
            }
        }

        private void Help_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            Help window2 = new Help();
            window2.Show();
        }

        private void cmbx1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            System.Windows.Controls.ComboBox cmb = sender as System.Windows.Controls.ComboBox;
            handle = !cmb.IsDropDownOpen;
            Handle();
        }
        private void cmbx1_DropDownClosed(object sender, EventArgs e)
        {

            if (handle) Handle();
            handle = true;
        }

        private void Handle() // COMBOBOX HANDLER
        {
            int f = cmbx1.SelectedIndex;
            switch (f)
            {

                case 0:
                    //Handle for the first combobox item
                    label1.Content = "";
                    label3.Content = "";
                    label2.Content = "";
                    counter_size = 0;
                    data_list.Clear();
                    datagrid.ItemsSource = null;
                    string reader = "";
                    Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
                    dlg.Filter = "All files (*.*)|*.*|Rich Text Format (*.rtf)|*.rtf";
                    if (dlg.ShowDialog() == true)
                    {
                        FileStream fileStream = new FileStream(dlg.FileName, FileMode.Open);
                        StreamReader file = new StreamReader(fileStream);
                        while ((reader = file.ReadLine()) != null)
                        {
                            counter_size++;
                            data_list.Add(new datagrid_elements { line_number = counter_size, data = reader, suffix = "=====" });

                        }
                        CurrentFilePath = dlg.FileName;
                        datagrid.ItemsSource = data_list;
                        TextEditorWindow.Title = "Kedit ~ " + CurrentFilePath;
                        label1.Content = "Path: " + CurrentFilePath;
                        label2.Content = "Currentline: " + currentline;
                        label3.Content = "Size: " + counter_size;
                        fileStream.Close();
                    }

                    break;
                case 1:
                    //Handle for the second combobox
                    if(CurrentFilePath == null)
                    {
                        Microsoft.Win32.SaveFileDialog dlg3 = new Microsoft.Win32.SaveFileDialog();
                        datagrid_elements tempgrid2 = new datagrid_elements();
                        string temp_s2 = "";
                        foreach (datagrid_elements element in datagrid.ItemsSource)
                        {
                            temp_s2 += element.data + "\n";
                        }
                        dlg3.Filter = "Text file (*.txt)|*.txt|All files (*.*)|*.*";
                        if (dlg3.ShowDialog() == true)
                        {
                            File.WriteAllText(dlg3.FileName, temp_s2);

                        }
                    }

                    else
                    {
                        string temp_s3 = "";
                        foreach (datagrid_elements element in datagrid.ItemsSource)
                        {
                            temp_s3 += element.data + "\n";
                        }
                        File.WriteAllText(CurrentFilePath, temp_s3);

                    }

                    break;
                case 2:
                    //Handle for the third combobox

                    Microsoft.Win32.SaveFileDialog dlg2 = new Microsoft.Win32.SaveFileDialog();
                    datagrid_elements tempgrid = new datagrid_elements();
                    string temp_s = "";
                    foreach (datagrid_elements element in datagrid.ItemsSource)
                    {
                        temp_s += element.data + "\n";
                    }
                    dlg2.Filter = "Text file (*.txt)|*.txt|All files (*.*)|*.*";
                    if (dlg2.ShowDialog() == true)
                    {
                        File.WriteAllText(dlg2.FileName, temp_s);

                    }

                    break;

                case 3:
                    Help window2 = new Help();
                    window2.Show();
                    break;
            }

        }

        private void commandline_KeyUp(object sender, System.Windows.Input.KeyEventArgs e) // COMMANDLINE STUFF
        {
            if (e.Key == Key.Enter)
            {
                e.Handled = true;
                var command = command_box.Text;
                string[] temp = command.Split(' ');

                if (temp[0].ToLower() == "save" && temp.Count() > 1 && temp[1].ToLower() == "as")
                {
                    Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
                    datagrid_elements tempgrid = new datagrid_elements();
                    string temp_s = "";
                    foreach (datagrid_elements element in datagrid.ItemsSource)
                    {
                        temp_s += element.data + "\n";
                    }
                    dlg.Filter = "Text file (*.txt)|*.txt|All files (*.*)|*.*";
                    if (dlg.ShowDialog() == true)
                    {
                        File.WriteAllText(dlg.FileName, temp_s);

                    }
                }
                else if (temp[0].ToLower() == "save")
                {
                    if (CurrentFilePath == null)
                    {
                        Microsoft.Win32.SaveFileDialog dlg3 = new Microsoft.Win32.SaveFileDialog();
                        datagrid_elements tempgrid2 = new datagrid_elements();
                        string temp_s2 = "";
                        foreach (datagrid_elements element in datagrid.ItemsSource)
                        {
                            temp_s2 += element.data + "\n";
                        }
                        dlg3.Filter = "Text file (*.txt)|*.txt|All files (*.*)|*.*";
                        if (dlg3.ShowDialog() == true)
                        {
                            File.WriteAllText(dlg3.FileName, temp_s2);

                        }
                    }

                    else
                    {
                        string temp_s3 = "";
                        foreach (datagrid_elements element in datagrid.ItemsSource)
                        {
                            temp_s3 += element.data + "\n";
                        }
                        File.WriteAllText(CurrentFilePath, temp_s3);

                    }
                }

                else if (temp[0].ToLower() == "search" || temp[0].ToLower() == "find")
                {
                    
                    int founds =0,totalfounds=0, line_num,control=0,position=0;
                    string s_str;
                    if(temp.Length == 3)
                    {
                        string[] parts = temp[1].Split('/');
                        s_str = parts[1];

                        if(parts[2] == "*") { line_num = 0; }
                        else { line_num = Int32.Parse(parts[2])-1; }

                        int column_number = Int32.Parse(temp[2]);

                        for(int i=line_num; i < data_list.Count(); i++)
                        {
                            if (control == 0 && data_list[i].data.Substring(column_number).Contains(s_str))
                            {
                                founds = 1;
                                totalfounds++;
                                control++;
                                position = i;
                            }
                            else if (control != 0 && data_list[i].data.Contains(s_str))
                            {
                                founds = 1;
                                totalfounds++;
                                position = i;
                            }
                            control++;
                        }

                        if(founds == 1)
                        {
                            System.Windows.MessageBox.Show(s_str + " is found " + totalfounds + " times.");
                            currentline = position;
                            datagrid.SelectedItem = datagrid.Items[currentline];
                            datagrid.ScrollIntoView(datagrid.Items[currentline]);

                        }
                        else
                        {
                            System.Windows.MessageBox.Show(s_str + " is not found ");
                        }

                    }

                   
                }

                else if (temp[0].Contains("1") || temp[0].Contains("2") || temp[0].Contains("3") || temp[0].Contains("4") || temp[0].Contains("5") || temp[0].Contains("6") ||
                         temp[0].Contains("7") || temp[0].Contains("8") || temp[0].Contains("9"))
                {
                    int number = Int32.Parse(temp[0]);
                    if (number >= counter_size) { number = counter_size; }

                    currentline = number;
                    datagrid.SelectedItem = datagrid.Items[number-1];
                    datagrid.ScrollIntoView(datagrid.Items[number-1]);
                    
                }

                else if (temp[0].ToLower() == "up")
                {
                    int number = Int32.Parse(temp[1]);

                    if(currentline - number <= 1)
                    {
                        currentline = 1;
                        for (int i = 0; i < counter_size; i++) { scrollViewer.LineUp(); }
                    }
                    else
                    {
                        currentline -= number ;
                        for (int i = 0; i < number; i++) { scrollViewer.LineUp();}
                    }
                }

                else if (temp[0].ToLower() == "down")
                {
                    int number = Int32.Parse(temp[1]);

                    if (number + currentline >= counter_size)
                    {
                        currentline = counter_size;
                        for (int i = 0; i < counter_size; i++) { scrollViewer.LineDown(); }
                       
                    }
                    else
                    {
                        currentline += number;
                        for (int i = 0; i < number; i++) { scrollViewer.LineDown();}
                       
                      
                    }

                }
                else if (temp[0].ToLower() == "left")
                {
                    int number = Int32.Parse(temp[1]);

                    for (int i = 0; i < number; i++)
                    {
                        scrollViewer.LineLeft();
                    }

                }
                else if (temp[0].ToLower() == "right")
                {
                    int number = Int32.Parse(temp[1]);
                    for (int i = 0; i < number; i++)
                    {
                        scrollViewer.LineRight();
                    }

                }
                else if (temp[0].ToLower() == "forward")
                {
                    if (MainWindowHeight == new_windowsize)
                    {
                        if (currentline - 9 < 1) { currentline = 1; }
                        else { currentline -= 9; }
                        for (int i = 0; i < 9; i++) { 
                            scrollViewer.LineUp();}

                    }
                    else if (MainWindowHeight > new_windowsize)
                    {
                        double a = (MainWindowHeight - new_windowsize) / 20;
                        int a2 = Convert.ToInt32(a);
                        if (currentline - 9 + a2 < 1) { currentline = 1; }
                        else { currentline += -9 + a2; }
                        for (int i = 0; i < 9 - a2; i++) { 
                              scrollViewer.LineUp();}

                    }
                    else
                    {
                        double a = (new_windowsize - MainWindowHeight) / 20;
                        int a2 = Convert.ToInt32(a);
                        if (currentline - 9 - a2 < 1) { currentline = 1; }
                        else { currentline += -9 - a2; }
                        for (int i = 0; i < 9 + a2; i++) { 
                            scrollViewer.LineUp(); }
                    }
                }



                else if (temp[0].ToLower() == "back")
                {
                    
                    if (MainWindowHeight == new_windowsize)
                    {
                        if (currentline+ 9 >= counter_size) { currentline = counter_size; }
                        else { currentline += 9; }
                        for (int i = 0; i < 9; i++) { 
                            scrollViewer.LineDown(); }
                    }

                    else if (MainWindowHeight > new_windowsize)
                    {
                        double a = (MainWindowHeight - new_windowsize) / 20;
                        int a2 = Convert.ToInt32(a);
                        if (currentline + 9 - a2 > counter_size) { currentline = counter_size; }
                        else { currentline += 9 - a2; }
                        for (int i = 0; i < 9 - a2; i++) { 
                            scrollViewer.LineDown(); }
                    }
                    else
                    {
                        double a = (new_windowsize - MainWindowHeight) / 20;
                        int a2 = Convert.ToInt32(a);
                        if (currentline + 9 + a2 > counter_size) { currentline = counter_size; }
                        else { currentline += 9 + a2; }
                        for (int i = 0; i < 9 + a2; i++) { 
                            scrollViewer.LineDown(); }
                    }
                }

                else if (temp[0].ToLower() == "setcl")
                {
                    int counter = 1;
                    if (Char.IsNumber(temp[1],0) == true)
                    {
                        int number = Int32.Parse(temp[1]);
                        if (number <= counter_size)
                        {
                            currentline = number;
                            foreach (datagrid_elements element in datagrid.ItemsSource)
                            {
                                var row = (DataGridRow)datagrid.ItemContainerGenerator.ContainerFromItem(element) as DataGridRow;
                                row.Foreground = Brushes.Black;
                                if (counter == number) { row.Foreground = Brushes.Red; }
                                counter++;
                            }
                            label2.Content = "Current Line: " + currentline;
                        }
                        else
                        {
                            currentline = counter_size;
                            foreach (datagrid_elements element in datagrid.ItemsSource)
                            {
                                var row = (DataGridRow)datagrid.ItemContainerGenerator.ContainerFromItem(element) as DataGridRow;
                                row.Foreground = Brushes.Black;
                                if (counter == counter_size ) { row.Foreground = Brushes.Red; }
                                counter++;
                            }
                            label2.Content = "Current Line: " + currentline;
                        }
                       
                    }
                    else
                    {
                        System.Windows.MessageBox.Show("Please Enter valid number");
                    }

                }
                

                else if (temp[0].ToLower() == "change" || temp[0].ToLower() == "replace")
                {
                    string s_str,r_str;
                    int found = 0, totalFounds = 0,n_lines;
                    if(temp.Count() == 2 || temp.Count() == 3)
                    {
                        string[] parts = temp[1].Split('/');
                        s_str = parts[1];
                        r_str = parts[2];

                        if(parts[3] == "*") { n_lines = counter_size; }
                        else { n_lines = Int32.Parse(parts[3]); }

                        if(temp[2] != null && temp[2] == "*")
                        {
                            for(int i=0; i < counter_size; i++)
                            {
                                if (data_list[i].data.Contains(s_str))
                                {
                                    found = 1;
                                    totalFounds++;
                                    string new_data = data_list[i].data.Replace(s_str, r_str);
                                    data_list[i].data = new_data;
                                }
                            }
                        }
                        else
                        {
                            for(int i = currentline-1; i<n_lines; i++)
                            {
                                if (i < counter_size)
                                {
                                    if (data_list[i].data.Contains(s_str))
                                    {
                                        found = 1;
                                        totalFounds++;
                                        string new_data = data_list[i].data.Replace(s_str, r_str);
                                        data_list[i].data = new_data;
                                    }
                                }
                            }
                        }
                        if(found == 1)
                        {
                            System.Windows.MessageBox.Show(s_str + " is replaced with " + r_str + " " + totalFounds + " times.");
                            datagrid.ItemsSource = data_list;
                            datagrid.SelectedItem = datagrid.Items[currentline];
                            datagrid.ScrollIntoView(datagrid.Items[currentline]);
                            datagrid.Items.Refresh();
                        }
                        else { System.Windows.MessageBox.Show(s_str + " is not found"); }

                    }
                }

                else if (temp[0].ToLower() == "help")
                {
                    Help window2 = new Help();
                    window2.Show();

                }
                else { System.Windows.MessageBox.Show("Invalid entry!! Please try again and enter new one"); }
            }
        }

        private void Datagrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        ObservableCollection<datagrid_elements> hidden_data = new ObservableCollection<datagrid_elements>();
        ObservableCollection<datagrid_elements> copied_data = new ObservableCollection<datagrid_elements>();
        ArrayList hiddenline_counter = new ArrayList();
        private void datagrid_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
            DataGridCell d = e.OriginalSource as DataGridCell;
            int found = 0;
            int hidden_counter=0;
            int control_line = 1;
            if (e.Key == Key.Enter)
            {
                    foreach(datagrid_elements element in datagrid.ItemsSource)
                    {
                        int n_lines;
                        if (element.suffix[0] == 'i')
                        {
                            string temp = (element.suffix[1]).ToString();
                            n_lines = Int32.Parse(temp);
                            for (int i = control_line; i < n_lines + control_line; i++)
                            {
                                data_list.Insert(i, new datagrid_elements { line_number = i, data = "", suffix = "=====" });
                                found = 1;
                            }
                            break;
                        }

                        else if (element.suffix[0] == 'x')
                        {
                            found = 1;
                            if (!Char.IsNumber(element.suffix[1]) || element.suffix[1] == '1')
                            {
                                hidden_data.Add(data_list[control_line - 1]);
                                hiddenline_counter.Add(control_line - 1);
                                data_list.RemoveAt(control_line - 1);
                                data_list.Insert(control_line - 1, new datagrid_elements { line_number = control_line, data = "HIDDEN ROW", suffix = "=====" });
                            }
                            else
                            {
                                string temp = (element.suffix[1]).ToString();
                                n_lines = Int32.Parse(temp);
                                for (int i = control_line - 1; i < control_line + n_lines - 1; i++)
                                {
                                    hidden_data.Add(data_list[i]);
                                    hiddenline_counter.Add(i);
                                    data_list.RemoveAt(i);
                                    data_list.Insert(i, new datagrid_elements { line_number = control_line, data = "HIDDEN ROW", suffix = "=====" });
                                }
                            }
                            break;
                        }
                        else if (element.suffix[0] == 's' && element.data == "HIDDEN ROW")
                        {
                            found = 1;
                            if (!Char.IsNumber(element.suffix[1]) || element.suffix[1] == '1')
                            {
                                int a = hiddenline_counter.IndexOf(control_line - 1);
                                data_list.RemoveAt(control_line-1);
                                data_list.Insert(control_line-1, hidden_data[a]);
                                hidden_data.RemoveAt(a);
                                hiddenline_counter.RemoveAt(a);
                            }
                            else
                            {
                                string temp = (element.suffix[1]).ToString();
                                n_lines = Int32.Parse(temp);
                                
                                for(int i = control_line - 1; i < control_line + n_lines - 1; i++)
                                {
                                    int a = hiddenline_counter.IndexOf(i);
                                    data_list.RemoveAt(i);
                                    data_list.Insert(i, hidden_data[a]);
                                    hidden_data.RemoveAt(a);
                                    hiddenline_counter.RemoveAt(a); 
                                }
                            }
                            break;
                        }
                        else if (element.suffix[0] == 'a')
                        {
                            found = 1;
                            if (copied_data.Count() != 0)
                            {
                                n_lines = copied_data.Count();
                                hidden_counter = 0;

                                for (int i = control_line; i < control_line + n_lines; i++)
                                {
                                    string s = copied_data[copied_data.Count() - n_lines + hidden_counter].data;
                                    data_list.Insert(i, new datagrid_elements { line_number = control_line, data = s, suffix = "=====" });
                                    hidden_counter++;
                                }
                                copied_data.Clear();
                            }
                            else
                            {
                                System.Windows.MessageBox.Show("There are no copied or moved lines. YOU HAVE TO DO THAT  ");
                            }
                            break;
                        }

                        else if (element.suffix[0] == 'b')
                        {
                            found = 1;
                            if (copied_data.Count() != 0)
                            {
                                n_lines = copied_data.Count();
                                hidden_counter = 0;


                                for (int i = control_line; i < control_line + n_lines; i++)
                                {
                                    string s = copied_data[copied_data.Count() - n_lines + hidden_counter].data;
                                    data_list.Insert(i - 1, new datagrid_elements { line_number = control_line, data = s, suffix = "=====" });
                                    hidden_counter++;
                                }
                                copied_data.Clear();
                            }
                            else { System.Windows.MessageBox.Show("There are no copied or moved lines. YOU HAVE TO DO THAT"); }
                            
                            break;
                        }

                        else if (element.suffix[0] == 'c')
                        {
                            found = 1;
                            if (!Char.IsNumber(element.suffix[1]))
                            {
                               
                                copied_data.Add(data_list[control_line - 1]);
                            }
                            else
                            {
                                
                                string temp = (element.suffix[1]).ToString();
                                n_lines = Int32.Parse(temp);
                                for (int i = control_line - 1; i < n_lines + control_line - 1; i++)
                                {
                                    copied_data.Add(data_list[i]);
                                }
                            }
                            break;
                        }
                        else if (element.suffix[0] == 'm')
                        {
                            found = 1;
                            if (!Char.IsNumber(element.suffix[1]))
                            {
                                copied_data.Add(data_list[control_line - 1]);
                                data_list.RemoveAt(control_line - 1);
                            }
                            else
                            {
                                string temp = (element.suffix[1]).ToString();
                                n_lines = Int32.Parse(temp);
                                for (int i = control_line - 1; i < control_line - 1 + n_lines; i++)
                                {
                                    copied_data.Add(data_list[i]);
                                }
                                for (int i = control_line - 1; i < control_line - 1 + n_lines; i++)
                                {
                                    data_list.RemoveAt(control_line - 1);
                                }
                            }
                            break;
                        }
                        else if (element.suffix[0] == '"')
                        {
                            found = 1;
                            string duplicate = data_list[control_line - 1].data;
                            string num_str = (element.suffix[1]).ToString();
                            int num = Int32.Parse(num_str);
                            for (int i = 0; i < num; i++)
                            {
                                data_list.Insert(control_line, new datagrid_elements { line_number = control_line, data = duplicate, suffix = "=====" });
                            }
                            break;
                        }
                        control_line++;
                        
                    }
                
            }
            if (found == 1) { Suffix_Refresh(); }
        }



        private void Suffix_Refresh()
        {
            for(int i = 0; i < data_list.Count; i++)
            {
                data_list[i].line_number = i+1;
                data_list[i].suffix = "=====";
            }
            datagrid.ItemsSource = data_list;
            datagrid.Items.Refresh();
            label3.Content = "Size: " + (datagrid.Items.Count-1);
        }

        private void Windowsize_changed(object sender, SizeChangedEventArgs e)
        {
            if (f_b_size == 0)
            {
                MainWindowHeight = TextEditorWindow.Height;
                new_windowsize = MainWindowHeight;
                f_b_size++;
            }
        } 

    }
            
}

