using System.IO;
using UnityEditor.Experimental.AssetImporters;
using UnityEngine;

namespace GSP.Editor
{
    /// <summary>
    /// An extremely simple scripted importer to enable the use of .lua files as TextAssets.
    /// </summary>
    [ScriptedImporter(1, "lua")]
    public class LuaImporter : ScriptedImporter
    {
        public override void OnImportAsset(AssetImportContext ctx)
        {
            var asset = new TextAsset(File.ReadAllText(ctx.assetPath));
            ctx.AddObjectToAsset("Text", asset);
            ctx.SetMainObject(asset);
        }
    }
}