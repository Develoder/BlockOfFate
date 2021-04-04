#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(SetDefualtDB))]
public class SetDefualtDBEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        
        SetDefualtDB defualtDB = (SetDefualtDB)target;
        if (GUILayout.Button("Сбросить базу"))
        {
            defualtDB.DefualtBD();
        }
    }
}
#endif
