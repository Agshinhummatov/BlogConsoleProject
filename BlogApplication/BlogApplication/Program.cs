
using BlogApplication.Controllers;
using ServiceLayer.Helpers;
using ServiceLayer.Helpers.Constants;
using ServiceLayer.Helpers.Enums;

BlogController blogController = new();



while (true)
{
    GetOptions();

Option: string option = Console.ReadLine();

    int selectOption;

    bool isCorrectOption = int.TryParse(option, out selectOption);

    if (isCorrectOption)
    {
        switch (selectOption)
        {

            case (int)Options.CreateBlog:
                blogController.CreateBlog();
                break;
            case
                (int)Options.GetAllBlogs:
                blogController.GetAllBlogs();
                break;
            case (int)Options.DeleteBlog:
                blogController.DeleteBlog();
                break;
            case (int)Options.SearchBlog:
                blogController.SearchBlog();
                break;
            case (int)Options.GetBlogById:
                blogController.GetBlogById();
                break;
            case (int)Options.UpdateBlog:
                blogController.UpdateBlog();
                break;

            default:
                ConsoleColor.Red.WriteConsole(ResponseMessages.CorrectOption);
                goto Option;

        }
    }
    else
    {
        ConsoleColor.Red.WriteConsole(ResponseMessages.CorrecFormatOption);
        goto Option;

    }

}

static void GetOptions()
{
    ConsoleColor.Cyan.WriteConsole(ResponseMessages.SelectOption);
    ConsoleColor.Cyan.WriteConsole(ResponseMessages.OptionsMessage);
}
