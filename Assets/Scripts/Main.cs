using UnityEngine;
using System.Collections;

public class Main : MonoBehaviour {
    public Object prefab;
    public int Count = 100;
    public GameObject cube;

	// Use this for initialization
	void Start () {
        for (int i = 0; i < Count; ++i)
        {
            GameObject go = GameObject.Instantiate(prefab) as GameObject;
            go.transform.position = new Vector3(0f, 0f, 0f);

            //ParticleSystem[] psList = go.GetComponentsInChildren<ParticleSystem>();

            //for (int j = 0; j < psList.Length; ++j)
            //{
            //    if (psList[j].renderer.enabled)
            //    {
            //        Material m = psList[j].renderer.material;
            //    }
            //}
        }

        if (cube)
        {
            cube.SetActive(true);
            GameObject go = GameObject.Find("/Cube");

            if (go != null)
                go.SetActive(false);
            else
                cube.SetActive(true);
        }
	}
	
	// Update is called once per frame
	void Update () {
	    
	}
}
