using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MiaNavicella : MonoBehaviour
{
    
    public GameObject mynav;
    public int viteIniziali = 1;
    public int viteAttuali;
    float shootTimer;
    public GameObject laser;
    public GameObject laserDannox2;
    public int bonusDanno = 0;
    public int bonusDannoCorrente;
    float bonusTimer = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
        viteAttuali = viteIniziali;
        Debug.Log("Numero di vite: " + viteAttuali);
        bonusDannoCorrente = bonusDanno;
    }

    // Update is called once per frame
    void Update()
    {
        if (bonusDannoCorrente != 0)
        {
            Debug.Log("è cambiato");
        }
        if (bonusDannoCorrente != 0)
        {
            bonusTimer -= Time.deltaTime;
            if (bonusTimer <= 0)
            {
                bonusDannoCorrente = 0;
                Debug.Log("Bonus terminato.");
                bonusTimer = 10.0f;
            }
        }

        //Debug.Log("Bonus: " + bonusDanno);
        shootTimer -= Time.deltaTime;
        if (shootTimer <= 0)
        {
            if (Input.GetButton("Fire1"))
            {
                if (bonusDannoCorrente == 0)
                {
                    Vector3 spawnLaserPos = Camera.main.ScreenToWorldPoint(
                        new Vector3(-5.0f, Input.mousePosition.y, 8));
                        Instantiate(laser, spawnLaserPos, Quaternion.identity);
                    shootTimer = 0.3f;
                }
                else
                {
                    Vector3 spawnLaserPos = Camera.main.ScreenToWorldPoint(
                        new Vector3(-5.0f, Input.mousePosition.y, 8));
                        Instantiate(laserDannox2, spawnLaserPos, Quaternion.identity);
                    shootTimer = 0.3f;
                }
            }
        } 
    }
}
