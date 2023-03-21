using Microsoft.EntityFrameworkCore;
using PerfectShoes.Models;
using PerfectShoes.Models.DTO;

namespace PerfectShoes.BusinessLogic
{
    public class AddressService : Service, IAddressService
    {
        public AddressService(DataContext context) : base(context) { }

        public Address AddAddress(AddressDto addressDto)
        {
            Address address = new Address
            {
                AddressLine1 = addressDto.AddressLine1,
                AddressLine2 = addressDto.AddressLine2,
                Zip = addressDto.Zip,
                City = addressDto.City,
                State = addressDto.State
            };

            _context.Addresses.Add(address);
            Customer customer= _context.Customers.Find(addressDto.CustomerId);
            _context.SaveChanges();
            customer.AddressId = address.Id;
            _context.Entry(customer).State = EntityState.Modified;
            _context.SaveChanges();
            return address;
        }

        public Address UpdateAddress(AddressDto addressDto)
        {
            Address address = new Address
            {
                Id = addressDto.Id,
                AddressLine1 = addressDto.AddressLine1,
                AddressLine2 = addressDto.AddressLine2,
                Zip = addressDto.Zip,
                City = addressDto.City,
                State = addressDto.State
            };

            _context.Addresses.Update(address);
            Customer customer = _context.Customers.Find(addressDto.CustomerId);
            _context.SaveChanges();
            customer.AddressId = address.Id;
            _context.Entry(customer).State = EntityState.Modified;
            _context.SaveChanges();
            return address;
        }
    }
}
