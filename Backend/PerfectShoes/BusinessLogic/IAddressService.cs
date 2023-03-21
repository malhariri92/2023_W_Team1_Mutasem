using PerfectShoes.Models;
using PerfectShoes.Models.DTO;

namespace PerfectShoes.BusinessLogic
{
    public interface IAddressService
    {
        public Address AddAddress(AddressDto addressDto);

        public Address UpdateAddress(AddressDto addressDto);
    }
}
