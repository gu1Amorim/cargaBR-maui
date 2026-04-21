namespace RotaSegura.Services
{
    public class SubscriptionService : ISubscriptionService
    {
        public bool IsFeatureAccessible(string featureId)
        {
            if(featureId == "HomePage" || featureId == "SettingPage")
                return true;

            return true;
        }
    }
}
