using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDialogue : MonoBehaviour
{
    public void StartDialogue()
    {
        PlayerChatBoxManager.Instance
            .Show("으으 어지러워", 3f, true)
            .Show("여긴 어디지?", 3f, true)
            .Show("깊은 심해로 들어왔나봐..", 3f, true)
            .Show("빨리 자료나 찾고 밖으로 나가자", 3.5f, true)
            .End();

        QuestPopupUI.Instance.QuestTxt();
    }

    public void LuminescentPlantDialogue()
    {
        PlayerChatBoxManager.Instance
            .Show("이 꽃은 뭐지?", 3f, true)
            .Show("안에서 빛이 세어나오고 있어", 4f, true)
            .Show("신기하네..주워가자", 4.5f, true)
            .Show("( I 와 U 로 밝기를 조절할 수 있습니다 )", 4f, true)
            .End();

       QuestPopupUI.Instance.QuestTxt();
    }

    public void LeafWallDialogue()
    {
        PlayerChatBoxManager.Instance
            .Show("이 잎사귀 전에 인터넷에서 본적있어", 3f, true)
            .Show("특정 밝기를 싫어한다고 했는데", 4.5f, true)
            .Show("이 식물을 이용해볼까?", 5f, true)
            .End();
    }

    public void AnglerFishDialogue()
    {
        PlayerChatBoxManager.Instance
            .Show("잠깐 여기 어떻게 생물체가 있지?", 3f, true)
            .Show("바이러스인가봐", 3.5f, true)
            .Show("아귀가 가까히 오면 불을 끄고 자취를 숨기자", 6.5f, true)
            .End();

        QuestPopupUI.Instance.QuestTxt();
    }

    public void BrightFlowerDialogue()
    {
        PlayerChatBoxManager.Instance
            .Show("이 꽃 드디어 찾았네", 4f, true)
            .Show("이 꽃도 특정 밝기를 좋아한다고 했지", 4f, true)
            .Show("( 왼쪽 밑에 있는 \"사전\"을 클릭해 정보를 확인할 수 있습니다 )", 5f, true)
            .Show("이정도면 과제에 넣을건 다 찾은것 같은데?", 5f, true)
            .Show("이제 출구만 찾으면 되겠어", 5f, true)
            .End();
    }

    public void OctopusDialogue()
    {
        PlayerChatBoxManager.Instance
            .Show("안에 문어가 들어있네?", 3f, true)
            .Show("특정 불빛을 싫어한다고 했던것 같아", 3f, true)
            .Show("이 꽃을 이용하면 문어가 내가 올라가는 걸 도와줄거야", 5.5f, true)
            .End();
    }
}
