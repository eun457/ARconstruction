//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UI;

//public class BtnUI : MonoBehaviour
//{
//    ShowObjs showObjScript;

//    #region Toggle
//    [SerializeField] Toggle m_Toggle_ViewAll;
//    [SerializeField] Toggle m_Toggle_Frame;
//    [SerializeField] Toggle m_Toggle_Wall;
//    [SerializeField] Toggle m_Toggle_MEPF;
//    [SerializeField] Toggle m_Toggle_Mechanical;
//    [SerializeField] Toggle m_Toggle_Plumbing;
//    [SerializeField] Toggle m_Toggle_FireProtection;
//    #endregion

//    #region Button
//    [SerializeField] Button m_resetBtn;
//    [SerializeField] Button m_deleteBtn;
//    [SerializeField] Button m_phaseBtn;
//    #endregion

//    [SerializeField] Slider phaseSlider;

//    public GameObject dropdownMenu; // ��� �ٿ� �޴�
//    private bool isMenuActive = false;
//    bool isPhaseBtnOn = true;

//    private void Start()
//    {
//        UIInit();

//        showObjScript = FindObjectOfType<ShowObjs>();

//        m_phaseBtn.onClick.AddListener(ClickPhaseBtn);
//    }

//    public void ToggleDropDown()
//    {
//        isMenuActive = !isMenuActive;
//        dropdownMenu.SetActive(isMenuActive);
//    }

//    void UIInit()
//    {
//        SetToggleInteractable(true);
//        SetButtonInteractable(true);
//        SetPhaseSliderInteractable(false);
//        dropdownMenu.SetActive(false); // �޴� ��Ȱ��ȭ
//    }

//    void ClickPhaseBtn()
//    {
//        isPhaseBtnOn = !isPhaseBtnOn;

//        if (showObjScript != null)
//        {
//            if (isPhaseBtnOn)
//            {
//                showObjScript.ToggleInit();
//            }
//            else
//            {
//                showObjScript.LostnDelete();
//            }
//        }

//        SetToggleInteractable(!isPhaseBtnOn);
//        SetButtonInteractable(!isPhaseBtnOn);
//        SetPhaseSliderInteractable(isPhaseBtnOn);
//    }

//    void SetToggleInteractable(bool interactable)
//    {
//        m_Toggle_ViewAll.interactable = interactable;
//        m_Toggle_Frame.interactable = interactable;
//        m_Toggle_Wall.interactable = interactable;
//        m_Toggle_MEPF.interactable = interactable;
//        m_Toggle_Mechanical.interactable = interactable;
//        m_Toggle_Plumbing.interactable = interactable;
//        m_Toggle_FireProtection.interactable = interactable;
//    }

//    void SetButtonInteractable(bool interactable)
//    {
//        m_resetBtn.interactable = interactable;
//        m_deleteBtn.interactable = interactable;
//    }

//    void SetPhaseSliderInteractable(bool interactable)
//    {
//        phaseSlider.interactable = interactable;
//        phaseSlider.value = interactable ? 0 : phaseSlider.value;
//    }
//}
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;



public class BtnUI : MonoBehaviour
{
    ShowObjs showObjScript;

    #region Toggle
    [SerializeField] Toggle m_Toggle_ViewAll;
    [SerializeField] Toggle m_Toggle_Frame;
    [SerializeField] Toggle m_Toggle_Wall;
    [SerializeField] Toggle m_Toggle_MEPF;
    [SerializeField] Toggle m_Toggle_Mechanical;
    [SerializeField] Toggle m_Toggle_Plumbing;
    [SerializeField] Toggle m_Toggle_FireProtection;
    #endregion

    #region Button
    [SerializeField] Button m_resetBtn;
    [SerializeField] Button m_deleteBtn;
    [SerializeField] Button m_phaseBtn;
    #endregion

    [SerializeField] Slider phaseSlider;

    public GameObject dropdownMenu; // ��� �ٿ� �޴�
    private bool isMenuActive = false; //MEPF ��� üũ�ڽ� bool��

    bool isPhaseBtnOn = true; //������ư on/off ���п� bool��

    private void Start()
    {
        //��ü UI �ʱ�ȭ
        UIInit();

        //showObgScript
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
