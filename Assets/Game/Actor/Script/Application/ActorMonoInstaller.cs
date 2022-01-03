using Actor.Adapter;
using Actor.UseCase;
using Actor.UseCase.Repository;
using DDDCore.Implement;
using Zenject;

namespace Actor.Application
{
    public class ActorMonoInstaller : MonoInstaller
    {
        public override void InstallBindings() {
            
            DDDInstaller.Install(Container);
            //layer 4
            Container.BindInterfacesAndSelfTo<ActorSamplePresenter>().AsSingle();
            //layer 3
            Container.Bind<ActorController>().AsSingle();
            //layer 2
            Container.Bind<IActorRepository>().To<ActorRepository>().AsSingle();
            Container.Bind<CreateActorUseCase>().AsSingle();
        }
    }

}
