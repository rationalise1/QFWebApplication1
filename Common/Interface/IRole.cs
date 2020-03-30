using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Interface
{
    public interface IRoles
    {
        string ReadDBValues(int id);
        string WriteDBValues(int id, string value);
        string DeleteDBValues(int id);

    }
}
