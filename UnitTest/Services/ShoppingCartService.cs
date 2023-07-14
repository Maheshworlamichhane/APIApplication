using Microsoft.EntityFrameworkCore.Diagnostics;
using UnitTest.Data;
using UnitTest.Model;

namespace UnitTest.Services
{
    public class ShoppingCartService : IShoppingCartService
    {
        private readonly ApplicationDbContext _context;
        public ShoppingCartService(ApplicationDbContext context)
        {
            _context = context;
        }
        public IEnumerable<ShoppingItem> GetAllItems()
        {
            var shop =  _context.ShoppingItems.ToList();
            return shop;
        }
        public ShoppingItem Add(ShoppingItem newItem)
        {

            _context.ShoppingItems.Add(newItem);
            _context.SaveChanges();

            return newItem;
        }
        public ShoppingItem GetById(int id)
        {
            return _context.ShoppingItems.Where(a => a.Id == id)
                .First();
        }
        public void Remove(int id)
        {
            var existing = _context.ShoppingItems.First(a => a.Id == id);
            _context.Remove(existing);
        }

        public ShoppingItem Update(ShoppingItem newItem)
        {
            _context.ShoppingItems.Update(newItem);
            _context.SaveChanges();

            return newItem;
        }
    }
}
