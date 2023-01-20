using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Achiv : MonoBehaviour
{
    public int money;
    public int oll_money; //Общее количество монет
    [SerializeField] Button firstAch; 
    [SerializeField] bool isFirst;  //получено достижение или нет
    void Start()
    {
        money = PlayerPrefs.GetInt("money");
        oll_money = PlayerPrefs.GetInt("oll_money"); //получет значение монет из PlayerPrefs(Помнит настройки)
        isFirst = PlayerPrefs.GetInt("isFirst") == 1 ? true : false;

        if (oll_money >= 450 && !isFirst) //&& - И, !isFirst = false
        {
           firstAch.interactable = true;
        }

        else
        {
            firstAch.interactable = false;
            StartCoroutine(IdleFarm());
        }  

    }

    public void GetFirst()
    {
        int money = PlayerPrefs.GetInt("money");
        money += 450;
        PlayerPrefs.SetInt("money", money);
        isFirst = true;
        PlayerPrefs.SetInt("isFirst", isFirst ? 1 : 0);
    }
    IEnumerator IdleFarm()
    {
       yield return new WaitForSeconds(1);
       money++;
       Debug.Log(money);
       PlayerPrefs.SetInt("money", money); // "money"-строка, ,money - передаем значение money
       StartCoroutine(IdleFarm());
    }
    

    public void ToMenu()
    {
        SceneManager.LoadScene(0);
    }
  
    void Update()
    {
        
    }
    
}
