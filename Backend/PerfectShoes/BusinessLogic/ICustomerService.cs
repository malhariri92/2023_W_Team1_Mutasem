﻿using PerfectShoes.Models;

namespace PerfectShoes.BusinessLogic
{
    public interface ICustomerService
    {
       User? GetCustomerById(int Id);
    }
}
