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
    public partial class rentalcarsContext
    {
        private IrentalcarsContextProcedures _procedures;

        public virtual IrentalcarsContextProcedures Procedures
        {
            get
            {
                if (_procedures is null) _procedures = new rentalcarsContextProcedures(this);
                return _procedures;
            }
            set
            {
                _procedures = value;
            }
        }

        public IrentalcarsContextProcedures GetProcedures()
        {
            return Procedures;
        }

        protected void OnModelCreatingGeneratedProcedures(ModelBuilder modelBuilder)
        {
        }
    }

    public partial class rentalcarsContextProcedures : IrentalcarsContextProcedures
    {
        private readonly rentalcarsContext _context;

        public rentalcarsContextProcedures(rentalcarsContext context)
        {
            _context = context;
        }

        public virtual async Task<int> addcustomerAsync(string name, DateTime? Dob, string address, string phone, string email, string userid, string pwd, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default)
        {
            var parameterreturnValue = new SqlParameter
            {
                ParameterName = "returnValue",
                Direction = System.Data.ParameterDirection.Output,
                SqlDbType = System.Data.SqlDbType.Int,
            };

            var sqlParameters = new []
            {
                new SqlParameter
                {
                    ParameterName = "name",
                    Size = 20,
                    Value = name ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.VarChar,
                },
                new SqlParameter
                {
                    ParameterName = "Dob",
                    Value = Dob ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.Date,
                },
                new SqlParameter
                {
                    ParameterName = "address",
                    Size = 20,
                    Value = address ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.VarChar,
                },
                new SqlParameter
                {
                    ParameterName = "phone",
                    Size = 10,
                    Value = phone ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.VarChar,
                },
                new SqlParameter
                {
                    ParameterName = "email",
                    Size = 20,
                    Value = email ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.VarChar,
                },
                new SqlParameter
                {
                    ParameterName = "userid",
                    Size = 20,
                    Value = userid ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.VarChar,
                },
                new SqlParameter
                {
                    ParameterName = "pwd",
                    Size = 10,
                    Value = pwd ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.VarChar,
                },
                parameterreturnValue,
            };
            var _ = await _context.Database.ExecuteSqlRawAsync("EXEC @returnValue = [dbo].[addcustomer] @name, @Dob, @address, @phone, @email, @userid, @pwd", sqlParameters, cancellationToken);

            returnValue?.SetValue(parameterreturnValue.Value);

            return _;
        }

        public virtual async Task<int> bookcarAsync(int? custid, int? Driverid, string Carno, string Rentaltype, DateTime? pickupdate, DateTime? dropdate, double? cost, string paymenttype, string pickuploc, string droploc, bool? status, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default)
        {
            var parameterreturnValue = new SqlParameter
            {
                ParameterName = "returnValue",
                Direction = System.Data.ParameterDirection.Output,
                SqlDbType = System.Data.SqlDbType.Int,
            };

            var sqlParameters = new []
            {
                new SqlParameter
                {
                    ParameterName = "custid",
                    Value = custid ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.Int,
                },
                new SqlParameter
                {
                    ParameterName = "Driverid",
                    Value = Driverid ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.Int,
                },
                new SqlParameter
                {
                    ParameterName = "Carno",
                    Size = 10,
                    Value = Carno ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.VarChar,
                },
                new SqlParameter
                {
                    ParameterName = "Rentaltype",
                    Size = 10,
                    Value = Rentaltype ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.VarChar,
                },
                new SqlParameter
                {
                    ParameterName = "pickupdate",
                    Value = pickupdate ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.Date,
                },
                new SqlParameter
                {
                    ParameterName = "dropdate",
                    Value = dropdate ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.Date,
                },
                new SqlParameter
                {
                    ParameterName = "cost",
                    Value = cost ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.Float,
                },
                new SqlParameter
                {
                    ParameterName = "paymenttype",
                    Size = 20,
                    Value = paymenttype ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.VarChar,
                },
                new SqlParameter
                {
                    ParameterName = "pickuploc",
                    Size = 20,
                    Value = pickuploc ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.VarChar,
                },
                new SqlParameter
                {
                    ParameterName = "droploc",
                    Size = 20,
                    Value = droploc ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.VarChar,
                },
                new SqlParameter
                {
                    ParameterName = "status",
                    Value = status ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.Bit,
                },
                parameterreturnValue,
            };
            var _ = await _context.Database.ExecuteSqlRawAsync("EXEC @returnValue = [dbo].[bookcar] @custid, @Driverid, @Carno, @Rentaltype, @pickupdate, @dropdate, @cost, @paymenttype, @pickuploc, @droploc, @status", sqlParameters, cancellationToken);

            returnValue?.SetValue(parameterreturnValue.Value);

            return _;
        }
    }
}
