using System;

namespace Models
{
    [Serializable]
    public class Entity<TId> {

        public TId Id { get; set; }
    }
}