using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Types;

[CreateAssetMenuAttribute(fileName = "New Rogue Data", menuName = "Character Data/Rogue")]
public class RogueData : CharacterData {

	[SerializeField]
	private RogueStrategyType strategyType;
    public RogueStrategyType StrategyType
    {
        get
        {
            return this.strategyType;
        }
        set
        {
            this.strategyType = value;
        }
    }

	[SerializeField]
	private RogueWpnType wpnType;
    public RogueWpnType WpnType
    {
        get
        {
            return this.wpnType;
        }
        set
        {
            this.wpnType = value;
        }
    }
	
}
