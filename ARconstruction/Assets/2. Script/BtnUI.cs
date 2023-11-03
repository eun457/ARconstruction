using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;



public class BtnUI : MonoBehaviour
{
    public GameObject dropdownMenu; // ��� �ٿ� �޴�
    private bool isMenuActive = false;  



    private void Start()
    {
        dropdownMenu.SetActive(false); //�޴� ��Ȱ��ȭ
    }



    public void ToggleDropDown()
    {
        isMenuActive = !isMenuActive;
        dropdownMenu.SetActive(isMenuActive);
    }

}
