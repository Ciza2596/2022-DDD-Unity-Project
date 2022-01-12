using Actor.Adapter.Controller;
using Actor.Adapter.EventHandler;
using Actor.Data;
using AutoBot.Scripts.Utilities.Extensions;
using UnityEngine;
using Zenject;

namespace Actor.Application.Preseter
{
    public class ActorSamplePresenter : IInitializable, IActorPresenter
    {
        [Inject] private ActorReference    actorReference;
        [Inject] private ActorController   actorController;
        [Inject] private ActorFactory      actorFactory;
        [Inject] private ActorDataOverview actorDataOverview;


        public void Initialize() {
            actorReference.CreateActorButton.BindClick(() => {
                                                           var randomData = actorDataOverview.GetRandomData();
                                                           actorController.CreateActor(randomData.DataID);
                                                       });
        }

        public void CreateActor(string dataId) {
            var actorComponent = actorFactory.Create();
            var position       = Random.onUnitSphere * 3;
            actorComponent.SetPosition(position);
            var actorData = actorDataOverview.GetData(dataId);

            if(actorData == null){
                Debug.Log("ActorData is null.");
                return;
            }

            actorComponent.SetSpriteRenderer(actorData.MainSprite);
        }
    }
}
