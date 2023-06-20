using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using System;
using System.Globalization;
using TMPro;

namespace Utils
{
    public static class TweenUtils
    {
        public static TweenerCore<int, int, NoOptions> DOCounter(
         this TMP_Text target, int fromValue, int endValue, float duration, string prefix = "", IFormatProvider formatProvider = null
             )
        {
            int v = fromValue;
            TweenerCore<int, int, NoOptions> t = DOTween.To(() => v, x =>
            {
                v = x;
                var text = string.Concat
                    (
                        $"{prefix}",
                        formatProvider != null ? v.ToString("N0", formatProvider) : v.ToString()
                    );
                target.text = text;
            }, endValue, duration);
            t.SetTarget(target);
            return t;
        }
    }
}