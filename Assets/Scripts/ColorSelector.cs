using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ColorSelector
{
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

        [SerializeField]
        int index = 0;

        public void SetPlayer1Color(bool status)
        {

            if (status)
            {
                index++;

                if (index > player1ColorList.Count -1)
                {
                    index = 0;
                }
            }
            else
            {
                index--;

                if (index < 0)
                {
                    index = player1ColorList.Count -1;
                }
            }

            ColorUtility.TryParseHtmlString(player1ColorList[index], out player1Color);
            halfLeft.color = player1Color;
        }

        public void SetPlayer2Color(bool status)
        {
            if (status)
            {
                index++;

                if (index > player2ColorList.Count - 1)
                {
                    index = 0;
                }
            }
            else
            {
                index--;

                if (index < 0)
                {
                    index = player2ColorList.Count - 1;
                }
            }

            ColorUtility.TryParseHtmlString(player2ColorList[index], out player2Color);
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
}

