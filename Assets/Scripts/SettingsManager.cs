using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsManager : Singleton<SettingsManager>
{
    private SettingsData _settings;

    public static SettingsData Settings => Instance._settings;
}
