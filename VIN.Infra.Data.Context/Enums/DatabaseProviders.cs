using System;
using System.Collections.Generic;
using System.Text;

namespace VIN.Infra.Data.Context.Enums
{
    /// <summary>
    /// Lista de Providers / Drivers de conexão disponíveis
    /// </summary>
    public enum DatabaseProviders
    {
        SQL_SERVER = 0,
        ORACLE = 1,
        POSGRE = 2
    }
}
