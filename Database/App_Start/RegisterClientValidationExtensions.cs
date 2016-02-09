using DataAnnotationsExtensions.ClientValidation;

[assembly: WebActivator.PreApplicationStartMethod( typeof( ContentManagementSystemDatabase.App_Start.RegisterClientValidationExtensions ), "Start" )]

namespace ContentManagementSystemDatabase.App_Start
{
    public static class RegisterClientValidationExtensions {
        public static void Start() {
            DataAnnotationsModelValidatorProviderExtensions.RegisterValidationExtensions();            
        }
    }
}