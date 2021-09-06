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
    [Header("���ʳt��"),Tooltip("�Ψӽվ�}�Ⲿ�ʳt��"),Range(1,500)]
    public float speed=10.5f;

    #region Unity ����
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


     #endregion
    #endregion
    #region �ݩ�Property
    #endregion

    #region ��k Method
    #endregion

    #region �ƥ� Event
    #endregion
}
