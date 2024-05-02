﻿using Blog.Service.Domain.TableView;
using Blog.WpfGui.ViewModels.Pages;
using System.Windows.Input;
using Wpf.Ui.Controls;

namespace Blog.WpfGui.Views.Pages;

/// <summary>
/// Interaction logic for TopicsPage.xaml
/// </summary>
public partial class TopicsPage : INavigableView<TopicsViewModel>
{
    public TopicsViewModel ViewModel { get; }

    public TopicsPage(TopicsViewModel viewModel)
    {
        ViewModel = viewModel;
        DataContext = this;

        InitializeComponent();

        ViewModel.ScrollToItem += OnScrollToItem;
    }

    /// <summary>
    /// Scroll down to the given topic in the table
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void OnScrollToItem(object? sender, TopicTableView e)
    {
        TopicsTable.ScrollIntoView(e);
    }

    private void DataGridCell_MouseDoubleClick(object sender, MouseButtonEventArgs e)
    {
        if (((FrameworkElement)sender).DataContext is TopicTableView topic)
        {
            ViewModel.OnRowSelected(topic);
        }
    }


}
