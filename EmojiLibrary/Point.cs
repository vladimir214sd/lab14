namespace EmojiLibrary
{
    public class Point<T>
    {
        public T? Data { get; set; }
        public Point<T>? Next { get; set; }
        public Point<T>? Pred { get; set; }

        public Point()
        {
            this.Data = default(T);
            this.Pred = null;
            this.Next = null;
        }

        public Point(T data)
        {
            this.Data = data;
            this.Pred = null;
            this.Next = null;
        }

        public override string? ToString()
        {
            return Data == null ? "" : Data.ToString();
        }
        public override int GetHashCode()
        {
            return Data == null ? 0 : Data.GetHashCode();
        }
    }
}