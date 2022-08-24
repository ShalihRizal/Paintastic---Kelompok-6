using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorSelector : MonoBehaviour
{
    [SerializeField]
    private List<string> player1ColorList = new List<string>();

    [SerializeField]
    private List<string> player2ColorList = new List<string>();

    [SerializeField]
    private Image halfLeft;

    [SerializeField]
    private Image halfRight;

    private Color player1Color;

    private Color player2Color;

    //int index = 0;

    public void SetPlayer1Color()
    {

        //if(index < player1ColorList.Count -1)
        //{
        //    index++;
        //}
        //else
        //{
        //    index = 0;
        //}

        ColorUtility.TryParseHtmlString(player1ColorList[Random.Range(0, player1ColorList.Count)], out player1Color);
        halfLeft.color = player1Color;
    }

    public void SetPlayer2Color()
    {
        ColorUtility.TryParseHtmlString(player2ColorList[Random.Range(0, player2ColorList.Count)], out player2Color);
        halfRight.color = player2Color;
    }

    //public void ScrollColor()
    //{

    //}


    //public void SetPlayerColor(List<string> colorList, string player, Color color, Image image)
    //{
    //    ColorUtility.TryParseHtmlString(colorList[Random.Range(0, colorList.Count)], out color);
    //    image.color = color;
    //}
}
