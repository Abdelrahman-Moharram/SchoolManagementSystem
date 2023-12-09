namespace SchoolManagementSystem.Configurations
{
    public class FileUpload
    {
        public string UploadUserImage(IFormFile Image, string inst_Image)
        {
            var fileName = Guid.NewGuid().ToString() + Path.GetExtension(Image.FileName);

            if (Image != null && inst_Image != "img/users/" + fileName)
            {

                var imagePath = Path.Combine("wwwroot", "img", "users", fileName);

                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    Image.CopyToAsync(stream);
                }
                return "img/users/" + fileName;
            }
            return inst_Image;
        }
    }
}
