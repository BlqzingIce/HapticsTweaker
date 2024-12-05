using IPA;
using IPA.Config.Stores;
using SiraUtil.Zenject;
using IPALogger = IPA.Logging.Logger;

namespace HapticsTweaker
{
    [Plugin(RuntimeOptions.SingleStartInit)]
    public class Plugin
    {
        internal static PluginConfig Config { get; private set; } = null;
        private IPALogger _log = null;
        private Zenjector _zenjector = null;

        [Init]
        public void Init(IPALogger logger, Zenjector zenjector, IPA.Config.Config config)
        {
            _log = logger;
            _zenjector = zenjector;

            Config = config.Generated<PluginConfig>();

            zenjector.UseMetadataBinder<Plugin>();
            zenjector.UseLogger(logger);
            zenjector.UseHttpService();
        }

        [OnStart]
        public void OnApplicationStart()
        {
            _zenjector.Install<AppInstaller>(Location.App);
            _zenjector.Install<MenuInstaller>(Location.Menu);
        }

        [OnExit]
        public void OnApplicationQuit()
        {

        }
    }
}