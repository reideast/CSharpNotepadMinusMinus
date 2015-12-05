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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Notepad__
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private TextFileHandler textFile;

        public MainWindow()
        {
            InitializeComponent();

            CommandBinding newCommandBinding = new CommandBinding(ApplicationCommands.New, newCommandExecuted, newCommandCanExecute);
            CommandBinding openCommandBinding = new CommandBinding(ApplicationCommands.Open, openCommandExecuted, openCommandCanExecute);
            CommandBinding saveCommandBinding = new CommandBinding(ApplicationCommands.Save, saveCommandExecuted, saveCommandCanExecute);
            CommandBinding saveAsCommandBinding = new CommandBinding(ApplicationCommands.SaveAs, saveAsCommandExecuted, saveAsCommandCanExecute);
            CommandBinding closeCommandBinding = new CommandBinding(ApplicationCommands.Close, closeCommandExecuted, closeCommandCanExecute);
            this.CommandBindings.Add(newCommandBinding);
            this.CommandBindings.Add(openCommandBinding);
            this.CommandBindings.Add(saveCommandBinding);
            this.CommandBindings.Add(saveAsCommandBinding);
            this.CommandBindings.Add(closeCommandBinding);

            menuNew.Command = ApplicationCommands.New;
            menuOpen.Command = ApplicationCommands.Open;
            menuSave.Command = ApplicationCommands.Save;
            menuSaveAs.Command = ApplicationCommands.SaveAs;
            menuExit.Command = ApplicationCommands.Close;

            menuUndo.Command = ApplicationCommands.Undo;
            menuRedo.Command = ApplicationCommands.Redo;
            menuCut.Command = ApplicationCommands.Cut;
            menuCopy.Command = ApplicationCommands.Copy;
            menuPaste.Command = ApplicationCommands.Paste;
            menuSelectAll.Command = ApplicationCommands.SelectAll;


            textFile = new TextFileHandler();
        }

        private void saveAsCommandCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void saveAsCommandExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void saveCommandCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if (textFile.isDirty)
                e.CanExecute = true;
            else
                e.CanExecute = false;
        }

        private void saveCommandExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            textFile.Clean();
        }

        private void openCommandCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void openCommandExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void newCommandCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void newCommandExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void closeCommandCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void closeCommandExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            MessageBox.Show("Close");
        }

        private void windowClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (textFile.isDirty == true)
            {
                MessageBox.Show("unclean!");
                e.Cancel = true;
            }
        }

        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            textFile.Dirty();
        }
    }
}
