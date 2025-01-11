using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(SpecialArm))]
public class ChangeAttackKey1 : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        SpecialArm arm = (SpecialArm)target;
        if(GUILayout.Button("Change Attack Button"))
        {
            arm.ChangeAttackKey(arm.attackKey);
        }
    }
}
