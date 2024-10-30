using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Microsoft.EntityFrameworkCore;

namespace Notatki_Studenckie_v3
{
    public partial class CategoryWindow : Window
    {
        private Category _category;
        private NotesContext _context;
        private ObservableCollection<Topic> _topics;
        private bool _isDarkMode = false;

        public CategoryWindow(Category category)
        {
            InitializeComponent();
            _category = category;
            _context = new NotesContext();
            CategoryName.Text = _category.CategoryNameDb;
            LoadTopics();
        }

        private void LoadTopics()
        {
            _topics = new ObservableCollection<Topic>(_context.Topics.Where(t => t.CategoryRefId == _category.CategoryId).ToList());
            TopicsListView.ItemsSource = _topics;
        }

        private void AddTopicButton_Click(object sender, RoutedEventArgs e)
        {
            string topicName = AddTopicTextBox.Text.Trim();

            if (!string.IsNullOrEmpty(topicName))
            {
                var topic = new Topic { TopicTextDb = topicName, CategoryRefId = _category.CategoryId };
                _context.Topics.Add(topic);
                _context.SaveChanges();

                _topics.Add(topic);  // Add the new topic to the ObservableCollection
                AddTopicTextBox.Clear();
            }
            else
            {
                MessageBox.Show("Please enter a valid topic name.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void TopicsListView_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (TopicsListView.SelectedItem is Topic selectedTopic)
            {
                TopicWindow topicWindow = new TopicWindow(selectedTopic);
                topicWindow.Show();
            }
        }

    }
}
