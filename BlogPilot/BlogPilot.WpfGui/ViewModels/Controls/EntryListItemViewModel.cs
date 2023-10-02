using BlogPilot.Services.Domain.TableViews;
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogPilot.WpfGui.ViewModels.Controls;

public partial class EntryListItemViewModel : ObservableObject
{
    public EntryTableView Entry { get; private set; }

    public EntryListItemViewModel(EntryTableView entry)
    {
        Entry = entry;
    }
}
