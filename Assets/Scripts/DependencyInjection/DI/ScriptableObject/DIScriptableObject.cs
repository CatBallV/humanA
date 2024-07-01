using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LKZ.DependencyInject
{
    /// <summary>
    /// Unity�������ļ�
    /// Ҫ�̳�����࣬����ע��
    /// </summary>
    public abstract class DIScriptableObject : ScriptableObject
    {
        /// <summary>
        /// ������ʱ����Զ������������
        /// </summary>
        /// <param name="registerBinding">�󶨵�����ע��Ľӿ�</param>
        public abstract void InjectBinding(IRegisterBinding registerBinding);
    }
}
