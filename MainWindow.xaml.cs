using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.EntityFrameworkCore;

namespace Notatki_Studenckie_v3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool isDarkMode = false;
        NotesContext db;
        //List<QuickNote> quickNotes;
        private NotesContext _context;

        public MainWindow()
        {
            db = new NotesContext();
            InitializeComponent();
            _context = new NotesContext();
            _context.Database.EnsureCreated();
            LoadNotes();
            LoadCategories();
        }
        private void QuickNoteButton_Click(object sender, RoutedEventArgs e)
        {
            string noteText = QuickNoteTextBox.Text.Trim();

            if (!string.IsNullOrEmpty(noteText))
            {
                // Save note to the database
                var quickNote = new QuickNote { QuickTextDb = noteText };
                _context.QuickNotes.Add(quickNote);
                _context.SaveChanges();

                // Add note to the UI
                AddNoteToUI(quickNote);

                // Clear the TextBox for new input
                QuickNoteTextBox.Text = string.Empty;
            }
            else
            {
                MessageBox.Show("Please enter a note.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void LoadNotes()
        {
            var notes = _context.QuickNotes.ToList();
            foreach (var note in notes)
            {
                AddNoteToUI(note);
            }
        }

        private void AddNoteToUI(QuickNote note)
        {
            Grid noteGrid = new Grid();
            noteGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(15, GridUnitType.Star) });
            noteGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });

            TextBlock noteTextBlock = new TextBlock
            {
                Text = note.QuickTextDb,
                FontSize = 12,
                VerticalAlignment = VerticalAlignment.Center,
                Margin = new Thickness(5)
            };
            Grid.SetColumn(noteTextBlock, 0);
            noteGrid.Children.Add(noteTextBlock);

            Button deleteButton = new Button
            {
                Content = "X",
                Height = 24,
                Width = 24,
                VerticalAlignment = VerticalAlignment.Top,
                HorizontalAlignment = HorizontalAlignment.Right,
                Margin = new Thickness(5)
            };
            deleteButton.Click += (s, args) => DeleteNoteFromUI(note, noteGrid);
            Grid.SetColumn(deleteButton, 1);
            noteGrid.Children.Add(deleteButton);

            NotesPanel.Children.Add(noteGrid);
        }

        private void DeleteNoteFromUI(QuickNote note, Grid noteGrid)
        {
            _context.QuickNotes.Remove(note);
            _context.SaveChanges();
            NotesPanel.Children.Remove(noteGrid);
        }

        private void AddCategoryButton_Click(object sender, RoutedEventArgs e)
        {
            string categoryName = CategoryTextBox.Text.Trim();

            if (!string.IsNullOrEmpty(categoryName) && categoryName != "[nazwa kategorii]")
            {
                var category = new Category { CategoryNameDb = categoryName };
                _context.Categories.Add(category);
                _context.SaveChanges();

                CategoryListView.Items.Add(category);

                CategoryTextBox.Text = "[nazwa kategorii]";
                CategoryTextBox.Foreground = Brushes.Black;
            }
            else
            {
                MessageBox.Show("Please enter a valid category name.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void LoadCategories()
        {
            var categories = _context.Categories.ToList();
            foreach (var category in categories)
            {
                CategoryListView.Items.Add(category);
            }
        }

        private void DeleteCategoryButton_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var category = button.CommandParameter as Category;

            if (category != null)
            {
                _context.Categories.Remove(category);
                _context.SaveChanges();
                CategoryListView.Items.Remove(category);
            }
        }

        private void CategoryTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (CategoryTextBox.Text == "[nazwa kategorii]")
            {
                CategoryTextBox.Text = string.Empty;
                CategoryTextBox.Foreground = Brushes.Black;
            }
        }

        private void CategoryTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(CategoryTextBox.Text))
            {
                CategoryTextBox.Text = "[nazwa kategorii]";
                CategoryTextBox.Foreground = Brushes.Black;
            }
        }

        private void CategoryListView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (CategoryListView.SelectedItem is Category selectedCategory)
            {
                CategoryWindow categoryWindow = new CategoryWindow(selectedCategory);
                categoryWindow.Show();
            }
        }

    }
    //private void QuickNoteButton_Click(object sender, RoutedEventArgs e)
    //{

    //    QuickNote addNote = new QuickNote() { QuickTextDb = QuickNoteTextBox.Text };

    //    try
    //    {
    //        db.QuickNotes.Add(addNote);
    //        db.SaveChanges();
    //    }
    //    catch (Exception ex)
    //    {
    //        MessageBox.Show(ex.Message);
    //    }
    //}


    //private void DarkModeButton_Click(object sender, RoutedEventArgs e)
    //{
    //    if (isDarkMode)
    //    {
    //        Application.Current.Resources.MergedDictionaries[0].Source = new Uri("LightMode.xaml", UriKind.Relative);
    //        ((Image)DarkModeButton.Content).Source = new BitmapImage(new Uri("/resources/dark_mode.png", UriKind.Relative));
    //    }
    //    else
    //    {
    //        Application.Current.Resources.MergedDictionaries[0].Source = new Uri("DarkMode.xaml", UriKind.Relative);
    //        ((Image)DarkModeButton.Content).Source = new BitmapImage(new Uri("/resources/light_mode.png", UriKind.Relative));
    //    }

    //    isDarkMode = !isDarkMode;
    //}

    //    private void SortingButton_Click(object sender, RoutedEventArgs e)
    //        {
    //            var sorted = from item in db.Categories.Local orderby item.CategoryNameDb select item;
    //            CategoryListView.ItemsSource = new ObservableCollection<Category>(sorted);
    //        }

    //        private void AddCategoryButton_Click(object sender, RoutedEventArgs e)
    //        {
    //            db.Categories.Add(new Category { CategoryNameDb = "New Category" });
    //            db.SaveChanges();
    //        }

    //        private void DeleteCategoryButton_Click(object sender, RoutedEventArgs e)
    //        {
    //            var button = (Button)sender;
    //            var category = (Category)button.CommandParameter;
    //            db.Categories.Remove(category);
    //            db.SaveChanges();
    //        }
    //    }
}