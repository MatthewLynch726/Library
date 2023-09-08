using Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryData
{
    public interface ICheckout
    {
        IEnumerable<Checkout> Getall();
        Checkout GetById(int checkoutId);
        void Add(Checkout newCheckout);
        void CheckOutItem(int assetId, int libraryCardId);
        void CheckInItem(int assetId);
        IEnumerable<CheckoutHistory> GetCheckoutHistory(int id);
        Checkout GetLatestCheckout(int assetId);
        bool IsCheckedOut(int id);

        void PlaceHold(int assetId, int libraryCardId);
        string GetCurrentHoldPatronName(int id);
        DateTime GetCurrentHoldPlaced(int id);
        IEnumerable<Hold> GetCurrentHolds(int id);
        string GetCurrentCheckoutPatron(int assetId);

        void MarkLost(int assetId);
        void MarkFound(int assetId);
    }
}
