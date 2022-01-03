﻿using DDDCore.Implement;

namespace Actor.Entity.Event
{
    public class ActorCreated: DomainEvent
    {
        public string ActorId     { get; }
        public object ActorDataId { get; }

        public ActorCreated(string actorId, string actorDataId) {
            ActorId     = actorId;
            ActorDataId = actorDataId;
        }

    }
}
