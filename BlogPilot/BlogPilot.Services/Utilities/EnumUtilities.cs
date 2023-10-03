using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogPilot.Services.Utilities;

public static class EnumUtilities
{

    public static IEnumerable<T> ToCollection<T>() where T : Enum
    {
        return Enum.GetValues(typeof(T)).Cast<T>();
    }

}
