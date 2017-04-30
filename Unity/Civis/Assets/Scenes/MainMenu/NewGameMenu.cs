using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

public class NewGameMenu : MonoBehaviour
{

    public InputField SaveName;
    public Dropdown Preset;
    public InputField MapWidth, MapLength, MapHeight;
    public Dropdown RscDensity;
    public Slider Amplitude, Smoothing;
    public Slider Ai;
    public Dropdown Difficulty;
    public InputField Seed;

    private Session _session;
    private Startup _startup;

    void Start()
    {
        _session = GameObject.FindGameObjectWithTag("TempState").GetComponent<Session>();
        _startup = GameObject.Find("MainMenu").GetComponent<Startup>();
    }

    public void Play()
    {
        //convert form data
        int width, length, height;
        int.TryParse(MapWidth.text, NumberStyles.Integer, null, out width);
        int.TryParse(MapLength.text, NumberStyles.Integer, null, out length);
        int.TryParse(MapHeight.text, NumberStyles.Integer, null, out height);

        _session.IsNewGame = true;

        _session.MapWidth = width;
        _session.MapLength = length;
        _session.MapHeight = height;

        _session.MapRscDensity = RscDensity.value;
        _session.MapAi = (int)Ai.value;
        _session.MapAiDifficulty = Difficulty.value;
        _session.Amplitude = Amplitude.value;
        _session.Smoothing = Smoothing.value;

        _session.Seed = Seed.text;
        
      
        _startup.StartGame();
    }

    public void SelectPreset()
    {
        
    }



}
