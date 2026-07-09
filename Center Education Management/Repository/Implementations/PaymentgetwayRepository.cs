﻿using Center_Education_Management.EFcore;
using Center_Education_Management.Models;
using Center_Education_Management.Repository.Interfaces;

namespace Center_Education_Management.Repository.Implementations
{
    public class PaymentgetwayRepository : GenericRepository<Paymentgetway>, IPaymentgetwayRepository
    {
        public PaymentgetwayRepository(CenterDBContext context) : base(context)
        {
        }
    }
}
