using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal.models;
namespace Bl.Services.Interfaces
{
    public interface IPromptService
    {
        public Task<string> SubmitPrompt(Prompt prompt);

    }
}
