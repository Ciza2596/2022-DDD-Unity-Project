using System;
using Actor.Adapter.Controller;
using Actor.Adapter.EventHandler;
using Actor.Application.Component;
using Actor.Application.Preseter;
using Actor.UseCase;
using Actor.UseCase.Repository;
using DDDCore.Implement;
using UnityEngine;
using Zenject;

namespace Actor.Application.Installer
{
    public class ActorMonoInstaller : MonoInstaller
    {
        [Inject] private Setting setting;
        
        public override void InstallBindings() {
            
            DDDInstaller.Install(Container);
            // 4: Application layer
            Container.BindInterfacesAndSelfTo<ActorSamplePresenter>().AsSingle();
            // 3: Adapter layer
            Container.Bind<ActorController>().AsSingle();
            Container.Bind<ActorEventHandler>().AsSingle().NonLazy();
            // 2: UseCase layer
            Container.Bind<IActorRepository>().To<ActorRepository>().AsSingle();
            Container.Bind<CreateActorUseCase>().AsSingle();
            
            //ObjectPool
            Container.Bind<ActorFactory>().AsSingle();
            Container.BindMemoryPool<ActorComponent, ActorComponent.Pool>()
                     .WithInitialSize(setting.PrefabAmount)
                     .FromComponentInNewPrefab(setting.ActorPrefab)
                     .UnderTransformGroup("Actor");
        }
        
        [Serializable]
        public class Setting
        {
            public int        PrefabAmount = 30;
            public GameObject ActorPrefab;
        }
    }
}
