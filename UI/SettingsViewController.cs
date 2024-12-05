using BeatSaberMarkupLanguage.Attributes;
using BeatSaberMarkupLanguage.ViewControllers;
using Libraries.HM.HMLib.VR;
using System;
using UnityEngine;
using UnityEngine.XR;
using Zenject;

namespace HapticsTweaker.UI
{
    [ViewDefinition("HapticsTweaker.UI.SettingsView.bsml")]
    internal class SettingsViewController : BSMLAutomaticViewController
    {
        [Inject] private PluginConfig _config = null;
        [Inject] private HapticFeedbackManager _hapticFeedbackManager = null;
        readonly HapticPresetSO preset = ScriptableObject.CreateInstance<HapticPresetSO>();

        [UIAction("d")]
        protected string DurationFormat(float value)
        {
            return $"{value:0.00#}s";
        }

        [UIAction("s")]
        protected string StrengthFormat(float value)
        {
            return $"{value:0.00#}%";
        }

        [UIValue("enable-mod")]
        protected bool EnableMod
        {
            get => _config.EnableMod;
            set => _config.EnableMod = value;
        }

        [UIValue("normal-duration")]
        protected float NormalHapticDuration
        {
            get => _config.NormalHapticDuration;
            set => _config.NormalHapticDuration = (float)Math.Round(value, 3);
        }

        [UIValue("normal-strength")]
        protected float NormalHapticStrength
        {
            get => _config.NormalHapticStrength;
            set => _config.NormalHapticStrength = (float)Math.Round(value, 3);
        }

        [UIValue("chainhead-duration")]
        protected float ChainHeadHapticDuration
        {
            get => _config.ChainHeadHapticDuration;
            set => _config.ChainHeadHapticDuration = (float)Math.Round(value, 3);
        }

        [UIValue("chainhead-strength")]
        protected float ChainHeadHapticStrength
        {
            get => _config.ChainHeadHapticStrength;
            set => _config.ChainHeadHapticStrength = (float)Math.Round(value, 3);
        }

        [UIValue("chainlink-duration")]
        protected float ChainLinkHapticDuration
        {
            get => _config.ChainLinkHapticDuration;
            set => _config.ChainLinkHapticDuration = (float)Math.Round(value, 3);
        }

        [UIValue("chainlink-strength")]
        protected float ChainLinkHapticStrength
        {
            get => _config.ChainLinkHapticStrength;
            set => _config.ChainLinkHapticStrength = (float)Math.Round(value, 3);
        }

        [UIValue("badcut-duration")]
        protected float BadCutHapticDuration
        {
            get => _config.BadCutHapticDuration;
            set => _config.BadCutHapticDuration = (float)Math.Round(value, 3);
        }

        [UIValue("badcut-strength")]
        protected float BadCutHapticStrength
        {
            get => _config.BadCutHapticStrength;
            set => _config.BadCutHapticStrength = (float)Math.Round(value, 3);
        }

        [UIValue("bomb-duration")]
        protected float BombHapticDuration
        {
            get => _config.BombHapticDuration;
            set => _config.BombHapticDuration = (float)Math.Round(value, 3);
        }

        [UIValue("bomb-strength")]
        protected float BombHapticStrength
        {
            get => _config.BombHapticStrength;
            set => _config.BombHapticStrength = (float)Math.Round(value, 3);
        }

        [UIValue("arc-strength")]
        protected float ArcHapticStrength
        {
            get => _config.ArcHapticStrength;
            set => _config.ArcHapticStrength = (float)Math.Round(value, 3);
        }

        [UIAction("normal_button_clicked")]
        private void Normal_Button_Clicked()
        {
            preset._continuous = false;
            preset._duration = _config.NormalHapticDuration;
            preset._strength = _config.NormalHapticStrength;
            if (preset._duration != 0 && preset._strength != 0)
            {
                _hapticFeedbackManager.PlayHapticFeedback(XRNode.RightHand, preset);
                _hapticFeedbackManager.PlayHapticFeedback(XRNode.LeftHand, preset);
            }
        }

        [UIAction("badcut_button_clicked")]
        private void BadCut_Button_Clicked()
        {
            preset._continuous = false;
            preset._duration = _config.BadCutHapticDuration;
            preset._strength = _config.BadCutHapticStrength;
            if (preset._duration != 0 && preset._strength != 0)
            {
                _hapticFeedbackManager.PlayHapticFeedback(XRNode.RightHand, preset);
                _hapticFeedbackManager.PlayHapticFeedback(XRNode.LeftHand, preset);
            }
        }

        [UIAction("chainhead_button_clicked")]
        private void ChainHead_Button_Clicked()
        {
            preset._continuous = false;
            preset._duration = _config.ChainHeadHapticDuration;
            preset._strength = _config.ChainHeadHapticStrength;
            if (preset._duration != 0 && preset._strength != 0)
            {
                _hapticFeedbackManager.PlayHapticFeedback(XRNode.RightHand, preset);
                _hapticFeedbackManager.PlayHapticFeedback(XRNode.LeftHand, preset);
            }
        }

        [UIAction("chainlink_button_clicked")]
        private void ChainLink_Button_Clicked()
        {
            preset._continuous = false;
            preset._duration = _config.ChainLinkHapticDuration;
            preset._strength = _config.ChainLinkHapticStrength;
            if (preset._duration != 0 && preset._strength != 0)
            {
                _hapticFeedbackManager.PlayHapticFeedback(XRNode.RightHand, preset);
                _hapticFeedbackManager.PlayHapticFeedback(XRNode.LeftHand, preset);
            }
        }

        [UIAction("bomb_button_clicked")]
        private void Bomb_Button_Clicked()
        {
            preset._continuous = false;
            preset._duration = _config.BombHapticDuration;
            preset._strength = _config.BombHapticStrength;
            if (preset._duration != 0 && preset._strength != 0)
            {
                _hapticFeedbackManager.PlayHapticFeedback(XRNode.RightHand, preset);
                _hapticFeedbackManager.PlayHapticFeedback(XRNode.LeftHand, preset);
            }
        }

        [UIAction("arc_button_clicked")]
        private void Arc_Button_Clicked()
        {
            preset._continuous = false;
            preset._duration = 1.0f;
            preset._strength = _config.ArcHapticStrength;
            if (preset._duration != 0 && preset._strength != 0)
            {
                _hapticFeedbackManager.PlayHapticFeedback(XRNode.RightHand, preset);
                _hapticFeedbackManager.PlayHapticFeedback(XRNode.LeftHand, preset);
            }
        }
    }
}