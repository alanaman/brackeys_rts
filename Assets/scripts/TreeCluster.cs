using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class TreeCluster : MonoBehaviour
{
    public GameObject tree;
    public int startX = -540;
    public int startZ = 0;
    public float width = 500f;
    public float threshold = .9f;
    public float noiseScale = .1f;

#if UNITY_EDITOR

    [ContextMenu("GenerateTrees")]
    void GenerateTrees()
    {
        //delete current trees
        Removetrees();

        //create new trees
        for (int i=0; i<100; i++)
        {
            for (int j=0; j<100; j++)
            {
                float x = i * width / 100;
                float z = j * width / 100;
                float perlinNoise = Mathf.PerlinNoise(x/noiseScale, z/noiseScale);
                if (perlinNoise > threshold)
                {
                    Instantiate(tree, new Vector3(startX + x, .5f, startZ + z), transform.rotation, transform);
                }
            }
        }
    }

    [ContextMenu("Removetrees")]
    void Removetrees()
    {
        while (transform.childCount != 0)
        {
            var child = transform.GetChild(0);
            DestroyImmediate(child.gameObject);
        }
    }


#endif

}
