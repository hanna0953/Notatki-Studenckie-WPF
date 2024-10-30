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

namespace Notatki_Studenckie_v3
{
    public partial class TopicWindow : Window
    {
        private Topic _topic;
        private bool _isDarkMode = false;

        public TopicWindow(Topic topic)
        {
            InitializeComponent();
            _topic = topic;
            TopicName.Text = _topic.TopicTextDb;
            NormalNote.Text = "Wpisz notatkę..."; // Initialize with a default text
        }

    }
}
