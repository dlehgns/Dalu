using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shopping_Basket : MonoBehaviour
{
    [SerializeField] private Text[] txt_Indexs;
    [SerializeField] private Text[] txt_prices;
    bool action = false;


    int bloodSundaeBig = 17000; // 피순대(대) 17,000원
    int bloodSundaeSmall = 12000; // 피순대(소) 12,000원
    int jabSundae = 10000; // 잡채순대 10,000원

    private int currentIndex_1 = 0;
    private int currentIndex_2 = 0;
    private int currentIndex_3 = 0;

    // Start is called before the first frame update
    void Start()
    {
        txt_Indexs[0].text = "0";
        txt_Indexs[1].text = "0";
        txt_Indexs[2].text = "0";
    }
    public void input_1() 
    {
        currentIndex_1 += 1;
        txt_Indexs[0].text = currentIndex_1.ToString();
    }

    public void output_1()
    {
        currentIndex_1 -= 1;
        txt_Indexs[0].text = currentIndex_1.ToString();
    }
    public void input_2()
    {
        currentIndex_2 += 1;
        txt_Indexs[1].text = currentIndex_2.ToString();
    }

    public void output_2()
    {
        currentIndex_2 -= 1;
        txt_Indexs[1].text = currentIndex_2.ToString();
    }
    public void input_3()
    {
        currentIndex_3 += 1;
        txt_Indexs[2].text = currentIndex_3.ToString();
    }

    public void output_3()
    {
        currentIndex_3 -= 1;
        txt_Indexs[2].text = currentIndex_3.ToString();
    }

    public void buy()
    {
        int totalPrice = bloodSundaeBig * currentIndex_1 + bloodSundaeSmall * currentIndex_2 + jabSundae * currentIndex_3;
        txt_prices[0].text = (GetThousandCommaText(totalPrice).ToString() + "원");
        txt_prices[1].text = (GetThousandCommaText(totalPrice).ToString() + "원 주문하기");
    }
    public string GetThousandCommaText(int data)
    {
        return string.Format("{0:#,###}", data);
    }
    public void return_index()
    {
        currentIndex_1 = 0;
        currentIndex_2 = 0;
        currentIndex_3 = 0;

        txt_Indexs[0].text = currentIndex_1.ToString();
        txt_Indexs[1].text = currentIndex_2.ToString();
        txt_Indexs[2].text = currentIndex_3.ToString();
    }
}
