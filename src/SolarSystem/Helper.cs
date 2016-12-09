using System;

namespace SolarSystem
{
    public static class Helper
    {
        public static string Uid(){
             return Guid.NewGuid().ToString().ToLowerInvariant();
        }
    }
}