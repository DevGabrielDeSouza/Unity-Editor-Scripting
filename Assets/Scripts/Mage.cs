using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Mage : MonoBehaviour {

	[SerializeField]
	private MageData mageData;

    public MageData Mage_Data
    {
        get
        {
            return this.mageData;
        }
        set
        {
            this.mageData = value;
        }
    }

	
}
