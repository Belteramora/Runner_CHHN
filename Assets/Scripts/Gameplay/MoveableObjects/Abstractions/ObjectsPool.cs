using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectsPool<T> : MonoBehaviour
{
    [SerializeField]
    protected GameObject objectPrefab;

    [SerializeField]
    protected int poolSize;

    protected List<T> pool;

	protected void Awake()
	{
        GameManager.GameSetup += Setup;
	}

	// Start is called before the first frame update
	protected virtual void Setup()
    {
        pool = new List<T>();

        for(int i = 0; i < poolSize; i++)
        {
            GameObject spawnedPrefab = Instantiate(objectPrefab, transform);
			pool.Add(spawnedPrefab.GetComponent<T>());
        }
    }
}
