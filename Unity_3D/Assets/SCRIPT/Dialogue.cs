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
        [Header("��ܫ���")]
        public KeyCode dialogueKey = KeyCode.Space;

        /// <summary>
        /// �}�l���
        /// </summary>
        public void Dialoguee(DataDiscript data)
        {
            StopAllCoroutines();
            StartCoroutine(SwitchDialogueGroup());        //�Ұʨ�P�{��
            StartCoroutine(ShowDialogueContent(data));

        }


        /// <summary>
        /// ������: ������ܥ\��A�����H�X
        /// </summary>
        public void StopDialogue()
        {
            StopAllCoroutines();
            StartCoroutine(SwitchDialogueGroup(false));
        }

        /// <summary>
        /// ������ܮظs�ժ���
        /// </summary>
        /// <param name="fadeIn">�O�_�H�J:true�H�J�A false�H�X</param>
        /// <returns></returns>
        private IEnumerator SwitchDialogueGroup(bool fadeIn = true)
        {
            //�T���B��l
            //�y�k: ���L��? true���G: false���G;
            //�z�L���L�� �M�w�n�W�[���� , true �W�[0.1 , false�W�[-0.1
            float increase = fadeIn ? 0.1f : -0.1f;

            for (int i = 0; i < 10; i++)                  //�j����w���榸��
            {
                groupDialogue.alpha += increase;              //�s�դ��� �z���� ���W
                yield return new WaitForSeconds(0.01f);   //���ݮɶ�
            }
        }

        /// <summary>
        /// ��ܹ�ܤ��e
        /// </summary>
        /// <param name="data">��ܸ��</param>
        /// <returns></returns>
        private IEnumerator ShowDialogueContent(DataDiscript data)
        {
            textName.text = "";    //�M�� ��ܪ�
            textName.text = data.nameDialogue; //��s ��ܪ�
            //�M�M�C�q��� 
            for (int j = 0; j < data.beforeMission.Length; j++)
            {
                textContent.text = "";//�M�� ��ܤ��e
                goTriangle.SetActive(false); //���� ���ܹϥ�
                //�M�M��ܨC�@�Ӧr
                for (int i = 0; i < data.beforeMission[j].Length; i++)
                {
                    textContent.text += data.beforeMission[j][i];
                    yield return new WaitForSeconds(dialogueInterval);
                }
                goTriangle.SetActive(true); //��� ���ܹϥ�

                //���򵥫� ��J ��ܫ��� null ���ݤ@�Ӽv�檺�ɶ�
                while (!Input.GetKeyDown(dialogueKey)) yield return null;
            }

            StartCoroutine(SwitchDialogueGroup(false));  //�H�X
        }
    }
}
