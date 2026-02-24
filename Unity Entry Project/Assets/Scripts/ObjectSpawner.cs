using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    // Inspector'da Assets klasöründeki Prefab'larý buralara sürükleyeceðiz
    public GameObject cubePrefab;
    public GameObject spherePrefab;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            Instantiate(cubePrefab, transform.position, Quaternion.identity);
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            Instantiate(spherePrefab, transform.position, Quaternion.identity);
        }
    }
}