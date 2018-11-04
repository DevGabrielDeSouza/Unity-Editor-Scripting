using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Types;

[CreateAssetMenuAttribute(fileName = "New Rogue Data", menuName = "Character Data/Rogue")]
public class RogueData : CharacterData {

	[SerializeField]
	private RogueStrategyType strategyType;

	[SerializeField]
	private RogueWpnType wpnType;
	
}
