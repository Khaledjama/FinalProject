using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Schools.DAL.UnitOfWork;
using Schools.DataStorage.Entity;
using Schools.DTO.DTO;
using Schools.Service.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Schools.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class Account : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _Map;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signManager;
        public Account(IUnitOfWork unit, IMapper map, UserManager<ApplicationUser> user , SignInManager<ApplicationUser> sign)
        {
            this._unitOfWork = unit;
            this._Map = map;
            this._userManager = user;
            this._signManager = sign;
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            if (!ModelState.IsValid)
                return BadRequest("Not valid !");
            else
            {
                var CurrentUser = await _userManager.FindByEmailAsync(loginDto.Email);
                if(CurrentUser is not null && await _userManager.CheckPasswordAsync(CurrentUser, loginDto.Password))
                {
                   await _signManager.SignInAsync(CurrentUser, true);
                    return Ok("You are Sign int");
                }
                else
                    return BadRequest("Error Sign please try again ");
            }
        }
        [HttpPost]
        public async Task<IActionResult> LogOut()
        {
            await _signManager.SignOutAsync();
            return Ok("SignOut Dine");
        }

        [HttpPost("{SSN}")]
        public async Task<IActionResult> Register(long SSN, string Role, UserRegistrationDto userRegistrationDto)
        {
            if (!ModelState.IsValid)
                return BadRequest("Please Fill Form Correct");
            else
            {
                // Mapping information from userRegistrationDto to ApplicationUser(User) to Register
                ApplicationUser AppUser = new ApplicationUser()
                {
                    UserName = userRegistrationDto.UserName,
                    Email = userRegistrationDto.Email
                };

                try
                {

                    var result = await _userManager.CreateAsync(AppUser, userRegistrationDto.Password);
                    if (!result.Succeeded)
                    {
                        return BadRequest($"Error in Registeration");
                    }
                    else
                    {
                        var CurrentUserByEmail = await _userManager.FindByEmailAsync(userRegistrationDto.Email);
                        var Current_User_ByUserId = CurrentUserByEmail.Id;
                        var AddingUserIdToRole= await AddUserIdToUser(Role,SSN, Current_User_ByUserId);
                        var AddingUserToRole = await _userManager.AddToRoleAsync(AppUser, Role);
                        var CheckUserIsExisted = await CheckUserIs_Existed(SSN, Role);
                        if (!AddingUserToRole.Succeeded || !AddingUserIdToRole || !CheckUserIsExisted)
                        {
                            await _userManager.DeleteAsync(CurrentUserByEmail);
                            return Ok("Register Failed Try Again !!!! ");
                        }
                        else
                            return Ok("Register Done");
                    }
                }
                catch (Exception ex)
                {
                    return BadRequest($"Error When User Register {ex.Message}");
                }
            }
        }
        [HttpPost("{ParentSSN}")]
        public async Task<IActionResult> RegisterAsParent(long StudentSSN , long ParentSSN, UserRegistrationDto userRegistrationDto)
        {
            if (!ModelState.IsValid)
                return BadRequest("Please Fill Form Correct");
            else
            {
                // Mapping information from userRegistrationDto to ApplicationUser(User) to Register
                ApplicationUser AppUser = new ApplicationUser()
                {
                    UserName = userRegistrationDto.UserName,
                    Email = userRegistrationDto.Email
                };

                try
                {

                    var result = await _userManager.CreateAsync(AppUser, userRegistrationDto.Password);
                    if (!result.Succeeded)
                    {
                        return BadRequest($"Error in Registeration");
                    }
                    else
                    {
                        var CheckStudentAndParentIsExisted = await CheckStudentAndParentIs_Existed(StudentSSN, ParentSSN);
                        if (CheckStudentAndParentIsExisted)
                        {
                            var CurrentUserEmail = await _userManager.FindByEmailAsync(userRegistrationDto.Email);
                            var CurrentUserId = CurrentUserEmail.Id; // User Id For User Registeration
                            var AddingUserIdToRole = await AddUserIdToUser("Parent", ParentSSN, CurrentUserId);
                            var AddingUserToRole = await _userManager.AddToRoleAsync(AppUser, "Parent");
                            var AddingParentToStudent = await AddStudenToParent(StudentSSN, ParentSSN);
                            if (!AddingUserToRole.Succeeded || !AddingUserIdToRole )
                            {
                                await _userManager.DeleteAsync(CurrentUserEmail);
                                return Ok("Register Failed Try Again !!!! ");
                            }
                            else
                                return Ok("Register Done");
                        }else
                            return BadRequest("Registeration Failed !! please Try Again");
                    }
                }
                catch (Exception ex)
                {
                    return BadRequest($"Error When User Register {ex.Message}");
                }
            }
        }




        private async Task<bool> AddUserIdToUser(string Role ,long SSN, string User_Id)
        {
            var CurrentUserEmail_ByUserId = await _userManager.FindByIdAsync(User_Id); // Get Email
            if (CurrentUserEmail_ByUserId is null) // Check Email is Not Null 
                return false;
            var CurrentUserId = CurrentUserEmail_ByUserId.Id; // Get User Id Of Email
            if (Role == "Teacher")
            {
                _unitOfWork.Teacher.GetById(SSN).User_Id = CurrentUserId;// Add User_Id To Teacher Record
                return _unitOfWork.Complete() > 0 ? true : false;
            }
            else if (Role == "Student")
            {
                _unitOfWork.Student.GetById(SSN).User_Id = CurrentUserId;// Add User_Id To Student Record
                return _unitOfWork.Complete() > 0 ? true : false;
            }
            else if (Role == "Parent")
            {
                _unitOfWork.Parent.GetById(SSN).User_Id = CurrentUserId;// SSN=> Parent SSN Add User_Id To Student Record
                return _unitOfWork.Complete() > 0 ? true : false;
            }

            else
                return false;
        }
        private async Task<bool> CheckUserIs_Existed(long SSN , string Role)
        {
            if (Role == "Teacher")
            {
                var CurrentUser =await _unitOfWork.Teacher.GetByIdAsync(SSN);
                return CurrentUser is not null ? true : false;
            }
            else if (Role == "Student")
            {
                var CurrentUser =await _unitOfWork.Student.GetByIdAsync(SSN);
                return CurrentUser is not null ? true : false;
            }
            
            else
                return false;
        }
        private async Task<bool> CheckStudentAndParentIs_Existed(long StudentSSN , long ParentSSN)
        {
            var CurrentStudent =await _unitOfWork.Student.GetByIdAsync(StudentSSN);
            var CurrentParent  =await _unitOfWork.Parent.GetByIdAsync(ParentSSN);
            if (CurrentStudent is not null && CurrentParent is not null)
                return true;
            else
                return false;
        }
        private async Task<bool> AddStudenToParent( long StudentSSN, long ParentUserId)
        {
            var CurrentStudent = await _unitOfWork.Student.GetByIdAsync(StudentSSN);
            CurrentStudent.ParentId = ParentUserId;
            return _unitOfWork.Complete() > 0 ? true : false;
        }
        
   



    }
}
