using UnitTest.Model;

namespace UnitTest.Services
{
    public interface IShoppingCartService
    {
        IEnumerable<ShoppingItem> GetAllItems();
        ShoppingItem Add(ShoppingItem newItem);
        ShoppingItem Update(ShoppingItem newItem);
        ShoppingItem GetById(int id);
        void Remove(int id);
    }
}
