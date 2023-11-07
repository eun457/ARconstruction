using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class BtnUI : MonoBehaviour
{
    #region Toggle
    Toggle m_Toggle_ViewAll;
    Toggle m_Toggle_Frame;
    Toggle m_Toggle_Wall;
    Toggle m_Toggle_MEPF;
    Toggle m_Toggle_Mechanical;
    Toggle m_Toggle_Plumbing;
    Toggle m_Toggle_FireProtection;
    #endregion

    #region Button
    [SerializeField] Button m_resetBtn;
    [SerializeField] Button m_deleteBtn;
    [SerializeField] Button m_phaseBtn;
    #endregion

    [SerializeField] Slider phaseSlider;
    ShowObjs showObjScript;
    public GameObject dropdownMenu; // ��� �ٿ� �޴�
    private bool isMenuActive = false; //MEPF ��� üũ�ڽ� bool��
    bool isPhaseBtnOn = true; //������ư on/off ���п� bool��

    private void Start()
    {
        //��ü UI �ʱ�ȭ
        UIInit();

        //showObgScript ����
        showObjScript = FindObjectOfType<ShowObjs>();

        m_phaseBtn.onClick.AddListener(delegate
        {
            ClickPhaseBtn();
        });
    }

    public void ToggleDropDown()
    {
        isMenuActive = !isMenuActive;
        dropdownMenu.SetActive(isMenuActive);
    }

    void UIInit()
    {
        Toggle[] togglesFromManager = ResourceManager.instance.toggles;
        m_Toggle_ViewAll = togglesFromManager[0];
        m_Toggle_Frame = togglesFromManager[1];
        m_Toggle_Wall = togglesFromManager[2];
        m_Toggle_MEPF = togglesFromManager[3];
        m_Toggle_Mechanical = togglesFromManager[4];
        m_Toggle_Plumbing = togglesFromManager[5];
        m_Toggle_FireProtection = togglesFromManager[6];

        //��� ��� Interactable = true;
        m_Toggle_ViewAll.interactable = true;
        m_Toggle_Frame.interactable = true;
        m_Toggle_Wall.interactable = true;
        m_Toggle_MEPF.interactable = true;
        m_Toggle_Mechanical.interactable = true;
        m_Toggle_Plumbing.interactable = true;
        m_Toggle_FireProtection.interactable = true;

        dropdownMenu.SetActive(false); //�޴� ��Ȱ��ȭ

        //����slider = false;
        phaseSlider.interactable = false;
    }

    void ClickPhaseBtn()
    {
        if (isPhaseBtnOn == true)
        {

            if (showObjScript != null)
            {
                showObjScript.LostnDelete();
            }

            //��� ��� Interactable = false;
            m_Toggle_ViewAll.interactable = false;
            m_Toggle_Frame.interactable = false;
            m_Toggle_Wall.interactable = false;
            m_Toggle_MEPF.interactable = false;
            m_Toggle_Mechanical.interactable = false;
            m_Toggle_Plumbing.interactable = false;
            m_Toggle_FireProtection.interactable = false;

            //�κк������ ��ư(Reset/Delete) Ŭ�� �Ұ�
            m_resetBtn.interactable = false;
            m_deleteBtn.interactable = false;

            //����slider = true;
            phaseSlider.interactable = true;

            isPhaseBtnOn = false;
        }
        else
        {
            if (showObjScript != null)
            {
                showObjScript.ToggleInit();
            }

            //��� ��� Interactable = true;
            m_Toggle_ViewAll.interactable = true;
            m_Toggle_Frame.interactable = true;
            m_Toggle_Wall.interactable = true;
            m_Toggle_MEPF.interactable = true;
            m_Toggle_Mechanical.interactable = true;
            m_Toggle_Plumbing.interactable = true;
            m_Toggle_FireProtection.interactable = true;

            //�κк������ ��ư(Reset/Delete) Ŭ�� ����
            m_resetBtn.interactable = true;
            m_deleteBtn.interactable = true;

            //����slider = false;
            phaseSlider.value = 0;
            phaseSlider.interactable = false;

            isPhaseBtnOn = true;
        }
    }
}
