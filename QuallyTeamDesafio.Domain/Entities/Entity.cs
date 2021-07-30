using System;

namespace QuallyTeamDesafio.Domain.Entities
{
    public abstract class Entity
    {
        public Guid Id { get; protected set; }

        public DateTime CreationDate { get; protected set; }

        public Entity()
        {
            Id = Guid.NewGuid();
            CreationDate = DateTime.Now;
        }
    }
}
