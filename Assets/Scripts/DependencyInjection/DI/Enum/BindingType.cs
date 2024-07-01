using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LKZ.DependencyInject
{
    /// <summary>
    /// �󶨵�����
    /// </summary>
    public enum BindingType
    {
        /// <summary>
        /// �Ͱ��Լ������ʵ����
        /// </summary>
        [InspectorName("�Ͱ��Լ������ʵ����")]
        BindingToSelf,

        /// <summary>
        /// ��������еĽӿڣ�������ı���
        /// </summary>
        [InspectorName("��������еĽӿڣ�������ı���")]
        BindingToSelfAndAllInterface,

        /// <summary>
        /// ��������еĽӿڣ���������ı���
        /// </summary>
        [InspectorName("��������еĽӿڣ���������ı���")]
        BindingToAllInterface
    }

}