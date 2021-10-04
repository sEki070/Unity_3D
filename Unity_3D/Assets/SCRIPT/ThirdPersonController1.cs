using UnityEngine;
namespace Shih
{
    /// <summary>
    /// Shih 2021.1004
    /// 第三人稱控制器
    /// 移動、跳躍
    /// </summary>


    public class ThirdPersonController1 : MonoBehaviour
    {
        #region 欄位Field
        
        [Header("移動速度"), Tooltip("用來調整腳色移動速度"), Range(1, 500)]
        public float speed = 10.5f;
        [Header("跳躍高度"), Tooltip("用來調整腳色跳躍高度"), Range(1, 1000)]
        public int jump = 100;

        [Header("檢查地面資料")]
        [Tooltip("用來檢查腳色是否在地面上")]
        public bool isGrounded;
        public float groundHannkei = 0.2f;
        public Vector3 v3CheckGroundOffset;
        [Range(0, 3)]
        public float checkGroundRadius = 0.2f;

        [Header("音效檔案")]
        public AudioClip jump_sound;
        public AudioClip landing_sound;

        [Header("動畫參數")]
        public string animatorWalk = "走路開關";
        public string animatorRun = "跑步開關";
        public string animatorHurt = "受傷開關";
        public string animatorDeath = "死亡開關";
        public string animatorJump = "跳躍觸發";
        public string animatorIsGrounded = "是否在地上";



        private AudioSource aud;
        private Rigidbody rig;
        private Animator ani;
       

        /// <summary>
        /// 移動按鍵輸入
        /// </summary>
        /// <param name="move">要取得軸向名稱</param>
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
        /// 檢查地版
        /// </summary>
        /// <returns>是否碰到地板</returns>
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
            print("是否在地面上: " + groundcheck());   
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
        #region Unity 類型
        

        #endregion
        #endregion

        #region 屬性Property

        
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
        #region 方法 Method
        private void Test()
        {
            print("我是自訂方法");
        }

        private int ReturnJump()
        {
            return 999;
        }
        private void Skill(int damage, string effect = "灰塵特效", string sound = "ㄚㄚㄚ")
        {
            print("參數版本 - 傷害值:" + damage);
            print("參數版本-技能特效:" + effect);
            print("參數版本 - 音效:" + sound);
        }
        private void Skill100()
        {
            print("傷害值:" + 100);
            print("技能特效");
        }
        private void Skill200()
        {
            print("傷害值:" + 200);
            print("技能特效");
        }
        private void Skill300()
        {
            print("傷害值:" + 300);
            print("技能特效");
        }
        /// <summary>
        /// 計算BMI方法
        /// </summary>
        /// <param name="weight"></param>
        /// <param name="height"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        private float BMI(float weight, float height, string name = "測試")
        {
            print(name + "的BMI");
            return weight / (height * height);
        }

        #endregion

        #region 事件 Event
        public GameObject playerObject;
        private void Start()
        {
            print(BMI(61, 1.71f, "SEKI"));


            Skill100();
            Skill200();
            Skill(300);
            Skill(999, "爆炸特效");
            Skill(500, sound: "咻咻咻");

            #region 輸出 方法
            /*
            print("哈囉");

            Debug.Log("一般訊息");
            Debug.LogWarning("警告訊息");
            Debug.LogError("錯誤訊息");
            */
            #endregion

            #region 屬性練習
            /** 屬性練習
            //欄位與屬性 取得Gt，設定Set
            print("欄位資料 - 移動速度:" + speed);
            print("屬性資料 - 讀寫屬性:" + readAndWrite);
            speed = 20.5f;
            readAndWrite = 90;
            print("修改後的資料");
            print("欄位資料 - 移動速度:" + speed);
            print("屬性資料 - 讀寫屬性:" + readAndWrite);
            //唯讀屬性
            //read = 7  //唯讀屬性不能設定set
            print("唯讀屬性:" + read);
            print("唯讀屬性，有預設值:" + readValue);

            //屬性存取練習
            print("HP :" + hp);
            hp = 100;
            print("HP :" + hp);
            /**/
            #endregion
            Test();
            int j = ReturnJump();
            print("跳躍值:" + j);
            print("跳躍值，當值使用:" + (ReturnJump() + 1));
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
