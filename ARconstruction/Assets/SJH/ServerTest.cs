using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BackEnd;

public class ServerTest : MonoBehaviour
{
    private void Awake()
    {
        BackendSetUP();
    }
    void BackendSetUP()
    {
        var bro = Backend.Initialize(true);

        if(bro.IsSuccess())
        {
            print("�ʱ�ȭ ����");
        }
        else
        {
            print("�ʱ�ȭ ����");
        }
    }

}
