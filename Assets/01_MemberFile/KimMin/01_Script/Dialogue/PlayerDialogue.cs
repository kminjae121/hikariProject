using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDialogue : MonoBehaviour
{
    void Start()
    {
        PlayerChatBoxManager.Instance
            .Show("으윽.. 이곳은 어디지..?", 3f, true)
            .Show("깊은 심해인가..", 3f, true)
            .Show("으흑... 어지럽군", 3f, true)
            .Show("이 곳을 빠져나가야곘어.", 3f, true)
            .End();
    }

    public void LuminescentPlantDialog()
    {
        PlayerChatBoxManager.Instance
            .Show("으윽..저 밝은건 뭐지..?", 3f, true)
            .Show("밝은것.. 과연 히카리군.", 3f, true)
            .Show("이것을 들어서 무언갈 해봐야겠어", 3f, true)
            .Show("아아, 정말 영롱하군.", 3f, true)
            .End();
    }

    public void AnglerFishDialog()
    {
        PlayerChatBoxManager.Instance
            .Show("뭐지..? 아귀조심..?", 3f, true)
            .Show("감히 아귀따위가 날 막을수 있을까.", 3f, true)
            .Show("보아하니 밝기에 따라 반응하는거 같군", 3f, true)
            .End();
    }
}
