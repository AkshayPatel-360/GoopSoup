﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monolith : MonoBehaviour, IUpdatable
{
    static readonly float Monolith_Death_Time = 3;

    public Ingredient ingredient;
    public SpriteRenderer symbols;
    public SpriteRenderer sr;
    string monsterType;
    float timeOfNextMonsterSpawn;
    public  bool IsMonolithDead = false;
    public void Initialize()
    {
        sr = GetComponent<SpriteRenderer>();
        ingredient = Ingredient.RandomIngredient();
        symbols.color = ingredient.ToColor();
        monsterType = MonsterFactory.Instance.GetRandomMonsterName();
    }

    public void IUpdate(float dt)
    {
        if(timeOfNextMonsterSpawn <= Time.time)
        {
            MonsterFactory.Instance.CreateMonster(monsterType, GV.GetRandomSpotNear(transform.position, new Vector2(1, GV.Monster_Breed_SpawnDist)),ingredient);
            timeOfNextMonsterSpawn = Time.time + GV.Monolith_Spawn_Monster_Rate;
        }
    }

    public static Monolith SpawnRandomMonolith()
    {
        GameObject monoObj = GameObject.Instantiate<GameObject>(Resources.Load<GameObject>("Prefabs/Monolith/Monolith"));
        Monolith toRet = monoObj.GetComponent<Monolith>();
        toRet.Initialize();
        monoObj.transform.position = GV.GetRandomSpotInMap();
        return toRet;
    }

    public void DestroyMonolith()
    {
        MonolithManager.Instance.RemoveItem(this);
        GetComponent<Collider2D>().enabled = false;
        StartCoroutine(MonolithDestructionEffect());
    }

    IEnumerator MonolithDestructionEffect()
    {
        float timeOfDeath = Time.time + Monolith_Death_Time;
        while(Time.time < timeOfDeath)
        {
            float p = 1 - ((timeOfDeath - Time.time) / Monolith_Death_Time);
            sr.color = Color.Lerp(Color.white, ingredient.ToColor(), p);
            yield return null;
        }
        GameObject.Destroy(gameObject);
    }
}
