using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ExResultScene : MonoBehaviour
{ 
    public void GoToGame()                  //버튼이 호출 할 함수를 제작          
    {
        SceneManager.LoadScene("GameScene_Gun");         //Scene 이동 
    }  
}
