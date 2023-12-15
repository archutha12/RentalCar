using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace RentalCar.Models;

[Table("Customer")]
public partial class Customer
{
    [Key]
    public int Custid { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string Name { get; set; }

    [Column(TypeName = "date")]
    public DateTime? DateOfBirth { get; set; }

    [StringLength(30)]
    [Unicode(false)]
    public string Address { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string Phoneno { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string Email { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string Userid { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string pwd { get; set; }

    [InverseProperty("Cust")]
    public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();
}
