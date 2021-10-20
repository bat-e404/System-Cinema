using System;
using System.Collections.Generic;
using System.Text;

namespace System_Cinema.Interface
{
    public interface IUsuario
    {
        string nombreUsuario { get; set; }
        string password { get; set; }
    }
}
