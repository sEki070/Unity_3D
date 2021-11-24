using UnityEngine;
namespace SHIH.Dialogue
{
    /// <summary>
    /// NPC 系統
    /// 偵測目標是否進入對話範圍
    /// 並且開啟對話系統
    /// </summary>
    public class NPC : MonoBehaviour
    {
        #region 欄位與屬性
        [Header("對話資料")]
        public DataDiscript dataDialogue;
        [Header("相關資訊")]
        [Range(0, 10)]
        public float checkPlayerRadius = 3f;
        public GameObject goTip;
        public float speedLookAt = 3;

        private Transform target;
        private bool startDialogueKey { get => Input.GetKeyDown(KeyCode.E); }
        #endregion

        [Header("對話系統")]
        public Dialogue dialogue;

        /// <summary>
        /// 目前任務數量
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
        /// 檢查玩家是否進入
        /// </summary>
        /// <returns>玩家進入 傳回true 否則false </returns>
        private bool CheckPlayer()
        {
            Collider[] hits = Physics.OverlapSphere(transform.position, checkPlayerRadius, 1 << 6);
            if (hits.Length > 0) target = hits[0].transform;
            return hits.Length > 0;
        }
        /// <summary>
        /// 面向玩家
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
        /// 玩家進入範圍內 並且按下指定案件 請對話系統執行 開始對話 
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
        /// 更新任務需求數量
        /// 任務目標物件得到或死亡後處理
        /// </summary>
        public void UpdateMissionCount()
        {
            countCurrent++;
            //目前數量 等於 需求數量 狀態 等於 完成任務
            if (countCurrent == dataDialogue.countNeed) dataDialogue.stateNPCMission = StateNPCMission.AfterMission;
            {

            }

        }
    }
}

