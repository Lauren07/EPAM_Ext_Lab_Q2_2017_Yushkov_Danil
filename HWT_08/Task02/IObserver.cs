namespace Task02
{
    public interface IObserver
    {
        void Update(object sender, PersonEventArgs e);
    }
}
