using System;

namespace DoctorSystem.Shared.Model.Entity
{
    public interface IEntity<TPrimaryKey>
    {
        TPrimaryKey Id { get; set; }
        byte[] RowVersion { get; set; }
        DateTimeOffset TimeStamp { get; set; }
    }

    public abstract class Entity : IEntity<int>
    {
        public int Id { get; set; }
        public byte[] RowVersion { get; set; }
        public DateTimeOffset TimeStamp { get; set; }
    }
}