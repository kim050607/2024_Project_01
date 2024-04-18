using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;                      //DoTween�� ����ϱ� ���� �߰�

public class TweenTest : MonoBehaviour
{
    void Start()
    {
        //transform.DOMoveX(5, 2);                  //�� ������Ʈ�� 2�ʵ��� X�� 5�� �̵���Ų��.
        //transform.DORotate(new Vector3(0, 0, 180), 2);       //�� ������Ʈ�� 2�ʵ��� Z������ 180�� ȸ�� ��Ų��.
        //transform.DOScale(new Vector3(2, 2, 2), 2);          //�� ������Ʈ�� 2�ʵ��� 2��� Ű���.

        //Sequence sequence = DOTween.Sequence();            //Tween�� �̾ ������� ���� �����ִ� ����
        //sequence.Append(transform.DOMoveX(5, 2));
        //sequence.Append(transform.DORotate(new Vector3(0, 0, 180), 2));
        //sequence.Append(transform.DOScale(new Vector3(2, 2, 2), 2));

        //transform.DOMoveX(5,2f) .SetEase(Ease.OutBounce);       //Ease �ɼ��� ����Ͽ� �ٿ ȿ�� ����
        //transform.DOShakeRotation(2f, new Vector3(0, 0, 90), 10, 90); //ȸ���� Z�� 90�� ���� 10, ���� 90���� ���� �ش�.

        transform.DOMoveX(5, 2f).SetEase(Ease.OutBounce).OnComplete(TweenEnd); 
    }

    void TweenEnd()
    {
        gameObject.SetActive(false);
    }
}
