using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Arm))]
public class ChangeAttackKey : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        Arm arm = (Arm)target;
        if(GUILayout.Button("Change Attack Button"))
        {
            arm.ChangeAttackKey(arm.attackKey);
        }
    }
}
