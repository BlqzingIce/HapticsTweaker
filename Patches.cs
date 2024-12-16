using Libraries.HM.HMLib.VR;
using SiraUtil.Affinity;
using SiraUtil.Logging;
using UnityEngine;
using Zenject;

namespace HapticsTweaker
{
    internal class NoteCutPatch : IAffinity
    {
        [Inject] readonly SiraLog _log;
        [Inject] private readonly PluginConfig _config;
        private readonly HapticPresetSO preset = ScriptableObject.CreateInstance<HapticPresetSO>();

        [AffinityPrefix]
        [AffinityPatch(typeof(NoteCutHapticEffect), nameof(NoteCutHapticEffect.HitNote))]
        private bool Prefix(SaberType saberType, NoteCutHapticEffect.Type type, HapticFeedbackManager ____hapticFeedbackManager)
        {
            if (!_config.EnableMod) return true;
            switch (type)
            {
                case NoteCutHapticEffect.Type.Normal:
                case NoteCutHapticEffect.Type.ArcHead:
                case NoteCutHapticEffect.Type.ArcTail:
                case NoteCutHapticEffect.Type.ArcHeadAndTail:
                    preset._continuous = false;
                    preset._duration = _config.NormalHapticDuration;
                    preset._strength = _config.NormalHapticStrength;
                    break;
                case NoteCutHapticEffect.Type.ChainHead:
                    preset._continuous = false;
                    preset._duration = _config.ChainHeadHapticDuration;
                    preset._strength =_config.ChainHeadHapticStrength;
                    break;
                case NoteCutHapticEffect.Type.ChainLink:
                    preset._continuous = false;
                    preset._duration = _config.ChainLinkHapticDuration;
                    preset._strength = _config.ChainLinkHapticStrength;
                    break;
                case NoteCutHapticEffect.Type.BadCut:
                    preset._continuous = false;
                    preset._duration = _config.BadCutHapticDuration;
                    preset._strength = _config.BadCutHapticStrength;
                    break;
                case NoteCutHapticEffect.Type.Bomb:
                    preset._continuous = false;
                    preset._duration = _config.BombHapticDuration;
                    preset._strength = _config.BombHapticStrength;
                    break;
                default:
                    _log.Warn("Unknown haptic type, falling back to basegame haptics");
                    return true;
            }
            if (preset._duration != 0 && preset._strength != 0) ____hapticFeedbackManager.PlayHapticFeedback(saberType.Node(), preset);
            return false;
        }
    }

    internal class SliderHapticPatch : IAffinity
    {
        [Inject] private readonly PluginConfig _config;
        readonly HapticPresetSO preset = ScriptableObject.CreateInstance<HapticPresetSO>();

        [AffinityPrefix]
        [AffinityPatch(typeof(SliderHapticFeedbackInteractionEffect), "Vibrate")]
        private bool Prefix(HapticFeedbackManager ____hapticFeedbackManager, SaberType ____saberType, HapticPresetSO ____hapticPreset)
        {
            if (!_config.EnableMod) return true;
            preset._continuous = true;
            preset._duration = 0.01f;
            preset._strength = _config.ArcHapticStrength;
            if (preset._strength != 0) ____hapticFeedbackManager.PlayHapticFeedback(____saberType.Node(), preset);
            return false;
        }
    }

    internal class SaberClashPatch : IAffinity
    {
        [Inject] private readonly PluginConfig _config;

        [AffinityPrefix]
        [AffinityPatch(typeof(SaberClashEffect), "Start")]
        private void Prefix(ref HapticPresetSO ____rumblePreset)
        {
            ____rumblePreset._strength = 0.75f;
            if (!_config.EnableMod) return;
            ____rumblePreset._strength = _config.SaberClashHapticStrength;
        }
    }

    internal class WallClashPatch : IAffinity
    {
        [Inject] private readonly PluginConfig _config;

        [AffinityPrefix]
        [AffinityPatch(typeof(ObstacleSaberSparkleEffectManager), "Start")]
        private void Prefix(ref HapticPresetSO ____rumblePreset)
        {
            ____rumblePreset._strength = 0.75f;
            if (!_config.EnableMod) return;
            ____rumblePreset._strength = _config.WallClashHapticStrength;
        }
    }
}