using System;

namespace hospitals.Utilities
{

    public interface IDbInitializer
    {

        void Initialize();
        void ClearDatabase();
        void SeedData();
    }
}
