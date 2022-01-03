using AutoBot.Scripts.Utilities.Extensions;
using UnityEngine;
using Zenject;

namespace Actor.Application
{
    public class ActorSamplePresenter : IInitializable
    {
        [Inject] private ActorReference reference;


        public void Initialize() {
            reference.CreateActorButton.BindClick(() => { Debug.Log("Create"); });
        }
    }
}
