﻿using PasswordSaver.Models;

namespace PasswordSaver.ViewModels
{
    class PasswordStringViewModel
    {
        private PasswordStringModel model;

        public string Name
        {
            get => model.Name;
            set
            {
                model.Name = value;
            }
        }

        public string PasswordValue
        {
            get => model.PasswordValue;
            set
            {
                model.PasswordValue = value;
            }
        }

        public PasswordStringViewModel()
        {
            model = new PasswordStringModel();
        }

        public PasswordStringViewModel(PasswordStringModel model)
        {
            this.model = model;
        }

        public PasswordStringModel Model { get => model; }
    }
}
