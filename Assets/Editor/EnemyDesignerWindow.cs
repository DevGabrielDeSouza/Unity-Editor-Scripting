using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Types;

public class EnemyDesignerWindow : EditorWindow {

    Texture2D headerSectionTexture;
    Texture2D mageSectionTexture;
    Texture2D warriorSectionTexture;
    Texture2D rogueSectionTexture;

    Color headerSectionColor = new Color(13f/255f, 32f/255f, 44f/255f, 1f);
    
	//Color headerSectionColor;

    Rect headerSection;
    Rect mageSection;
    Rect warriorSection;
    Rect rogueSection;


    private static MageData mageData;
    public static MageData MageInfo{
        get{
            return mageData;
        }
    }

    private static WarriorData warriorData;
    public static WarriorData WarriorInfo{
        get
        {
            return warriorData;
        }
    }

    private static RogueData rogueData;
    public static RogueData RogueInfo
    {
        get
        {
            return rogueData;
        }
    }


	[MenuItem("Window/Enemy Designer")]
	static void OpenWindow(){
		EnemyDesignerWindow window = (EnemyDesignerWindow)GetWindow(typeof (EnemyDesignerWindow));
		window.minSize = new Vector2(600, 300);
		window.Show();
	}

	/// <summary>
	/// This function is called when the object becomes enabled and active.
	/// </summary>
	void OnEnable()
	{
		InitTextures();
        InitData();
	}


    void InitData(){
        mageData = (MageData)ScriptableObject.CreateInstance(typeof(MageData));
        warriorData = (WarriorData)ScriptableObject.CreateInstance(typeof(WarriorData));
        rogueData = (RogueData)ScriptableObject.CreateInstance(typeof(RogueData));
    }


    /// <summary>
    /// Initializes Texture2D values
    /// </summary>
    void InitTextures(){
		headerSectionTexture = new Texture2D(1,1);

		Color tempColor;

		if(ColorUtility.TryParseHtmlString("#B0BEC5", out tempColor)){
			headerSectionColor = tempColor;
		}


		headerSectionTexture.SetPixel(0,0, headerSectionColor);
		headerSectionTexture.Apply();

        mageSectionTexture = Resources.Load<Texture2D>("Graphics/Interface/yellowBG");

        warriorSectionTexture = Resources.Load<Texture2D>("Graphics/Interface/redBG");

        rogueSectionTexture = Resources.Load<Texture2D>("Graphics/Interface/greenBG");
    }


    /// <summary>
    /// OnGUI is called for rendering and handling GUI events.
    /// This function can be called multiple times per frame (one call per event).
    /// </summary>
    void OnGUI()
    {
		DrawLayouts();
		DrawHeader();
        DrawMageSettings();
        DrawWarriorSettings();
        DrawRogueSettings();
    }


    /// <summary>
    /// Defines Rect values and paints textures based on Rects
    /// </summary>
    void DrawLayouts()
    {
        headerSection.x = 0;
        headerSection.y = 0;
        headerSection.width = position.width;
        headerSection.height = 50;


        mageSection.x = 0;
        mageSection.y = 50;
        mageSection.width = position.width / 3;
        mageSection.height = position.height - 50;


        warriorSection.x = position.width / 3;
        warriorSection.y = 50;
        warriorSection.width = position.width / 3;
        warriorSection.height = position.height - 50;


        rogueSection.x = (position.width / 3) * 2;
        rogueSection.y = 50;
        rogueSection.width = position.width / 3;
        rogueSection.height = position.height - 50;


        GUI.DrawTexture(headerSection, headerSectionTexture);

        //GUI.DrawTexture(mageSection, mageSectionTexture);
        GUI.DrawTextureWithTexCoords(mageSection, mageSectionTexture, new Rect(0, 1, 1, -1));
        //GUI.DrawTexture(warriorSection, warriorSectionTexture);
        GUI.DrawTextureWithTexCoords(warriorSection, warriorSectionTexture, new Rect(0, 1, 1, -1));
        //GUI.DrawTexture(rogueSection, rogueSectionTexture);
        GUI.DrawTextureWithTexCoords(rogueSection, rogueSectionTexture, new Rect(0, 1, 1, -1));
    }


    /// <summary>
    /// Draw contents of Header
    /// </summary>
    void DrawHeader()
    {
        GUILayout.BeginArea(headerSection);

        GUILayout.Label("Enemy Designer");

        GUILayout.EndArea();
    }


