using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol;
using SimpleBank.Data;
using SimpleBank.Models;

namespace SimpleBank.Controllers
{

    [ApiController]
    [Route("simpleBank/api/auth")]

    public class AuthController : ControllerBase
    {
        private readonly SimpleBankDBContext _context;


        public AuthController(SimpleBankDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("getData/{personId}")]
        public async Task<IActionResult> GetData(int personId)
        {
            var data = _context.Persons
            .Join(
                _context.Users,
                person => person.userId,
                user => user.userId,
                (person, user) => new { person, user }
            )
            .Join(
                _context.Accounts,
                row => row.user.accountId,
                account => account.accountId,
                (row, account) => new { row.person, row.user, account }
            )
            .Where(fullEntry => fullEntry.person.personId == personId).FirstOrDefault();

            if (data == null)
            {
                return NotFound();
            }

            return Ok(data);
        }

        [HttpPost]
        [Route("createAccount")]

        public async Task<IActionResult> storeClient()
        {
            try
            {
                // Acessando o contexto HTTP
                var request = HttpContext.Request;

                // Verificando se o corpo da solicitação não está vazio
                if (!request.ContentLength.HasValue || request.ContentLength == 0)
                {
                    return BadRequest("Corpo da solicitação vazio");
                }
                using (var reader = new System.IO.StreamReader(request.Body))
                {
                    var body = reader.ToJson();
                    return Ok(body);
                }
                
                //var account = new Account();
                //account.agency = agency;
                //account.number = number;
                //account.startingCapital = startingCapital ?? 0.0;
                //account.balance = balance ?? 0.0;
                //
                //await _context.Accounts.AddAsync(account);
                //await _context.SaveChangesAsync();
                //var accountId = account.accountId;
                //if (account is not null)
                //{
                //    var user = new User();
                //    user.email = email;
                //    user.password = password;
                //    user.accountId = accountId;
                //
                //    await _context.Users.AddAsync(user);
                //    await _context.SaveChangesAsync();
                //    var userId = user.userId;
                //
                //    if (user is not null)
                //    {
                //        var person = new Person();
                //        person.name = name;
                //        person.lastName = lastName;
                //        person.taxId = taxId;
                //        person.userId = userId;
                //        person.birthday = (DateTime)(birthday is not null ? birthday : DateTime.UtcNow);
                //        await _context.Persons.AddAsync(person);
                //        await _context.SaveChangesAsync();
                //
                //        if (person is not null)
                //        {
                //            return CreatedAtAction("GetData", new { id = person.personId }, person);
                //        } else
                //        {
                //            return BadRequest("Person not saved");
                //        }
                //    } else
                //    {
                //        return BadRequest("User not saved");
                //    }
                //} else
                //{
                //    return BadRequest("Account not saved");
                //}
            } catch (Exception error)
            {
                return BadRequest(error.Message);   
            }
        }
    }
}