using Library;
using Library.Models;
using LibraryData;
using Microsoft.EntityFrameworkCore;

namespace LibraryServices
{
    public class LibraryAssetService : ILibraryAsset
    {
        private LibraryContext _context;

        public LibraryAssetService(LibraryContext context)
        {
            _context = context;
        }


        public void Add(LibraryAsset newAsset)
        {
            _context.Add(newAsset);
            _context.SaveChanges();
        }

        public IEnumerable<LibraryAsset> GetAll()
        {
            return _context.LibraryAssets
                .Include(asset => asset.Status)
                .Include(asset => asset.Status);
        }

        public string GetAuthorOrDirector(int id)
        {
            throw new NotImplementedException();
        }

        public LibraryAsset GetById(int id)
        {
            return _context.LibraryAssets
                .Include(asset => asset.Status)
                .Include(asset => asset.Status)
                .FirstOrDefault(asset => asset.Id == id);
        }

        public LibraryBranch GetCurrentLocation(int id)
        {
            return GetById(id).Location;
        }

        public string GetDeweyIndex(int id)
        {
            if (_context.Books.Any(book => book.Id == id))
            {
                return _context.Books.FirstOrDefault(book => book.Id == id).DeweyIndex;
            }
            else return "";
        }

        public string GetIsbn(int id)
        {
            throw new NotImplementedException();
        }

        public string GetTitle(int id)
        {
            throw new NotImplementedException();
        }

        public string GetType(int id)
        {
            throw new NotImplementedException();
        }
    }
}