using System;
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
using System.Windows.Shapes;

namespace FinalProject2
{
    /// <summary>
    /// Interaction logic for Help.xaml
    /// </summary>
    public partial class Help : Window
    {
        public Help()
        {
            InitializeComponent();
            txtbox.Text += " Save: Overwrites the original file.\nSave As: Saves the file to a path with the name specified at command line or menu command\n" +

                       "Open: Opens a specified file for editing.\nSearch or Find: Allows the user to search for a string.\n" +

                       "#: Skip the line number of the file.\nUp #: Scroll up # lines.\nDown #: Scroll down # lines.\n" +

                       "Left #: Scroll left # lines.\nRight #: Scroll right # lines.\nForward: Scrolls one screenfull towards the end of file.\n" +

                       "Backward: Scrolls one screenfull towards the top of file.\nSetcl #: Defines which line number is the current line.\n" +

                       "Change or Replace: Finds & modifies a searched string, starting with the defined current line.\nHelp: Usage of the commands.\n\n\n" +

                       " NOTE!! : You can use * in change and replace commands to scan all the document.\nIn replace it scans from the current line if you use " +

                       "it in second command, or it scans all the file if you use it as third command";
        }
    }
}
