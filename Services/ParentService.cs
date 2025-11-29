using BadeePlatform.Data;
using BadeePlatform.DTOs;
using BadeePlatform.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace BadeePlatform.Services
{
    public class ParentService : IParentService
    {
        private readonly BadeedbContext _db;
        private readonly IPasswordHasher<Parent> _passwordHasher;

        public ParentService(BadeedbContext db, IPasswordHasher<Parent> passwordHasher) 
        {
            _db = db;
            _passwordHasher = passwordHasher;
        }

        public async Task<ServiceResult> RegisterParentAsync(RegisterParentDTO dto)
        {
            var errorMsg = await CheckDuplicateFields(dto);
            if (!string.IsNullOrEmpty(errorMsg))
            {
                return new ServiceResult(false, errorMsg);
            }

            var parent = new Parent
            {
                ParentId = dto.ParentId,
                ParentName = dto.ParentName,
                Email = dto.Email,
                PhoneNumber = dto.PhoneNumber,
                Username = dto.Username,
                IsVerified = false,
                CreatedAt = DateTime.Now,
                Role = dto.Role
            };

            string hashedPassword = _passwordHasher.HashPassword(parent, dto.Password);
            parent.Password = hashedPassword;

            try
            {
                _db.Parents.Add(parent);
                await _db.SaveChangesAsync();
                return new ServiceResult(true, "تم التسجيل بنجاح.", parent.ParentId);
            }
            catch (Exception)
            {
                return new ServiceResult(false, "حدث خطأ في قاعدة البيانات أثناء التسجيل.");
            }
        }

        private async Task<string> CheckDuplicateFields(RegisterParentDTO dto)
        {
            if (await _db.Parents.AnyAsync(p => p.ParentId == dto.ParentId))
                return "الهوية الوطنية مسجلة مسبقًا.";

            if (await _db.Parents.AnyAsync(p => p.Username == dto.Username))
                return "اسم المستخدم مسجل مسبقًا.";

            if (await _db.Parents.AnyAsync(p => p.Email == dto.Email))
                return "البريد الإلكتروني مسجل مسبقًا.";

            return null;
        }
       
        public async Task<ServiceResult> LoginParentAsync(LoginParentDTO dto)
        {
            var usernameOrEmail = dto.UsernameOrEmail.ToLower();

            var parent = await _db.Parents
                .FirstOrDefaultAsync(p =>
                    p.Username.ToLower() == usernameOrEmail ||
                    p.Email.ToLower() == usernameOrEmail);

            if (parent == null || parent.Password == null)
            {
                return new ServiceResult(false, "اسم المستخدم أو كلمة المرور غير صحيحة.");
            }

            var verificationResult = _passwordHasher.VerifyHashedPassword(
                parent,
                parent.Password, 
                dto.Password
            );

            if (verificationResult == PasswordVerificationResult.Success)
            {
                return new ServiceResult(true, "تم تسجيل الدخول بنجاح.", parent.ParentId, parent.Role);
            }

            return new ServiceResult(false, "اسم المستخدم أو كلمة المرور غير صحيحة.");
        }

      
    }

         

}
