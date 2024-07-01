using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEditor;
using UnityEngine;

namespace LKZ.DependencyInject
{
    /// <summary>
    /// ��������ע���Unity�����ļ�
    /// </summary>
    public class CreateScriptableObject
    {
        [MenuItem("Assets/Create/DI/ScriptableObject", priority = 5000, validate = false)]
        public static void jj()
        {
            string path = EditorUtility.SaveFilePanel("����Unity���л��ļ�", AssetDatabase.GetAssetPath(Selection.activeObject),
                  "GameSetting", "cs");

            if (!string.IsNullOrEmpty(path))
            {
                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder
                    .Append("using LKZ.DependencyInject;\r\n")
                    .Append("using UnityEngine; \r\n")
                    .Append("\r\n")
                    .Append(@"/// <summary>
/// Unity �����ļ�
/// �����Ҫ�ϵ�SceneDependencyInjectContextManager�ű��е�GameSetting�£�������������
/// </summary>")
    .Append("\r\n[CreateAssetMenu(menuName =\"GameSetting/\"+nameof(FileName))]\r\n")
    .Append("public class FileName : DIScriptableObject\r\n")
    .Append("{\r\n")
    .Append("  /// <summary>\r\n")
    .Append("   /// ������ʱ�򣬻��Զ����������ע�������\r\n")
            .Append("   /// </summary>\r\n")
        .Append("   /// <param name=\"registerBinding\">�󶨽ӿ�</param>\r\n")
            .Append("   public override void InjectBinding(IRegisterBinding registerBinding)\r\n")
            .Append("   {\r\n")
            .Append("        registerBinding.BindingToSelf(this);//������\r\n")
            .Append("   }\r\n")
            .Append("}\r\n");
                stringBuilder.Replace("FileName", Path.GetFileNameWithoutExtension(path));
                File.WriteAllText(path, stringBuilder.ToString());
                AssetDatabase.Refresh();
            }
        }
    }
}
