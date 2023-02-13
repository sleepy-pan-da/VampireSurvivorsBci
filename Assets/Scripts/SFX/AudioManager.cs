using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioMixerGroup musicMixerGroup;
    [SerializeField] private AudioMixerGroup sfxMixerGroup;
    public Sound[] sounds;

    private void Awake()
    {
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.isLoop;
            s.source.playOnAwake = s.playOnAwake;

            switch (s.audioType)
            {
                case Sound.AudioTypes.sfx:
                    s.source.outputAudioMixerGroup = sfxMixerGroup;
                    break;
                case Sound.AudioTypes.music:
                    s.source.outputAudioMixerGroup = musicMixerGroup;
                    break;
            }

            if (s.playOnAwake) s.source.Play();
        }

        AudioOptionsManager.OnChangedMusicVol += UpdateMixerMusicVolume;
        AudioOptionsManager.OnChangedSfxVol += UpdateMixerSfxVolume;

        EnemyStatsManager.OnTakenDamageSfx += PlaySfx;
        Collector.OnCollectCoinSfx += PlaySfx;

        CollisionManager.OnTakingDamageSfx += PlaySfx;
        CollisionManager.OnStopTakingDamage += StopSfx;

        Sword.OnSwingSwordSfx += PlaySfx;
        KnifeInstance.OnFireKnifeSfx += PlaySfx;
        CleaverInstance.OnFireCleaverSfx += PlaySfx;
        SpearInstance.OnFireSpearSfx += PlaySfx;
        HammerChild.OnHitHammerSfx += PlaySfx;
        FireboltInstance.OnFireFireboltSfx += PlaySfx;
    }
    
    private void OnDisable()
    {
        AudioOptionsManager.OnChangedMusicVol -= UpdateMixerMusicVolume;
        AudioOptionsManager.OnChangedSfxVol -= UpdateMixerSfxVolume;

        EnemyStatsManager.OnTakenDamageSfx -= PlaySfx;
        Collector.OnCollectCoinSfx -= PlaySfx;

        CollisionManager.OnTakingDamageSfx -= PlaySfx;
        CollisionManager.OnStopTakingDamage -= StopSfx;

        Sword.OnSwingSwordSfx -= PlaySfx;
        KnifeInstance.OnFireKnifeSfx -= PlaySfx;
        CleaverInstance.OnFireCleaverSfx -= PlaySfx;
        SpearInstance.OnFireSpearSfx -= PlaySfx;
        HammerChild.OnHitHammerSfx -= PlaySfx;
        FireboltInstance.OnFireFireboltSfx -= PlaySfx;
    }

    private void PlaySfx(string source)
    {
        Sound s = Array.Find(sounds, sound => sound.name == source);
        if (s == null) return;
        if (s.source.isPlaying && s.cannotBeInterrupted) return;
        s.source.Play();
    }

    private void StopSfx(string source)
    {
        Sound s = Array.Find(sounds, sound => sound.name == source);
        if (s == null) return;
        s.source.Stop();
    }

    public void UpdateMixerMusicVolume(float newMusicVol)
    {
        musicMixerGroup.audioMixer.SetFloat("MusicVol", Mathf.Log10(newMusicVol)*20);
    }

    public void UpdateMixerSfxVolume(float newSfxVol)
    {
        musicMixerGroup.audioMixer.SetFloat("SfxVol", Mathf.Log10(newSfxVol)*20);
    }
}
