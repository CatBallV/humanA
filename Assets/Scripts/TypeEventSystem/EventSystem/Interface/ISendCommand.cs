using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LKZ.TypeEventSystem
{
    /// <summary>
    /// ��������ӿ�
    /// </summary>
    public interface ISendCommand
    {
        /// <summary>
        /// �����¼�
        /// </summary>
        /// <param name="instanceParameter">������Ǹ��������ע���ί�е�����
        /// �����һ��ʵ���������Ǹ�ע��ί�еĲ����ṹ�壬�ṹ��������ԷŸ������ߴ��ݲ���</param>
        public void Send<T>(T instanceParameter)
            where T : struct;
        }
}
