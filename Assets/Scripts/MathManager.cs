using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MathManager : MonoBehaviour
{
    public int[] typeList = new int[10];
    public int[] numberList = new int[10];
    public string[] type = { "+", "-", "*", "/" };

    public int result = 0;
    public int maxCount = 0;

    public int[] typeMath = new int[10];
    public int[] numberMath = new int[10];

    private void Start()
    {
        RandomMath();

        Debug.Log(GetFormulaMath());
        Debug.Log(GetResult());
    }

    public void RandomMath()
    {
        /*
            0 : none
            1 : plus
            2 : minus
            3 : multiplication
            4 : division
        */
        maxCount = Random.Range(2, 9);

        result = 0;

        for (int i = 0; i < maxCount; i++)
        {
            typeList[i] = Random.Range(1, 5);
            numberList[i] = Random.Range(1, 10);

            typeMath[i] = typeList[i];
            numberMath[i] = numberList[i];
        }

        for(int i=0; i<maxCount; i++)
        {
            for (int j=0; j<maxCount - 1; j++)
            {
                if(typeMath[j] == 1 || typeMath[j] == 2)
                    if(typeMath[j + 1] == 3 || typeMath[j + 1] == 4)
                    {
                        int temp = numberMath[j];
                        numberMath[j] = numberMath[j + 1];
                        numberMath[j + 1] = temp;

                        temp = typeMath[j];
                        typeMath[j] = typeMath[j + 1];
                        typeMath[j + 1] = temp;
                    }
            }
        }

        SetResult();
    }

    public int SetResult()
    {
        result = 0;

        for(int i=0; i<maxCount; i++)
        {
            if (i == 0)
                result = numberMath[i];
            else
                switch(typeMath[i-1])
                {
                    case 1:
                        result += numberMath[i];
                        break;

                    case 2:
                        result -= numberMath[i];
                        break;

                    case 3:
                        result *= numberMath[i];
                        break;

                    case 4:
                        while(true)
                            if (result % numberMath[i] == 0)
                                break;
                            else
                                numberMath[i] = Random.Range(1, 10);

                        result /= numberMath[i];
                        break;
                }

            //Debug.Log(i + " : " + result);
        }

        return result;
    }

    public int GetResult()
    {
        return result;
    }

    public string GetFormula()
    {
        string formula = "";

        for (int i = 0; i < maxCount; i++)
        {
            if (i == maxCount - 1)
                formula += numberList[i] + " = " + result;
            else
                formula += numberList[i] + " " + type[typeList[i]] + " ";
        }

        return formula;
    }

    public string GetFormulaMath()
    {
        string formula = "";

        for(int i=0; i<maxCount; i++)
        {
            if (i == maxCount - 1)
                formula += numberMath[i] + " = " + result;
            else
                formula += numberMath[i] + " " + type[typeMath[i]] + " ";
        }

        return formula;
    }

    public int GetType(int index)
    {
        return typeList[index];
    }

    public int GetNumber(int index)
    {
        return typeList[index];
    }
}
