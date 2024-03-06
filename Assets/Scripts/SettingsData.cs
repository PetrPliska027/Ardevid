using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SerializeField]
public class SettingsData
{
    [SerializeField]
    public class GameSettings
    {
        // Add Settings Here
    }

    [SerializeField]
    public class GraphicsSettings
    {
        public int Resolution = -1;
        public int GraphicsPreset = 3;
        public int FullscreenMode = 2;

        public GraphicsSettings() { }

        public GraphicsSettings(GraphicsSettings graphicsSettings)
        {
            Resolution = graphicsSettings.Resolution;
            GraphicsPreset = graphicsSettings.GraphicsPreset;
            FullscreenMode = graphicsSettings.FullscreenMode;
        }
    }

    [SerializeField]
    public class AudioSettings
    {
        // Add Settings Here
    }

    [SerializeField]
    public class ControlSettings
    {
        // Add Settings Here
    }

    public GameSettings Game = new GameSettings();
    public GraphicsSettings Graphics = new GraphicsSettings();
    public AudioSettings Audio = new AudioSettings();
    public ControlSettings Control = new ControlSettings();
}
