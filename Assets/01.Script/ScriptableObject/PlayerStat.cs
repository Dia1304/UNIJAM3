using UnityEngine;

[CreateAssetMenu(fileName = "PlayerStat", menuName = "Scriptable Objects/PlayerStat")]
public class PlayerStat : ScriptableObject
{
    [Header("Base Stat")]
    public int maxHealth;
    public int attackDamage;
    public int moveSpeed;
    public int attackSpeed;

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
}
