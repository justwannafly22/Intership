using System;
using System.Collections.Generic;
using System.Text;

namespace Contracts.DbUp
{
    public interface IDbUp
    {
        void Upgrade();
    }
}
