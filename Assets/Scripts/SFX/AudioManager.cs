using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{
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
        }

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
}
