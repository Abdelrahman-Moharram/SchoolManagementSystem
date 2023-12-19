namespace SchoolManagementSystem.Configurations
{
    public class FileUpload
    {
        public string UploadUserImage(IFormFile Image, string inst_Image= "img/users/user.webp")
        {

            if (Image != null)
            {
                var fileName = Guid.NewGuid().ToString() + Path.GetExtension(Image.FileName);

                var imagePath = Path.Combine("wwwroot", "img", "users", fileName);

                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    Image.CopyToAsync(stream);
                }
                return "img/users/" + fileName;
            }
            return inst_Image;
        }

        public string UploadPostFile(IFormFile Image)
        {

            if (Image != null)
            {
                var fileName = Guid.NewGuid().ToString() + Path.GetExtension(Image.FileName);

                var imagePath = Path.Combine("wwwroot", "files", "posts", fileName);

                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    Image.CopyToAsync(stream);
                }
                return "/files/posts/" + fileName;
            }
            return null;
        }
    }
}
