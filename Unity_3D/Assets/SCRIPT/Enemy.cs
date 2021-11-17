using UnityEngine;
using System.Collections;
namespace SHIH.Enemy
{
    /// <summary>
    /// �ĤH�欰
    /// �ĤH���A: ���ݡB�����B�l�ܡB�����B���ˡB���`
    /// </summary>
    public class Enemy : MonoBehaviour
    {
        #region ���: ���}
        [Header("���ʳt��"), Range(0, 20)]
        public float speed = 2.5f;
        [Header("�����O"), Range(0, 200)]
        public float attack = 35;
        [Header("�d�� : �l�ܻP����")]
        public float rangeAttack = 5;
        public float rangeTrack = 15;
        #endregion

        #region ���: �p�H
        [SerializeField]    // �ǦC����� : ��ܨp�H���
        private StateEnemy state;
        #endregion


        #region ø�s�ϧ�
        private void OnDrawGizmos()
        {
            Gizmos.color = new Color(1, 0, 0.2f, 0.3f);
            Gizmos.DrawSphere(transform.position, rangeAttack);

            Gizmos.color = new Color(0.2f, 1, 0, 0.3f);
            Gizmos.DrawSphere(transform.position, rangeTrack);
        }
        #endregion

        #region �ƥ�
        private void Update()
        {
            StateManger();
        }
        #endregion

        #region ��k: �p�H
        private void StateManger()
        {
            switch (state)
            {
                case StateEnemy.Idle:
                    Idle();
                    break;
                case StateEnemy.Walk:
                    break;
                case StateEnemy.Track:
                    break;
                case StateEnemy.Attack:
                    break;
                case StateEnemy.Hurt:
                    break;
                case StateEnemy.Dead:
                    break;
                default:
                    break;
            }
        }

        private bool isIdle;
        [Header("�����H�����")]
        public Vector2 v2RandomWait = new Vector2(1f, 5f);

        /// <summary>
        /// ����: �H����ƫ�i�J�������A
        /// </summary>
        private void Idle()
        {
            #region �i�J����
            if (isIdle) return;

            isIdle = true;
            #endregion

            print("����");
            StartCoroutine(IdleEffect());
        }

        private IEnumerator IdleEffect()
        {
            float randomWait = Random.Range(v2RandomWait.x, v2RandomWait.y);
            yield return new WaitForSeconds(randomWait);

            state = StateEnemy.Walk;
            #region �X�h����
            isIdle = false;
            #endregion
        }
    }
    #endregion
}

