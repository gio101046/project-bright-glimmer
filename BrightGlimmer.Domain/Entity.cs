using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BrightGlimmer.Domain
{
    public abstract class Entity
    {
        [Key]
        public Guid Id { get; private set; }
        [JsonIgnore]
        public bool IsDeleted { get; protected set; }
        [JsonIgnore]
        public DateTime CreatedDate { get; protected set; }
        [JsonIgnore]
        public DateTime ModifiedDate { get; protected set; }

        public Entity()
        {
            Id = Guid.NewGuid();
            CreatedDate = DateTime.UtcNow;
            ModifiedDate = DateTime.UtcNow;
        }

        public void Delete()
        {
            IsDeleted = true;
        }

        /* TODO: Currently not working when entities modified */
        protected void MarkModified()
        {
            ModifiedDate = DateTime.UtcNow;
        }
    }
}
