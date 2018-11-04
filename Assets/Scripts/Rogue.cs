using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SerializeField]
public class Rogue : MonoBehaviour {
	[SerializeField]
	private RogueData rogueData;


    public RogueData Rogue_Data
    {
        get
        {
            return this.rogueData;
        }
        set
        {
            this.rogueData = value;
        }
    }
}
