using UnityEngine;

[CreateAssetMenu(fileName = "PlayerStat", menuName = "Scriptable Objects/PlayerStat")]
public class PlayerStat : ScriptableObject
{
    public int maxHealth;
    public int attackDamage;
    public int moveSpeed;
    public int attackSpeed;
}
