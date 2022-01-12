using UnityEngine;
using Zenject;

namespace Actor.Application.Component
{
    public class ActorComponent : MonoBehaviour
    {
        private Transform      transform;
        [SerializeField]
        private SpriteRenderer spriteRenderer;
        
        private void Awake() {
            transform = gameObject.transform;
            
        }


        public void SetPosition(Vector3 position) {
            transform.position = position;
        }
        
        public void SetSpriteRenderer(Sprite sprite) {
            spriteRenderer.sprite = sprite;
        }
        
        public class Pool : MonoMemoryPool<ActorComponent>
        {
            protected override void Reinitialize(ActorComponent actorComponent) { }
        }
    }
}
