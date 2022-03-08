using System.IO;

using UnityEngine;

namespace GSP.Editor
{
    /// <summary>
    /// An extremely simple scripted importer to enable the use of .lua files as TextAssets.
    /// </summary>
    [UnityEditor.AssetImporters.ScriptedImporter(1, "lua")]
    public class LuaImporter : UnityEditor.AssetImporters.ScriptedImporter
    {
        public override void OnImportAsset(UnityEditor.AssetImporters.AssetImportContext ctx)
        {
            var asset = new TextAsset(File.ReadAllText(ctx.assetPath));
            ctx.AddObjectToAsset("Text", asset);
            ctx.SetMainObject(asset);
        }
    }
}