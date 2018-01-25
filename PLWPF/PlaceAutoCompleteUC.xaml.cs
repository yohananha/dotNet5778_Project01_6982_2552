﻿using System;
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

using System.Threading;


namespace PLWPF
{
    /// <summary>
    /// Interaction logic for PlaceAutoCompleteUC.xaml
    /// </summary>
    public partial class PlaceAutoCompleteUC : UserControl
    {
        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register("Text", typeof(string), typeof(PlaceAutoCompleteUC), new PropertyMetadata(null));


        public PlaceAutoCompleteUC()
        {
            InitializeComponent();
            this.DataContext = this;
        }

        void run(object text)
        {
            if (text != null)
            {
                try
                {
                    List<string> result = GoogleApiFunc.GetPlaceAutoComplete(text.ToString());

                    Action<List<string>> action = setListInvok;
                    Dispatcher.BeginInvoke(action, new object[] { result });
                }
                catch (Exception)
                {


                }
            }
        }

        private void setListInvok(List<string> list)
        {
            this.textComboBox.ItemsSource = null;

            if (list.Count > 0 && list[0].CompareTo(Text) != 0)
            {
                this.textComboBox.ItemsSource = list;
                textComboBox.IsDropDownOpen = true;
            }
            else
            {
                textComboBox.IsDropDownOpen = false;
            }
        }


        private void textInput_TextChanged(object sender, TextChangedEventArgs e)
        {
            Thread thread = new Thread(run);
            thread.Start(Text);
        }

        private void textComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            object item = textComboBox.SelectedItem;
            if (item != null)
            {
                this.Text = item.ToString();
                textComboBox.IsDropDownOpen = false;
            }
        }



        private void textInput_PreviewKeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.Down)
            {
                this.textComboBox.Focus();

            }
        }

        private void textComboBox_PreviewKeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.Up)

                if (this.textComboBox.SelectedIndex == 0)
                    this.textInput.Focus();
        }
    }
}

