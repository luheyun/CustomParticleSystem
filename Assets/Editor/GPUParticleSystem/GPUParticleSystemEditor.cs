using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(GPUParticleSystem))]
[CanEditMultipleObjects]
public class GPUParticleSystemEditor : Editor 
{
    SerializedProperty m_MaxParticle;
    SerializedProperty m_EmitterCenter;
    SerializedProperty m_EmitterSize;
    SerializedProperty m_Life;
    SerializedProperty m_InitVelocity;

    SerializedProperty m_Meshes;
    SerializedProperty m_Material;

    static GUIContent s_TextCenter = new GUIContent("Center");
    static GUIContent s_TextSize = new GUIContent("Size");

    void OnEnable()
    {
        m_MaxParticle = serializedObject.FindProperty("m_MaxParticles");
        m_EmitterCenter = serializedObject.FindProperty("m_EmitterCenter");
        m_EmitterSize = serializedObject.FindProperty("m_EmitterSize");
        m_Life = serializedObject.FindProperty("m_Life");
        m_InitVelocity = serializedObject.FindProperty("m_InitVelocity");

        m_Meshes = serializedObject.FindProperty("m_Meshes");
        m_Material = serializedObject.FindProperty("m_Material");
    }

    public override void OnInspectorGUI()
    {
        var targetPS = target as GPUParticleSystem;
        serializedObject.Update();

        EditorGUI.BeginChangeCheck();
        EditorGUILayout.PropertyField(m_MaxParticle);

        if (EditorGUI.EndChangeCheck())
        {
            targetPS.OnChanged();
        }

        EditorGUILayout.LabelField("Emitter", EditorStyles.boldLabel);
        EditorGUILayout.PropertyField(m_EmitterCenter, s_TextCenter);
        EditorGUILayout.PropertyField(m_EmitterSize, s_TextSize);

        EditorGUILayout.Space();
        EditorGUILayout.PropertyField(m_Life);

        EditorGUILayout.Space();

        EditorGUILayout.LabelField("Velocity", EditorStyles.boldLabel);
        EditorGUILayout.PropertyField(m_InitVelocity);

        EditorGUILayout.Space();
        EditorGUI.BeginChangeCheck();

        EditorGUILayout.PropertyField(m_Meshes, true);

        if (EditorGUI.EndChangeCheck())
            targetPS.OnChanged();

        EditorGUILayout.PropertyField(m_Material);



        serializedObject.ApplyModifiedProperties();
    }
}
