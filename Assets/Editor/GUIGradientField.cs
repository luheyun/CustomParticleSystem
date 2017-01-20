using System;
using System.Reflection;
using UnityEditor;
using UnityEngine;

public static class GUIGradientField
{
    private static MethodInfo s_GradField;

    static GUIGradientField()
    {
        Type typeEditorGUILayout = typeof(EditorGUILayout);
        s_GradField = typeEditorGUILayout.GetMethod("GradientField", BindingFlags.NonPublic | BindingFlags.Static, null
            , new Type[] {typeof(string), typeof(Gradient), typeof(GUILayoutOption[])}, null);

        //s_GradField = typeEditorGUILayout.GetMethod("GradientField", BindingFlags.NonPublic | BindingFlags.Static, null
        //    , new Type[] { typeof(Gradient), typeof(GUILayoutOption[]) }, null);
    }

    public static Gradient GradientField(string lable, Gradient grad, params GUILayoutOption[] options)
    {
        if (grad == null)
            grad = new Gradient();

        return s_GradField.Invoke(null, new object[] { lable, grad, options}) as Gradient;
    }
}
