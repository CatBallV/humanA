using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LKZ.DependencyInject
{
    /// <summary>
    /// ��̬����ע���
    /// ���Ҫ���ų���һ��������
    /// ����볡�������ˣ���̬��������ӽű��Զ�ע��
    /// </summary>
    [DisallowMultipleComponent]
    [AddComponentMenu("LKZ/����ע��/��̬������ע��", order: 11)]
    public class DynamicDIInjectBind : MonoBehaviour
    {
        /// <summary>
        /// �Ƿ�������ȡ��ע��
        /// </summary>
        public bool isDestroyUnRegister = true;

        /// <summary>
        /// ������ʹ����DynamicInjectBindAttribute���Ե���
        /// </summary>
        private object[] useDynamicInjectBindComponent;

        /// <summary>
        /// ����ע��󶨵Ľӿ�
        /// </summary>
        private IRegisterBinding registerBinding;

        /// <summary>
        /// �������ϵ��Զ���ű�
        /// </summary>
        private  object[] customComponent;

        /// <summary>
        /// ��̬�İ����Ա�ʶ����
        /// </summary>
        private readonly static Type DynamicInjectBindAttributeType = typeof(DynamicInjectBindAttribute);

        private void Start()
        {
            Inject();
        }

        /// <summary>
        /// ע��
        /// </summary>
        public void Inject()
        {
            MonoBehaviour[] monos = GetComponents<MonoBehaviour>();

            customComponent = FilteationUtility.FiltrationComponent(monos);

            registerBinding = SceneDependencyInjectContextManager.Instance.GetRegisterBindingInterface();
            useDynamicInjectBindComponent = customComponent.GetUseDynamicInjectBindAttribute();

            //���������ϵ�������Ҫ�󶨵Ľű���ע�뵽DI
            foreach (object item in useDynamicInjectBindComponent)
            {
                var att = item.GetType().GetCustomAttributes(DynamicInjectBindAttributeType, false)[0] as DynamicInjectBindAttribute;
                switch (att.BindingType)
                {
                    case BindingType.BindingToSelf:
                        registerBinding.BindingToSelf(item);
                        break;
                    case BindingType.BindingToSelfAndAllInterface:
                        registerBinding.BindingToSelfAndAllInterface(item);
                        break;
                    case BindingType.BindingToAllInterface:
                        registerBinding.UnBindingToAllInterface(item.GetType());
                        break;
                }
            }

            //�������ϵĽű�ʹ����Ҫע��ֵ������ע�룬���Ǹ��Ǹ�����ע��
            SceneDependencyInjectContextManager.Instance.InjectsProperty(customComponent);
        }

        private void OnDestroy()
        {
            if (isDestroyUnRegister)
            {
                foreach (object item in useDynamicInjectBindComponent)
                {
                    var att = item.GetType().GetCustomAttributes(DynamicInjectBindAttributeType, false)[0] as DynamicInjectBindAttribute;

                    switch (att.BindingType)
                    {
                        case BindingType.BindingToSelf:
                            registerBinding.UnRegister(item.GetType());
                            break;
                        case BindingType.BindingToSelfAndAllInterface:
                            registerBinding.UnBindingToSelfAndAllInterface(item.GetType());
                            break;
                        case BindingType.BindingToAllInterface:
                            registerBinding.UnBindingToSelfAndAllInterface(item.GetType());
                            break;
                    }
                }
            }
        }
    }
}
