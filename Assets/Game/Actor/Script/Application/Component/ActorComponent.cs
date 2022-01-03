using System;
using UnityEngine;
using Zenject;

namespace Actor.Application.Component
{
    public class ActorComponent : MonoBehaviour
    {
        private Transform transform;
        
        private void Awake() {
            transform = gameObject.transform;
        }


        public void SetPosition(Vector3 position) {
            transform.position = position;
        }
        
        public class Pool : MonoMemoryPool<ActorComponent>
        {
            protected override void Reinitialize(ActorComponent actorComponent) { }
        }
    }
}
