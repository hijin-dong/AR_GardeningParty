using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    [SerializeField] private GameObject vfxPrefab;
    private GameObject vfx;

    private int growingLevel;
    public int GrowingLevel { get { return growingLevel; } set { growingLevel = value; } }
    private int cubeType;
    public int CubeType { get { return cubeType; } set { cubeType = value; } }
    
    void OnEnable() => CubeManager.Instance?.RegisterCube(this);
    void OnDisable() => CubeManager.Instance?.UnregisterCube(this);

    private void Start()
    {
        for (int i = 0; i < transform.childCount; i++)
            transform.GetChild(i).gameObject.SetActive(false);

        transform.GetChild(growingLevel).gameObject.SetActive(true);

        vfx = Instantiate(vfxPrefab, transform.position + new Vector3(0, -0.45f, 0), transform.rotation, transform);
        vfx.SetActive(false);
    }
    
    public void Grow()
    {
        if (growingLevel == transform.childCount - 2) return;
        
        transform.GetChild(growingLevel++).gameObject.SetActive(false);
        StartCoroutine(VFXController(1));
        transform.GetChild(growingLevel).gameObject.SetActive(true);
    }

    private IEnumerator VFXController(int vfxTime)
    {
        vfx.SetActive(true);
        yield return new WaitForSeconds(vfxTime);
        vfx.SetActive(false);
    }
}
