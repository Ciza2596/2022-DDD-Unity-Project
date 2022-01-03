using Actor.Adapter.Controller;
using Actor.Adapter.EventHandler;
using AutoBot.Scripts.Utilities.Extensions;
using UnityEngine;
using Zenject;

namespace Actor.Application.Preseter
{
    public class ActorSamplePresenter : IInitializable ,IActorPresenter
    {
        [Inject] private ActorReference  actorReference;
        [Inject] private ActorController actorController;
        [Inject] private ActorFactory    actorFactory;


        public void Initialize() {
            actorReference.CreateActorButton.BindClick(() => actorController.CreateActor("123"));
        }

        public void CreateActor() {

            var actorComponent = actorFactory.Create();
            var position       = Random.onUnitSphere * 3;
            actorComponent.SetPosition(position);

        }
    }
}
