using System.Drawing;
using System.Windows.Forms;

namespace CCVD.Win.Design
{
    public static class TextHelper
    {
        public static StringAlignment TranslateAligment(HorizontalAlignment aligment)
        {
            switch (aligment)
            {
                case HorizontalAlignment.Left:
                    return StringAlignment.Near;
                case HorizontalAlignment.Right:
                    return StringAlignment.Far;
            }
            return StringAlignment.Center;
        }

        public static HorizontalAlignment TranslateGridColumnAligment(DataGridViewContentAlignment aligment)
        {
            switch (aligment)
            {
                case DataGridViewContentAlignment.BottomLeft:
                case DataGridViewContentAlignment.MiddleLeft:
                case DataGridViewContentAlignment.TopLeft:
                    return HorizontalAlignment.Left;
                case DataGridViewContentAlignment.BottomRight:
                case DataGridViewContentAlignment.MiddleRight:
                case DataGridViewContentAlignment.TopRight:
                    return HorizontalAlignment.Right;
            }
            return HorizontalAlignment.Left;
        }

        public static TextFormatFlags TranslateAligmentToFlag(HorizontalAlignment aligment)
        {
            switch (aligment)
            {
                case HorizontalAlignment.Left:
                    return TextFormatFlags.Left;
                case HorizontalAlignment.Right:
                    return TextFormatFlags.Right;
            }
            return TextFormatFlags.HorizontalCenter;
        }

        public static TextFormatFlags TranslateTrimmingToFlag(StringTrimming trimming)
        {
            switch (trimming)
            {
                case StringTrimming.EllipsisCharacter:
                    return TextFormatFlags.EndEllipsis;
                case StringTrimming.EllipsisPath:
                    return TextFormatFlags.PathEllipsis;
                case StringTrimming.EllipsisWord:
                    return TextFormatFlags.WordEllipsis;
                case StringTrimming.Word:
                    return TextFormatFlags.WordBreak;
            }
            return TextFormatFlags.Default;
        }
    }
}
