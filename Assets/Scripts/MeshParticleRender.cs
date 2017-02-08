using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MeshParticleRender : MonoBehaviour
{
    [HideInInspector]
    public Gradient Grad;

    private ParticleSystem m_ParticleSystem;
    public Mesh particleMesh;
    public int maximumParticles = 1;
    public Material[] particleMaterials;
    GameObject[] particlePool;
    ParticleSystem.Particle[] m_Particles;
    private int m_CurUpdateFrameNum = 0;
    private const int UPDATE_FRAME_SPAN = 3;
    private int m_ColorPropertyId = -1;

    // Use this for initialization
    void Start()
    {
        InitializeIfNeeded();
        ResetSubParticles();
        m_ColorPropertyId = Shader.PropertyToID("_TintColor"); 
    }

    void InitializeIfNeeded()
    {
        if (m_ParticleSystem == null)
            m_ParticleSystem = GetComponent<ParticleSystem>();

        if (m_Particles == null || m_Particles.Length < m_ParticleSystem.maxParticles)
            m_Particles = new ParticleSystem.Particle[m_ParticleSystem.maxParticles];
    }

    void LateUpdate()
    {
        if (particleMesh == null || maximumParticles <= 0) return;

        m_CurUpdateFrameNum = (m_CurUpdateFrameNum + 1) % UPDATE_FRAME_SPAN;
        if (m_CurUpdateFrameNum != 0) return;

        InitializeIfNeeded();
        int count = m_ParticleSystem.GetParticles(m_Particles);

        for (int i = 0; i < maximumParticles; ++i)
        {
            GameObject particleObject = particlePool[i];
            if (i >= count)
            {
                particleObject.renderer.enabled = false;
            }
            else
            {
                ParticleSystem.Particle p = m_Particles[i];
                particleObject.renderer.enabled = true;
                particleObject.transform.localPosition = p.position;
                particleObject.transform.localRotation = Quaternion.AngleAxis(p.rotation, p.axisOfRotation);
                float scale = p.size;
                particleObject.transform.localScale = new Vector3(scale, scale, scale);
                
                MeshRenderer meshRender = particleObject.renderer as MeshRenderer;
                float time = NormalizeTime(p);
                Color col = Grad.Evaluate(time) * m_ParticleSystem.startColor;
                meshRender.sharedMaterial.SetColor(m_ColorPropertyId, col);
            }
        }
    }

    private float NormalizeTime(ParticleSystem.Particle particle)
    {
        return (particle.startLifetime - particle.lifetime) / particle.startLifetime;
    }

    void RemoveSubParticles()
    {
        if (particlePool != null)
        {
            foreach (var o in particlePool)
            {
                if (Application.isEditor)
                {
                    DestroyImmediate(o);
                }
                else
                {
                    Destroy(o);
                }
            }
            particlePool = null;
        }
    }

    void ResetSubParticles()
    {
        if (particleMesh == null || maximumParticles <= 0) return;

        RemoveSubParticles();

        particlePool = new GameObject[maximumParticles];

        for (int i = 0; i < maximumParticles; ++i)
        {
            GameObject particleObject = new GameObject();
            particleObject.name = "ParticleMesh";
            MeshFilter mf = particleObject.AddComponent<MeshFilter>();
            mf.mesh = particleMesh;
            MeshRenderer mr = particleObject.AddComponent<MeshRenderer>();
            mr.materials = particleMaterials;

            if (m_ParticleSystem != null && m_ParticleSystem.renderer != null)
            {
                mr.castShadows = m_ParticleSystem.renderer.castShadows;
                mr.receiveShadows = m_ParticleSystem.renderer.receiveShadows;
            }

            particleObject.transform.parent = transform;
            particleObject.transform.localScale = new Vector3(1, 1, 1);
            particleObject.renderer.enabled = false;

            particlePool[i] = particleObject;
        }
    }
}
