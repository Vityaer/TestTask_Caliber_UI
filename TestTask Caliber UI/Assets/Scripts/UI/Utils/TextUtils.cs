using UnityEngine;

namespace UI.Utils
{
    public class TextUtils
    {
        public static string SpriteWithInheritColor(string name) =>
            $"<sprite tint=1 name={name}>";

        public static string SpriteWithColor(string name, string color) =>
            $"<sprite color={color} name={name}>";

    }
}
