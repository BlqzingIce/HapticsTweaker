namespace HapticsTweaker
{
    public class PluginConfig
    {
        public virtual bool EnableMod { get; set; } = true;
        public virtual float NormalHapticDuration { get; set; } = 0.13f;
        public virtual float NormalHapticStrength { get; set; } = 1.0f;
        public virtual float ChainHeadHapticDuration { get; set; } = 0.13f;
        public virtual float ChainHeadHapticStrength { get; set; } = 1.0f;
        public virtual float ChainLinkHapticDuration { get; set; } = 0.13f;
        public virtual float ChainLinkHapticStrength { get; set; } = 1.0f;
        public virtual float BadCutHapticDuration { get; set; } = 0.13f;
        public virtual float BadCutHapticStrength { get; set; } = 1.0f;
        public virtual float BombHapticDuration { get; set; } = 0.13f;
        public virtual float BombHapticStrength { get; set; } = 1.0f;
        public virtual float ArcHapticStrength { get; set; } = 0.75f;
    }
}