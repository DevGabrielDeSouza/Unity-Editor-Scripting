using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterData : ScriptableObject {
	[SerializeField]
	private GameObject prefab;
    public GameObject Prefab { 
        get{
            return this.prefab;
        }
        set{
            this.prefab = value;
        }
     }

    [SerializeField]
    private float maxHealth;
    public float MaxHealth
    {
        get
        {
            return this.maxHealth;
        }
        set
        {
            this.maxHealth = value;
        }
    }

    [SerializeField]
    private float maxEnergy;
    public float MaxEnergy {
        get
        {
            return this.maxEnergy;
        }
        set
        {
            this.maxEnergy = value;
        }
    }

    
    [SerializeField]
    private float critChance;
    public float CritChance {
        get
        {
            return this.critChance;
        }
        set
        {
            this.critChance = value;
        }
    }

    [SerializeField]
    private float power;
    public float Power {
        get
        {
            return this.power;
        }
        set
        {
            this.power = value;
        }
    }

    [SerializeField]
    private new string name;
    public string Name {
        get
        {
            return this.name;
        }
        set
        {
            this.name = value;
        }
    }
}
