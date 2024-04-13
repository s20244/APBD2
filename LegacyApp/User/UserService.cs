using System;

namespace LegacyApp
{
    
    public class UserService 
    {
        
        private IClientRepository repository;
    
        public UserService()
        {
            repository = new IClientRepository();
        }
        
        public bool AddUser(string firstName, string lastName, string email, DateTime dateOfBirth, int clientId)
        {
                
            if (!IsNameValid(firstName,lastName) || !IsEmailValid(email) || !IsAgeValid(dateOfBirth))
            {
                return false;
            }
            
            var client = repository.GetById(clientId);

            var user = CreateUser(firstName,lastName,email,dateOfBirth,client);

            SetUserCredit(user,client);
            
            if (!IsCreditValid(user))
            {
                return false;
            }

            UserDataAccess.AddUser(user);
            return true;
        }

        public bool IsNameValid (String firstName, String lastName)
        {
            return !string.IsNullOrEmpty(firstName) && !string.IsNullOrEmpty(lastName);
        }
        
        public bool IsEmailValid (String email)
        {
            return email.Contains("@") && email.Contains(".");
        }
        
        public bool IsAgeValid (DateTime dateOfBirth)
        {
            var now = DateTime.Now;
            int age = now.Year - dateOfBirth.Year;
            if (now.Month < dateOfBirth.Month || (now.Month == dateOfBirth.Month && now.Day < dateOfBirth.Day)) 
                age--;
            
            return age>=21;
        }
        
        private User CreateUser(string firstName, string lastName, string email, DateTime dateOfBirth, Client client)
        {
            var user = new User
            {
                Client = client,
                DateOfBirth = dateOfBirth,
                EmailAddress = email,
                FirstName = firstName,
                LastName = lastName
            };
            return user;
        }
        
        private void SetUserCredit(User user, Client client)
        {
            {
                if (client.Type == "VeryImportantClient")
                {
                    user.HasCreditLimit = false;
                }
                else
                {
                    user.HasCreditLimit = true;
                    using (var userCreditService = new IUserCreditService())
                    {
                        int creditLimit = userCreditService.GetCreditLimit(user.LastName, user.DateOfBirth);
                        if (client.Type == "ImportantClient")
                        {
                            user.CreditLimit = creditLimit * 2;
                        }
                        else
                        {
                            user.CreditLimit = creditLimit;
                        }
                    }
                }
            }
        }

        private bool IsCreditValid(User user)
        {
            return !user.HasCreditLimit || user.CreditLimit >= 500;
        }
        
    }
    
}
