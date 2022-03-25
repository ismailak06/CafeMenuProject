using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using static Business.Constants.CustomClaimTypes;

namespace Business.Extensions
{
    public static class ClaimTypeExtensions
    {
        public static void AddUserId(this ICollection<Claim> claims, string userId)
        {
            claims.Add(new Claim(CustomClaimType.UserId, userId));
        }
        public static void AddName(this ICollection<Claim> claims, string name)
        {
            claims.Add(new Claim(CustomClaimType.Name, name));
        }
        public static void AddSurname(this ICollection<Claim> claims, string surname)
        {
            claims.Add(new Claim(CustomClaimType.Surname, surname));
        }
        public static void AddUsername(this ICollection<Claim> claims, string username)
        {
            claims.Add(new Claim(CustomClaimType.Username, username));
        }
    }
}
