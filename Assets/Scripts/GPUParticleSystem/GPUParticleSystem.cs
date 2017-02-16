using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public partial class GPUParticleSystem : MonoBehaviour {

    [SerializeField]
    int m_MaxParticles;

    #region Emitter Parameters

    [SerializeField]
    Vector3 m_EmitterCenter = Vector3.zero;

    [SerializeField]
    Vector3 m_EmitterSize = Vector3.one;

    #endregion

    #region Particle life Parameters

    [SerializeField]
    float m_Life = 4.0f;

    #endregion

    #region Velocity Parameters

    [SerializeField]
    Vector3 m_InitVelocity = Vector3.forward;

    #endregion

    #region Render Setting

    [SerializeField]
    Mesh[] m_Meshes = new Mesh[1];

    [SerializeField]
    Material m_Material;

    #endregion

    bool m_NeedReset = false;

    public void OnChanged()
    {
        m_NeedReset = true;
    }

    private void Update()
    {
        
    }
}
