﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Business.Models;

namespace Business.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentDetailsController : ControllerBase
    {
        private readonly PaymentDbContext _context;

        public PaymentDetailsController(PaymentDbContext context)
        {
            _context = context;
        }

        // GET: api/PaymentDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PaymentDetails>>> GetPaymentDetails()
        {
            return await _context.PaymentDetails.ToListAsync();
        }

        // GET: api/PaymentDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PaymentDetails>> GetPaymentDetails(int id)
        {
            var paymentDetails = await _context.PaymentDetails.FindAsync(id);

            if (paymentDetails == null)
            {
                return NotFound();
            }

            return paymentDetails;
        }

        // PUT: api/PaymentDetails/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPaymentDetails(int id, PaymentDetails paymentDetails)
        {
            if (id != paymentDetails.ID)
            {
                return BadRequest();
            }

            _context.Entry(paymentDetails).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PaymentDetailsExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/PaymentDetails
        [HttpPost]
        public async Task<ActionResult<PaymentDetails>> PostPaymentDetails(PaymentDetails paymentDetails)
        {
            _context.PaymentDetails.Add(paymentDetails);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPaymentDetails", new { id = paymentDetails.ID }, paymentDetails);
        }

        // DELETE: api/PaymentDetails/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PaymentDetails>> DeletePaymentDetails(int id)
        {
            var paymentDetails = await _context.PaymentDetails.FindAsync(id);
            if (paymentDetails == null)
            {
                return NotFound();
            }

            _context.PaymentDetails.Remove(paymentDetails);
            await _context.SaveChangesAsync();

            return paymentDetails;
        }

        private bool PaymentDetailsExists(int id)
        {
            return _context.PaymentDetails.Any(e => e.ID == id);
        }
    }
}
