using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constants
{
    public class Messages
    {
        public static string OutOfRule = "Description must be at least 2 characters. The daily fee should be above zero.";
        public static string Added = "Added.";
        public static string Deleted = "Deleted.";
        public static string Listed = "Listed.";
        public static string Updated = "Updated.";
        public static string NotAdded = "Couldn't be added";
        public static string ReturnDateIsNull = "The vehicle cannot be rented because the returndate is null.";
        public static string NotListed = "Couldn't be listed.";
        public static string NotDeleted = "Couldn't be deleted.";
        public static string NotUpdated = "Couldn't be updated.";
        public static string CarImageLımıtExceeded = "More than 5 photos cannot be uploaded for a vehicle.";
        public static string UserNotFound = "User not found.";
        public static string SuccessLogin = "Successfully logged in.";
        public static string PasswordInvalid = "Password invalid.";
        public static string UserExist = "User already exists.";
        public static string AccessTokenCreated = "The access token has been successfully created.";
        public static string UserRegistered = "User successfully registered ";
        public static string AuthorizationDenied = "Authorization denied.";
        public static string NotRentable = "The car is currently rented.";
        public static string Rentable = "The vehicle is rentable now.";
        public static string Processed = "Purchase processed.";
        public static string UsingNow = "The item is currently in use.";
        public static string UserUpdated = "The changes have been saved.";
        public static string PasswordChanged = "The password has been changed successfully.";
        public static string OldPasswordInvalid = "Old password does not match.";
        public static string EmailInvalid = "E-mail is incorrect.";
        public static string BecameVIP = "You are a VIP customer.";
    }
}
