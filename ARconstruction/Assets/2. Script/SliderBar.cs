using UnityEngine;
using UnityEngine.UI;

public class SliderBar : MonoBehaviour
{
    [SerializeField] private Slider slider;

    GameObject[] gameObjects;

    void Start()
    {
        // ResourceManager���� ������Ʈ�� ������ �迭�� ����
        gameObjects = ResourceManager.instance.objects;

        // Slider�� ���� ����� �� ȣ��� �޼��� ����
        slider.onValueChanged.AddListener(OnSliderValueChanged);
    }

    private void OnSliderValueChanged(float value)
    {
        // ����, ��� ������Ʈ�� ��Ȱ��ȭ
        SetActiveObjects(false);

        // ���� ���� Ư�� ������Ʈ�鸸 Ȱ��ȭ
        switch (value)
        {
            case 0:
                SetActiveObjects(false);
                break;
            case 1:
                SetActiveForIndices(true, 3, 4, 5);
                break;
            case 2:
                SetActiveForIndices(true, 1, 3, 4, 5);
                break;
            case 3:
                SetActiveForIndices(true, 2, 3, 4, 5);
                break;
            default:
                gameObjects[0].SetActive(true);
                SetActiveForIndices(true, 2, 3, 4, 5);
                break;
        }
    }

    // ��� ������Ʈ�� Ȱ�� ���¸� �����ϴ� �޼���
    private void SetActiveObjects(bool active)
    {
        foreach (GameObject obj in gameObjects)
        {
            if (obj != null)
            {
                obj.SetActive(active);
            }
        }
    }

    // �־��� �ε����� ������Ʈ�� Ȱ��ȭ�ϴ� �޼���
    private void SetActiveForIndices(bool active, params int[] indices)
    {
        foreach (int i in indices)
        {
            if (i >= 0 && i < gameObjects.Length && gameObjects[i] != null)
            {
                gameObjects[i].SetActive(active);
            }
        }
    }
}
