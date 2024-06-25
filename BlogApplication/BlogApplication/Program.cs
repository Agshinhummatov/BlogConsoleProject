
using BlogApplication.Controllers;
using ServiceLayer.Helpers;
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
                blogController.Create();
                break;
            case
                (int)Options.GetAllBlogs:
                blogController.GetAll();
                break;

            default:
                ConsoleColor.Red.WriteConsole("Please add correct option");
                goto Option;

        }
    }
    else
    {
        ConsoleColor.Red.WriteConsole("Please add correct format option");
        goto Option;

    }

}

static void GetOptions()
{
    ConsoleColor.Cyan.WriteConsole("Please select one option :");
    ConsoleColor.Cyan.WriteConsole("Blog options : \n 1 - Create Blog, \n 2 - Get all Blog,");
}
