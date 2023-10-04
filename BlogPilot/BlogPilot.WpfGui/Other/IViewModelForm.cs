using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogPilot.WpfGui.Other;

public interface IViewModelForm<T>
{
    public void SetFormInputValues(T model);
    public T GetFormInputValues();
}
