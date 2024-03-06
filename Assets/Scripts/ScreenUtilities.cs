using System;
using System.Collections.Generic;
using UnityEngine;

public class ScreenUtilities
{
    public static Vector2Int[] GetAvailableResolutions()
    {
        List<Vector2Int> resolutions = new List<Vector2Int>();
        Resolution[] resolutionsArray = Screen.resolutions;
        for (int i = 0; i < resolutionsArray.Length; i++)
        {
            Vector2Int resolution = new Vector2Int(resolutionsArray[i].width, resolutionsArray[i].height);
            if (!resolutions.Contains(resolution))
            {
                resolutions.Add(resolution);
            }
        }
        return resolutions.ToArray();
    }
    public static int GetDefaultResolution(Vector2Int[] resolutions)
    {
        Vector2Int currentResolution = new Vector2Int(Screen.currentResolution.width, Screen.currentResolution.height);
        for (int i = 0; i < resolutions.Length; i++)
        {
            if (resolutions[i] == currentResolution)
            {
                return i;
            }
        }
        return -1;
    }
    public static int GetDefaultResolution()
    {
        return GetDefaultResolution(GetAvailableResolutions());
    }
    public static FullScreenMode GetFullScreenMode()
    {
        return SettingsManager.Settings.Graphics.FullscreenMode switch
        {
            0 => FullScreenMode.Windowed,
            1 => FullScreenMode.MaximizedWindow,
            _ => FullScreenMode.ExclusiveFullScreen
        };
    }
    public static void ApplyScreenSettings()
    {
        if (SettingsManager.Settings == null)
        {
            return;
        }
        Vector2Int[] availableResolutions = GetAvailableResolutions();
        Vector2Int resolution = default(Vector2Int);
        if (SettingsManager.Settings.Graphics.Resolution != -1)
        {
            try
            {
                resolution = availableResolutions[SettingsManager.Settings.Graphics.Resolution];
            }
            catch (Exception ex)
            {
                Debug.LogWarning("Something went wrong when trying to read and set the resolution, so we are going to reset to the default values.");
                Debug.LogWarning(ex.Message);
                DefaultFallBack();
            }
        }
        else
        {
            DefaultFallBack();
        }
        Vector2Int vector2Int = new Vector2Int(Screen.width, Screen.height);
        if (vector2Int.x != resolution.x || vector2Int.y != resolution.y || Screen.fullScreenMode != GetFullScreenMode())
        {
            Screen.SetResolution(resolution.x, resolution.y, GetFullScreenMode());
        }
        void DefaultFallBack()
        {
            SettingsManager.Settings.Graphics.Resolution = GetDefaultResolution();
            resolution = availableResolutions[SettingsManager.Settings.Graphics.Resolution];
        }
    }

}
