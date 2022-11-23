namespace LexFlix.Services
{
    public interface ICartServices
    {
        void RemoveSessionFromCart(int id);
        void IncrementSessionFromCart(int Id);
        void DecrementSessionFromCart(int Id);
        void AddSessionToCart(int Id);
    }
}
