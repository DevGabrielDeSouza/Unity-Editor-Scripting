using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

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

        GUILayout.EndArea();
    }


    /// <summary>
    /// Draw contents of warrior region
    /// </summary>
    void DrawWarriorSettings()
    {
        GUILayout.BeginArea(warriorSection);

        GUILayout.Label("Warrior");

        GUILayout.EndArea();
    }


    /// <summary>
    /// Draw contents of rogue region
    /// </summary>
    void DrawRogueSettings()
    {
        GUILayout.BeginArea(rogueSection);

        GUILayout.Label("Rogue");

        GUILayout.EndArea();
    }
}
