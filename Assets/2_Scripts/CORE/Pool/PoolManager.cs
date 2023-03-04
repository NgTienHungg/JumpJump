using UnityEngine;
using System.Collections.Generic;

public class PoolManager : MonoBehaviour
{
    public static PoolManager Instance { get; private set; }

    [SerializeField] private List<Pool> _listPool;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        PreparePools();
    }

    private void PreparePools()
    {
        foreach (var pool in _listPool)
        {
            pool.ListObject = new List<GameObject>();

            for (int i = 0; i < pool.Size; i++)
            {
                pool.ListObject.Add(CreateObject(pool.Prefab));
            }
        }
    }

    private GameObject CreateObject(GameObject prefab)
    {
        GameObject obj = Instantiate(prefab);
        obj.transform.parent = transform;
        obj.SetActive(false);
        return obj;
    }

    /// <summary>
    /// Spawn object với tag truyền vào là tên của Prefab trong pool
    /// </summary>
    public GameObject Spawn(string tag)
    {
        foreach (var pool in _listPool)
        {
            if (pool.Prefab.name == tag)
            {
                foreach (var obj in pool.ListObject)
                {
                    if (!obj.activeInHierarchy)
                    {
                        obj.SetActive(true);
                        return obj;
                    }
                }

                // expand pool
                if (pool.Expandable)
                {
                    GameObject obj = CreateObject(pool.Prefab);
                    pool.ListObject.Add(obj);
                    obj.SetActive(true);
                    return obj;
                }
                else
                {
                    Debug.LogWarning("The pool with tag " + tag + " is not expandable!");
                    return null;
                }
            }
        }

        Debug.LogWarning("The pool with tag " + tag + " is not exist!");
        return null;
    }

    public void Recall(GameObject obj)
    {
        obj.transform.parent = transform;
        obj.transform.localScale = Vector3.one;
        obj.transform.localPosition = Vector3.zero;
        obj.SetActive(false);
    }

    public void RecallAll()
    {
        Debug.Log("PoolManager recall all object!");

        foreach (var pool in _listPool)
        {
            foreach (var obj in pool.ListObject)
            {
                Recall(obj);
            }
        }
    }

    public GameObject GetPrefab(string prefabName)
    {
        foreach (var pool in _listPool)
        {
            if (pool.Prefab.name == prefabName)
            {
                return pool.Prefab;
            }
        }

        Debug.LogWarning("The pool with tag " + tag + " is not exist!");
        return null;
    }
}