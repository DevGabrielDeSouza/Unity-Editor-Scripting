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

    Texture2D mageTexture;
    Rect mageIconSection;
    Texture2D warriorTexture;
    Rect warriorIconSection;
    Texture2D rogueTexture;
    Rect rogueIconSection;

    float iconSize = 60;
    float iconSpace = 8;


    Color headerSectionColor = new Color(13f/255f, 32f/255f, 44f/255f, 1f);
    
	//Color headerSectionColor;

    Rect headerSection;
    Rect mageSection;
    Rect warriorSection;
    Rect rogueSection;


    GUISkin skin;


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
        window.maxSize = new Vector2(600, 300);
		window.Show();
	}

	/// <summary>
	/// This function is called when the object becomes enabled and active.
	/// </summary>
	void OnEnable()
	{
		InitTextures();
        InitData();
        skin = Resources.Load<GUISkin>("Graphics/StylesGUI/EnemyDesignerSkin");
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

        mageTexture = Resources.Load<Texture2D>("Graphics/Interface/editor_mageIcon");
        warriorTexture = Resources.Load<Texture2D>("Graphics/Interface/editor_warriorIcon");
        rogueTexture = Resources.Load<Texture2D>("Graphics/Interface/editor_rogueIcon");
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

        mageIconSection.x = (mageSection.x + mageSection.width/2f) - iconSize/2f;
        mageIconSection.y = mageSection.y + iconSpace;
        mageIconSection.width = iconSize;
        mageIconSection.height = iconSize;


        warriorSection.x = position.width / 3;
        warriorSection.y = 50;
        warriorSection.width = position.width / 3;
        warriorSection.height = position.height - 50;

        warriorIconSection.x = (warriorSection.x + warriorSection.width / 2f) - iconSize / 2f;
        warriorIconSection.y = warriorSection.y + iconSpace;
        warriorIconSection.width = iconSize;
        warriorIconSection.height = iconSize;


        rogueSection.x = (position.width / 3) * 2;
        rogueSection.y = 50;
        rogueSection.width = position.width / 3;
        rogueSection.height = position.height - 50;

        rogueIconSection.x = (rogueSection.x + rogueSection.width / 2f) - iconSize / 2f;
        rogueIconSection.y = rogueSection.y + iconSpace;
        rogueIconSection.width = iconSize;
        rogueIconSection.height = iconSize;


        GUI.DrawTexture(headerSection, headerSectionTexture);

        //GUI.DrawTexture(mageSection, mageSectionTexture);
        GUI.DrawTextureWithTexCoords(mageSection, mageSectionTexture, new Rect(0, 1, 1, -1));
        //GUI.DrawTexture(warriorSection, warriorSectionTexture);
        GUI.DrawTextureWithTexCoords(warriorSection, warriorSectionTexture, new Rect(0, 1, 1, -1));
        //GUI.DrawTexture(rogueSection, rogueSectionTexture);
        GUI.DrawTextureWithTexCoords(rogueSection, rogueSectionTexture, new Rect(0, 1, 1, -1));

        GUI.DrawTexture(mageIconSection, mageTexture);
        GUI.DrawTexture(warriorIconSection, warriorTexture);
        GUI.DrawTexture(rogueIconSection, rogueTexture);
    }


    /// <summary>
    /// Draw contents of Header
    /// </summary>
    void DrawHeader()
    {
        GUILayout.BeginArea(headerSection);

        GUILayout.Label("Enemy Designer", skin.GetStyle("Header1"));

        GUILayout.EndArea();
    }


    /// <summary>
    /// Draw contents of mage region
    /// </summary>
    void DrawMageSettings()
    {
        GUILayout.BeginArea(mageSection);

        GUILayout.Space(iconSize + iconSpace);

        GUILayout.Label("Mage", skin.GetStyle("MageHeader"));

        EditorGUILayout.BeginHorizontal();
        GUILayout.Label("Damage: ", skin.GetStyle("MageField"));
        mageData.DmgType = (MageDmgType)EditorGUILayout.EnumPopup(mageData.DmgType);
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.BeginHorizontal();
        GUILayout.Label("Weapon: ", skin.GetStyle("MageField"));
        mageData.WpnType = (MageWpnType)EditorGUILayout.EnumPopup(mageData.WpnType);
        EditorGUILayout.EndHorizontal();

        if(GUILayout.Button("Create!",skin.GetStyle("Button") ,GUILayout.Height(40))){
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

        GUILayout.Space(iconSize + iconSpace);

        GUILayout.Label("Warrior", skin.GetStyle("WarriorHeader"));

        EditorGUILayout.BeginHorizontal();
        GUILayout.Label("Damage: ", skin.GetStyle("WarriorField"));
        warriorData.ClassType = (WarriorClassType)EditorGUILayout.EnumPopup(warriorData.ClassType);
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.BeginHorizontal();
        GUILayout.Label("Weapon: ", skin.GetStyle("WarriorField"));
        warriorData.WpnType = (WarriorWpnType)EditorGUILayout.EnumPopup(warriorData.WpnType);
        EditorGUILayout.EndHorizontal();

        if (GUILayout.Button("Create!", skin.GetStyle("Button"), GUILayout.Height(40)))
        {
            GeneralSettings.OpenWindow(GeneralSettings.SettingsType.WARRIOR);
        }

        GUILayout.EndArea();
    }


    /// <summary>
    /// Draw contents of rogue region
    /// </summary>
    void DrawRogueSettings()
    {
        GUILayout.BeginArea(rogueSection);

        GUILayout.Space(iconSize + iconSpace);

        GUILayout.Label("Rogue", skin.GetStyle("RogueHeader"));

        EditorGUILayout.BeginHorizontal();
        GUILayout.Label("Damage: ", skin.GetStyle("RogueField"));
        rogueData.StrategyType = (RogueStrategyType)EditorGUILayout.EnumPopup(rogueData.StrategyType);
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.BeginHorizontal();
        GUILayout.Label("Weapon: ", skin.GetStyle("RogueField"));
        rogueData.WpnType = (RogueWpnType)EditorGUILayout.EnumPopup(rogueData.WpnType);
        EditorGUILayout.EndHorizontal();

        if (GUILayout.Button("Create!", skin.GetStyle("Button"), GUILayout.Height(40)))
        {
            GeneralSettings.OpenWindow(GeneralSettings.SettingsType.ROGUE);
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


    static SettingsType dataSetting;

    static GeneralSettings window;


    public static void OpenWindow(SettingsType setting){
        dataSetting = setting;
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
        switch (dataSetting)
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
        GUILayout.Label("Prefab: ");
        charData.Prefab = (GameObject)EditorGUILayout.ObjectField(charData.Prefab, typeof(GameObject), false);
        EditorGUILayout.EndHorizontal();


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

        if(charData.Prefab == null){
            EditorGUILayout.HelpBox("This enemy needs a [Prefab] before it can be created.", MessageType.Warning);
        }else if(charData.Name == null || charData.Name.Length < 1){
            EditorGUILayout.HelpBox("This enemy needs a [Name] before it can be created.", MessageType.Warning);
        }else if(GUILayout.Button("Finish and Save", GUILayout.Height(30))){
            SaveCharacterData();
            window.Close();
        }

    }

    void SaveCharacterData()
    {
        string prefabPath; //path to the base prefab
        string newPrefabPath = "Assets/Prefabs/Characters/";
        string dataPath = "Assets/Resources/CharacterData/Data/";

        switch (dataSetting)
        {
            case SettingsType.MAGE:
                //create the .asset file
                dataPath += "Mage/" + EnemyDesignerWindow.MageInfo.Name + ".asset";
                AssetDatabase.CreateAsset(EnemyDesignerWindow.MageInfo, dataPath);

                newPrefabPath += "Mage/" + EnemyDesignerWindow.MageInfo.Name + ".prefab";
                prefabPath = AssetDatabase.GetAssetPath(EnemyDesignerWindow.MageInfo.Prefab);
                AssetDatabase.CopyAsset(prefabPath, newPrefabPath);
                AssetDatabase.SaveAssets();
                AssetDatabase.Refresh();

                GameObject magePrefab = (GameObject)AssetDatabase.LoadAssetAtPath(newPrefabPath, typeof(GameObject));
                if(!magePrefab.GetComponent<Mage>()){
                    magePrefab.AddComponent(typeof(Mage));
                }

                magePrefab.GetComponent<Mage>().Mage_Data = EnemyDesignerWindow.MageInfo;

                break;
            case SettingsType.WARRIOR:
                //create the .asset file
                dataPath += "Warrior/" + EnemyDesignerWindow.WarriorInfo.Name + ".asset";
                AssetDatabase.CreateAsset(EnemyDesignerWindow.WarriorInfo, dataPath);

                newPrefabPath += "Warrior/" + EnemyDesignerWindow.WarriorInfo.Name + ".prefab";
                prefabPath = AssetDatabase.GetAssetPath(EnemyDesignerWindow.WarriorInfo.Prefab);
                AssetDatabase.CopyAsset(prefabPath, newPrefabPath);
                AssetDatabase.SaveAssets();
                AssetDatabase.Refresh();

                GameObject warriorPrefab = (GameObject)AssetDatabase.LoadAssetAtPath(newPrefabPath, typeof(GameObject));
                if (!warriorPrefab.GetComponent<Warrior>())
                {
                    warriorPrefab.AddComponent(typeof(Warrior));
                }

                warriorPrefab.GetComponent<Warrior>().Warrior_Data = EnemyDesignerWindow.WarriorInfo;
                break;
            case SettingsType.ROGUE:
                //create the .asset file
                dataPath += "Rogue/" + EnemyDesignerWindow.RogueInfo.Name + ".asset";
                AssetDatabase.CreateAsset(EnemyDesignerWindow.RogueInfo, dataPath);

                newPrefabPath += "Rogue/" + EnemyDesignerWindow.RogueInfo.Name + ".prefab";
                prefabPath = AssetDatabase.GetAssetPath(EnemyDesignerWindow.RogueInfo.Prefab);
                AssetDatabase.CopyAsset(prefabPath, newPrefabPath);
                AssetDatabase.SaveAssets();
                AssetDatabase.Refresh();

                GameObject roguePrefab = (GameObject)AssetDatabase.LoadAssetAtPath(newPrefabPath, typeof(GameObject));
                if (!roguePrefab.GetComponent<Rogue>())
                {
                    roguePrefab.AddComponent(typeof(Rogue));
                }

                roguePrefab.GetComponent<Rogue>().Rogue_Data = EnemyDesignerWindow.RogueInfo;
                break;
        }
    }
}