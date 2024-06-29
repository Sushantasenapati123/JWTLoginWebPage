using Dapper;
using System.Data;
using Repo.Repository.BaseRepository;
using Repo.Repository.Factory;
using JwtloginModel.Model.LoginEntity;
using Microsoft.Extensions.Configuration;
using System.Security.Claims;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using JwtLogin.Repository.Repositories.Interfaces;





namespace JwtLogin.Repository.Repository 
{ 
public class JWTloginRepository : WizTestRepositoryBase, IJwtRepository
    {
        public JWTloginRepository(IWizTestConnectionFactory TConnectionFactory) : base(TConnectionFactory)
        {

        }

        //public async Task<List<LoginEntity>> GetByUserIdAsync(string uname)
        //{
        //    try
        //    {

        //        DynamicParameters param = new DynamicParameters();
        //        param.Add("@action", "S");
        //        param.Add("@UserName", uname);
        //        return (await Connection.QueryAsync<LoginEntity>("USP_UserDetails", param, commandType: CommandType.StoredProcedure)).ToList();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message, ex);
        //    }
        //}

        public async Task<List<LoginEntity>> GetByUserIdAsync(string uname)
        {
            try
            {
                // Simulate async operation
                await Task.Delay(1);

                // Return static data
                var staticData = new List<LoginEntity>
        {
            new LoginEntity
            {
                UserName = "Chikun",
                Password = "Chikun",
                UserID = "1",
                PhoneNo = "12386581938894567890",
                Email = "SushantaSenapati@example.com"
            },
            new LoginEntity
            {
                UserName = "user2",
                Password = "user2",
                UserID = "2",
                PhoneNo = "0987654321",
                Email = "user2@example.com"
            }
        };

                // Filter the static data based on the provided username
                return staticData.Where(user => user.UserName.Equals(uname, StringComparison.OrdinalIgnoreCase)).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }


        /// <summary>
        /// Creating Token 
        /// </summary>
        /// <param name="username"></param>
        /// <param name="roles"></param>
        /// <returns></returns>
        public static string GenerateJwtToken(string username, List<string> roles)
        {
            IConfigurationBuilder _config = new ConfigurationBuilder();
            _config.AddJsonFile("appsettings.json");
            IConfiguration configuration = _config.Build();

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, username),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.NameIdentifier, username)

            };

            roles.ForEach(role =>
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            });

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Convert.ToString(configuration["Jwt:JwtKey"])));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddDays(Convert.ToDouble(Convert.ToString(configuration["Jwt:JwtExpireDays"])));

            var token = new JwtSecurityToken(
                Convert.ToString(configuration["Jwt:JwtIssuer"]),
                Convert.ToString(configuration["Jwt:JwtAudience"]),
                claims,
                expires: DateTime.Now.AddSeconds(10),  //expires,
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        /// <summary>
        /// For Validating Created Toke 
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public static string ValidateToken(string token)
        {
            IConfigurationBuilder _config = new ConfigurationBuilder();
            _config.AddJsonFile("appsettings.json");
            IConfiguration configuration = _config.Build();

            if (token == null)
                return null;

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(configuration["Jwt:JwtKey"]);
            //var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]));
            var userName = "";
            try
            {
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    // set clockskew to zero so tokens expire exactly at token expiration time (instead of 5 minutes later)
                   // ClockSkew = TimeSpan.Zero

                    // Increase clockskew to allow a small grace period for token expiration
                    ClockSkew = TimeSpan.FromMinutes(5)
                }, out SecurityToken validatedToken);


                var jwtToken = (JwtSecurityToken)validatedToken;

                var jti = jwtToken.Claims.First(claim => claim.Type == "jti").Value;
                userName = jwtToken.Claims.First(sub => sub.Type == "sub").Value;
               
                return userName;
            }
            catch (Exception ex)
            {
                if (ex.Data.Count == 0)
                {
                    return userName;
                }
                // return null if validation fails
                return userName;
            }
        }
     
    }
}

    