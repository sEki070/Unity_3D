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

    [Header("檢查地面資料") ]
    [Tooltip("用來檢查腳色是否在地面上")]
    public bool on_the_ground ;
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
    #endregion

    #region 方法 Method
    #endregion

    #region 事件 Event
    //特定時間點會執行的方法，程式的入口start等於Console Main
    #endregion

}






