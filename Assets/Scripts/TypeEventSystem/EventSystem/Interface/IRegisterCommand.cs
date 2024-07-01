using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LKZ.TypeEventSystem
{

    /// <summary>
    /// ��������ӿ�
    /// </summary>
    public interface IRegisterCommand
    {
        /// <summary>
        /// ����
        /// ����Ҫ�����¼��Ļ����͵���UnRegisterȡ�������¼�
        /// </summary>
        /// <param name="action">�ص�</param>
        public void Register<T>(Action<T> action)
            where T : struct;

        /// <summary>
        /// ȡ�������¼�
        /// </summary>
        /// <param name="action">ȡ�������Ļص�ί��</param>
        public void UnRegister<T>(Action<T> action)
            where T : struct;
    }
}
