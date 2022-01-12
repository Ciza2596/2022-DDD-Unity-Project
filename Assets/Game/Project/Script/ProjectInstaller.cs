
using DDDCore.Implement;
using Zenject;

public class ProjectInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        DDDInstaller.Install(Container);
        Container.BindInterfacesAndSelfTo<ProjectFlow>().AsSingle().NonLazy();
    }
}