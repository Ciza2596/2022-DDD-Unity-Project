using UnityEngine;
using Zenject;

namespace Actor.Application.Installer
{
    [CreateAssetMenu(fileName = "New ActorDataInstaller",menuName = "DataInstaller/ActorDataInstaller")]
    public class ActorDataInstaller: ScriptableObjectInstaller

    {
        public ActorMonoInstaller.Setting ActorMonoInstallerSetting;

        public override void InstallBindings() {
            Container.BindInstance(ActorMonoInstallerSetting);
        }
    }
}
