using UnityEngine;
namespace Shih
{
    /// <summary>
    /// Shih 2021.1004
    /// �ĤT�H�ٱ��
    /// ���ʡB���D
    /// </summary>


    public class ThirdPersonController1 : MonoBehaviour
    {
        #region ���Field
        
        [Header("���ʳt��"), Tooltip("�Ψӽվ�}�Ⲿ�ʳt��"), Range(1, 500)]
        public float speed = 10.5f;
        [Header("���D����"), Tooltip("�Ψӽվ�}����D����"), Range(1, 1000)]
        public int jump = 100;

        [Header("�ˬd�a�����")]
        [Tooltip("�Ψ��ˬd�}��O�_�b�a���W")]
        public bool isGrounded;
        public float groundHannkei = 0.2f;
        public Vector3 v3CheckGroundOffset;
        [Range(0, 3)]
        public float checkGroundRadius = 0.2f;

        [Header("�����ɮ�")]
        public AudioClip jump_sound;
        public AudioClip landing_sound;

        [Header("�ʵe�Ѽ�")]
        public string animatorWalk = "�����}��";
        public string animatorRun = "�]�B�}��";
        public string animatorHurt = "���˶}��";
        public string animatorDeath = "���`�}��";
        public string animatorJump = "���DĲ�o";
        public string animatorIsGrounded = "�O�_�b�a�W";



        private AudioSource aud;
        private Rigidbody rig;
        private Animator ani;
       

        /// <summary>
        /// ���ʫ����J
        /// </summary>
        /// <param name="move">�n���o�b�V�W��</param>
        private void movement(float move)
        {
           
            rig.velocity =
                Vector3.forward * Movebutton("Vertical") * move +
                Vector3.right * Movebutton("Horizontal") * move +
                Vector3.up * rig.velocity.y;



        }

        private float Movebutton(string axisName)
        {
            return Input.GetAxis(axisName);
        }

        /// <summary>
        /// �ˬd�a��
        /// </summary>
        /// <returns>�O�_�I��a�O</returns>
        private bool groundcheck()
        {
            Collider[] hits = Physics.OverlapSphere
                (transform.position +
                transform.right * v3CheckGroundOffset.x +
                transform.up * v3CheckGroundOffset.y +
                transform.forward * v3CheckGroundOffset.z,
                checkGroundRadius, 1 << 3);
            isGrounded = hits.Length > 0;
            return hits.Length > 0;
        }
        private void Jump()
        {
            print("�O�_�b�a���W: " + groundcheck());   
            if (groundcheck() && keyJump)
            {
                rig.AddForce(transform.up * jump);
            }
        }
        private bool KeyUp { get => Input.GetKey(KeyCode.UpArrow); }
        private bool KeyDown { get => Input.GetKey(KeyCode.DownArrow); }
        private bool KeyRight { get => Input.GetKey(KeyCode.RightArrow); }
        private bool KeyLeft { get => Input.GetKey(KeyCode.LeftArrow); }
        private void UpdateAnimation()

        {
            if (KeyUp | KeyDown | KeyRight | KeyLeft)
            {
                ani.SetBool(animatorWalk, true);
            }
            else
            {
                ani.SetBool(animatorWalk, false);
            }

            ani.SetBool(animatorIsGrounded, isGrounded);
            if (keyJump) ani.SetTrigger(animatorJump);

        }
        #region Unity ����
        

        #endregion
        #endregion

        #region �ݩ�Property

        
        public int readAndWrite { get; set; }
        public int read { get; }
        public int readValue
        {
            get
            {
                return 77;
            }
        }
        private int _hp;
        public int hp
        {
            get
            {
                return _hp;
            }
            set
            {
                _hp = value;
            }

        }
        #endregion
       
        private bool keyJump { get => Input.GetKeyDown(KeyCode.Space); }
        #region ��k Method
        private void Test()
        {
            print("�ڬO�ۭq��k");
        }

        private int ReturnJump()
        {
            return 999;
        }
        private void Skill(int damage, string effect = "�ǹЯS��", string sound = "������")
        {
            print("�Ѽƪ��� - �ˮ`��:" + damage);
            print("�Ѽƪ���-�ޯ�S��:" + effect);
            print("�Ѽƪ��� - ����:" + sound);
        }
        private void Skill100()
        {
            print("�ˮ`��:" + 100);
            print("�ޯ�S��");
        }
        private void Skill200()
        {
            print("�ˮ`��:" + 200);
            print("�ޯ�S��");
        }
        private void Skill300()
        {
            print("�ˮ`��:" + 300);
            print("�ޯ�S��");
        }
        /// <summary>
        /// �p��BMI��k
        /// </summary>
        /// <param name="weight"></param>
        /// <param name="height"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        private float BMI(float weight, float height, string name = "����")
        {
            print(name + "��BMI");
            return weight / (height * height);
        }

        #endregion

        #region �ƥ� Event
        public GameObject playerObject;
        private void Start()
        {
            print(BMI(61, 1.71f, "SEKI"));


            Skill100();
            Skill200();
            Skill(300);
            Skill(999, "�z���S��");
            Skill(500, sound: "������");

            #region ��X ��k
            /*
            print("���o");

            Debug.Log("�@��T��");
            Debug.LogWarning("ĵ�i�T��");
            Debug.LogError("���~�T��");
            */
            #endregion

            #region �ݩʽm��
            /** �ݩʽm��
            //���P�ݩ� ���oGt�A�]�wSet
            print("����� - ���ʳt��:" + speed);
            print("�ݩʸ�� - Ū�g�ݩ�:" + readAndWrite);
            speed = 20.5f;
            readAndWrite = 90;
            print("�ק�᪺���");
            print("����� - ���ʳt��:" + speed);
            print("�ݩʸ�� - Ū�g�ݩ�:" + readAndWrite);
            //��Ū�ݩ�
            //read = 7  //��Ū�ݩʤ���]�wset
            print("��Ū�ݩ�:" + read);
            print("��Ū�ݩʡA���w�]��:" + readValue);

            //�ݩʦs���m��
            print("HP :" + hp);
            hp = 100;
            print("HP :" + hp);
            /**/
            #endregion
            Test();
            int j = ReturnJump();
            print("���D��:" + j);
            print("���D�ȡA��Ȩϥ�:" + (ReturnJump() + 1));
            aud = playerObject.GetComponent(typeof(AudioSource)) as AudioSource;
            rig = gameObject.GetComponent<Rigidbody>();
            ani = GetComponent<Animator>();
        }
        private void Update()
        {
            Jump();
            UpdateAnimation();
        }

        private void FixedUpdate()
        {
            movement(speed);
        }
        private void OnDrawGizmos()
        { 
            Gizmos.color = new Color(1, 0, 0.3f, 0.3f);
            Gizmos.DrawSphere(
                transform.position +
                transform.right * v3CheckGroundOffset.x +
                transform.up * v3CheckGroundOffset.y +
                transform.forward * v3CheckGroundOffset.z, checkGroundRadius);
            #endregion
        }

    }
}
