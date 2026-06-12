using System.IO;
using System.Text;
using UnityEditor;
using UnityEditorInternal;
using UnityEngine;

namespace _Project.Develop.Editor
{
    public class UnityLayersGenerator
    {
        private static string OutputPath =>
            Path.Combine(Application.dataPath, "_Project/Develop/Runtime/Gameplay/UnityLayers.cs"); 

        
        [InitializeOnLoadMethod]
        [MenuItem("Tools/UnityLayersGenerator")]
        private static void Generate()
        {
            StringBuilder sb = new StringBuilder();
            
            sb.AppendLine("using UnityEngine;");
            sb.AppendLine();
            
            sb.AppendLine("namespace _Project.Develop.Runtime.Gameplay");
            sb.AppendLine("{");
            
            sb.AppendLine("\tpublic static class UnityLayers");
            sb.AppendLine("\t{");

            foreach (string layer in InternalEditorUtility.layers)
            {
                string name = ToIdentifier(layer);
                sb.AppendLine($"\t\tpublic static readonly int Layer{name} = LayerMask.NameToLayer(\"{layer}\");");
            }
            
            sb.AppendLine();
            
            foreach (string layer in InternalEditorUtility.layers)
            {
                string name = ToIdentifier(layer);
                sb.AppendLine($"\t\tpublic static readonly int LayerMask{name} = 1 << Layer{name};");
            }
            
            sb.AppendLine("\t}");
            sb.AppendLine("}");
            
            File.WriteAllText(OutputPath, sb.ToString());
            
            AssetDatabase.Refresh();
            AssetDatabase.SaveAssets();
        }
        
        private static string ToIdentifier(string layerName)
        {
            string[] parts = layerName.Split(' ');
            string result = "";

            foreach (string part in parts)
            {
                if (string.IsNullOrWhiteSpace(part))
                    continue;

                result += char.ToUpperInvariant(part[0]) + part.Substring(1);
            }

            return result;
        }
    }
}