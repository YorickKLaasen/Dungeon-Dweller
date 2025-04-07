using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName = "Scriptable Objects/PlayerData")]
public class PlayerData : ScriptableObject
{
    [Header("Combat Stats")]
    public float damage;
    public float strength;
    public float critDamage;
    public float critChance;
    public float attackSpeed;

    [Header("Player Stats")]
    public float health;
    public float healthRegeneration;
    public float defense;
    public float speed;
    public float luck;
    public float mana;
    public float manaRegeneration;
    public float magicDamage;
    public float dungeonExpBoost;
    public float goldFortune;
    public float gemFortune;
    public float essenceFortune;

    [Header("Mining Stats")]
    public float miningFortune;
    public float gemstoneFortune;
    public float oreFortune;
    public float miningSpeed;

    [Header("Resistances/Buffs")]
    public float undeadDamage;
    public float undeadResistance;
    public float golemDamage;
    public float golemResistance;
    public float draconicDamage;
    public float draconicResistance;
    public float demonicDamage;
    public float demonicResistance;
    public float angelicDamage;
    public float angelicResistance;
    public float giantDamage;
    public float giantResistance;

    public float fireDamage;
    public float fireResistance;
    public float waterDamage;
    public float waterResistance;
    public float lightningDamage;
    public float lightningResistance;
    public float poisonDamage;
    public float poisonResistance;
    public float iceDamage;
    public float iceResistance;
    public float darknessDamage;
    public float darknessResistance;
    public float lightDamage;
    public float lightResistance;
}
