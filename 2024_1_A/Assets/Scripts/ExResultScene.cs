using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ExResultScene : MonoBehaviour
{ 
    public void GoToGame()                  //��ư�� ȣ�� �� �Լ��� ����          
    {
        SceneManager.LoadScene("GameScene_Gun");         //Scene �̵� 
    }  
}
