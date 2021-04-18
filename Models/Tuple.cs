namespace Models
{
    public class Tuple<TE1,TE2>
    {
        public Tuple(TE1 left, TE2 right)
        {
            Left = left;
            Right = right;
        }

        public TE1 Left { get; set; }
        public TE2 Right { get; set; }
    }
}