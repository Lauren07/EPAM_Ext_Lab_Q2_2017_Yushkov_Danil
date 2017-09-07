namespace FileStorage.Models
{
    public class CheckboxRoleViewModel
    {
        public RoleViewModel Role { get; set; }
        public bool IsSelected { get; set; }

        public CheckboxRoleViewModel(RoleViewModel role, bool defaultSelected)
        {
            Role = role;
            IsSelected = defaultSelected;
        }

        public CheckboxRoleViewModel()
        {
            Role = new RoleViewModel();
            IsSelected = true;
        }
    }
}