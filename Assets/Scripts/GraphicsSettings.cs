using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace UI.SettingsMenu
{
    public class GraphicsSettings : UISubmenuBase
    {
        [SerializeField]
        private TMP_Dropdown _resolutionDropdown;
        [SerializeField]
        private TMP_Dropdown _graphicsPresetDropdown;
        [SerializeField]
        private TMP_Dropdown _fullScreenModeDropdown;

        public override void Awake()
        {
            base.Awake();
        }

        public void Configure(SettingsData.GraphicsSettings graphicsSettings)
        { 
            _resolutionDropdown.value = graphicsSettings.Resolution;
            _graphicsPresetDropdown.value = graphicsSettings.GraphicsPreset;
            _fullScreenModeDropdown.value = graphicsSettings.FullscreenMode;
        }

        public void Reset()
        {
            SettingsManager.Settings.Graphics = new SettingsData.GraphicsSettings()
            {
                Resolution = ScreenUtilities.GetDefaultResolution()
            };
        }

        private void OnResolutionChanged(int index)
        {
            SettingsManager.Settings.Graphics.Resolution = index;
            ScreenUtilities.ApplyScreenSettings();
            Debug.Log($"Resolution value changed to {index}");
        }

        private void OnGraphicsPresetChanged(int index)
        {
            SettingsManager.Settings.Graphics.GraphicsPreset = index;
            switch (index)
            {
                default:
                    return;
                case 0:
                    SetToPreset(GraphicsSettingsUtilities.LowPreset);
                    break;
                case 1:
                    SetToPreset(GraphicsSettingsUtilities.MediumPreset);
                    break;
                case 2:
                    SetToPreset(GraphicsSettingsUtilities.HighPreset);
                    break;
                case 3:
                    SetToPreset(GraphicsSettingsUtilities.UltraPreset);
                    break;
            }
            Configure(SettingsManager.Settings.Graphics);
        }

        private void SetToPreset(GraphicsSettingsUtilities.GraphicsPresetValues preset)
        {
            // Add all of the quality settings here
        }

        private void SetToCustomPreset()
        {
            _graphicsPresetDropdown.value = (SettingsManager.Settings.Graphics.GraphicsPreset = 4);
        }

        private void OnFullScreenModeChanged(int index)
        {
            SettingsManager.Settings.Graphics.FullscreenMode = index;
            Screen.fullScreenMode = ScreenUtilities.GetFullScreenMode();
            Debug.Log($"FullScreen Mode value changed to {Screen.fullScreenMode}");
        }
    }
}
