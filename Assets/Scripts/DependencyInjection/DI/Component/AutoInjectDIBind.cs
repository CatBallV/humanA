using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace LKZ.DependencyInject
{
    /// <summary>
    /// �Զ�����ע���
    /// ���Ҫ���ų���һ��������
    /// ����볡�������ˣ���̬��������ӽű��Զ�ע��
    /// </summary>
    [DisallowMultipleComponent]
    [AddComponentMenu("LKZ/����ע��/�Զ�������ע��",order:11)]
    public class AutoInjectDIBind : MonoBehaviour, IDRegisterBindingInterface
    {
        /// <summary>
        /// ��Ҫ�󶨵ļ���
        /// </summary>
        [SerializeField,  FormerlySerializedAs("��Ҫ�󶨵ļ���")]
        private AutoBindingItemStruct[] autoBindingItemStructs;

        /// <summary>
        /// �Ƿ�������ȡ��ע��
        /// </summary>
        [SerializeField, FormerlySerializedAs("�Ƿ�������ȡ��ע��")]
        private bool isDestroyUnRegister = true;

        /// <summary>
        /// ע�������
        /// </summary>
        private IRegisterBinding registerBinding;

        /// <summary>
        /// �Զ�ʱ�Զ����������
        /// </summary>
        /// <param name="registerBinding"></param>
        void IDRegisterBindingInterface.DIRegisterBinding(IRegisterBinding registerBinding)
        {
            this.registerBinding = registerBinding;
            foreach (AutoBindingItemStruct item in autoBindingItemStructs)
            {
                switch (item.bindingType)
                {
                    case BindingType.BindingToSelf:
                        registerBinding.BindingToSelf(item.monoBehaviour);
                        break;
                    case BindingType.BindingToSelfAndAllInterface:
                        registerBinding.BindingToSelfAndAllInterface(item.monoBehaviour);
                        break;
                    case BindingType.BindingToAllInterface:
                        registerBinding.BindingToAllInterface(item.monoBehaviour);
                        break;
                }
            }
        }

        private void OnDestroy()
        {
            if (isDestroyUnRegister)
            {
                foreach (AutoBindingItemStruct item in autoBindingItemStructs)
                {
                    switch (item.bindingType)
                    {
                        case BindingType.BindingToSelf:
                            registerBinding.UnRegister(item.monoBehaviour.GetType());
                            break;
                        case BindingType.BindingToSelfAndAllInterface:
                            registerBinding.UnBindingToSelfAndAllInterface(item.monoBehaviour.GetType());
                            break;
                        case BindingType.BindingToAllInterface:
                            registerBinding.UnBindingToAllInterface(item.monoBehaviour.GetType());
                            break;
                    }
                }
            }
        }
    }
}
