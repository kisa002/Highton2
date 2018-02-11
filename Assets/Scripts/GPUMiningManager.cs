using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GPUMiningManager : MonoBehaviour
{
    [SerializeField]
    Sprite[] gpuSprite;

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

        SetGPU(gpuList[PlayDataManager.Instance.GetGPU()]);
    }

    private void Init()
    {
        gpuList.Add(new GPU { id = 0, name = "GPU TRASH", price = 0, perGetCoin = 0.01f, sprite = gpuSprite[0] });
        gpuList.Add(new GPU { id = 1, name = "GPU RADEON", price = 1500, perGetCoin = 0.02f, sprite = gpuSprite[1] });
        gpuList.Add(new GPU { id = 2, name = "GPU HOS", price = 2500, perGetCoin = 0.035f, sprite = gpuSprite[2] });
        gpuList.Add(new GPU { id = 3, name = "GPU 1080", price = 4000, perGetCoin = 0.05f, sprite = gpuSprite[3] });
        gpuList.Add(new GPU { id = 4, name = "GTX Gold", price = 8500, perGetCoin = 0.07f, sprite = gpuSprite[4] });
        //gpuList.Add(new GPU { id = 5, name = "GTX 1000", price = 7200, perGetCoin = 1f });
    }

    public void SetGPU(GPU _gpu)
    {
        gpu = _gpu;
        UIInGame.Instance.gpuMining.SetGPU(gpu);
        PlayDataManager.Instance.SaveGPU(gpu.id);
        if (mining != null)
            StopCoroutine(mining);

        mining = StartCoroutine(Mining());
    }

    public GPU GetNextGPU()
    {
        if (gpu.id + 1 > gpuList.Count - 1)
            return null;
        else
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
