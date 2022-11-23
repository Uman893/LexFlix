using LexFlix.Data;
using LexFlix.Models;
using LexFlix.Helper;
using Microsoft.AspNetCore.Http;
using LexFlix.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LexFlix.Services;
using LexFlix.Exceptions;

namespace LexFlix.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly ICustomerServices _IcustomerServices;
        const string SessionKeyCart = "ShoppingCart";
        public CustomerController(ApplicationDbContext db, ICustomerServices icustomerServices)
        {
            _db = db;
            _IcustomerServices = icustomerServices;
        }
        public IActionResult Checkout()
        {

            return View();
        }
        public IActionResult ValidationStep(string email)
        {

            try
            {
                _IcustomerServices.ValidationSteps(email);
            }
            catch (ValdionStepException)
            {
                return View("SuccessfullyCompleted");
                throw;
            }
            catch (ValidationStepExceptionView)
            {
                return View("RegistrationForm");
                throw;
            }
            return View();
        }
        public IActionResult SuccessfullyCompleted()
        {
            return View();
        }
        public IActionResult RegistrationForm()
        {
            return View();
        }
        public async Task<IActionResult> AddCustomer([Bind("Id,FirstName,LastName,BillingAddress,BillingZip, BillingCity, BillingAddress, DeliveryZip, DeliveryCity, Email, PhoneNo")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                _db.Add(customer);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(CompleteFromRegistrationForm));

            }
            return View();
        }
        public IActionResult CompleteFromRegistrationForm()
        {
            return View();
        }


    }
}
