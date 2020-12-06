﻿using System;
using System.Windows.Forms;
using IMDbTrackerLibrary;
using IMDbTrackerLibrary.Models;

namespace IMDbTrackerUI {
    public partial class RegisterForm : Form {

        private User user = null;

        public RegisterForm() {
            InitializeComponent();

            this.AcceptButton = RegisterButton;
        }

        private bool ValidateFields() {
            bool validUsername = Validator.ValidateUsernameTextBox(usernameTextBox, usernameValidateErrorLabel);
            bool validFirstName = Validator.ValidateFirstNameTextBox(firstNameTextBox, firstNameValidateErrorLabel);
            bool validLastName = Validator.ValidateLastNameTextBox(lastNameTextBox, lastNameValidateErrorLabel);
            bool validEmail = Validator.ValidateEmailTextBox(emailTextBox, emailValidateErrorLabel);
            bool validPassword = Validator.ValidatePasswordTextBox(passwordTextBox, passwordValidateErrorLabel);
            bool validRepeatPassword = Validator.ValidateRepeatPasswordTextBox(passwordTextBox, repeatPasswordTextBox, repeatPasswordValidateErrorLabel);
            bool validApiKey = Validator.ValidateApiKeyTextBox(apiKeyTextBox, apiKeyValidateErrorLabel);

            if(validUsername && validFirstName && validLastName && validEmail && validPassword && validRepeatPassword && validApiKey)
                return true;

            return false;
        }

        private void RegisterUser() {

            User user = new User();
            user.Username = usernameTextBox.Text;
            user.FirstName = firstNameTextBox.Text;
            user.LastName = lastNameTextBox.Text;
            user.Email = emailTextBox.Text;
            user.Password = Helpers.HashPassword(passwordTextBox.Text);
            user.APIKey = apiKeyTextBox.Text;

            GlobalConfig.Connection.CreateUser(user);

            this.user = user;
        }

        private void SignUpForm_Load(object sender, EventArgs e) {

        }
        private void ShowPasswordCheckbox_CheckedChanged(object sender, EventArgs e) {
            passwordTextBox.UseSystemPasswordChar = !ShowPasswordCheckbox.Checked;
        }

        private void ShowRequiredPasswordCheckbox_CheckedChanged(object sender, EventArgs e) {
            repeatPasswordTextBox.UseSystemPasswordChar = !ShowRepeatPasswordCheckbox.Checked;
        }

        private void RegisterButton_Click(object sender, EventArgs e) {
            if(!ValidateFields()) {
                return;
            };

            RegisterUser();

            if(user == null) {
                return;
            }

            Email.SendWelcomeMail(user.Email, user, passwordTextBox.Text, null);
            Helpers.ShowMessageBox("UserRegistered");

            this.Hide();

            LogInForm logInForm = new LogInForm();
            logInForm.Show();
        }

    }
}
