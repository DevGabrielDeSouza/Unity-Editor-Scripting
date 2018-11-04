using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Warrior : MonoBehaviour {
	[SerializeField]
	private WarriorData warriorData;

	public WarriorData Warrior_Data{
		get{
			return this.warriorData;
		}
		set{
			this.warriorData = value;
		}
	}
}
