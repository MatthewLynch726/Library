using Library;
using Library.Models;
using LibraryData;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryServices
{
    public class CheckoutService : ICheckout
    {

        private LibraryContext _context;

        public CheckoutService(LibraryContext context) {
            _context = context;
        }

        public void Add(Checkout newCheckout)
        {
            _context.Add(newCheckout);
            _context.SaveChanges();
        }

        public IEnumerable<Checkout> Getall()
        {
            return _context.Checkouts; //return all instances of Checkouts from database
        }

        public Checkout GetById(int checkoutId)
        {
            return Getall().FirstOrDefault(checkout => checkout.Id == checkoutId);
        }

        public IEnumerable<CheckoutHistory> GetCheckoutHistory(int id)
        {
            return _context.CheckoutsHistories
                .Include(h => h.LibraryAsset)
                .Include(h => h.LibraryCard)
                .Where(h => h.LibraryAsset.Id == id);
        }

        public DateTime GetCurrentHoldPlaced(int id)
        {
            throw new NotImplementedException();
        }

        public string GetCurrentHoldPtronName(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Hold> GetCurrentHolds(int id)
        {
            return _context.Holds
                .Include(h => h.LibraryAsset)
                .Where(h=>h.LibraryAsset.Id == id);
        }

        public void CheckInItem(int assetId, int libraryCardId)
        {
            throw new NotImplementedException();
        }

        public void CheckOutItem(int assetId, int libraryCardId)
        {
            throw new NotImplementedException();
        }

        public void MarkFound(int assetId) //Where ended VIdeo
        {
            throw new NotImplementedException();
        }

        public void MarkLost(int assetId)
        {
            throw new NotImplementedException();
        }

        public void PlaceHold(int assetId, int libraryCardId)
        {
            throw new NotImplementedException();
        }

        public Checkout GetLatestCheckout(int assetId)
        {
            return _context.Checkouts.Where(c => c.LibraryAsset.Id == assetId)
                .OrderByDescending(c=>c.Since)
                .FirstOrDefault();
        }
    }
}
