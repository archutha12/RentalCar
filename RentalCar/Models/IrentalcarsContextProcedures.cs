﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using RentalCar.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading;
using System.Threading.Tasks;

namespace RentalCar.Models
{
    public partial interface IrentalcarsContextProcedures
    {
        Task<int> addcustomerAsync(string name, DateTime? Dob, string address, string phone, string email, string userid, string pwd, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<int> bookcarAsync(int? custid, int? Driverid, string Carno, string Rentaltype, DateTime? pickupdate, DateTime? dropdate, double? cost, string paymenttype, string pickuploc, string droploc, bool? status, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
    }
}