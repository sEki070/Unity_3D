using UnityEngine;

namespace SHIH
{
    /// <summary>
    /// 音效系統
    /// 提供窗口給要撥放音效的物教
    /// </summary>
    //套用元件時會要求元件: 會自動添加指定的元件
    
    //[要求元件(類型(元件1),類型(元件2),....)]
    [RequireComponent(typeof(AudioSource))]
    public class AudioSystem : MonoBehaviour
    {
        #region 欄位
        private AudioSource aud;
        #endregion


        #region 事件
        private void Awake()
        {
            aud = GetComponent<AudioSource>();
        }
        #endregion


        #region 方法: 公開
        /// <summary>
        /// 以正常音量撥放音效
        /// </summary>
        /// <param name="sound">音效</param>
        public void PlaySound(AudioClip sound)
        {
            aud.PlayOneShot(sound);
        }

        /// <summary>
        /// 撥放音效並且隨機音量: 0.7 ~ 1.2
        /// </summary>
        /// <param name="sound"></param>
        public void PlaySoundRandomVolume(AudioClip sound)
        {
            float volume = Random.Range(0.7f, 1.2f);
            aud.PlayOneShot(sound, volume);
        }
        #endregion


    }

}
