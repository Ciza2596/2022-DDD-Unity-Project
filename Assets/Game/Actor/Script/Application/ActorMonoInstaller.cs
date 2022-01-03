using Zenject;

namespace Actor.Application
{
    public class ActorMonoInstaller : MonoInstaller
    {
        public override void InstallBindings() {
            Container.BindInterfacesAndSelfTo<ActorSamplePresenter>().AsSingle();
        }
    }

}
