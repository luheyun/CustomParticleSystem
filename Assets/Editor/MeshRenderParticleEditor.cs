using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(MeshParticleRender))]
public class MeshRenderParticleEditor : Editor
{
    SerializedProperty particleMaterials;
    ParticleSystem m_ParticleSystem;
    Gradient m_Grad;

    void OnEnable()
    {
        var targetRender = target as MeshParticleRender;
        m_ParticleSystem = targetRender.GetComponent<ParticleSystem>();
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        if (m_ParticleSystem != null)
        {
            var targetRender = target as MeshParticleRender;
            ParticleSystemRenderer psRender = m_ParticleSystem.renderer as ParticleSystemRenderer;

            if (psRender.renderMode == ParticleSystemRenderMode.Mesh)
            {
                CopyFromParticleSystem();
            }
        }

        m_Grad = GUIGradientField.GradientField("Color over Lifetime", m_Grad);
    }

    private void CopyFromParticleSystem()
    {
        var targetRender = target as MeshParticleRender;
        ParticleSystemRenderer psRender = m_ParticleSystem.renderer as ParticleSystemRenderer;
        targetRender.particleMesh = psRender.mesh;

        if (targetRender.particleMaterials.Length <= 0)
        {
            if (m_ParticleSystem)
            {
                targetRender.particleMaterials = new Material[1];
                targetRender.particleMaterials[0] = psRender.sharedMaterial;
            }
        }

        targetRender.maximumParticles = m_ParticleSystem.maxParticles;
    }
}
