namespace GameZone.Settings
{
    public static class FileSettings
    {
        public const string ImagePath = "/assets/images/games";
        public const string AllowedExtension = ".jpg,.png,.jpeg";
        public const int MaxFileSizeInMB = 1;
        public const int MaxAllowedSizeInBytes = MaxFileSizeInMB * 1024 * 1024;
    }
}
