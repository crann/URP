using System;
using URP.DataAccess.Scaffolding.Implementation;

namespace URP.DataAccess.Scaffolding
{
    public interface IDatabaseFactory : IDisposable
    {
        ApplicationContext Get();
    }
}
