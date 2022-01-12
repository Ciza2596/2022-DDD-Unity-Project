using Actor.Adapter.Controller;
using Actor.Application.Component;
using Actor.Application.Data;
using AutoBot.Scripts.Utilities.Extensions;
using UnityEngine;
using Zenject;

namespace Actor.Application.Presenter
{
    public class ActorSamplePresenter : IInitializable
    {
        [Inject] private ActorReference    actorReference;
        [Inject] private ActorController   actorController;
        [Inject] private ActorDataOverview actorDataOverview;


        public void Initialize() {
            actorReference.CreateActorButton.BindClick(() => {
                                                           var randomData = actorDataOverview.GetRandomData();
                                                           actorController.CreateActor(randomData.DataID);
                                                       });
        }

        public void ShowActor(ActorComponent actorComponent, string dataId) {
            var position = Random.onUnitSphere * 3;
            actorComponent.SetPosition(position);
            var actorData = actorDataOverview.GetData(dataId);

            if(actorData == null){
                Debug.Log("ActorData is null.");
                return;
            }

            actorComponent.SetSpriteRenderer(actorData.MainSprite);
        }

        public void ShowActorCount() {
            var countText = actorReference.Text;
            var actors    = actorController.GetAllActor();
            countText.text = $"Actor Count: {actors.Count}";
        }
    }
}
