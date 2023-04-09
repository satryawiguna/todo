using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ToDo.Models.User;
using ToDo.Repository.Contract;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ToDo.Controllers
{
    [Route("api/[controller]")]
    public class MembershipController : ControllerBase
    {
        private readonly IAuthRepository _authRepository;
        private readonly ILogger<MembershipController> _logger;

        public MembershipController(IAuthRepository authRepository, ILogger<MembershipController> logger)
        {
            this._authRepository = authRepository;
            this._logger = logger;
        }

        [HttpPost]
        [Route("register")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> Register([FromBody] RegisterDto registerDto)
        {
            _logger.LogInformation($"Registration attempt for {registerDto.Email}");

            try
            {
                var errors = await _authRepository.Register(registerDto);

                if (errors.Any())
                {
                    foreach (var error in errors)
                    {
                        ModelState.AddModelError(error.Code, error.Description);
                    }

                    return BadRequest(ModelState);
                }

                return Ok(registerDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in the {nameof(Register)} - User registration attempt for {registerDto.Email}");

                return Problem($"Something went wrong in the {nameof(Register)}, Please contact support", statusCode: 500);
            }

            
        }

        [HttpPost]
        [Route("login")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> Login([FromBody] LoginDto loginDto)
        {
            _logger.LogInformation($"Login attempt for {loginDto.Email}");

            try
            {
                var loginResponse = await _authRepository.Login(loginDto);

                if (loginResponse is null)
                {
                    return Unauthorized();
                }

                return Ok(loginResponse);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in the {nameof(Register)}");

                return Problem($"Something went wrong in the {nameof(Register)}", statusCode: 500);
            }
        }

        [HttpPost]
        [Route("refreshToken")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> RefreshToken([FromBody] RefreshTokenDto refreshTokenDto)
        {
            var refreshTokenResponse = await _authRepository.VerifyRefreshToken(refreshTokenDto);

            if (refreshTokenResponse is null)
            {
                return Unauthorized();
            }

            return Ok(refreshTokenResponse);
        }
    }
}

