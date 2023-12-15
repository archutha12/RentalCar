using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace RentalCar.Models;

[Table("Admin")]
[Index("Userid", Name = "UQ__Admin__1797D025D58903B3", IsUnique = true)]
[Index("Name", Name = "UQ__Admin__737584F655D1515D", IsUnique = true)]
[Index("Phoneno", Name = "UQ__Admin__F2111EDAA789CA33", IsUnique = true)]
public partial class Admin
{
    [Key]
    public int Adminid { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string Name { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string Phoneno { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string Userid { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string Pwd { get; set; }
}
