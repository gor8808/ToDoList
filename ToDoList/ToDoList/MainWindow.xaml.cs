using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace ToDoList
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        int tasksN = 0;
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SolidColorBrush blackBorderBrush = new SolidColorBrush(Colors.Black);

            Thickness borderThickness = new Thickness(0, 0, 0, 1);

            GridLength gridLength1 = new GridLength(1, GridUnitType.Star);
            GridLength gridLength4 = new GridLength(4, GridUnitType.Star);


            Grid grid = new Grid();
            grid.Width = 700;
            ColumnDefinition c1 = new ColumnDefinition();
            ColumnDefinition c2 = new ColumnDefinition();
            ColumnDefinition c4 = new ColumnDefinition();
            ColumnDefinition c3 = new ColumnDefinition();

            c1.Width = gridLength1;
            c2.Width = gridLength1;
            c3.Width = gridLength4;
            c1.Width = gridLength1;

            grid.ColumnDefinitions.Add(c1);
            grid.ColumnDefinitions.Add(c2);
            grid.ColumnDefinitions.Add(c3);
            grid.ColumnDefinitions.Add(c4);

            TextBlock textBlock = new TextBlock();
            textBlock.SetValue(Grid.ColumnProperty, 0);
            textBlock.TextAlignment = TextAlignment.Center;
            textBlock.Text = DataPicker.Text;


            CheckBox checkBox = new CheckBox();
            checkBox.SetValue(Grid.ColumnProperty, 1);
            checkBox.HorizontalAlignment = HorizontalAlignment.Center;
            checkBox.Click += CheckBox_Clicked;


            TextBlock taskDescription = new TextBlock();
            taskDescription.SetValue(Grid.ColumnProperty, 2);
            taskDescription.TextAlignment = TextAlignment.Center;
            taskDescription.Text = TaskDesription.Text;


            Button button = new Button();
            button.SetValue(Grid.ColumnProperty, 3);
            button.Background = Brushes.DarkRed;
            button.Click += DeleteTask;
            button.Content = "X";
            button.SetValue(NameProperty, "DelButton_" + tasksN);


            grid.Children.Add(textBlock);
            grid.Children.Add(checkBox);
            grid.Children.Add(taskDescription);
            grid.Children.Add(button);



            ListViewItem listViewItem = new ListViewItem();
            listViewItem.SetValue(NameProperty, "ListItem_" + tasksN);
            listViewItem.Content = grid;
            listViewItem.BorderBrush = blackBorderBrush;
            listViewItem.BorderThickness = borderThickness;
            Tasks.Items.Add(listViewItem);

            tasksN++;
        }

        private void CheckBox_Clicked(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Clicked");
        }

        private void DeleteTask(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            int delIndex = Convert.ToInt32(button.Name[button.Name.Length - 1]);
            MessageBoxResult result = MessageBox.Show(button.Name);

        }
    }
}
