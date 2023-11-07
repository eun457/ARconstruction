using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class BtnUI : MonoBehaviour
{
    Toggle[] toggles;
    enum ButtonIndex { Reset, Delete, Phase}
    Button[] buttons;

    [SerializeField] private Slider phaseSlider;
    [SerializeField] private GameObject dropdownMenu; //MEDF��� Ȱ��ȭ�� ������ ��Ӵٿ�޴�

    private bool isMenuActive = false; // Dropdown �޴� active��
    private bool isPhaseBtnOn = true; // ������ư on/off bool��

    private ShowObjs showObjScript;

    private void Start()
    {
        //UI�ʱ�ȭ
        InitializeUI();

        //ShowObjs.cs ����
        showObjScript = FindObjectOfType<ShowObjs>();

        //ResourceManager���� ��ư �迭 ����
        buttons = ResourceManager.instance.buttons;

        //���� ��ư Ŭ�� �� �̺�Ʈ ������ �Ҵ� TogglePhase �޼��� ����
        buttons[(int)ButtonIndex.Phase].onClick.AddListener(TogglePhase);
    }

    public void ToggleDropDown()
    {
        isMenuActive = !isMenuActive;
        dropdownMenu.SetActive(isMenuActive);
    }
    private void InitializeUI()
    {
        //ResourceManager���� Toggles �迭 ����
        toggles = ResourceManager.instance.toggles;

        dropdownMenu.SetActive(false);
        phaseSlider.interactable = false;

        //��� ��� Interactable = true ����
        SetTogglesInteractable(true);
    }

    private void TogglePhase()
    {
        if (showObjScript != null)
        {
            if (isPhaseBtnOn)
                //��� Objs.SetActive = false; ���·�
                showObjScript.LostnDelete();
            else
                //ViewAll���.isOn = true; ���·�
                showObjScript.ToggleInit();
        }

        //������ư on�� ��� ���/��Ÿ ��ư�� Interactable = false;
        SetTogglenBtnInteractable(!isPhaseBtnOn);

        //��ư ������ isPhaseBtnOn bool�� ����
        isPhaseBtnOn = !isPhaseBtnOn;
    }

    private void SetTogglenBtnInteractable(bool interactable)
    {
        //��� ���� ����
        SetTogglesInteractable(interactable);

        //��ư ���� ����
        buttons[(int)ButtonIndex.Reset].interactable = interactable;
        buttons[(int)ButtonIndex.Delete].interactable = interactable;

        //���� �����̴� ���� ����
        phaseSlider.interactable = !interactable;
        //������ưoff�Ǹ� �����̴� �� 0���� �ʱ�ȭ
        if (!interactable)
            phaseSlider.value = 0;
    }

    private void SetTogglesInteractable(bool interactable)
    {
        foreach (Toggle toggle in toggles)
        {
            toggle.interactable = interactable;
        }
    }
}
