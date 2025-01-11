using UnityEngine;

[CreateAssetMenu(fileName = "PlayerStat", menuName = "Scriptable Objects/PlayerStat")]
public class PlayerStat : ScriptableObject
{
    [Header("Base Stat")]
    public float maxHealth;
    public float currentHealth;
    public float moveSpeed;
    public float attackSpeed;

    [Header("Clsss Damage Multiplier")]
    public float bluntDamageMultiplier;
    public float bladeDamageMultiplier;
    public float gunDamageMultiplier;
    public float magicDamageMultiplier;
    public float fightDamageMultiplier;
    public float toolDamageMultiplier;
    public float buildingDamageMultiplier;
    public float machineDamageMultiplier;
    public float foodDamageMultiplier;

    [Header("Class CoolTime Multiplier")]
    public float bluntCoolTimeMultiplier;
    public float bladeCoolTimeMultiplier;
    public float gunCoolTimeMultiplier;
    public float magicCoolTimeMultiplier;
    public float fightCoolTimeMultiplier;
    public float toolCoolTimeMultiplier;
    public float buildingCoolTimeMultiplier;
    public float machineCoolTimeMultiplier;
    public float foodCoolTimeMultiplier;

    [Header("Class Range Multiplier")]
    public float bluntRangeMultiplier;
    public float bladeRangeMultiplier;
    public float gunRangeMultiplier;
    public float magicRangeMultiplier;
    public float fightRangeMultiplier;
    public float toolRangeMultiplier;
    public float buildingRangeMultiplier;
    public float machineRangeMultiplier;
    public float foodRangeMultiplier;

    [Header("Class Area Multiplier")]
    public float bluntAreaMultiplier;
    public float bladeAreaMultiplier;
    public float gunAreaMultiplier;
    public float magicAreaMultiplier;
    public float fightAreaMultiplier;
    public float toolAreaMultiplier;
    public float buildingAreaMultiplier;
    public float machineAreaMultiplier;
    public float foodAreaMultiplier;

    [Header("Element Multiplier")]
    public float positionMultiplier;
    public float waterMultiplier;
    public float grassMultiplier;
    public float electricMultiplier;
    public float metalMultiplier;
    public float fireMultiplier;
    public float madMultiplier;
    public float lightMultiplier;
    public float physicalMultiplier;

    [Header("Extra Multiplier")]
    public float structureDurabilityMultiplier;
}
