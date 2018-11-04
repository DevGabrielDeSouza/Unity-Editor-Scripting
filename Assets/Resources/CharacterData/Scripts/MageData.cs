using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Types;

[CreateAssetMenuAttribute(fileName = "New Mage Data", menuName = "Character Data/Mage")]
public class MageData : CharacterData {

	[SerializeField]
	private MageDmgType dmgType;
	public MageDmgType DmgType{
		get{
			return this.dmgType;
		}
		set{
			this.dmgType = value;
		}
	}

	[SerializeField]
	private MageWpnType wpnType;
    public MageWpnType WpnType
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
