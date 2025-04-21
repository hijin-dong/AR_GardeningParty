using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubePalette : MonoBehaviour {
    private CubeList cubeList;
    [SerializeField] private CubeSelectButton cubeSelectButton;
    [SerializeField] private Transform content;

    private void Start()
    {
        cubeList = CubeManager.Instance.CubeList;

        ClearChildren(content);

        for (int i = 0; i < cubeList.cubes.Length; i++)
            Instantiate(cubeSelectButton, content).Set(i);
    }

    private static void ClearChildren(Transform o)
    {
        int n = o.childCount;
        if (n <= 0) return;
        for (int i = n - 1; i >= 0; i--)
            GameObject.Destroy(o.GetChild(i).gameObject);
    }
}
