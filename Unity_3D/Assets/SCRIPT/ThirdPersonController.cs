using UnityEngine;   //�ޥ�Unity API (�ܮw ��ƻP�\��)
using UnityEngine.Video;
//MonBahaviour:�����O
/// <summary>
/// {�K�n}
/// </summary>
public class ThirdPersonController : MonoBehaviour
{
    #region ���Field
    //�x�s�C����ơA�Ҧp:���ʳt�סB���D���׵���...
    //�`�Υ|�j����:��ơB���I�ơB�r��B���L��
    //���y�k:�׹��� ������� ���W�� (���w �w�]��) ����
    //�׹���:
    //1.���}public - ���\��L�����s�� - ��ܦb�ݩʭ��O - �ݭn�վ㪺��Ƴ]�w�����}
    //2.�p�Hprivate - �T���L�����s�� - ���æb�ݩʭ��O - �w�]��
    //*Unity �H�ݩʭ��O��Ƭ��D
    //��_�{���w�]�ȽЫ�...Reset
    //����ݩ�Attribute :���U�����
    //����ݩʻy�k:[�ݩʦW��(�ݩʭ�)]
    [Header("���ʳt��"), Tooltip("�Ψӽվ�}�Ⲿ�ʳt��"), Range(1, 500)]
    public float speed = 10.5f;
    [Header("���D����"), Tooltip("�Ψӽվ�}����D����"), Range(1, 1000)]
    public int hight = 100;

    [Header("�ˬd�a�����")]
    [Tooltip("�Ψ��ˬd�}��O�_�b�a���W")]
    public bool on_the_ground;
    public float groundhannkei = 0.2f;
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

    private AudioSource aud;
    private Rigidbody rig;
    private Animator ani;
    //�P�|ctrl+M O
    //�i�}ctrl+M L
    
    private void movement(float speed)
    {

    }
   
    private float movebutton()
    {
        return 0f;
    }
    private bool groundcheck()
     {
        return false;
     } 
    private void Jump()
    {
        
    }
    private void UpdateAnimation() 
    {
        
    }



    
    #region Unity ����
    /** �m��Unity
    //�C�� Color
    public Color color;
    public Color white = Color.white;                  //�����C��
    public Color yellow = Color.yellow;              
    public Color color1 = new Color(1,0.5f,0.5f,0.5f); //�ۭq�C��RGB

    //�y��Vector 2 - 4
    public Vector2 v2;
    public Vector2 v2Right = Vector2.right;
    public Vector2 v2Left = Vector2.left;
    public Vector2 v2Up = Vector2.one;
    public Vector2 v2Custom = new Vector2(7.5f, 100.9f);
    public Vector2 v3 = new Vector3(1, 2, 3);
    public Vector3 v3Forward = Vector3.forward; 
    public Vector4 v4 = new Vector4(1, 2, 3,4);

    //���� �C�|���enum
    public KeyCode key;
    public KeyCode move = KeyCode.W;
    public KeyCode jump = KeyCode.Space;

    //�C���������: ������w�w�]��
    public AudioClip sound;    //���� mp3,ogg,wav
    public VideoClip video;  //�v�� mp4
    public Sprite sprite;      //�Ϥ�png,jpeg    -���䴩gif
    public Texture2D texture2D;//2D �Ϥ� png,jpeg
    public Material material;  //����y
    [Header("����")]
    //���� Component :�ݩʭ��O�W�i���|��
    public Transform tra;
    public Animation aniOld;
    public Animator aniNew;
    public Light lig;
    public Camera caml

    //���L�C
    //1.��ĳ���n�ϥΦ��W��
    //2.�J��L�ɪ�API
    **/

    #endregion
    #endregion

    #region �ݩ�Property

