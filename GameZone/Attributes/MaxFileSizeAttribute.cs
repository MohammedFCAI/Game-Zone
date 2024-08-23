using System.ComponentModel.DataAnnotations;

namespace GameZone.Attributes
{
    public class MaxFileSizeAttribute : ValidationAttribute
    {
        private readonly int _maxFileSize;

        public MaxFileSizeAttribute(int maxSize)
        {
            _maxFileSize = maxSize;
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var file = value as IFormFile;

            if (file is not null)
            {

                var maxBytes = _maxFileSize * 1024 * 1024;
                if (file.Length > maxBytes)
                    return new ValidationResult($"Maximum allowed size is {_maxFileSize / 1024 / 1024}MB");

            }

            return ValidationResult.Success;
        }

    }
}
