using UnityEngine;
using UnityEngine.Audio;

public class AudioControl : MonoBehaviour
{
    [Header("音效管理")]
    public AudioMixer Mixer;

    /// <summary>
    /// 背景音樂
    /// </summary>
    public void VolumeBGM(float v)
    {
        Mixer.SetFloat("VolumeBGM", v);
    }

    /// <summary>
    /// 效果音樂
    /// </summary>
    public void VolumeSFX(float v)
    {
        Mixer.SetFloat("VolumeSFX", v);
    }
}
