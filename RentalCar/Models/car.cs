using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace RentalCar.Models;

[Table("car")]
public partial class car
{
    [Key]
    [StringLength(10)]
    [Unicode(false)]
    public string CarNo { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string Brand { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string Color { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string FuelType { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? Registereddate { get; set; }

    public double? Mileage { get; set; }

    public short? Capacity { get; set; }

    public double? Cost { get; set; }

    public bool? Status { get; set; }

    [Unicode(false)]
    public string image { get; set; }

    [InverseProperty("CarNoNavigation")]
    public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();
}
