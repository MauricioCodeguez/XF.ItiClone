namespace ItiClone.Events
{
    public class ShowBackCardEvent
    {
        public ShowBackCardEvent()
        {
            SetInitialColor = false;
        }

        public bool SetInitialColor { get; set; }
    }
}
