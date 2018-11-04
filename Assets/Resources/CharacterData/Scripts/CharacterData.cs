using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterData : ScriptableObject {
	[SerializeField]
	private GameObject prefab;

    [SerializeField]
    private float maxHealth;

    public float MaxHealth { get; set; }

    [SerializeField]
    private float maxEnergy;
    public float MaxEnergy { get; set; }

    
    [SerializeField]
    private float critChance;
    private float CritChance { get; set; }

    [SerializeField]
    private float power;
    private float Power { get; set; }

    [SerializeField]
    private new float name;
    public float Name { get; set; }
}
