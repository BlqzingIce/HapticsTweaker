﻿using HMUI;
using Zenject;

namespace HapticsTweaker.UI
{
    internal class SettingsFlowCoordinator : FlowCoordinator
    {
        private MainFlowCoordinator _mainFlowCoordinator = null;
        private SettingsViewController _settingsViewController = null;

        [Inject]
        private void Construct(MainFlowCoordinator mainFlowCoordinator, SettingsViewController settingsViewController)
        {
            _mainFlowCoordinator = mainFlowCoordinator;
            _settingsViewController = settingsViewController;
        }

        protected override void DidActivate(bool firstActivation, bool addedToHierarchy, bool screenSystemEnabling)
        {
            if (firstActivation)
            {
                SetTitle("Haptics Tweaker");
                showBackButton = true;
                ProvideInitialViewControllers(_settingsViewController);
            }
        }

        protected override void BackButtonWasPressed(ViewController topViewController)
        {
            _mainFlowCoordinator.DismissFlowCoordinator(this);
        }
    }
}