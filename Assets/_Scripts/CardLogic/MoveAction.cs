namespace _Scripts.CardLogic
{
    public class MoveAction
    {
        public Spot From;
        public Spot To;
        public CardView Card;

        public void Undo()
        {
            To.RemoveCard(Card);
            From.AddCard(Card);
        }
    }
}