using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class MultipleImageTracker : MonoBehaviour
{
    ARTrackedImageManager imageManager;

    // Start is called before the first frame update
    void Start()
    {
        // ARTrackedImageManager ������Ʈ�� �����ɴϴ�.
        imageManager = GetComponent<ARTrackedImageManager>();

        // �̹��� Ʈ��ŷ ���� ���� �̺�Ʈ�� ���� �ݹ� �Լ��� ����մϴ�.
        imageManager.trackedImagesChanged += OnTrackedImage;
    }

    private void OnTrackedImage(ARTrackedImagesChangedEventArgs args)
    {
        // ���ο� �̹����� �νĵǾ��� ���� ó��
        foreach (ARTrackedImage trackedImage in args.added)
        {
            // �̹����� �̸��� �����ɴϴ�. �� �̸��� �̹��� ���̺귯������ ������ ���Դϴ�.
            string imageName = trackedImage.referenceImage.name;

            // Resources �������� �̹����� �̸��� ������ �̸��� ���� �������� ã���ϴ�.
            GameObject imagePrefab = Resources.Load<GameObject>(imageName);

            // �˻��� �������� �����ϴ� ���
            if (imagePrefab != null)
            {
                // �̹����� �̹� �ڽ� ������Ʈ�� ���ٸ�
                if (trackedImage.transform.childCount < 1)
                {
                    // �̹����� ��ġ�� ȸ���� �ش��ϴ� �������� �����ϰ� �̹����� �ڽ����� �����մϴ�.
                    GameObject go = Instantiate(imagePrefab, trackedImage.transform.position, trackedImage.transform.rotation);
                    go.transform.SetParent(trackedImage.transform);
                }
            }
        }

        // �̹��� Ʈ��ŷ ���� �̹������� ��� ��ȸ
        foreach (ARTrackedImage trackedImage in args.updated)
        {
            // �̹����� �ڽ� ������Ʈ�� �ִ� ���
            if (trackedImage.transform.childCount > 0)
            {
                // �ڽ� ������Ʈ�� ��ġ�� ȸ���� �̹����� ����ȭ��ŵ�ϴ�.
                trackedImage.transform.GetChild(0).transform.position = trackedImage.transform.position;
                trackedImage.transform.GetChild(0).transform.rotation = trackedImage.transform.rotation;
            }
        }

        //�̹��� Ʈ��ŷ�� �ϴٰ� �̹����� �������
        foreach (ARTrackedImage trackedImage in args.removed)
        {
            // �̹����� �ڽ� ������Ʈ�� �ִ� ���
            if (trackedImage.transform.childCount > 0)
            {
                // �ڽ� ������Ʈ�� ��ġ�� ȸ���� �̹����� ����ȭ��ŵ�ϴ�.
                trackedImage.transform.GetChild(0).gameObject.SetActive(false);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        // �� �Լ������� �����Ӹ��� � �۾��� �������� ����
    }
}