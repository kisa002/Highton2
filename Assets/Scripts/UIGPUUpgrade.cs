using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class UIGPUUpgrade : MonoBehaviour
{
    public Text textGPUPrice, textCurrentGPU, textNextGPU, textCant;

    public UnityEvent viewEvent, hideEvent;

    public void View()
    {
        //이 부분은 나중에 PlayDataManager에서 가져오는걸로

        textCurrentGPU.text = GPUMiningManager.Instance.gpu.name;
        textNextGPU.text = GPUMiningManager.Instance.GetNextGPU().name;

        textGPUPrice.text = GPUMiningManager.Instance.GetNextGPU().price.ToString() + " 골드";

        if (PlayDataManager.Instance.EnoughGold(GPUMiningManager.Instance.GetNextGPU().price))
            textCant.gameObject.SetActive(false);
        else
            textCant.gameObject.SetActive(true);

        if (viewEvent == null)
            return;

        viewEvent.Invoke();
    }

    public void GPUUpgrade()
    {
        int price = GPUMiningManager.Instance.GetNextGPU().price;

        if (PlayDataManager.Instance.EnoughGold(price))
        {
            PlayDataManager.Instance.AddGold(-price);
            GPUMiningManager.Instance.SetGPU(GPUMiningManager.Instance.GetNextGPU());

            Hide();
        }
    }

    public void Hide()
    {
        if (hideEvent == null)
            return;

        hideEvent.Invoke();
    }
}
