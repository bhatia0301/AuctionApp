using AuctionApp.Application.DTOs;
using AuctionApp.Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AuctionApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private ResponseDTO response;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
            response = new ResponseDTO();          
        }

        [HttpPost("login")]
        public async Task<ResponseDTO> Login(LoginRequestDTO loginRequestDTO)
        {
            try
            {
                var user = await _authService.AuthenticateUserAsync(loginRequestDTO.Email, loginRequestDTO.Password);
                if (user == null) 
                {
                    response.Result = null;
                    response.Message = "Invalid Credentials.";
                    response.IsSuccess = false;
                    return response;
                }
                var token = _authService.GenerateJwtTokenAsync(user, user.Role);
                response.Result = token;
                response.Message = "Login Successfully!";
            }
            catch (Exception ex) 
            {
                response.Message = ex.Message.ToString();
                response.IsSuccess = false;
            }    
            return response;
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("User-Detail/{userId:Guid}")]
        public async Task<ResponseDTO> GetUserDetails(string userId)
        {
            try
            {
                var user = await _authService.GetUserByIdAsync(userId);
                if (user == null || user.Role != "User")
                {
                    response.Result = null;
                    response.Message = "User not Found!";
                    response.IsSuccess = false;
                    return response;
                }
                var userDto = new UserDTO()
                {
                    UserId = userId,
                    Email = user.Email, 
                    UserName = user.UserName,   
                    FullName = user.FullName, 
                    PhoneNumber = user.PhoneNumber, 
                    IsBanned = user.IsBanned    
                };
                response.Message = "Success";
                response.Result = userDto;
            }
            catch (Exception ex) 
            {
                response.Message = ex.Message.ToString();
                response.IsSuccess = false;
            }
            return response;    
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("Get-All-Users")]
        public async Task<ResponseDTO> GetAllUsers()
        {
            try
            {
                var users = await _authService.GetAllUsersAsync();
                var userDTO = new List<UserDTO>();
                foreach (var user in users) 
                {
                    userDTO.Add(new UserDTO()
                    {
                        UserId=user.Id,    
                        Email = user.Email,
                        UserName = user.UserName,
                        FullName = user.FullName,
                        PhoneNumber = user.PhoneNumber,
                        IsBanned = user.IsBanned,   
                    });
                }
                response.Result = userDTO;
                response.Message = "Success";
            }
            catch(Exception ex) 
            {
                response.Message = ex.Message.ToString();
                response.IsSuccess = false;
            } 
            return response;
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("Suspend-User/{userId:Guid}")]
        public async Task<ResponseDTO> SuspendUser(string userId)
        {
            try
            {
                var user = await _authService.GetUserByIdAsync(userId);
                if (user == null || user.Role != "User")
                {
                    response.Result = null;
                    response.Message = "User not Found!";
                    response.IsSuccess = false;
                    return response;
                }
                user.IsBanned = true;
                var status = await _authService.UpdateUserAsync(user);
                if (status)
                {
                    response.Result = status;
                    response.Message = "User suspend successfully";
                }
                else
                {
                    throw new Exception("Error in updating the user details of banned status");
                }

            }
            catch (Exception ex) 
            {
                response.Message = ex.Message.ToString();
                response.IsSuccess = false;
            }
            return response;
        } 
    }
}
