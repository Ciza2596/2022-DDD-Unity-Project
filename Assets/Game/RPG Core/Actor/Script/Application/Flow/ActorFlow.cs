using Actor.Adapter.EventHandler;
using Actor.Application.Presenter;
using Zenject;

namespace Actor.Application.Flow
{
    public class ActorFlow: IActorFlow
    {
        [Inject] private ActorFactory         actorFactory;
        [Inject] private ActorSamplePresenter actorSamplePresenter;

        public void WhenActorCreated(string dataId) {
            // Create actor instances with factor
            var actorComponent = actorFactory.Create();
            
            // Display actor details by presenter.
            actorSamplePresenter.ShowActor(actorComponent, dataId);
        }
    }
}

