using System.Data.Entity;

namespace System.Data
{
    internal class EntityState
    {
        public static Entity.EntityState Modified { get; internal set; }
    }
}