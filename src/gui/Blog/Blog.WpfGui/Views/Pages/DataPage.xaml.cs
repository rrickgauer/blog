﻿// This Source Code Form is subject to the terms of the MIT License.
// If a copy of the MIT was not distributed with this file, You can obtain one at https://opensource.org/licenses/MIT.
// Copyright (C) Leszek Pomianowski and WPF UI Contributors.
// All Rights Reserved.

using Blog.WpfGui.ViewModels.Pages;
using Wpf.Ui.Controls;

namespace Blog.WpfGui.Views.Pages;

public partial class DataPage : INavigableView<DataViewModel>
{
    public DataViewModel ViewModel { get; }

    public DataPage(DataViewModel viewModel)
    {
        ViewModel = viewModel;
        DataContext = this;

        InitializeComponent();
    }
}
