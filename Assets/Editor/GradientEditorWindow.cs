using UnityEditor;
using UnityEngine;

public class GradientEditorWindow : EditorWindow
{
    [MenuItem("Window/Gradient Editor Test")]
    public static void Show()
    {
        GetWindow<GradientEditorWindow>("Gradient Editor test Window");
    }

    Gradient m_Grad;

    void OnGUI()
    {
        m_Grad = GUIGradientField.GradientField("Test Grad", m_Grad);
 
        if (GUILayout.Button("Set Keys Test"))
        {
            OnSetKeyTest();
            GUIUtility.ExitGUI();
        }
    }

    void OnSetKeyTest()
    {

    }
}
