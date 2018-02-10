using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GPUMiningManager : MonoBehaviour
{
    private static GPUMiningManager _instance;

    public static GPUMiningManager Instance
    {
        get
        {
            return _instance;
        }
    }

    private void Awake()
    {
        if (_instance != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }

    public List<GPU> gpuList;

    public GPU gpu;

    public float countCoin;

    private void Start()
    {
        Init();

        SetGPU(gpuList[0]);
    }

    private void Init()
    {
        gpuList.Add(new GPU { id = 0, name = "GTX 960", price = 0, perGetCoin = 0.01f });
        gpuList.Add(new GPU { id = 1, name = "GTX 970", price = 500, perGetCoin = 0.02f });
        gpuList.Add(new GPU { id = 2, name = "GTX 980", price = 2000, perGetCoin = 0.35f });
        gpuList.Add(new GPU { id = 3, name = "GTX 980", price = 4500, perGetCoin = 0.5f });
    }

    public void SetGPU(GPU _gpu)
    {
        gpu = _gpu;
        UIInGame.Instance.gpuMining.SetGPU(gpu);

        if (mining != null)
            StopCoroutine(mining);

        mining = StartCoroutine(Mining());
    }

    public GPU GetNextGPU()
    {
        return gpuList[gpu.id + 1];
    }

    Coroutine mining = null;

    IEnumerator Mining()
    {
        while (true)
        {
            countCoin += gpu.perGetCoin;
            if ((int)countCoin > 0)
            {
                PlayDataManager.Instance.AddCoin((int)countCoin);
                countCoin -= (int)countCoin;
            }
            yield return new WaitForSeconds(1f);
        }
    }
}
