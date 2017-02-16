using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public partial class GPUParticleSystem
{
    class BlukMesh
    {
        #region Properties

        Mesh m_Mesh;

        int m_CopyCount;

        #endregion

        #region Public Methods

        public BlukMesh(Mesh[] meshes)
        {
            CombineMeshes(meshes);
        }

        #endregion

        #region Private Methods

        struct MeshCacheData
        {
            Vector3[] vertices;
            Vector3[] normals;
            Vector4[] tangents;
            Vector2[] uv;
            int[] indices;

            public MeshCacheData(Mesh mesh)
            {
                if (mesh)
                {
                    vertices = mesh.vertices;
                    normals = mesh.normals;
                    tangents = mesh.tangents;
                    uv = mesh.uv;
                    indices = mesh.GetIndices(0);
                }
            }
        }


        void CombineMeshes(Mesh[] meshes)
        {

        }

        #endregion
    }
}
