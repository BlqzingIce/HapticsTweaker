using Zenject;

namespace HapticsTweaker
{
    internal class MenuInstaller : Installer
    {
        public override void InstallBindings()
        {
            Container.Bind<UI.SettingsViewController>().FromNewComponentAsViewController().AsSingle();
            Container.Bind<UI.SettingsFlowCoordinator>().FromNewComponentOnNewGameObject().AsSingle();
            Container.BindInterfacesTo<UI.MenuButtonManager>().AsSingle();
        }
    }

    internal class AppInstaller : Installer
    {
        public override void InstallBindings()
        {
            Container.Bind<PluginConfig>().FromInstance(Plugin.Config).AsSingle();

            Container.BindInterfacesTo<NoteCutPatch>().AsSingle();
            Container.BindInterfacesTo<SliderHapticPatch>().AsSingle();
            Container.BindInterfacesTo<SaberClashPatch>().AsSingle();
            Container.BindInterfacesTo<WallClashPatch>().AsSingle();
        }
    }
}