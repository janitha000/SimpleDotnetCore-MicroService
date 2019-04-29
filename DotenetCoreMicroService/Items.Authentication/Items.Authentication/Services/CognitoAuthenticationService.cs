using Amazon;
using Amazon.CognitoIdentityProvider;
using Amazon.CognitoIdentityProvider.Model;
using Vehicle.Authentication.Entities;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace Vehicle.Authentication.Services
{
    public class CognitoAuthenticationService : IAuthenticationService
    {
        private readonly ILogger logger;
        private const string _clientId = "e63r39b1umh8n55p5qhhn72t8";
        private readonly RegionEndpoint _region = RegionEndpoint.USEast1;

        public CognitoAuthenticationService(ILogger<CognitoAuthenticationService> logger)
        {
            this.logger = logger;
        }

        /// <summary>
        /// Registering users in the AWS Cognito
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public async Task<ApiResult> RegisterAsync(User user)
        {
            try
            {
                logger.LogDebug("Calling AWS cognito API");
                var cognito = new AmazonCognitoIdentityProviderClient(_region);
                var request = new SignUpRequest
                {
                    ClientId = _clientId,
                    Password = user.Password,
                    Username = user.Name
                };

                var emailAttribute = new AttributeType
                {
                    Name = "email",
                    Value = user.Email
                };

                request.UserAttributes.Add(emailAttribute);
                var response = await cognito.SignUpAsync(request);
                if (response.HttpStatusCode == System.Net.HttpStatusCode.OK)
                    return new ApiResult(true, "User registration successful");
                else
                    return new ApiResult(false, "User registration unsuccessful");
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error when registering with Cognito");
                return new ApiResult(false, ex);
            }

        }

        /// <summary>
        /// Sigin to AWS Cognito and take the
        /// Accesstoken
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public async Task<ApiResult> SigninAsync(User user)
        {
            try
            {
                logger.LogDebug("Calling AWS cognito API");
                var cognito = new AmazonCognitoIdentityProviderClient(_region);

                var request = new AdminInitiateAuthRequest
                {
                    UserPoolId = "us-east-1_fEiQUmfRQ",
                    ClientId = _clientId,
                    AuthFlow = AuthFlowType.ADMIN_NO_SRP_AUTH
                };

                request.AuthParameters.Add("USERNAME", user.Name);
                request.AuthParameters.Add("PASSWORD", user.Password);

                var response = await cognito.AdminInitiateAuthAsync(request);
                if (response.HttpStatusCode == System.Net.HttpStatusCode.OK)
                {
                    return new ApiResult(true, response.AuthenticationResult.IdToken);
                }
                else
                {
                    logger.LogWarning("Login failed");
                    return new ApiResult(false, "Login failed");
                }

            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error when sigin with Cognito");
                return new ApiResult(false, ex);
            }
        }
    }
}
