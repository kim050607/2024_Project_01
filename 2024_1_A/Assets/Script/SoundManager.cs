using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour                    
{
    public static SoundManager instance;                 //�̱��� �ν��Ͻ�(static�� ���� ������ �÷��� ��𼭵� ������ �� �ְ� ���ش�.)
    public List<Sound> sounds = new List<Sound>();       //���� ����Ʈ ����(List �ڷᱸ���� ����)
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);                    //Scene�� ����Ǿ (�� ������Ʈ��)�ı����� �ʴ´�.
        }
        else
        {
            Destroy(gameObject);                             //�̹� �ٸ� ������Ʈ�� ������� �ı��Ѵ�. Ŭ������ �������� 1���� ������ų �� �ִ�.
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
