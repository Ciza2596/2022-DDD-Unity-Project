using Actor.Adapter;
using AutoBot.Scripts.Utilities.Extensions;
using Zenject;

namespace Actor.Application
{
    public class ActorSamplePresenter : IInitializable
    {
        [Inject] private ActorReference  actorReference;
        [Inject] private ActorController actorController;


        public void Initialize() {
            actorReference.CreateActorButton.BindClick(actorController.CreateActor);
        }
    }
}
