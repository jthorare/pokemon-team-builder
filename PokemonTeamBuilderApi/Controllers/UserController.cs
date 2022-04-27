using Microsoft.AspNetCore.Mvc;
using PokemonTeamBuilderApi.Models;
using PokemonTeamBuilderApi.Services;
using System.Text.Json;

namespace PokemonTeamBuilderApi.Controllers
{
    // Creating the Mongo Connection and Controller is from this doc link
    // https://docs.microsoft.com/en-us/aspnet/core/tutorials/first-mongo-app?view=aspnetcore-6.0&tabs=visual-studio
    [ApiController]
    [Route("api")]
    public class UserController : Controller
    {
        private readonly UserInfoService _userInfoService;
        private readonly UserTeamsService _userTeamsService;
        private readonly UserSuggestionsService _userSuggestionsService;

        public UserController(UserInfoService userInfoService, UserTeamsService userTeamsService, UserSuggestionsService userSuggestionsService)
        {
            _userInfoService = userInfoService;
            _userTeamsService = userTeamsService;
            _userSuggestionsService = userSuggestionsService;
        }




        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register(string username, string password)
        {
            var user = await _userInfoService.GetAsync(username, password);
            if (user == null)
            {
                var userInfos = await _userInfoService.GetAsync();
                var exists = await _userInfoService.GetAsync(username, password);
                int highestUserId = 1;
                if (exists is null)
                {
                    if (userInfos is not null && exists is null)
                    {
                        highestUserId = userInfos.MaxBy(u => u.UserId).UserId ?? highestUserId; // force the compiler to know that it is not a null collection
                    }
                    await _userInfoService.CreateAsync(new UserInfo()
                    {
                        Username = username,
                        Password = password,
                        UserId = highestUserId + 1
                    });
                    return Ok(highestUserId + 1); // register w/ 0 teams saved
                }
            }
            return BadRequest();
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login(string username, string password)
        {
            var user = await _userInfoService.GetAsync(username, password);
            if (user is null) { return NotFound(); }
            var userTeams = await _userTeamsService.GetAsync(user.UserId);
            if (userTeams is not null)
            {
                return Ok(new object[] { user.IsContributor, userTeams });
            }
            if (userTeams is null)
            {
                return Ok(new object[] { false, new Dictionary<string, List<List<int>>>() });
            }
            return BadRequest();
        }

        [HttpPost]
        [Route("save")]
        public async Task<IActionResult> SaveTeam(int userId, [FromBody] Dictionary<string, List<List<int>>> teamsToSave)
        {
            if (teamsToSave is null)
            {
                return BadRequest();
            }
            var userTeam = await _userTeamsService.GetAsync(userId);
            var userInfo = await _userInfoService.GetAsync(userId);
            if (userInfo is null) { return NotFound(); } // no user exists with the given userId

            if (userTeam is null) // saving first team
            {
                UserTeams newUserTeams = new() { UserId = userId, TeamMappings = teamsToSave };
                await _userTeamsService.CreateAsync(newUserTeams);
                return CreatedAtAction(nameof(SaveTeam), newUserTeams);
            }
            if (userTeam is not null) // updating saved teams
            {
                userTeam = UpdateUserTeam(userTeam, teamsToSave);
                await _userTeamsService.UpdateAsync(userTeam.Id, userTeam); // userTeam is not null, it's received from the service so we know
                                                                            // it has UserTeam.Id that is not null
            }
            return Ok(userId);
        }

        [HttpPost]
        [Route("suggest")]
        public async Task<IActionResult> SubmitSuggestion([FromBody] string suggestion)
        {
            await _userSuggestionsService.CreateAsync(new UserSuggestion() { Suggestion = suggestion });
            return Ok();
        }

        /// <summary>
        /// Updates the given UserTeam to include the given mappings in its TeamMappings.
        /// </summary>
        /// <param name="userTeam">The UserTeam to update.</param>
        /// <param name="teamsToSave">The teams to add to the TeamMappings.</param>
        /// <returns>A new UserTeam with the same UserTeam.Id, UserTeam.UserId as the parameter.</returns>
        private static UserTeams UpdateUserTeam(UserTeams userTeam, Dictionary<string, List<List<int>>> teamsToSave)
        {
            Dictionary<string, List<List<int>>> teamsMappings = userTeam.TeamMappings;
            UserTeams updated = new() { Id = userTeam.Id, UserId = userTeam.UserId };
            if (teamsMappings is not null)
            {
                foreach (var teamMapping in teamsToSave)
                {
                    if (teamsMappings.ContainsKey(teamMapping.Key)) // adding to a region's list of teams
                    {
                        teamsMappings[teamMapping.Key].AddRange(teamMapping.Value);
                    }
                    else
                    {
                        teamsMappings.Add(teamMapping.Key, teamMapping.Value);
                    }
                }
            }
            updated.TeamMappings = teamsMappings;
            return updated;
        }

    }
}
