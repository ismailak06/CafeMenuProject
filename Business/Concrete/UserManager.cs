using Business.Abstract;
using Business.Utilities.AutoMapper;
using Business.ValidationRules.FluentValidation.Entities.User;
using Core.Utilities.Results;
using Core.Utilities.Security.Hashing;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {

        private readonly IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public IDataResult<User> Create(AddUserDto addUserDto)
        {
            var validator = new AddUserValidator(this);
            var validateResult = validator.Validate(addUserDto);
            if (!validateResult.IsValid)
            {
                var errorResults = ValidationHelper.GetErrors(validateResult.Errors);
                return new ErrorDataResult<User>("Kullanıcı ekleme işlemi başarısız oldu.", errorResults);
            }

            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(addUserDto.Password, out passwordHash, out passwordSalt);
            var user = new User
            {
                Name = addUserDto.Name,
                Surname = addUserDto.Surname,
                Username = addUserDto.Username,
                HashPassword = passwordHash,
                SaltPassword = passwordSalt
            };

            var addedUser = _userDal.Add(user);

            return new SuccessDataResult<User>(addedUser);
        }
        public IDataResult<User> Update(EditUserDto updateUserDto)
        {
            var validator = new UpdateUserValidator(this);
            var validateResult = validator.Validate(updateUserDto);
            if (!validateResult.IsValid)
            {
                var errorResults = ValidationHelper.GetErrors(validateResult.Errors);
                return new ErrorDataResult<User>("Kullanıcı güncelleme işlemi başarısız oldu.", errorResults);
            }

            var user = _userDal.GetById(updateUserDto.Id);
            user.Name = updateUserDto.Name;
            user.Surname = updateUserDto.Surname;

            var updatedUser = _userDal.Update(user);
            return new SuccessDataResult<User>(updatedUser);
        }

        public IDataResult<User> Delete(int userId)
        {
            var user = _userDal.GetById(userId);
            var deletedUser = _userDal.Delete(user);
            return new SuccessDataResult<User>(deletedUser);
        }

        public IDataResult<bool> CheckExistsUserName(string userName)
        {
            return new SuccessDataResult<bool>(_userDal.Any(m => m.Username == userName));
        }

        public User GetUserByUserName(LoginUserDto loginUserDto)
        {
            return _userDal.Get(m => m.Username == loginUserDto.Username);
        }

        public IList<UserDto> GetList()
        {
            return Mapping.Mapper.Map<IList<UserDto>>(_userDal.GetList());
        }

        public UserDto GetById(int userId)
        {
            return Mapping.Mapper.Map<UserDto>(_userDal.GetById(userId));
        }

        public IDataResult<UserDto> CheckLogin(LoginUserDto loginUserDto)
        {
            var userDto = _userDal.Get(m => m.Username == loginUserDto.Username);
        
            if(userDto is null)
            {
                return new ErrorDataResult<UserDto>("Kullanıcı adı veya şifre geçersiz.");
            }
       
            if (!HashingHelper.VerifyPasswordHash(loginUserDto.Password, userDto.HashPassword, userDto.SaltPassword))
            {
                return new ErrorDataResult<UserDto>("Kullanıcı adı veya şifre geçersiz.");
            }

            return new SuccessDataResult<UserDto>(Mapping.Mapper.Map<UserDto>(userDto));
        }
    }
}
