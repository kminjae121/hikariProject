using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDialogue : MonoBehaviour
{
    void Start()
    {
        PlayerChatBoxManager.Instance
            .Show("으으 어지러워", 3f, true)
            .Show("이곳은 어디일까?", 3f, true)
            .Show("깊은 심해인거 같아", 3f, true)
            .Show("이곳을 빠져나가야 할것같아!", 3.5f, true)
            .End();

        QuestPopupUI.Instance.QuestTxt();
    }

    public void LuminescentPlantDialogue()
    {
        PlayerChatBoxManager.Instance
            .Show("이 밝은 물체는 뭘까?", 3f, true)
            .Show("과연 히카리.. 밝은것을 좋아하네", 4f, true)
            .Show("이 물체를 들고 I와 U를 눌러서 밝기를 조절할 수 있어", 4.5f, true)
            .Show("그리고 밝기를 이용해 특정한 물체들을 동작시킬 수 있어", 4f, true)
            .End();

        QuestPopupUI.Instance.QuestTxt();
    }

    public void LeafWallDialogue()
    {
        PlayerChatBoxManager.Instance
            .Show("이것은 잎사귀 기둥이야", 3f, true)
            .Show("이 기둥은 특정한 밝기에만 잠깐 사라지지", 4.5f, true)
            .Show("특정한 밝기를 잘 찾아서 기둥을 통과 해보자!", 5f, true)
            .End();
    }

    public void AnglerFishDialogue()
    {
        PlayerChatBoxManager.Instance
            .Show("이건 아귀 조심 표지판이야!", 3f, true)
            .Show("아귀는 정말 무시무시한 존재지", 3.5f, true)
            .Show("하지만 걱정마 만약 너가 불빛을 내지 않는다면 아귀가 공격하는 일은 없을테니까!", 6.5f, true)
            .End();

        QuestPopupUI.Instance.QuestTxt();
    }

    public void BrightFlowerDialogue()
    {
        PlayerChatBoxManager.Instance
            .Show("이곳은 다양한 꽃들을 밟아서 위로 올라가야해", 3.5f, true)
            .Show("꽃들은 특정한 밝기에만 꽃봉우리가 열릴거야", 4f, true)
            .Show("왼쪽 밑에 있는 \"책 모양 버튼\"을 클릭해 사전을 열어봐", 5f, true)
            .Show("사전에는 무슨 꽃이 무슨 밝기에 열리는지 적혀있어!", 5f, true)
            .Show("사전을 잘 참조해봐!", 5f, true)
            .End();
    }
}
