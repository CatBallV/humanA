using System;

namespace LKZ.DependencyInject
{
    /// <summary>
    /// ��̬�İ�
    /// ���ǽű�û�и��ų���һ����������������ű��Ǻ���ʹ�ô��������ȥ�ģ����õ��������
    /// ˵������ű���Ҫ��ע�뵽����ע����
    /// </summary>
    [AttributeUsage(AttributeTargets.Class,AllowMultiple= false, Inherited= false)]
    public class DynamicInjectBindAttribute : Attribute
    {
        /// <summary>
        /// �󶨵�����
        /// </summary>
        public BindingType BindingType;

        public DynamicInjectBindAttribute() { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bindingType">�󶨵�����</param>
        public DynamicInjectBindAttribute(BindingType bindingType)
        {
            BindingType = bindingType;
        }
    }
}
