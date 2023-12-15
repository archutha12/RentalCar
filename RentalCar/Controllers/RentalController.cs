using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using RentalCar.Models;
using System.Linq.Expressions;

namespace RentalCar.Controllers
{
    [ApiController]
    public class RentalController : ControllerBase
    {
        rentalcarsContext rentalcar = new rentalcarsContext();

        [HttpPost]
        [Route("api/Adminlogin")]
        public async Task<ActionResult> AdminLogin(Admin admin)
        {
            try {
                var Adminid = "";
                var res = rentalcar.Admins.Where(u => u.Userid == admin.Userid && u.Pwd == admin.Pwd).SingleOrDefault();
                if (res != null)
                {
                    Adminid = res.Userid;
                    return Ok(Adminid);
                }
                else
                {
                    return NotFound("Invalid credentials");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost]
        [Route("api/Custlogin")]
        public async Task<ActionResult> Customerlogin(Customer login)
        {
            try
            {
                var Custid = "";
                var res = rentalcar.Customers.Where(c => c.Userid == login.Userid && c.pwd == login.pwd).SingleOrDefault();
                if (res != null)
                {
                    Custid = res.Custid.ToString();

                    return Ok(Custid);
                }
                else
                {
                    return NotFound("Invalid Credentials");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost]
        [Route("api/Adminaddcustomer")]
        public ActionResult AddCustomer(Customer cust)
        {
            var res = rentalcar.Procedures.addcustomerAsync(cust.Name, cust.DateOfBirth, cust.Address, cust.Phoneno, cust.Email, cust.Userid, cust.pwd);
            return Ok(res);
        }


        [HttpPost]
        [Route("api/Adminaddcar")]
        public async Task<ActionResult> AddCar(car carData)
        {
            try
            {
                rentalcar.cars.Add(carData);
                int i = await rentalcar.SaveChangesAsync();
                return Ok(i);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }


        [HttpPost]
        [Route("api/Adminadddriver")]
        public async Task<ActionResult> AddDriver(Driver driverdata)
        {
            try
            {
               
                rentalcar.Drivers.Add(driverdata);
                int i = await rentalcar.SaveChangesAsync();
                return Ok(i);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet]
        [Route("api/Admindriverreports")]
        public async Task<ActionResult> getdriver()
        {
            var res = from t in rentalcar.Drivers
                      select t;
            return Ok(res.ToList());
        }


        [HttpDelete]
        [Route("api/Adminremovecar/{carno}")]
        public async Task<ActionResult> RemoveCar(string carno)
        {
            try
            {
                var res = (from t in rentalcar.cars
                          where t.CarNo == carno
                          select t).FirstOrDefault();
                if (res != null)
                {
                    rentalcar.cars.Remove(res);
                    int i = rentalcar.SaveChanges();
                    return Ok(i);
                }
                else
                {
                    return Ok(0);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpDelete]
        [Route("api/Adminremovedriver/{Driverid}")]
        public async Task<ActionResult> RemoveDriver(int Driverid)
        {
         
            try
            {
                var res = from t in rentalcar.Drivers
                          where t.Driverid == Driverid
                          select t;
                if (res.Count() > 0)
                {
                    rentalcar.Drivers.Remove(res.First());
                    int i = rentalcar.SaveChanges();
                    return Ok(i);
                }
                else
                {
                    return Ok(0);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("api/Adminupdatecar")]
        public async Task<ActionResult> UpdateCar(car cardata)
        {
            try
            {
                var res = from t in rentalcar.cars
                          where t.CarNo == cardata.CarNo
                          select t;
                if (res.Count() > 0)
                {
                    car carupdate = new car
                    {
                        CarNo = cardata.CarNo,
                        Brand = cardata.Brand,
                        Color = cardata.Color,
                        FuelType = cardata.FuelType,
                        Registereddate = cardata.Registereddate,
                        Mileage = cardata.Mileage,
                        Capacity = cardata.Capacity,
                        Cost = cardata.Cost,
                        Status = cardata.Status,
                        image = cardata.image
                    };
                    rentalcar.cars.Update(carupdate);
                    int i = rentalcar.SaveChanges();
                    return Ok(i);
                }
                else
                {
                    return Ok(0);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPut]
        [Route("api/Adminupdatedriver")]
        public async Task<ActionResult> UpdateDriver(Driver driverdata)
        {
            try
            {
                var res = from t in rentalcar.Drivers
                          where t.Driverid == driverdata.Driverid
                          select t;
                if (res.Count() > 0)
                {
                    Driver driverupdate = new Driver
                    {
                        Driverid = driverdata.Driverid,
                        Name = driverdata.Name,
                        DateOfBirth = driverdata.DateOfBirth,
                        Phoneno = driverdata.Phoneno,
                        Address = driverdata.Address,
                        Licenseno = driverdata.Licenseno,
                        Status = driverdata.Status
                    };
                    rentalcar.Drivers.Update(driverupdate);
                    int i = rentalcar.SaveChanges();
                    return Ok(i);
                }
                else
                {
                    return Ok(0);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("api/Adminbookedcarsreports")]
        public async Task<ActionResult> BookedCars()
        {
            var res = from t in rentalcar.cars
                      where t.Status == true
                      select t;
            return Ok(res.ToList());

        }

        [HttpGet]
        [Route("api/availablecars")]
        public async Task<ActionResult> AvailableCars()
        {
            var res = from t in rentalcar.cars
                      where t.Status == false
                      select t;
            return Ok(res.ToList());
        }

        [HttpGet]
        [Route("api/availableDrivers")]
        public async Task<ActionResult> AvailableDrivers()
        {
            var res = from t in rentalcar.Drivers
                      where t.Status == false
                      select t;
            return Ok(res.ToList());
        }

        [HttpGet]
        [Route("api/unavailableDrivers")]
        public async Task<ActionResult> UnAvailableDrivers()
        {
            var res = from t in rentalcar.Drivers
                      where t.Status == true
                      select t;
            return Ok(res.ToList());
        }


        [HttpPost]
        [Route("api/Customerbookcars")]
        public async Task<ActionResult> BookCars([FromBody] Booking book)
        {
            try
            {
                int i = await rentalcar.Procedures.bookcarAsync(book.Custid, book.Driverid, book.CarNo, book.RentalType, book.PickupDate, book.DropDate, book.Cost, book.PaymentType, book.PickupLoc, book.DropLoc, true);
                return Ok(i);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("api/Admincarslist")]
        public async Task<ActionResult> CarReports()
        {
            var res = from t in rentalcar.cars
                      select t;
            return Ok(res.ToList());
        }

        [HttpGet]
        [Route("api/AdminUnbookedcars")]
        public async Task<ActionResult> UnBookedCars()
        {
            var res = from t in rentalcar.cars
                      where t.Status == false
                      select t;
            return Ok(res.ToList());
        }


        [HttpDelete]
        [Route("api/Customercancelride/{bid}")]
        public ActionResult CancelRide(Booking book, int bid)
        {
            try
            {
                var bookid = rentalcar.Bookings.Where(c => c.Bookingid == bid);

                if (bookid != null)
                {
                    var res = from b in rentalcar.Bookings
                              where b.Bookingid == bid
                              select b;
                    if (res.Count() > 0)
                    {
                        rentalcar.Bookings.Remove(res.First());
                        int i = rentalcar.SaveChanges();
                        return Ok(i);
                    }
                    else
                    {
                        return Ok(0);
                    }
                }
                else
                {
                    return Ok(0);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("api/Custupdateride{bid}")]
        public async Task<ActionResult> EditRide(Booking book, int bid)
        {
            try
            {
                var bookid = rentalcar.Bookings.Where(c => c.Bookingid == bid);
                if (bookid != null)
                {
                    var res = from b in rentalcar.Bookings
                              where b.Bookingid == bid
                              select b;
                    if (res.Count() > 0)
                    {
                        rentalcar.Bookings.Update(book);
                        int i = rentalcar.SaveChanges();
                        return Ok(i);
                    }
                    else
                    {
                        return Ok(0);
                    }
                }
                else
                {
                    return Ok(0);
                }
            }
            catch(Exception ex) 
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("api/CustUpdateProfile/{cid}")]
        public async Task<ActionResult> UpdateCustomer(Customer cust , int cid)
        {
            try
            {
                var custid = rentalcar.Customers.Where(c => c.Custid == cid);
                if (custid != null)
                {
                    var res = from c in rentalcar.Customers
                              where c.Custid == cid
                              select c;
                    if (res.Count() > 0)
                    {
                        rentalcar.Customers.Update(cust);
                        int i = rentalcar.SaveChanges();
                        return Ok(i);
                    }
                    else
                    {
                        return Ok(0);
                    }
                }
                else
                {
                    return Ok(0);
                }
            }
            catch (Exception ex) 
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("api/custbookedcarsreports/{cid}")]
        public async Task<ActionResult> bookedreportsforcustomer(int cid)
        {
            try
            {
                
                    var res = from b in rentalcar.Bookings
                              where b.Custid == cid
                              select b;
                    return Ok(res.ToList());
               
            }
            catch(Exception ex) 
            {
                return BadRequest(ex.Message);
            }
        }
    }
}


