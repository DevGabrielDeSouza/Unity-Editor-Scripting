using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterData : ScriptableObject {
	[SerializeField]
	private GameObject prefab;

    [SerializeField]
    private float maxHealth;
    [SerializeField]
    private float maxEnergy;
    [SerializeField]
    private float critChance;
    [SerializeField]
    private float power;
    [SerializeField]
    private float name;
}
