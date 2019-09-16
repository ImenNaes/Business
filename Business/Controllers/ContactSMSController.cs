using System;
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
    public class ContactSMSController : ControllerBase
    {
        private readonly PaymentDbContext _context;

        public ContactSMSController(PaymentDbContext context)
        {
            _context = context;
        }

        // GET: api/ContactSMS
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ContactSMS>>> GetContactSMS()
        {
            return await _context.ContactSMS.ToListAsync();
        }

        // GET: api/ContactSMS/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ContactSMS>> GetContactSMS(Guid id)
        {
            var contactSMS = await _context.ContactSMS.FindAsync(id);

            if (contactSMS == null)
            {
                return NotFound();
            }

            return contactSMS;
        }

        // PUT: api/ContactSMS/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutContactSMS(Guid id, ContactSMS contactSMS)
        {
            if (id != contactSMS.ID)
            {
                return BadRequest();
            }

            _context.Entry(contactSMS).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContactSMSExists(id))
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

        // POST: api/ContactSMS
        [HttpPost]
        public async Task<ActionResult<ContactSMS>> PostContactSMS(ContactSMS contactSMS)
        {
            _context.ContactSMS.Add(contactSMS);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetContactSMS", new { id = contactSMS.ID }, contactSMS);
        }

        // DELETE: api/ContactSMS/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ContactSMS>> DeleteContactSMS(Guid id)
        {
            var contactSMS = await _context.ContactSMS.FindAsync(id);
            if (contactSMS == null)
            {
                return NotFound();
            }

            _context.ContactSMS.Remove(contactSMS);
            await _context.SaveChangesAsync();

            return contactSMS;
        }

        private bool ContactSMSExists(Guid id)
        {
            return _context.ContactSMS.Any(e => e.ID == id);
        }
    }
}
