using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace SHIH.Dialogue
{
    /// <summary>
    /// ��ܨt��
    /// ��ܹ�ܮءB��ܤ��e���r�ĪG
    /// </summary>

    public class Dialogue : MonoBehaviour
    {
        [Header("��ܨt�λݭn����������")]
        public CanvasGroup groupDialogue;
        public Text textName;
        public Text textContent;
        public GameObject goTriangle;
        [Header("��ܶ��j"), Range(0, 10)]
        public float dialogueInterval = 0.3f;

        /// <summary>
        /// �}�l���
        /// </summary>
        public void Dialoguee(DataDiscript data)
        {
            StartCoroutine(SwitchDialogueGroup());        //�Ұʨ�P�{��
            StartCoroutine(ShowDialogueContent(data));       

        }

        private IEnumerator SwitchDialogueGroup()
        {
            for (int i = 0; i < 10; i++)                  //�j����w���榸��
            {
                groupDialogue.alpha += 0.1f;              //�s�դ��� �z���� ���W
                yield return new WaitForSeconds(0.01f);   //���ݮɶ�
            }
        }
        private IEnumerator ShowDialogueContent(DataDiscript data)
        {
            textName.text = "";
            textContent.text = "";

            for (int i = 0; i < data.beforeMission[0].Length; i++)
            {
                textContent.text += data.beforeMission[0][i];
                yield return new WaitForSeconds(dialogueInterval);
            }
        }
    }
}

