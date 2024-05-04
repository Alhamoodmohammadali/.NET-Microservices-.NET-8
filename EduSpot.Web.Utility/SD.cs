namespace EduSpot.Web.Utility
{
    public class SD
    {
        public static string AuthAPIBase { get; set; }
        public static string UniversityAPIBase { get; set; }
        public static string MajorAPIBase { get; set; }
        public static string MaterialAPIBase { get; set; }
        public static string SummaryAPIBase { get; set; }
        public static string LectureAPIBase { get; set; }
        public static string ChapterAPIBase { get; set; }
        public static string CourceAPIBase { get; set; }
        public static string CouponAPIBase { get; set; }
        public static string SubscriptionCardAPIBase { get; set; }
        public static string OrderAPIBase { get; set; }


        

        public const string RoleAdmin = "ADMIN";
        public const string RoleCustomer = "CUSTOMER";
        public const string TokenCookie = "JWTToken";
        public enum ApiType
        {
            GET,
            POST,
            PUT,
            DELETE
        }
        public enum ContentType
        {
            Json,
            MultipartFormData,
        }
    }
}
