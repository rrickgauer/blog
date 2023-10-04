using CommunityToolkit.Mvvm.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogPilot.WpfGui.Other;

public interface IMessengerCompliant
{
    //public void RegisterMessages();

    public void RegisterMessages()
    {
        WeakReferenceMessenger.Default.RegisterAll(this);
    }
}
