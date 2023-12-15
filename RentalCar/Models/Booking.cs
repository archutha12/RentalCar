using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace RentalCar.Models;

[Table("Booking")]
public partial class Booking
{
    public int? Custid { get; set; }

    public int? Driverid { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string? CarNo { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string? RentalType { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? PickupDate { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DropDate { get; set; }

    public double? Cost { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string? PaymentType { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string? PickupLoc { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string? DropLoc { get; set; }

    public bool? status { get; set; }

    [Key]
    public int Bookingid { get; set; }

    [ForeignKey("CarNo")]
    public virtual car? CarNoNavigation { get; set; }

    [ForeignKey("Custid")]
    public virtual Customer? Cust { get; set; }

    [ForeignKey("Driverid")]
    public virtual Driver? Driver { get; set; }
}
