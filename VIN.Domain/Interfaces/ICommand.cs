using System;
using System.Collections.Generic;
using System.Text;

namespace VIN.Domain.Interfaces
{
    public interface ICommand
    {
        void Execute();
        bool IsValid();
    }
}
