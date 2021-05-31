using AppFiscDf.Application.Model.RequestResponse;
using AppFiscDf.Domain.Entities;

namespace AppFiscDf.Domain.Services.Mappers
{
    public static class ActivityMapper
    {
        public static ActivityResponse ConvertToResponse(this Activity activity) => ConvertObjectToResponse(activity);

        public static ActivityResponse ConvertObjectToResponse(Activity activity)
        {
            if (activity == null) return null;

            return new ActivityResponse
            {
                ActivityId = activity.ActivityId,
                Name = activity.Name
            };
        }

        internal static Activity ConvertToObject(this ActivityResponse response)
        {
            return new Activity
            {
                ActivityId = response.ActivityId,
                Name = response.Name
            };
        }
    }
}