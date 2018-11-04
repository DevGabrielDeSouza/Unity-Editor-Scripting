using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class EnemyDesignerWindow : EditorWindow {

    Texture2D headerSectionTexture;
    Texture2D leftSectionTexture;
    Texture2D rightSectionTexture;

    Color headerSectionColor = new Color(13f/255f, 32f/255f, 44f/255f, 1f);
    
	//Color headerSectionColor;

    Rect headerSection;
    Rect leftSection;
    Rect rightSection;

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

        leftSectionTexture = Resources.Load<Texture2D>("Graphics/Interface/redBG");

        rightSectionTexture = Resources.Load<Texture2D>("Graphics/Interface/greenBG");

        //rightSectionTexture.Resize
    }


    /// <summary>
    /// OnGUI is called for rendering and handling GUI events.
    /// This function can be called multiple times per frame (one call per event).
    /// </summary>
    void OnGUI()
    {
		DrawLayouts();
		DrawHeader();
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


        leftSection.x = 0;
        leftSection.y = 50;
        leftSection.width = position.width / 2;
        leftSection.height = position.height - 50;


        rightSection.x = position.width / 2;
        rightSection.y = position.height;
        rightSection.width = position.width / 2;
        rightSection.height = (position.height - 50) * -1;

        GUI.DrawTexture(headerSection, headerSectionTexture);
        GUI.DrawTexture(leftSection, leftSectionTexture);
        GUI.DrawTexture(rightSection, rightSectionTexture);
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


	

}
