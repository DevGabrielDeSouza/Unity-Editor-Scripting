using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterData : ScriptableObject {
	[SerializeField]
	private GameObject prefab;
    public GameObject Prefab { get; set; }

    [SerializeField]
    private float maxHealth;

    public float MaxHealth { get; set; }

    [SerializeField]
    private float maxEnergy;
    public float MaxEnergy { get; set; }

    
    [SerializeField]
    private float critChance;
    public float CritChance { get; set; }

    [SerializeField]
    private float power;
    public float Power { get; set; }

    [SerializeField]
    private new string name;
    public string Name { get; set; }
}
