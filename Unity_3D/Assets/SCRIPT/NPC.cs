using UnityEngine;
namespace SHIH.Dialogue
{
    /// <summary>
    /// NPC �t��
    /// �����ؼЬO�_�i�J��ܽd��
    /// �åB�}�ҹ�ܨt��
    /// </summary>
    public class NPC : MonoBehaviour
    {
        #region ���P�ݩ�
        [Header("��ܸ��")]
        public DataDiscript dataDialogue;
        [Header("������T")]
        [Range(0, 10)]
        public float checkPlayerRadius = 3f;
        public GameObject goTip;
        public float speedLookAt = 3;

        private Transform target;
        private bool startDialogueKey { get => Input.GetKeyDown(KeyCode.E); }
        #endregion

        [Header("��ܨt��")]
        public Dialogue dialogue;

        /// <summary>
        /// �ثe���ȼƶq
        /// </summary>
        private int countCurrent;

        private void OnDrawGizmos()
        {
            Gizmos.color = new Color(0, 1, 0.2f, 0.3f);
            Gizmos.DrawSphere(transform.position, checkPlayerRadius);
        }
        private void Update()
        {
            goTip.SetActive(CheckPlayer());
            LookAtPlayer();
            StartDialogue();
        }
        /// <summary>
        /// �ˬd���a�O�_�i�J
        /// </summary>
        /// <returns>���a�i�J �Ǧ^true �_�hfalse </returns>
        private bool CheckPlayer()
        {
            Collider[] hits = Physics.OverlapSphere(transform.position, checkPlayerRadius, 1 << 6);
            if (hits.Length > 0) target = hits[0].transform;
            return hits.Length > 0;
        }
        /// <summary>
        /// ���V���a
        /// </summary>
        private void LookAtPlayer()
        {
            if (CheckPlayer())
            {
                Quaternion angle = Quaternion.LookRotation(target.position - transform.position);
                transform.rotation = Quaternion.Lerp(transform.rotation, angle, Time.deltaTime * speedLookAt);
            }
        }

        /// <summary>
        /// ���a�i�J�d�� �åB���U���w�ץ� �й�ܨt�ΰ��� �}�l��� 
        /// </summary>
        private void StartDialogue()
        {
            if (CheckPlayer() && startDialogueKey)
            {
                dialogue.Dialoguee(dataDialogue);
            }
            else if (!CheckPlayer()) dialogue.StopDialogue();
        }


        /// <summary>
        /// ��s���ȻݨD�ƶq
        /// ���ȥؼЪ���o��Φ��`��B�z
        /// </summary>
        public void UpdateMissionCount()
        {
            countCurrent++;
            //�ثe�ƶq ���� �ݨD�ƶq ���A ���� ��������
            if (countCurrent == dataDialogue.countNeed) dataDialogue.stateNPCMission = StateNPCMission.AfterMission;
            {

            }

        }
    }
}

