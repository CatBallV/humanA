using System;

namespace LKZ.TypeEventSystem
{
    /// <summary>
    /// �¼�����
    /// ʵ�ִ洢�ص���ί�е�
    /// </summary>
    /// <typeparam name="T">�ص�ί�еĲ���</typeparam>
    internal class EventRegister<T> : IEventInterface
    where T : struct
    {
        /// <summary>
        /// �ص�ί���¼�
        /// </summary>
        private event Action<T> onEvent;

        /// <summary>
        /// ����
        /// </summary>
        /// <param name="callback">�ص�ί��</param>
        public EventRegister(Action<T> callback)
        {
            onEvent += callback;
        }

        /// <summary>
        /// ����
        /// ����Ҫ�����¼��Ļ����͵���UnRegisterȡ�������¼�
        /// </summary>
        /// <param name="actionCallback">�ص�</param>
        public void Register(Action<T> actionCallback)
        {
            this.onEvent += actionCallback;
        }

        /// <summary>
        /// ȡ�������¼�
        /// </summary>
        /// <param name="actionCallback">ȡ�������Ļص�ί��</param>
        public void UnRegister(Action<T> actionCallback)
        {
            this.onEvent -= actionCallback;
        }

        /// <summary>
        /// �����¼�
        /// </summary>
        /// <param name="instanceParameter">������Ǹ��������ע���ί�е�����
        /// �����һ��ʵ���������Ǹ�ע��ί�еĲ����ṹ�壬�ṹ��������ԷŸ������ߴ��ݲ���</param>
        public void Send(T instanceParameter)
        {
            this.onEvent?.Invoke(instanceParameter);
        }
    }
}
