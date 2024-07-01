using LKZ.DependencyInject.Extension;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LKZ.DependencyInject
{
    /// <summary>
    /// ����ע��洢
    /// ������
    /// </summary>
    internal sealed class DependencyInjectContext : IRegisterBinding, IGetBindingImplementation
    {
        /// <summary>
        /// �洢���е�����ע��İ����ͺ�ʵ������
        /// ���������Ǹ��󶨵����ͣ����ĸ��ӿ�
        /// ֵ�����Ǹ�ʵ�ֵĽӿڵ�ʵ��
        /// </summary>
        public Dictionary<Type, IDependencyInjectItem> DependencyInjectBind_Dic = new Dictionary<Type, IDependencyInjectItem>();

        /// <summary>
        /// ע��ӿڷ����Ĳ���
        /// </summary>
        public object[] RegisterBindingInterfaceParameter { get; }

        public DependencyInjectContext()
        {
            ///���������еĽӿ�
            BindingToAllInterface(this);
            RegisterBindingInterfaceParameter = new object[] { this };
        }

        public BindingTo<TBindType> Binding<TBindType>()
        {
            Type bindType = typeof(TBindType);
            DependencyInjectItem<TBindType> dependencyInjectItem = new DependencyInjectItem<TBindType>();
            if (DependencyInjectBind_Dic.ContainsKey(bindType))
            {
                DependencyInjectException.Throw($"�󶨵�����{bindType.Name}�Ѿ����ڣ�����Ҫ�ٴΰ�");
            }
            else
            {
                DependencyInjectBind_Dic.Add(bindType, dependencyInjectItem);
            }
            return dependencyInjectItem;
        }

        public BindingTo Binding(Type bindType)
        {
            DependencyInjectItem<object> dependencyInjectItem = new DependencyInjectItem<object>();
            if (DependencyInjectBind_Dic.ContainsKey(bindType))
            {
                DependencyInjectException.Throw($"�󶨵�����{bindType.Name}�Ѿ����ڣ�����Ҫ�ٴΰ�");
            }
            else
            {
                DependencyInjectBind_Dic.Add(bindType, dependencyInjectItem);
            }
            return dependencyInjectItem;
        }


        public void BindingToAllInterface<TBindType>(TBindType instance)
            where TBindType : new()
        {
            Type[] allCustomInterface = instance.GetType().GetCustomInterface();
            foreach (Type item in allCustomInterface)
            {
                Binding(item).To(instance);
            }
        }

        public void BindingToSelf<TBindType>(TBindType instance)
        {
            Binding(instance.GetType()).To(instance);
        }

        public void BindingToSelfAndAllInterface<TBindType>(TBindType instance)
            where TBindType : new()
        {
            BindingToAllInterface(instance);
            BindingToSelf(instance);
        }

        public TBindType GetBindType<TBindType>()
        {
            Type type = typeof(TBindType);
            return (TBindType)GetBindType(type);
        }

        public object GetBindType(Type bindType)
        {
            object obj = null;
            if (DependencyInjectBind_Dic.TryGetValue(bindType, out IDependencyInjectItem value))
            {
#if UNITY_EDITOR
                if (!bindType.IsAssignableFrom(value.BindInstance.GetType()))
                {
                    DependencyInjectException.Throw($"ǿתʧ�ܣ�{bindType.FullName}����ǿת����{value.BindInstance.GetType().FullName}");
                }
#endif
                obj = value.BindInstance;
            }

#if UNITY_EDITOR
            if (obj == null)
            {
                DependencyInjectException.Throw($"����û��ע��{bindType.FullName}");
            }
#endif
            return obj;
        }

        public void UnRegister<TBindType>()
        {
            this.UnRegister(typeof(TBindType));
        }

        public void UnRegister(Type bindType)
        {
            bool isSucceed = DependencyInjectBind_Dic.Remove(bindType);
#if UNITY_EDITOR
            if (!isSucceed)
            {
                DependencyInjectException.Throw($"ȡ��ע��ʧ�ܣ�{bindType.FullName}���û�а�");
            }
#endif
        }

        public void UnBindingToSelfAndAllInterface(Type bindType)
        {
            this.UnBindingToAllInterface(bindType);
            UnRegister(bindType);//ȡ������
        }

        public void UnBindingToAllInterface(Type bindType)
        {
            Type[] allCustomInterface = bindType.GetCustomInterface();
            foreach (Type item in allCustomInterface)
            {
                UnRegister(item);
            }
        }
    }
}
