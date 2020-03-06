using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienGrid : MonoBehaviour
{
    GameObject prefab;
    Transform parent;

    private void Awake()
    {
        prefab = Resources.Load(("Prefabs/Alien"), typeof(GameObject)) as GameObject;
        parent = transform;
    }
    void Start()
    {
        for (int x = 0; x < 3; x++)
            for (int y = 0; y < 2; y++)
                for (int z = 0; z < 1; z++)
                    Instantiate(prefab, transform.position + new Vector3(x * 3, y * 5, z * 3), Quaternion.identity, parent);
    }
    private void Update()
    {
        Destroy(this);
    }
}
