using System.Collections;

namespace EmojiLibrary
{
    public class SortByTag : IComparer
    {
        public int Compare(object? x, object? y)
        {
            Emoji e1 = x as Emoji;
            Emoji e2 = y as Emoji;
            return string.Compare(e1.Tag, e2.Tag);
        }
    }
}