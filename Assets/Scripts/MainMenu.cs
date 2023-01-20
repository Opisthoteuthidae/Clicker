using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Библиотека для работы с UI элементами(UI- кнопки, текст и т.д.).
using UnityEngine.SceneManagement; // Работа со сценами

public class MainMenu : MonoBehaviour
{
    
    [SerializeField] int money; // SerializeField - дает возможность, даже приватным переменным, редактировать в Unity. 
    public Text moneyText; //Переменная типа текст для отображения денег
    public int oll_money; //переменная для хранения количества монет заработанных во время игры

    void Start()
    {
        money = PlayerPrefs.GetInt("money"); //При загрузке игры получить(Get) значение монет
        oll_money = PlayerPrefs.GetInt("oll_money"); //Выводит количество монет заработанных в прошлых играх
        bool isFirst = PlayerPrefs.GetInt("isFirst") == 1 ? true : false;
        
            StartCoroutine(IdleFarm());
        
    }

     public void ButtonClick() // Event Trigger - pointer click - ButtonClick (Метод встроенный в Unity)
     {
       money++; // Увеличение переменной на 1 еденицу
       oll_money++;
       PlayerPrefs.SetInt("money", money); //Сохранение монет при каждом нажатии
       PlayerPrefs.SetInt("oll_money", oll_money); //Сохранение монет
     } 

     IEnumerator IdleFarm()
     {
        yield return new WaitForSeconds(1);
        money++;
        Debug.Log(money);
        PlayerPrefs.SetInt("money", money);
        StartCoroutine(IdleFarm());
     }

    void Update()
    {
        moneyText.text = money.ToString();  //ToString - Он преобразует объект в строковое представление, чтобы он был подходил для отображения.
    }

    public void ToAchiv() //Переменная 2ой сцены
    {
    SceneManager.LoadScene(1);
    }
}


 