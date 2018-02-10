using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMath : MonoBehaviour {

    [SerializeField]
    private Text textQuestion, textAnswer;

    [SerializeField]
    private GameObject panelMath;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ShowMath()
    {
        panelMath.SetActive(true);
        
        MathManager.Instance.RandomMath();

        textQuestion.text = MathManager.Instance.GetFormulaMath();
        textAnswer.text = "";
    }

    public void CloseMath()
    {
        panelMath.SetActive(false);
    }

    public void CheckMath()
    {
        if(MathManager.Instance.GetResult() == int.Parse(MathManager.Instance.answer))
        {
            // 올바른 답
            CloseMath();
        }
        else
        {
            // 올바르지 않은 답
            Debug.LogError("WRONG ANSWER - " + MathManager.Instance.GetResult());
        }
    }

    public void ClickNumber(string number)
    {
        MathManager.Instance.answer += number;
        textAnswer.text = MathManager.Instance.answer;
    }

    public void ClearNumber()
    {
        MathManager.Instance.answer = "";
        textAnswer.text = MathManager.Instance.answer;
    }

    public void MinusNumber()
    {
        MathManager.Instance.answer = "-" + MathManager.Instance.answer;
        textAnswer.text = MathManager.Instance.answer;
    }

    public void BackspaceNumber()
    {
        MathManager.Instance.answer = MathManager.Instance.answer.Substring(0, MathManager.Instance.answer.Length - 1);
        textAnswer.text = MathManager.Instance.answer;
    }
}
