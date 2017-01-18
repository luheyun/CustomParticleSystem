using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(MeshParticleRender))]
public class MeshRenderParticleEditor : Editor
{
    SerializedProperty particleMaterials;
    ParticleSystem m_ParticleSystem;

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

            if (targetRender.particleMaterials.Length <= 0)
            {
                if (m_ParticleSystem)
                {
                    targetRender.particleMaterials = new Material[1];
                    targetRender.particleMaterials[0] = m_ParticleSystem.renderer.sharedMaterial;
                }
            }

            targetRender.maximumParticles = m_ParticleSystem.maxParticles;
        }
    }
}