    //�ݩʤ��|��ܦb���O�W
    //�x�s��ơA�P���ۦP
    //�t���b��:�i�H�]�w�s������ Get Set
    //�ݩʻy�k:�׹��� ������� �ݩʦW�� {��;�s;}
    public int readAndWrite { get; set; }
    //��Ū�ݩ�:�u����oGet
    public int read { get; }
    //��Ū�ݩ�: �z�Lget�]�w�w�]�ȡA����rreturn���Ǧ^��
    public int readValue
    {
        get
        {
            return 77;
        }
    }
    //�߼g�ݩʬO�T��A�����n��get
    //public int write { set; }
    //value �����O���w����
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
    #region ��k Method
    //�w�q�P��@�������{�����϶��A�\��
    //��k�y�k:�׹��� �Ǧ^������� ��k�W��(�Ѽ�1,....�Ѽ�N){�{���϶�}
    //�`�ζǦ^����: �L�Ǧ^void - ����k�S���Ǧ^���
    //�榡��:ctrl+K�BD
    //�ۭq��k:
    //�ۭq��k�ݭn�Q�I�s�~�|�����k�����{��
    //�W���C�⬰�H���� - �S���Q�I�s
    //�W���C�⬰�G���� - ���Q�I�s
    private void Test()
    {
        print("�ڬO�ۭq��k");
    }

    private int ReturnJump()
    {
        return 999;
    }
    //��񦡰Ѽƥu���b()�k��
    //�Ѽƻy�k:������� �ѼƦW��
    //���w�]�Ȫ��Ѽƥi�H����J�޼ơA��񦡰Ѽ�
    private void Skill(int damage,string effect="�ǹЯS��",string sound ="������")
    {
        print("�Ѽƪ��� - �ˮ`��:" + damage);
        print("�Ѽƪ���-�ޯ�S��:"+effect);
        print("�Ѽƪ��� - ����:" + sound);
    }

    //��Ӳ�:���ϥΰѼ�
    //���C���@�X�R��
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
    
    //*�D���n���ܭ��n
    //BMI = �魫/����*����(����)
    /// <summary>
    /// �p��BMI��k
    /// </summary>
    /// <param name="weight"></param>
    /// <param name="height"></param>
    /// <param name="name"></param>
    /// <returns></returns>
    private float BMI (float weight,float height, string name = "����")
    {
        print(name + "��BMI");
        return weight / (height * height);
    }

    #endregion

    #region �ƥ� Event
    //�S�w�ɶ��I�|���檺��k�A�{�����J�fstart����Console Main
    //�}�l�ƥ�:�C���}�l�ɰ���@���A�B�z��l�ơA���o��Ƶ���
    private void Start()
    {
        print(BMI(61, 1.71f, "SEKI"));
        
        
        Skill100();
        Skill200();
        //�I�s���ѼƤ�k�ɡA������J�������޼�
        Skill(300);
        Skill(999,"�z���S��");
        //�ݨD:�ˮ`��500�A�S�ĥιw�]�ȡA���Ĵ���������
        //���h�ӿ�񦡰Ѽƥi�ϥΫ��W�Ѽƻy�k;�ѼƦW��:��
        Skill(500, sound: "������");

        #region ��X ��k
        /*
        print("���o");

        Debug.Log("�@��T��");
        Debug.LogWarning("ĵ�i�T��");
        Debug.LogError("���~�T��");
        */
        #endregion

        # region �ݩʽm��
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
        //�I�s�ۭq��k�y�k:��k�W��();
        Test();
        //�I�s���Ǧ^�Ȫ���k
        //1.�ϰ��ܼƫ��w�Ǧ^�� - �ϰ��ܼƶȯ�b�����c(�j�A��)���s��
        int j = ReturnJump();
        print("���D��:" + j);
        //2.�N�Ǧ^��k���Ȩϥ�
        print("���D�ȡA��Ȩϥ�:" + (ReturnJump() + 1));
    }
    //��s�ƥ�:�@�����60��.60FPS - Frame Per Second
    //�B�z����ʪ��B�ʡA���ʪ���A��ť���a��J����
    private void Update()
    {

    }
    #endregion

}






