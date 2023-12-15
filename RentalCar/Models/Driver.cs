using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace RentalCar.Models;

[Table("Driver")]
[Index("Licenseno", Name = "UQ__Driver__72D6F42867B248C0", IsUnique = true)]
public partial class Driver
{
    [Key]
    public int Driverid { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string Name { get; set; }

    [Column(TypeName = "date")]
    public DateTime? DateOfBirth { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string Phoneno { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string Address { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string Licenseno { get; set; }

    public bool? Status { get; set; }

    [InverseProperty("Driver")]
    public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();
}
