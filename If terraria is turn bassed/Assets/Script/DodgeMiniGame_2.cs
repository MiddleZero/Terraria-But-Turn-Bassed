    using System;
    using System.Collections;
using System.Collections.Generic;
    using UnityEditor;
    using UnityEngine;
    using UnityEngine.UIElements;
    using Random = UnityEngine.Random;

    public class DodgeMiniGame_2 : MonoBehaviour
    {
        public GameManager GM;
        public float FailedTime = 0f;
        public float spawnNumber = 4f;
        public float GameTimer = 8;
        public float spawnRange;
        private bool onetime = false;
        public float SpawnTimer = 1f;
        public GameObject ThisO;
        public Up up;
        public Right right;
        public Down down;
        public Left left;
        public List<float> list = new List<float>{1, 2, 3, 4 };

    public void Start()
    {
        GM = FindObjectOfType<GameManager>();
        
        
    }

    private void Update()
    {
        
        if (SpawnTimer <=0)
        {
            RandomPick();
        }
       
        SpawnTimer -= Time.deltaTime;
        GameTimer -= Time.deltaTime;
        if (GameTimer <= 0)
        {
            Execute();
        }
    }

    public void Execute()
    {
        if (FailedTime >= 1f)
        {
            GM.SK.SetState(SlimeKing.SlimeState.teleport);
        }
        
        if (FailedTime <= 0)
        {
            GM.PlayertextObject.SetActive(true);
            GM.Invoke("TextClear",2f);
        }

        GM.Invoke("SlimeTurnEnd", 4f);
        GM.PS.ArmorPoint -= FailedTime * 5;
        if (GM.PS.ArmorPoint <= 0)
        {
            GM.PS.playrHealth -= FailedTime * 5;
        }
        Destroy(ThisO);
    }

    public void RandomPick()
    {
        SpawnTimer = 1f;
        spawnRange = list[Random.Range(0, list.Count)];
        list.Remove(spawnRange);
        
        if ((spawnRange == 1)&&spawnNumber>=1)
        {
            left.SpawnLeft();
            spawnNumber -= 1f;
        }
        if ((spawnRange == 2)&&spawnNumber>=1)
        {
            right.SpawnRight();
            spawnNumber -= 1f;
        }
        if ((spawnRange == 3)&&spawnNumber>=1)
        {
            up.SpawnUp();
            spawnNumber -= 1f;
        }
        if ((spawnRange == 4)&&spawnNumber>=1)
        {
            down.SpawnDown();
            spawnNumber -= 1f;
        }
    }

}
