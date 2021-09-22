using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    //   [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly CoreDBContext _context;

        public PersonController(CoreDBContext context)
        {
            _context = context;
        }

        // GET: api/Person
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Person>>> GetPerson()
        {
            return await _context.Person.ToListAsync();
        }

        // GET: api/Person/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Person>> GetPerson(int id)
        {
            var person = await _context.Person.FindAsync(id);

            if (person == null)
            {
                return NotFound();
            }

            return person;
        }

        // PUT: api/Person/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPerson(int id, Person person)
        {
            if (id != person.Id)
            {
                return BadRequest();
            }

            _context.Entry(person).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonExists(id))
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

        // POST: api/Person
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Person>> PostPerson(Person person)
        {
            _context.Person.Add(person);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PersonExists(person.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetPerson", new { id = person.Id }, person);
        }

        // DELETE: api/Person/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Person>> DeletePerson(int id)
        {
            var person = await _context.Person.FindAsync(id);
            if (person == null)
            {
                return NotFound();
            }

            _context.Person.Remove(person);
            await _context.SaveChangesAsync();

            return person;
        }

        private bool PersonExists(int id)
        {
            return _context.Person.Any(e => e.Id == id);
        }

        // GET: api/Person/5
        [Route("PersonView")]
        [HttpGet]
        public async Task<IActionResult> GetPersonView(
        /*
            int? id ,
            int? topRecords ,
            string firstName,
            string lastName,
            string pid,
            DateTime? bodFrom ,
            DateTime? bodTo ,
            int? clientTypeID
       */
Int32? id,
DateTime? birthDate_from,
DateTime? birthDate_to,
Int32? citizenShipId,
String firstName,
String lastName,
String personalId
      )
        {
          /*
           var result = from a in _context.Person
                        join b in _context.ClienType on a.ClientTypeId equals b.Id into c
                        from b in c.DefaultIfEmpty()
                        select new
                           {
                               client = new 
                               {
                                   a.Id,
                                   a.FirstName,
                                   a.LastName,
                                   a.Mobile,
                                   a.PersonalId,
                                   a.BirthDate,
                                   a.Address,
                                   a.ClientTypeId
                               },
                               clientType = new {
                                                 b.Id, 
                                                 b.ClientTypeName
                                                }
                           };
            */
            
           var result = from e in _context.Person
                         join _client in _context.Client on e.Id equals _client.Id into __client
 from _client in __client.DefaultIfEmpty(),
 join _country in _context.Country on e.CitizenShipId equals _country.CitizenShipId into __country
 from _country in __country.DefaultIfEmpty()
                        select new
                           {
                             person={
                             e.Id,
e.Address,
e.BirthDate,
e.CitizenShipId,
e.Email,
e.FirstName,
e.LastName,
e.Mobile,
e.PersonalId,
e.Version
                            },
                            client = new {
_client.Id,
_client.Name
},
country = new {
_country.Id,
_country.Code,
_country.Name
}
                           }
            /*
            if (id != null)
                result = result.Where(r => r.person.Id == id);

            if (topRecords != null)
                result = result.Take((int)topRecords);

            if (firstName != null)
                result = result.Where( r=>r.person.FirstName.StartsWith(firstName) );

            if (lastName != null)
                result = result.Where(r => r.person.LastName.StartsWith(lastName));

            if (pid != null)
                result = result.Where(r =>r.person.PersonalId == pid);

            if (bodFrom != null)
                result = result.Where(r => r.person.BirthDate >= (DateTime)bodFrom );

            if (bodTo != null)
                result = result.Where(r => r.person.BirthDate >= (DateTime)bodTo);
            */

                            if (id!= null) 
 result = result.Where(r => r.person.Id== id);

                if (birthDate_from!= null) 
 result = result.Where(r => r.person.BirthDate>= birthDate_from);

                if (birthDate_to!= null) 
 result = result.Where(r => r.person.BirthDate<= birthDate_to);

                if (citizenShipId!= null) 
 result = result.Where(r => r.person.CitizenShipId== citizenShipId);

                if (firstName!= null) 
 result = result.Where(r => r.person.FirstName.StartsWith(firstName));

                if (lastName!= null) 
 result = result.Where(r => r.person.LastName.StartsWith(lastName));

                if (personalId!= null) 
 result = result.Where(r => r.person.PersonalId== personalId);

            return Ok(await result.ToListAsync());
        }

    }
}
