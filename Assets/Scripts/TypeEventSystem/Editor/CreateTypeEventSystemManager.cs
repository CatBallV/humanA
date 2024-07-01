using LKZ.TypeEventSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

/// <summary>
/// �㼶�������Ҽ����������¼�ϵͳ����
/// </summary>
public class CreateTypeEventSystemManager
{
    [UnityEditor.MenuItem("GameObject/LKZ/�����¼�ϵͳ������", priority = 11)]
    private static void CreateEventSystemManager()
    {
        if (Object.FindObjectOfType<TypeEventSystemManager>() != null)
        {
            Debug.LogError("�������Ѿ���һ�������¼�ϵͳ��������Ҫ����");
        }
        else
        {
            GameObject eventSystemGo = new GameObject("TypeEventSystemManager");
            eventSystemGo.AddComponent<TypeEventSystemManager>();
            Selection.activeObject = eventSystemGo;
        }
    }
}
