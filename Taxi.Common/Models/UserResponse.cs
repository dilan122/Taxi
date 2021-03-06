﻿using Taxi.Common.Enums;

namespace Taxi.Common.Models
{
    public class UserResponse
    {
        public string Id { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string Document { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Address { get; set; }

        public string PicturePath { get; set; }

        public UserType UserType { get; set; }

        public string FullName => $"{FirstName} {LastName}";

        public string FullNameWithDocument => $"{FirstName} {LastName} - {Document}";

        public string PictureFullPath => string.IsNullOrEmpty(PicturePath)
        ? "https://taxiwebdilan23.azurewebsites.net//images/camera1.jpg"
        : $"https://taxiwebdilan23.azurewebsites.net{PicturePath.Substring(1)}";


    }
}

