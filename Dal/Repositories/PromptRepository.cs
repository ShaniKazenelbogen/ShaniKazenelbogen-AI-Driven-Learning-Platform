using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal.models;

namespace Dal.Repositories
{
    public class PromptRepository
    {
        private readonly dbClass _context;

        public PromptRepository(dbClass context)
        {
            _context = context;
        }

        public async Task CreatePrompt(Prompt prompt)
        {
            try
            {
                if (prompt.Category != null) prompt.Category = null;
                if (prompt.SubCategory != null) prompt.SubCategory = null;
                if (prompt.User != null) prompt.User = null;
               
                _context.Prompts.Add(prompt);
                _context.SaveChanges();
            }
            catch (DbUpdateException dbEx)
            {
                Console.WriteLine("שגיאת שמירה במסד הנתונים: " + dbEx.Message);
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine("שגיאה כללית: " + ex.Message);
                throw;
            }
        }

       
        
    }

}

