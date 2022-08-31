using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ColorSelection
{
    public class ColorSelector : MonoBehaviour
    {
        [SerializeField]
        UnlockColor[] playerColors;
        [SerializeField]
        private List<string> player1ColorList = new List<string>();

        [SerializeField]
        private List<string> player2ColorList = new List<string>();

        [SerializeField]
        private Image halfLeft;

        [SerializeField]
        private Image halfRight;

        public Color player1Color;

        public Color player2Color;

        [SerializeField]
        int index = 0;

        private void Start()
        {
            index = GetRandomNumber(0, 3);

            ColorUtility.TryParseHtmlString(player1ColorList[index], out player1Color);
            halfLeft.color = player1Color;

            ColorUtility.TryParseHtmlString(player2ColorList[index], out player2Color);
            halfRight.color = player2Color;
        }

        public static string ToRGBHex(Color c)
        {
            return string.Format("#{0:X2}{1:X2}{2:X2}", ToByte(c.r), ToByte(c.g), ToByte(c.b));
        }

        private static byte ToByte(float f)
        {
            f = Mathf.Clamp01(f);
            return (byte)(f * 255);
        }

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

        int GetRandomNumber(int min, int max)
        {
            return Random.Range(min, max);
        }

        public string GetPlayer1Color()
        {
            return ToRGBHex(player1Color);
        }

        public string GetPlayer2Color()
        {
            return ToRGBHex(player2Color);
        }

        private void OnDestroy()
        {
            PlayerPrefs.SetString("Player1Color", ToRGBHex(player1Color));
            PlayerPrefs.SetString("Player2Color", ToRGBHex(player2Color));
        }
    }
}

