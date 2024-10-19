using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundFXManager : MonoBehaviour
{
    public static SoundFXManager instance;

    [Tooltip("Objeto vazio apenas com um AudioSource")]
    [SerializeField] private AudioSource soundFXObject;

    //Para tocar um som use em outros scripts:
    //SoundFXManager.instance.PlaySoundFXClip(audio, posicao, volume);
    //Use PlayRandomSoundFXClip se quiser um aleatorio
    //Caso de duvidas, video referencia: https://www.youtube.com/watch?v=DU7cgVsU2rM

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    /// <summary>
    /// Cria um AudioSource na cena para tocar o clip requisitado. 
    /// Sons daqui sao afetados pelo mixer e logo pelo slider de volume de FX
    /// </summary>
    /// <param name="audioClip">Clip a ser tocado</param>
    /// <param name="spawnTransform">Posicao</param>
    /// <param name="volume">Volume</param>
    public void PlaySoundFXClip(AudioClip audioClip, Transform spawnTransform, float volume)
    {   
        AudioSource audioSource = Instantiate(soundFXObject, spawnTransform.position, Quaternion.identity);
        audioSource.clip = audioClip;
        audioSource.volume = volume;
        audioSource.Play();

        float clipLength = audioSource.clip.length;
        Destroy(audioSource.gameObject, clipLength);
    }

    /// <summary>
    /// Cria um AudioSource na cena para tocar um clip aleatorio dentro do array. 
    /// Sons daqui sao afetados pelo mixer e logo pelo slider de volume de FX.
    /// </summary>
    /// <param name="audioClip">Array de clips a ser passados</param>
    /// <param name="spawnTransform">Posicao</param>
    /// <param name="volume">Volume</param>
    public void PlayRandomSoundFXClip(AudioClip[] audioClip, Transform spawnTransform, float volume)
    {
        int rand = Random.Range(0, audioClip.Length);

        AudioSource audioSource = Instantiate(soundFXObject, spawnTransform.position, Quaternion.identity);
        audioSource.clip = audioClip[rand];
        audioSource.volume = volume;
        audioSource.Play();

        float clipLength = audioSource.clip.length;
        Destroy(audioSource.gameObject, clipLength);
    }
}
