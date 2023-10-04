using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogPilot.Services.Domain.Model;

public interface IUpdateable
{
    public bool UpdatePropertiesValid();
}
