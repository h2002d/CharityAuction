using CharrityAuction.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CharrityAuction.Models
{
    public class UserViewModel
    {
        #region Properties
        public string UserId { get; set; }
        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Required]
        [Display(Name = "Phone number")]
        public string Phone { get; set; }
        [Required]
        [Display(Name = "Nickname")]
        public string Nickname { get; set; }
        static UserDAO DAO = new UserDAO();
        #endregion

        public UserViewModel()
        {

        }
        public UserViewModel(string id)
        {
            var user = DAO.getUserById(id).First();
            this.LastName = user.LastName;
            this.Name = user.Name;
            this.Nickname = user.Nickname;
            this.Phone = user.Phone;
            this.UserId = user.UserId;

        }
        public void Save()
        {
            DAO.saveUser(this);
        }
    }
}