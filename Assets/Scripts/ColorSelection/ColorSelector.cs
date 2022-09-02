using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ColorSelection
{
    public class ColorSelector : MonoBehaviour
    {
        [SerializeField]
        private List<UnlockColor> playerColors;

        [SerializeField]
        private Image[] colorDisplay;

        /*[SerializeField]
        private Image halfRight;*/
        [SerializeField]
        private Color[] playerGetColor;

        //public Color player2Color;
        private UnlockColor[] baseColor;
        private int[] index;
        private PlayerData[] playersData;

        private void Start()
        {
            LoadDataPlayer();
            baseColor = new UnlockColor[playerColors.Count];
            for (int i=0; i<playerColors.Count; i++)
            {
                baseColor[i] = playerColors[i];
            }
            index = new int[playerGetColor.Length]; 

            for (int i=0; i<playerGetColor.Length; i++)
            {
                ColorUtility.TryParseHtmlString(ToRGBHex(playerColors[0].color), out playerGetColor[i]);
                colorDisplay[i].color = playerGetColor[i];
                playerColors.Remove(playerColors[0]);
            }
            

            /*ColorUtility.TryParseHtmlString(player2ColorList[index], out player2Color);
            halfRight.color = player2Color;*/
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

        public void SetPlayerColor(int indexPlayer)
        {
            index[indexPlayer]++;
            if (index[indexPlayer] > playerColors.Count - 1)
            {
                index[indexPlayer] = 0;
            }

            Debug.Log(GetPlayerFromData("Player" + (indexPlayer + 1)).winCount);
            if (playerColors[index[indexPlayer]].indexUnlock > GetPlayerFromData("Player"+(indexPlayer+1)).winCount)
            {
                SetPlayerColor(indexPlayer);
                return;
            }
            BackToList(playerGetColor[indexPlayer]);
            ColorUtility.TryParseHtmlString(ToRGBHex(playerColors[index[indexPlayer]].color), out playerGetColor[indexPlayer]);
            colorDisplay[indexPlayer].color = playerGetColor[indexPlayer];
            playerColors.Remove(playerColors[index[indexPlayer]]);
        }

        /*public void SetPlayer2Color(bool status)
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
        }*/

        int GetRandomNumber(int min, int max)
        {
            return Random.Range(min, max);
        }

        public string GetPlayerColor(int index)
        {
            return ToRGBHex(playerGetColor[index]);
        }

        private void BackToList(Color color)
        {
            foreach(UnlockColor c in baseColor)
            {
                if (color == c.color)
                {
                    playerColors.Add(c);
                }
            }
        }

        private void OnDestroy()
        {
            for(int i=1; i<playerGetColor.Length+1; i++)
            {
                PlayerPrefs.SetString("Player"+i+"Color", ToRGBHex(playerGetColor[i-1]));
            }   
        }

        private void LoadDataPlayer()
        {
            MatchHistory history = new MatchHistory();
            playersData = history.LoadData();

            if (playersData.Length < playerGetColor.Length)
            {
                PlayerData[] temp = new PlayerData[playerGetColor.Length];
                for (int i = 0; i < playersData.Length; i++)
                {
                    temp[i] = playersData[i];
                }

                for (int j = playersData.Length; j < temp.Length; j++)
                {
                    temp[j] = new PlayerData();
                    temp[j].id = "Player" + (j + 1);
                }
                playersData = temp;
            }
        }

        private PlayerData GetPlayerFromData(string id)
        {
            foreach(PlayerData player in playersData)
            {
                Debug.Log(player.id + " : " + player.winCount);
                if (player.id == id)
                {
                    return player;
                }
            }
            return new PlayerData();
        }
    }
}

