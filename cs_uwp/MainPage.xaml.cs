using Microsoft.UI.Xaml.Controls;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// 빈 페이지 항목 템플릿에 대한 설명은 https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x412에 나와 있습니다.

namespace cs_uwp
{
    /// <summary>
    /// 자체적으로 사용하거나 프레임 내에서 탐색할 수 있는 빈 페이지입니다.
    /// </summary>
    public partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            List<String> list = new List<String>();
            list.Add("1");
            list.Add("2");
            list.Add("3");
            //treeView1.ItemsSource = list;

            var tabView = new TabView();
            var itemSource = new List<TabViewItem>
            {
                new TabViewItem{ Header = "Tab 1", Content = new TextBlock{ Text = "Hello Tab 1!"} },
                new TabViewItem{ Header = "Tab 2", Content = new TextBlock{ Text = "Hello Tab 2!"} },
                new TabViewItem{ Header = "Tab 3", Content = new TextBlock{ Text = "Hello Tab 3!"} },
            };
            tabView1.TabItemsSource = itemSource;

        }

        private async void btnTest_Click(object sender, RoutedEventArgs e)
        {
            // https://docs.microsoft.com/en-us/uwp/api/windows.ui.popups.messagedialog?view=winrt-19041
            var messageDialog = new MessageDialog("No internet connection has been found.");
            messageDialog.Commands.Add(new UICommand( "Try again", new UICommandInvokedHandler(this.CommandInvokedHandler)));
            messageDialog.Commands.Add(new UICommand( "Close", new UICommandInvokedHandler(this.CommandInvokedHandler)));

            // Set the command that will be invoked by default
            messageDialog.DefaultCommandIndex = 0;

            // Set the command to be invoked when escape is pressed
            messageDialog.CancelCommandIndex = 1;

            // Show the message dialog
            await messageDialog.ShowAsync();
        }

        //private async void OnSelectionChanged(object sender, TreeViewItemInvokedEventArgs e)
        //{
        //    var messageDialog = new MessageDialog(e.InvokedItem.ToString());
        //    await messageDialog.ShowAsync();
        //}

        private void CommandInvokedHandler(IUICommand command)
        {

        }
    }
}
