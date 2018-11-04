using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Types;

[CreateAssetMenuAttribute(fileName = "New Warrior Data", menuName = "Character Data/Warrior")]
public class WarriorData : CharacterData {

	[SerializeField]
	private WarriorClassType classType;
    public WarriorClassType ClassType
    {
        get
        {
            return this.classType;
        }
        set
        {
            this.classType = value;
        }
    }

	[SerializeField]
	private WarriorWpnType wpnType;
    public WarriorWpnType WpnType
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
