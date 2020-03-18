using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Data;
using System.Data.Entity;

namespace Biblioteczka
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        libraryEntities libraryEntities = new libraryEntities();
        int bookID;

        Dictionary<string, string> valuePairs = new Dictionary<string, string>()
        {
            { "Autor", "Author" },
            {"Tytuł", "Tittle" },
            {"Gatunek", "Genre" }
        };

        public MainWindow()
        {
            InitializeComponent();
            keyComboBox.SelectedIndex = 1;
            foreach(var key in valuePairs.Keys)
            {
                keyComboBox.Items.Add(key);
            }
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DbSet<Books> books = libraryEntities.Books;
            var query = from book in books select new { Tytuł = book.Tittle, Autor = book.Author, Gatunek = book.Genre, Mam = book.Have, ChcęPrzeczytać = book.WantRead};
            booksDataGrid.AutoGeneratingColumn += booksDataGrid_AutoGeneratingColumns;
            booksDataGrid.ItemsSource = query.ToList();
        }

        private void booksDataGrid_AutoGeneratingColumns(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if (e.Column.Header.Equals("Autor"))
                e.Column.Width = 150;
            if (e.Column.Header.Equals("Tytuł"))
                e.Column.Width = 190;
            if (e.Column.Header.Equals("Gatunek"))
                e.Column.Width = 100;
        }

        private void clearInputs()
        {
            authorTextBox.Text = "";
            tittleTextBox.Text = "";
            genreComboBox.SelectedIndex = -1;
            haveCheckBox.IsChecked = false;
            wantReadCheckBox.IsChecked = false;
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            if(!string.IsNullOrEmpty(authorTextBox.Text) && !string.IsNullOrEmpty(tittleTextBox.Text) && genreComboBox.SelectedIndex != -1)
            {
                DbSet<Books> books = libraryEntities.Books;

                string have = haveCheckBox.IsChecked == true ? "Tak" : "Nie";
                string wantRead = wantReadCheckBox.IsChecked == true ? "Tak" : "Nie";

                Books newBook = new Books {Tittle = tittleTextBox.Text, Author = authorTextBox.Text, Genre = genreComboBox.Text, Have = have, WantRead = wantRead };

                books.Add(newBook);

                libraryEntities.SaveChanges();
                Window_Loaded(this, null);

                clearInputs();
            }
            else
            {
                string error = "";
                if (string.IsNullOrEmpty(authorTextBox.Text))
                    error += "Nie podano autora\n";
                if (string.IsNullOrEmpty(tittleTextBox.Text))
                    error += "Nie podano tytułu\n";
                if (genreComboBox.SelectedIndex == -1)
                    error += "Wybierz gatunek książki\n";
                MessageBox.Show(error, "Błąd");
            }
        }

        private void booksDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DbSet<Books> books = libraryEntities.Books;
            try
            {
                string tittle = (booksDataGrid.SelectedCells[0].Column.GetCellContent(booksDataGrid.SelectedItem) as TextBlock).Text;
                var query = from book in books where (book.Tittle == tittle) select new { id = book.Id, autor = book.Author, genre = book.Genre, have = book.Have, wantRead = book.WantRead };

                foreach (var i in query)
                {
                    authorTextBox.Text = i.autor;
                    tittleTextBox.Text = tittle;
                    genreComboBox.Text = i.genre;
                    bool have = i.have == "Tak" ? true : false;
                    haveCheckBox.IsChecked = have;
                    bool wantRead = i.wantRead == "Tak" ? true : false;
                    wantReadCheckBox.IsChecked = wantRead;
                    bookID = i.id;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
        }

        private void editButton_Click(object sender, RoutedEventArgs e)
        {
            DbSet<Books> books = libraryEntities.Books;

            var query = books.SingleOrDefault(b => b.Id == bookID);

            if(query != null)
            {
                query.Tittle = tittleTextBox.Text;
                query.Author = authorTextBox.Text;
                query.Genre = genreComboBox.Text;
                string have = haveCheckBox.IsChecked == true ? "Tak" : "Nie";
                query.Have = have;
                string wantRead = wantReadCheckBox.IsChecked == true ? "Tak" : "Nie";
                query.WantRead = wantRead;
                libraryEntities.SaveChanges();
            }         
            Window_Loaded(this, null);
            clearInputs();
        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            DbSet<Books> books = libraryEntities.Books;

            var query = books.SingleOrDefault(b => b.Id == bookID);

            if (query != null)
            {
                books.Remove(query);
                libraryEntities.SaveChanges();
            }
            Window_Loaded(this, null);
        }

        private void showAllButton_Click(object sender, RoutedEventArgs e)
        {
            Window_Loaded(sender, null);
        }

        private void searchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(searchTextBox.Text))
            {
                DbSet<Books> books = libraryEntities.Books;
                var value = valuePairs[keyComboBox.Text];
                string category = value;
                //MessageBox.Show(category.ToString());
                var query = from book in books where book.Tittle.Contains(searchTextBox.Text) select new { Tytuł = book.Tittle, Autor = book.Author, Gatunek = book.Genre, Mam = book.Have, ChcęPrzeczytać = book.WantRead };
                switch (category)
                {
                    case ("Author"):
                        query = from book in books where book.Author.Contains(searchTextBox.Text) select new { Tytuł = book.Tittle, Autor = book.Author, Gatunek = book.Genre, Mam = book.Have, ChcęPrzeczytać = book.WantRead };
                        break;
                    case ("Tittle"):
                        break;
                    case ("Genre"):
                        query = from book in books where book.Genre.Contains(searchTextBox.Text) select new { Tytuł = book.Tittle, Autor = book.Author, Gatunek = book.Genre, Mam = book.Have, ChcęPrzeczytać = book.WantRead };
                        break;
                }
                booksDataGrid.AutoGeneratingColumn += booksDataGrid_AutoGeneratingColumns;
                booksDataGrid.ItemsSource = query.ToList();
            }
            if (string.IsNullOrWhiteSpace(searchTextBox.Text))
            {
                Window_Loaded(null, null);
            }
        }
    }
}
