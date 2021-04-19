using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers{

    [ApiController]
    [Route("api/[controller]")]
    public class UsersController: ControllerBase{

        private readonly DataContext context;

        public UsersController(DataContext _context)
        {
            context= _context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppUser>>> Get(){
            var users=await context.AppUsers.ToListAsync();
            return users;
        }

        [HttpGet("[action]/{id}")]
        public async Task<ActionResult<AppUser>> GetById(int id){
            var user= await context.AppUsers.SingleOrDefaultAsync(i=> i.Id==id);
            if(user==null)
                {
                    user=new AppUser();
                    user.Id=1;
                    user.UserName="nothing";
                }
            return user;
        }

    } 
}