using Paintastic.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ColorSelection
{
    public class ColorSelector : MonoBehaviour
    {
        /*[SerializeField]
        private List<UnlockColor> playerColors;*/
        [SerializeField]
        private ScriptableMaterialBlock scriptableBlock;

        private List<PlayerMaterialBlock> playerColors;

        [SerializeField]
        private Image[] colorDisplay;

        /*[SerializeField]
        private Image halfRight;*/
        [SerializeField]
        private Color[] playerGetColor;

        //public Color player2Color;
        private PlayerMaterialBlock[] baseColor;
        private int[] index;
        private PlayerData[] playersData;

        private void Start()
        {
            playerColors = scriptableBlock.materialProperty;
            LoadDataPlayer();
            baseColor = new PlayerMaterialBlock[playerColors.Count];
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


            if(playerColors[index[indexPlayer]].indexUnlock > GetPlayerFromData("Player"+(indexPlayer+1)).winCount)
            {
                SetPlayerColor(indexPlayer);
                return;
            }
            BackToList(playerGetColor[indexPlayer]);
            //Debug.Log(playerColors[indexPlayer].propertyId);
            ColorUtility.TryParseHtmlString(ToRGBHex(playerColors[index[indexPlayer]].color), out playerGetColor[indexPlayer]);
            colorDisplay[indexPlayer].color = playerGetColor[indexPlayer];
            playerColors.Remove(playerColors[index[indexPlayer]]);
        }

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
            foreach (PlayerMaterialBlock c in baseColor)
            {
                if (ToRGBHex(color).Equals(ToRGBHex(c.color)))
                {
                    playerColors.Add(c);
                }
            }
        }

        private void OnDestroy()
        {
            foreach(Color c in playerGetColor)
            {
                BackToList(c);
            }
            for(int i=1; i<playerGetColor.Length+1; i++)
            {
                int _throw=0;
                foreach (PlayerMaterialBlock c in baseColor)
                {
                    if (ToRGBHex(playerGetColor[i - 1]).Equals(ToRGBHex(c.color)))
                    {
                        _throw = c.propertyId;
                    }
                }
                PlayerPrefs.SetInt("Player"+i+"Color", _throw);
            }   
        }

        private void LoadDataPlayer()
        {
            MatchHistory history = new MatchHistory();
            playersData = history.LoadData();
            
            if (playersData.Length < playerGetColor.Length)
            {
                PlayerData[] temp = new PlayerData[playerGetColor.Length];
                for(int i=0; i<playersData.Length; i++)
                {
                    temp[i] = playersData[i];
                }

                int startIdx = playersData.Length;
                if (startIdx == 0) startIdx = 1;

                for(int j=startIdx - 1; j<temp.Length; j++)
                {
                    temp[j] = new PlayerData();
                    temp[j].id = "Player" + j;
                }
                playersData = temp;
            }
        }

        private PlayerData GetPlayerFromData(string id)
        {
            foreach(PlayerData player in playersData)
            {
                if (player.id == id)
                {
                    return player;
                }
            }
            return new PlayerData();
        }
    }
}

