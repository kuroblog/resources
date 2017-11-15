
namespace WebApiSite.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Web.Http;
    using System.Web.Http.Description;

    public class TestController : ApiController
    {
        private static Dictionary<Guid, string> dictUsers = new Dictionary<Guid, string>();
        private static readonly ThreadLocal<Random> localRandom = new ThreadLocal<Random>(() => new Random());

        [HttpPost]
        [ResponseType(typeof(UserDto))]
        public async Task<IHttpActionResult> ApplyForUserKey([FromUri]string userName)
        {
            if (string.IsNullOrEmpty(userName))
            {
                return await Task.FromResult(BadRequest($"{nameof(userName)} is empty."));
            }

            var user = new UserDto { ApplyName = userName };
            dictUsers.Add(user.ApplyKey, userName);

            return await Task.FromResult(Created(new Uri(Url.Link("DefaultApi", new { user.ApplyKey })), user));
        }

        [HttpGet]
        [ResponseType(typeof(UserDto[]))]
        public async Task<IHttpActionResult> GetApplyUsers()
        {
            return await Task.FromResult(Content(HttpStatusCode.OK, dictUsers.Select(p => new UserDto
            {
                ApplyKey = p.Key,
                ApplyName = p.Value
            }).ToArray()));
        }

        [HttpGet]
        [ResponseType(typeof(UserDto))]
        public async Task<IHttpActionResult> GetApplyUser([FromUri]Guid userKey)
        {
            if (userKey == Guid.Empty)
            {
                return await Task.FromResult(BadRequest($"{nameof(userKey)} is empty."));
            }
            var userValue = dictUsers[userKey];
            if (string.IsNullOrEmpty(userValue))
            {
                return await Task.FromResult(NotFound());
            }
            else
            {
                return await Task.FromResult(Ok(new UserDto
                {
                    ApplyKey = userKey,
                    ApplyName = userValue
                }));
            }
        }

        [HttpPut]
        [ResponseType(typeof(UserOrderDto))]
        public async Task<IHttpActionResult> ProcessUser([FromBody]UserDto user)
        {
            if (user == null)
            {
                return await Task.FromResult(BadRequest($"{nameof(user)} is empty."));
            }

            if (user.ApplyKey == null)
            {
                return await Task.FromResult(BadRequest($"{nameof(user.ApplyKey)} is empty."));
            }

            if (dictUsers.ContainsKey(user.ApplyKey) == false)
            {
                return await Task.FromResult(NotFound());
            }

            if (string.IsNullOrEmpty(user.ApplyName))
            {
                user.ApplyName = dictUsers[user.ApplyKey];
            }

            var amount = localRandom.Value.Next(10, 100) + localRandom.Value.NextDouble();
            var userOrder = user.GetUserOrder(Convert.ToDecimal(amount));
            dictUsers.Remove(userOrder.User.ApplyKey);

            return await Task.FromResult(Content(HttpStatusCode.OK, userOrder));
        }

        [HttpDelete]
        public async Task<IHttpActionResult> Clear()
        {
            dictUsers.Clear();
            return await Task.FromResult(Ok());
        }
    }

    public class UserDto
    {
        public Guid ApplyKey { get; set; } = Guid.NewGuid();

        public string ApplyName { get; set; }
    }

    public static class UserDtoExtensions
    {
        public static UserOrderDto GetUserOrder(this UserDto user, decimal amount)
        {
            return new UserOrderDto
            {
                Amount = amount,
                User = user
            };
        }
    }

    public class UserOrderDto
    {
        public DateTime Date => DateTime.Now;

        public decimal Amount { get; set; }

        public UserDto User { get; set; }
    }
}
