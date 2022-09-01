using Paintastic.Audio;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Paintastic.AsignButton
{
    public class AssignButton : MonoBehaviour
    {
        [SerializeField]
        SceneButtonName[] buttonChangeScene;

        [SerializeField]
        Button[] allButton;


        private void Start()
        {
            foreach (SceneButtonName buttonChange in buttonChangeScene)
            {
                buttonChange.button.onClick.RemoveAllListeners();
                buttonChange.button.onClick.AddListener(buttonChange.OnClickEventChangeScene);
            }
            foreach (Button buttons in allButton)
            {
                buttons.onClick.AddListener(() => AudioManager.instance.PlaySfx("SFX_ButtonClick"));
            }


        }

    }
}
