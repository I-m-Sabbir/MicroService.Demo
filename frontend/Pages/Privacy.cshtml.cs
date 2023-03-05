using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace frontend.Pages
{
    public class PrivacyModel : PageModel
    {
        private readonly ILogger<PrivacyModel> _logger;
        public List<Person> People { get; set; }

        public string ErrorMessage { get; set; }
        public PrivacyModel(ILogger<PrivacyModel> logger)
        {
            _logger = logger;
        }

        public async Task OnGet([FromServices] PersonClient client)
        {
            People = await client.GetPeopleAsync();

            if (People.Count == 0)
                ErrorMessage = "There is no People here.";
            else
                ErrorMessage = string.Empty;
        }

        public async Task OnPost([FromServices] PersonClient client, Person person)
        {
            if (await client.AddPersonAsync(person))
                ErrorMessage = string.Empty;
            else
                ErrorMessage = "Something Went Wrong";

            People = await client.GetPeopleAsync();
        }
    }
}
