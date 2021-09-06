using UnityEngine;   //引用Unity API (倉庫 資料與功能)
using UnityEngine.Video;
//MonBahaviour:基底類別
/// <summary>
/// {摘要}
/// </summary>
public class ThirdPersonController : MonoBehaviour
{
    #region 欄位Field
    //儲存遊戲資料，例如:移動速度、跳躍高度等等...
    //常用四大類型:整數、福點數、字串、布林值
    //欄位語法:修飾詞 資料類型 欄位名稱 (指定 預設值) 結尾
    //修飾詞:
    //1.公開public - 允許其他類型存取 - 顯示在屬性面板 - 需要調整的資料設定為公開
    //2.私人private - 禁止其他類型存取 - 隱藏在屬性面板 - 預設值
    //*Unity 以屬性面板資料為主
    //恢復程式預設值請按...Reset
    //欄位屬性Attribute :輔助欄位資料
    //欄位屬性語法:[屬性名稱(屬性值)]
    [Header("移動速度"), Tooltip("用來調整腳色移動速度"), Range(1, 500)]
    public float speed = 10.5f;
    [Header("跳躍高度"), Tooltip("用來調整腳色跳躍高度"), Range(1, 1000)]
    public int hight = 100;

    [Header("檢查地面資料")]
    [Tooltip("用來檢查腳色是否在地面上")]
    public bool on_the_ground;
    public float groundhannkei = 0.2f;
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

    private AudioSource aud;
    private Rigidbody rig;
    private Animator ani;

    #region Unity 類型
    /** 練習Unity
    //顏色 Color
    public Color color;
    public Color white = Color.white;                  //內建顏色
    public Color yellow = Color.yellow;              
    public Color color1 = new Color(1,0.5f,0.5f,0.5f); //自訂顏色RGB

    //座標Vector 2 - 4
    public Vector2 v2;
    public Vector2 v2Right = Vector2.right;
    public Vector2 v2Left = Vector2.left;
    public Vector2 v2Up = Vector2.one;
    public Vector2 v2Custom = new Vector2(7.5f, 100.9f);
    public Vector2 v3 = new Vector3(1, 2, 3);
    public Vector3 v3Forward = Vector3.forward; 
    public Vector4 v4 = new Vector4(1, 2, 3,4);

    //按鍵 列舉資料enum
    public KeyCode key;
    public KeyCode move = KeyCode.W;
    public KeyCode jump = KeyCode.Space;

    //遊戲資料類型: 不能指定預設值
    public AudioClip sound;    //音效 mp3,ogg,wav
    public VideoClip video;  //影片 mp4
    public Sprite sprite;      //圖片png,jpeg    -不支援gif
    public Texture2D texture2D;//2D 圖片 png,jpeg
    public Material material;  //材質球
    [Header("元件")]
    //元件 Component :屬性面板上可折疊的
    public Transform tra;
    public Animation aniOld;
    public Animator aniNew;
    public Light lig;
    public Camera caml

    //綠色蚯蚓
    //1.建議不要使用此名稱
    //2.遇到過時的API
    **/

    #endregion
    #endregion

    #region 屬性Property

    //屬性不會顯示在面板上
    //儲存資料，與欄位相同
    //差異在於:可以設定存取全縣 Get Set
    //屬性語法:修飾詞 資料類型 屬性名稱 {取;存;}
    public int readAndWrite { get; set; }
    //唯讀屬性:只能取得Get
    public int read { get; }
    //唯讀屬性: 透過get設定預設值，關鍵字return為傳回值
    public int readValue
    {
        get
        {
            return 77;
        }
    }
    //唯寫屬性是禁止的，必須要有get
    //public int write { set; }
    //value 指的是指定的值
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
    public KeyCode keyJump { get; }
    #region 方法 Method
    //定義與實作較複雜程式的區塊，功能
    //方法語法:修飾詞 傳回資料類型 方法名稱(參數1,....參數N){程式區塊}
    //常用傳回類型: 無傳回void - 此方法沒有傳回資料
    //格式化:ctrl+K、D
    //自訂方法:
    //自訂方法需要被呼叫才會執行方法內的程式
    //名稱顏色為淡黃色 - 沒有被呼叫
    //名稱顏色為亮黃色 - 有被呼叫
    private void Test()
    {
        print("我是自訂方法");
    }

    private int ReturnJump()
    {
        return 999;
    }

    //參數語法:資料類型 參數名稱
    private void Skill(int damage)
    {
        print("參數版本 - 傷害值:" + damage);
        print("參數版本-技能特效");
    }

    //對照組:不使用參數
    //降低維護擴充性
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

    #endregion

    #region 事件 Event
    //特定時間點會執行的方法，程式的入口start等於Console Main
    //開始事件:遊戲開始時執行一次，處理初始化，取得資料等等
    private void Start()
    {
        Skill100();
        Skill200();
        //呼叫有參數方法時，必須輸入對應的引數
        Skill(300);
        Skill(999);


        #region 輸出 方法
        /*
        print("哈囉");

        Debug.Log("一般訊息");
        Debug.LogWarning("警告訊息");
        Debug.LogError("錯誤訊息");
        */
        #endregion

        # region 屬性練習
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
        //呼叫自訂方法語法:方法名稱();
        Test();
        //呼叫有傳回值的方法
        //1.區域變數指定傳回值 - 區域變數僅能在此結構(大括號)內存取
        int j = ReturnJump();
        print("跳躍值:" + j);
        //2.將傳回方法當成值使用
        print("跳躍值，當值使用:" + (ReturnJump() + 1));
    }
    //更新事件:一秒執行60次.60FPS - Frame Per Second
    //處理持續性的運動，移動物件，監聽玩家輸入按鍵
    private void Update()
    {

    }
    #endregion

}






