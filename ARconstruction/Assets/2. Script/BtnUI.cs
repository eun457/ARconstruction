using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;



public class BtnUI : MonoBehaviour
{
    public GameObject dropdownMenu; // ��� �ٿ� �޴�
    private bool isMenuActive = false;  

    public CanvasScaler scaler;
    float fixedRatio = 16f / 9f; //�ػ� Default
    float currentRatio = (float)Screen.width / (float)Screen.height; //���� �ػ� ����




    private void Start()
    {
        scaler = GetComponent<CanvasScaler>();
        dropdownMenu.SetActive(false); //�޴� ��Ȱ��ȭ
        AdjustCanvasnScaler();
    }

    void AdjustCanvasnScaler()
    {
        // ���� �ػ� ���� ������ �� �� ���
        if (currentRatio > fixedRatio)
        {
            scaler.matchWidthOrHeight = 1; // ���� ���� ����
        }
        // ���� �ػ��� ���� ������ �� �� ���
        else if (currentRatio < fixedRatio)
        {
            scaler.matchWidthOrHeight = 0; // ���� ���� ����
        }
    }

    public void ToggleDropDown()
    {
        isMenuActive = !isMenuActive;
        dropdownMenu.SetActive(isMenuActive);
    }

}
