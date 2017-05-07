using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsTransfer : MonoBehaviour {

    public Settings Config;
    public MenuAnim Menu;

    //UI
    public InputField AutoSaveInterval;
    public Toggle AutoSave;

    public Toggle ShowTurnOverlay;
    public Toggle DoF;

    public void AcceptSettings()
    {
        int.TryParse(AutoSaveInterval.text, out Config.AutoSaveInterval);
        Config.AutoSave = AutoSave.isOn;

        Config.ShowTurnOverlay = ShowTurnOverlay.isOn;
        Config.CameraBlur = DoF.isOn;

        Menu.SwitchTo("Front");
    }

    public void LoadSettings()
    {
        AutoSaveInterval.text = Config.AutoSaveInterval.ToString();
        AutoSave.isOn = Config.AutoSave;

        ShowTurnOverlay.isOn = Config.ShowTurnOverlay;
        DoF.isOn = Config.CameraBlur;
    }

    void Awake()
    {
        Debug.Log("----");
        LoadSettings();
    }
}