    /// <summary>
    /// Draw contents of mage region
    /// </summary>
    void DrawMageSettings()
    {
        GUILayout.BeginArea(mageSection);

        GUILayout.Label("Mage");

        EditorGUILayout.BeginHorizontal();
        GUILayout.Label("Damage: ");
        mageData.DmgType = (MageDmgType)EditorGUILayout.EnumPopup(mageData.DmgType);
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.BeginHorizontal();
        GUILayout.Label("Weapon: ");
        mageData.WpnType = (MageWpnType)EditorGUILayout.EnumPopup(mageData.WpnType);
        EditorGUILayout.EndHorizontal();

        if(GUILayout.Button("Create!", GUILayout.Height(40))){
            GeneralSettings.OpenWindow(GeneralSettings.SettingsType.MAGE);
        }

        GUILayout.EndArea();
    }


    /// <summary>
    /// Draw contents of warrior region
    /// </summary>
    void DrawWarriorSettings()
    {
        GUILayout.BeginArea(warriorSection);

        GUILayout.Label("Warrior");

        EditorGUILayout.BeginHorizontal();
        GUILayout.Label("Damage: ");
        warriorData.ClassType = (WarriorClassType)EditorGUILayout.EnumPopup(warriorData.ClassType);
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.BeginHorizontal();
        GUILayout.Label("Weapon: ");
        warriorData.WpnType = (WarriorWpnType)EditorGUILayout.EnumPopup(warriorData.WpnType);
        EditorGUILayout.EndHorizontal();

        if (GUILayout.Button("Create!", GUILayout.Height(40)))
        {
            GeneralSettings.OpenWindow(GeneralSettings.SettingsType.MAGE);
        }

        GUILayout.EndArea();
    }


    /// <summary>
    /// Draw contents of rogue region
    /// </summary>
    void DrawRogueSettings()
    {
        GUILayout.BeginArea(rogueSection);

        GUILayout.Label("Rogue");

        EditorGUILayout.BeginHorizontal();
        GUILayout.Label("Damage: ");
        rogueData.StrategyType = (RogueStrategyType)EditorGUILayout.EnumPopup(rogueData.StrategyType);
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.BeginHorizontal();
        GUILayout.Label("Weapon: ");
        rogueData.WpnType = (RogueWpnType)EditorGUILayout.EnumPopup(rogueData.WpnType);
        EditorGUILayout.EndHorizontal();

        if (GUILayout.Button("Create!", GUILayout.Height(40)))
        {
            GeneralSettings.OpenWindow(GeneralSettings.SettingsType.MAGE);
        }

        GUILayout.EndArea();
    }
}


public class GeneralSettings : EditorWindow{
    public enum SettingsType{
        MAGE,
        WARRIOR,
        ROGUE
    }


    static SettingsType dataSettings;

    static GeneralSettings window;


    public static void OpenWindow(SettingsType setting){
        dataSettings = setting;
        window = (GeneralSettings)GetWindow(typeof(GeneralSettings));
        window.minSize = new Vector2(250, 200);
        window.Show();
    }

    /// <summary>
    /// OnGUI is called for rendering and handling GUI events.
    /// This function can be called multiple times per frame (one call per event).
    /// </summary>
    void OnGUI()
    {
        switch (dataSettings)
        {
            case SettingsType.MAGE:
                DrawSettings((CharacterData)EnemyDesignerWindow.MageInfo);
                break;
            case SettingsType.WARRIOR:
                DrawSettings((CharacterData)EnemyDesignerWindow.WarriorInfo);
                break;
            case SettingsType.ROGUE:
                DrawSettings((CharacterData)EnemyDesignerWindow.RogueInfo);
                break;
        }
    }

    void DrawSettings(CharacterData charData){
        EditorGUILayout.BeginHorizontal();
        GUILayout.Label("Max Health: ");
        charData.MaxHealth = EditorGUILayout.FloatField(charData.MaxHealth);
        EditorGUILayout.EndHorizontal();


        EditorGUILayout.BeginHorizontal();
        GUILayout.Label("Max Energy: ");
        charData.MaxEnergy = EditorGUILayout.FloatField(charData.MaxEnergy);
        EditorGUILayout.EndHorizontal();


        EditorGUILayout.BeginHorizontal();
        GUILayout.Label("Power: ");
        charData.Power = EditorGUILayout.Slider(charData.Power, 0, 100);
        EditorGUILayout.EndHorizontal();


        EditorGUILayout.BeginHorizontal();
        GUILayout.Label("% Crit Chance: ");
        charData.CritChance = EditorGUILayout.Slider(charData.CritChance, 0, charData.Power);
        EditorGUILayout.EndHorizontal();
        
        
        EditorGUILayout.BeginHorizontal();
        GUILayout.Label("Name: ");
        charData.Name = EditorGUILayout.TextField(charData.Name);
        EditorGUILayout.EndHorizontal();



    }
}