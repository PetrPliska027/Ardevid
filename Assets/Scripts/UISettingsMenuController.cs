using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering;

namespace UI.SettingsMenu
{
    public class UISettingsMenuController : UIMenuBase
    {
        [SerializeField]
        private GameSettings _gameSettings;
        [SerializeField]
        private GraphicsSettings _graphicsSettigns;
        [SerializeField]
        private AudioSettings _audioSettings;
        [SerializeField]
        private ControlSettings _controlSettings;


    }
}

