using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour                    
{
    public static SoundManager instance;                 //싱글톤 인스턴스(static은 전역 변수로 올려서 어디서든 접근할 수 있게 해준다.)
    public List<Sound> sounds = new List<Sound>();       //사운드 리스트 관리(List 자료구조로 관리)
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);                    //Scene이 변경되어도 (이 오브젝트는)파괴되지 않는다.
        }
        else
        {
            Destroy(gameObject);                             //이미 다른 오브젝트가 있을경우 파괴한다. 클래스를 전역으로 1개를 유지시킬 수 있다.
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
